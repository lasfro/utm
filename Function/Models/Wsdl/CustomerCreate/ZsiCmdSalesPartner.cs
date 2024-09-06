#nullable disable
namespace RU_NO_CRM_Functions.Models.Wsdl.CustomerCreate;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:sap-com:document:sap:soap:functions:mc-style")]
public partial class ZsiCmdSalesPartner
{

    private string parvwField;

    private string parzaField;

    private string defpaField;

    private string knrefField;

    private string partnerField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Parvw
    {
        get
        {
            return this.parvwField;
        }
        set
        {
            this.parvwField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Parza
    {
        get
        {
            return this.parzaField;
        }
        set
        {
            this.parzaField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Defpa
    {
        get
        {
            return this.defpaField;
        }
        set
        {
            this.defpaField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Knref
    {
        get
        {
            return this.knrefField;
        }
        set
        {
            this.knrefField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Partner
    {
        get
        {
            return this.partnerField;
        }
        set
        {
            this.partnerField = value;
        }
    }
}