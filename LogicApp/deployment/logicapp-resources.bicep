@description('The datacenter to use for the deployment.')
param location string
param environmentName string
param projectName string
param appInsightsName string
param logicAppName string
param appServicePlanName string
param sharedResourceGroup string
param vnetName string
param localKeyVaultName string
param dataverseObjectId string
param apimManagedIdentityId string

var vaultUri = 'https://${localKeyVaultName}.vault.azure.net/'

// storage account parameters
param sa_name string = 'sa'
param customStorageName string
param storageAccountType string = 'Standard_LRS'

// key vault secrets (to create in keyvault)
@secure()
param dynamicsCrmSecret string
@secure()
param dynamicsCrmClientId string
param dynamicsCrmDirectoryId string
param dynamicsCrmEnvironmentUri string
param cpiCreateCustomerUrl string
param cpiCreateCustomerClientId string
param cpiAccessTokenUrl string
@secure()
param cpiCreateCustomerClientSecret string

// generic variables
var ResourceGroup = resourceGroup().location
var customStorageAccountid = '${resourceGroup().id}/providers/Microsoft.Storage/storageAccounts/${customStorageName}'
var endpointSuffix = ';EndpointSuffix=core.windows.net'

// set up storage account, default used by logic and function app
var storageName = concat(toLower(sa_name), uniqueString(resourceGroup().id))

// vnet reference to existing vnet
resource vnet 'Microsoft.Network/virtualNetworks@2021-08-01' existing = {
  name: vnetName
  scope: resourceGroup(sharedResourceGroup)
}

resource storageAccount 'Microsoft.Storage/storageAccounts@2018-07-01' = {
  name: storageName
  location: ResourceGroup
  kind: 'StorageV2'
  sku: {
    name: storageAccountType
  }
  properties: {}
}

// set up host for logic app runtime
resource logicApp 'Microsoft.Web/sites@2022-09-01' = {
  name: logicAppName
  location: location
  kind: 'workflowapp,functionapp'
  identity: {
    type: 'SystemAssigned'
  }
  tags: {
    Environment: environmentName
    Project: projectName
  }
  properties: {
    serverFarmId: resourceId(sharedResourceGroup, 'Microsoft.Web/serverFarms', appServicePlanName)
    clientAffinityEnabled: false
    vnetRouteAllEnabled: true
    vnetImagePullEnabled: false
    vnetContentShareEnabled: false
    virtualNetworkSubnetId: vnet.properties.subnets[0].id
  } 
  dependsOn: [
    storageAccount
  ]
}

