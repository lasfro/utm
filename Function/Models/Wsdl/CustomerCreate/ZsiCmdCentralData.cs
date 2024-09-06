#nullable disable
namespace RU_NO_CRM_Functions.Models.Wsdl.CustomerCreate;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:sap-com:document:sap:soap:functions:mc-style")]
public partial class ZsiCmdCentralData
{

    private string customerField;

    private CmdsEiVmdCentralData centralField;

    private Bapiad1vl addressField;

    private ZsiCmdCommunication communicationField;

    private ZsiCmdBankdetail[] bankdetailsField;

    private ZsiCmdVat[] vatNumberField;

    private ZsiCmdTaxInd[] taxIndField;

    private ZsiCmdContactPerson[] contactField;

    private ZsiCmdKnsttv[] sttvLicenseField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Customer
    {
        get
        {
            return this.customerField;
        }
        set
        {
            this.customerField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public CmdsEiVmdCentralData Central
    {
        get
        {
            return this.centralField;
        }
        set
        {
            this.centralField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Bapiad1vl Address
    {
        get
        {
            return this.addressField;
        }
        set
        {
            this.addressField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public ZsiCmdCommunication Communication
    {
        get
        {
            return this.communicationField;
        }
        set
        {
            this.communicationField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("item", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    public ZsiCmdBankdetail[] Bankdetails
    {
        get
        {
            return this.bankdetailsField;
        }
        set
        {
            this.bankdetailsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("item", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    public ZsiCmdVat[] VatNumber
    {
        get
        {
            return this.vatNumberField;
        }
        set
        {
            this.vatNumberField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("item", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    public ZsiCmdTaxInd[] TaxInd
    {
        get
        {
            return this.taxIndField;
        }
        set
        {
            this.taxIndField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("item", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    public ZsiCmdContactPerson[] Contact
    {
        get
        {
            return this.contactField;
        }
        set
        {
            this.contactField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("item", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    public ZsiCmdKnsttv[] SttvLicense
    {
        get
        {
            return this.sttvLicenseField;
        }
        set
        {
            this.sttvLicenseField = value;
        }
    }
}