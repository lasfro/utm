#nullable disable
using System.Xml.Serialization;

namespace RU_NO_CRM_Functions.Models.Wsdl.CustomerCreate;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:sap-com:document:sap:soap:functions:mc-style")]
public partial class ZfmCustomerMasterCreate
{

    private ZsiCmdCentralData centralDataField;

    private ZsiCmdCompanyData[] companyDataField;

    private ZsiCmdSalesData[] salesDataField;

    private string testRunField;

    /// <remarks/>
    //[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public ZsiCmdCentralData CentralData
    {
        get
        {
            return this.centralDataField;
        }
        set
        {
            this.centralDataField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("item", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    public ZsiCmdCompanyData[] CompanyData
    {
        get
        {
            return this.companyDataField;
        }
        set
        {
            this.companyDataField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("item", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    public ZsiCmdSalesData[] SalesData
    {
        get
        {
            return this.salesDataField;
        }
        set
        {
            this.salesDataField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string TestRun
    {
        get
        {
            return this.testRunField;
        }
        set
        {
            this.testRunField = value;
        }
    }
}