resource appSettings 'Microsoft.Web/sites/config@2022-09-01' = {
  name: 'appsettings'
  kind: 'string'
  parent: logicApp
  properties: {
    netFrameworkVersion: 'v6.0'
    WORKFLOWS_RESOURCE_GROUP_NAME: resourceGroup().name
    APP_KIND: 'workflowApp'    
    AzureFunctionsJobHost__extensionBundle__id: 'Microsoft.Azure.Functions.ExtensionBundle.Workflows'
    AzureFunctionsJobHost__extensionBundle__version: '[1.*, 2.0.0)'
    AzureWebJobsStorage: 'DefaultEndpointsProtocol=https;AccountName=${storageName};AccountKey=${listKeys('${resourceGroup().id}/providers/Microsoft.Storage/storageAccounts/${storageName}','2019-06-01').keys[0].value};EndpointSuffix=core.windows.net'
    FUNCTIONS_EXTENSION_VERSION: '~4'
    FUNCTIONS_V2_COMPATIBILITY_MODE: 'true'
    FUNCTIONS_WORKER_RUNTIME: 'node'
    WEBSITE_CONTENTAZUREFILECONNECTIONSTRING: 'DefaultEndpointsProtocol=https;AccountName=${storageName};AccountKey=${listKeys('${resourceGroup().id}/providers/Microsoft.Storage/storageAccounts/${storageName}','2019-06-01').keys[0].value};EndpointSuffix=core.windows.net'
    WEBSITE_CONTENTSHARE: logicAppName
    WEBSITE_NODE_DEFAULT_VERSION: '~18'
    WORKFLOWS_SUBSCRIPTION_ID: subscription().subscriptionId
    WORKFLOWS_LOCATION_NAME: location
    BLOB_CONNECTION_RUNTIMEURL: ''
    keyVault_VaultUri: 'https://${localKeyVaultName}.vault.azure.net/'
    APPINSIGHTS_INSTRUMENTATIONKEY: appInsights.properties.InstrumentationKey
    APPLICATIONINSIGHTS_CONNECTION_STRING: 'InstrumentationKey=${appInsights.properties.InstrumentationKey};IngestionEndpoint=https://northeurope-0.in.applicationinsights.azure.com/;LiveEndpoint=https://northeurope.livediagnostics.monitor.azure.com/;ApplicationId=${appInsights.properties.ApplicationId}'
    DynamicsCrmSecret: '@Microsoft.KeyVault(SecretUri=${vaultUri}secrets/DynamicsCrmSecret/)'
    DynamicsCrmClientId: '@Microsoft.KeyVault(SecretUri=${vaultUri}secrets/DynamicsCrmClientId/)'
    DynamicsCrmDirectoryId: '@Microsoft.KeyVault(SecretUri=${vaultUri}secrets/DynamicsCrmDirectoryId/)'
    DynamicsCrmEnvironmentUri: '@Microsoft.KeyVault(SecretUri=${vaultUri}secrets/DynamicsCrmEnvironmentUri/)'
    CpiCreateCustomerClientId: '@Microsoft.KeyVault(SecretUri=${vaultUri}secrets/CpiCreateCustomerClientId/)'
    CpiCreateCustomerClientSecret: '@Microsoft.KeyVault(SecretUri=${vaultUri}secrets/CpiCreateCustomerClientSecret/)'
    CpiCreateCustomerUrl: '@Microsoft.KeyVault(SecretUri=${vaultUri}secrets/CpiCreateCustomerUrl/)'
    CpiAccessTokenUrl: '@Microsoft.KeyVault(SecretUri=${vaultUri}secrets/CpiAccessTokenUrl/)'
    Dataverse_environment: dynamicsCrmEnvironmentUri
    CustomStorageTableConnectionString: '@Microsoft.KeyVault(SecretUri=${vaultUri}secrets/CustomStorageTableConnectionString/)'
  }
}

// table storage setup (custom)
resource storageAccountCustom 'Microsoft.Storage/storageAccounts@2018-07-01' = {
  name: customStorageName
  location: ResourceGroup
  kind: 'StorageV2'
  sku: {
    name: storageAccountType
  }
  properties: {}
}

// create tables
resource storageaccountCustom_tableService 'Microsoft.Storage/storageAccounts/tableServices@2021-08-01' = {
  name: 'default'  
  parent: storageAccountCustom  
}

resource storageaccountCustom_tableService_HashesTable 'Microsoft.Storage/storageAccounts/tableServices/tables@2021-08-01' = {
  name: 'Hashes'  
  parent: storageaccountCustom_tableService
}

resource storageaccountCustom_tableService_table_product_transaction_log 'Microsoft.Storage/storageAccounts/tableServices/tables@2021-08-01' = {
  name: 'InboundAccountsTransactionLog'  
  parent: storageaccountCustom_tableService
}

resource storageaccount_tableService_table_inbound_products_queue 'Microsoft.Storage/storageAccounts/tableServices/tables@2021-08-01' = {
  name: 'InboundAccountsQueue'  
  parent: storageaccountCustom_tableService
}

// app insights
resource appInsights 'Microsoft.Insights/components@2014-04-01' = {
  name: appInsightsName
  location: ResourceGroup
  properties: {
    applicationId: appInsightsName
  }
}

// key vault and secrets
resource kv 'Microsoft.KeyVault/vaults@2021-11-01-preview' = {
  name: localKeyVaultName
  location: ResourceGroup
  tags: {
      Environment: environmentName
  }
  properties: {
    enabledForDeployment: false
    enabledForDiskEncryption: false
    enabledForTemplateDeployment: false
    tenantId: subscription().tenantId
    enableSoftDelete: true
    softDeleteRetentionInDays: 90
    enableRbacAuthorization: true
    sku: {
      name: 'standard'
      family: 'A'
    }
    networkAcls: {
      defaultAction: 'Allow'
      bypass: 'AzureServices'
    }
  }
}

resource dynamicsCrmSecretSecret 'Microsoft.KeyVault/vaults/secrets@2021-11-01-preview' = {
  parent: kv
  name: 'DynamicsCrmSecret'
  properties: {
    value: dynamicsCrmSecret
  }
}

