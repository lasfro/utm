#nullable disable
namespace RU_NO_CRM_Functions.Models.Wsdl.CustomerCreate;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:sap-com:document:sap:soap:functions:mc-style")]
public partial class ZsiCmdKnsttv
{

    private string sttvField;

    private string sttv6Field;

    private string begdtField;

    private string enddtField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Sttv
    {
        get
        {
            return this.sttvField;
        }
        set
        {
            this.sttvField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Sttv6
    {
        get
        {
            return this.sttv6Field;
        }
        set
        {
            this.sttv6Field = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Begdt
    {
        get
        {
            return this.begdtField;
        }
        set
        {
            this.begdtField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Enddt
    {
        get
        {
            return this.enddtField;
        }
        set
        {
            this.enddtField = value;
        }
    }
}