resource dynamicsCrmClientIdSecret 'Microsoft.KeyVault/vaults/secrets@2021-11-01-preview' = {
  parent: kv
  name: 'DynamicsCrmClientId'
  properties: {
    value: dynamicsCrmClientId
  }
}

resource dynamicsCrmDirectoryIdSecret 'Microsoft.KeyVault/vaults/secrets@2021-11-01-preview' = {
  parent: kv
  name: 'DynamicsCrmDirectoryId'
  properties: {
    value: dynamicsCrmDirectoryId
  }
}

resource dynamicsCrmEnvironmentSecret 'Microsoft.KeyVault/vaults/secrets@2021-11-01-preview' = {
  parent: kv
  name: 'DynamicsCrmEnvironmentUri'
  properties: {
    value: dynamicsCrmEnvironmentUri
  }
}

resource customStorageTableConnectionStringSecret 'Microsoft.KeyVault/vaults/secrets@2021-11-01-preview' = {
  parent: kv
  name: 'CustomStorageTableConnectionString'
  properties: {
    value: 'DefaultEndpointsProtocol=https;AccountName=${customStorageName};AccountKey=${listKeys(customStorageAccountid,'2015-05-01-preview').key1}${endpointSuffix}'
  }
}


resource cpiCreateCustomerClientIdSecret 'Microsoft.KeyVault/vaults/secrets@2021-11-01-preview' = {
  parent: kv
  name: 'CpiCreateCustomerClientId'
  properties: {
    value: cpiCreateCustomerClientId
  }
}

resource cpiCreateCustomerClientSecretSecret 'Microsoft.KeyVault/vaults/secrets@2021-11-01-preview' = {
  parent: kv
  name: 'CpiCreateCustomerClientSecret'
  properties: {
    value: cpiCreateCustomerClientSecret
  }
}

resource cpiCreateCustomerUrlSecret 'Microsoft.KeyVault/vaults/secrets@2021-11-01-preview' = {
  parent: kv
  name: 'CpiCreateCustomerUrl'
  properties: {
    value: cpiCreateCustomerUrl
  }
}

resource cpiAccessTokenUrlSecret 'Microsoft.KeyVault/vaults/secrets@2021-11-01-preview' = {
  parent: kv
  name: 'CpiAccessTokenUrl'
  properties: {
    value: cpiAccessTokenUrl
  }
}

// key vault rbac access setup
@description('This is the built-in Key Vault Secret User role. See https://docs.microsoft.com/azure/role-based-access-control/built-in-roles#key-vault-secrets-user')
resource keyVaultSecretUserRoleRoleDefinition 'Microsoft.Authorization/roleDefinitions@2018-01-01-preview' existing = {
  scope: subscription()
  name: '4633458b-17de-408a-b874-0445c86b69e6'
}

// grant access to logic app
resource keyVaultSecretUserRoleAssignmentLogicApp 'Microsoft.Authorization/roleAssignments@2020-08-01-preview' = {
  scope: kv
  name: guid(resourceGroup().id, logicApp.id, keyVaultSecretUserRoleRoleDefinition.id)
  properties: {
    roleDefinitionId: keyVaultSecretUserRoleRoleDefinition.id
    principalId: logicApp.identity.principalId
    principalType: 'ServicePrincipal'
  }
}

// grant access to dataverse
resource keyVaultSecretUserRoleAssignmentDataverse 'Microsoft.Authorization/roleAssignments@2020-08-01-preview' = {
  scope: kv
  name: guid(resourceGroup().id, dataverseObjectId, keyVaultSecretUserRoleRoleDefinition.id)
  properties: {
    roleDefinitionId: keyVaultSecretUserRoleRoleDefinition.id
    principalId: dataverseObjectId
    principalType: 'ServicePrincipal'
  }
}

// grant access to apim
resource keyVaultSecretUserRoleAssignmentApimManagedIdentity 'Microsoft.Authorization/roleAssignments@2020-08-01-preview' = {
  scope: kv
  name: guid(resourceGroup().id, apimManagedIdentityId, keyVaultSecretUserRoleRoleDefinition.id)
  properties: {
    roleDefinitionId: keyVaultSecretUserRoleRoleDefinition.id
    principalId: apimManagedIdentityId
    principalType: 'ServicePrincipal'
  }
}

output logicAppSystemAssignedIdentityTenantId string = subscription().tenantId
output logicAppSystemAssignedIdentityObjectId string = reference(logicApp.id, '2019-08-01', 'full').identity.principalId
output LAname string = logicAppName
