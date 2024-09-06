#nullable disable
namespace RU_NO_CRM_Functions.Models.Wsdl.CustomerCreate;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:sap-com:document:sap:soap:functions:mc-style")]
public partial class CvisMessage
{

    private string isErrorField;

    private Bapiret2[] messagesField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string IsError
    {
        get
        {
            return this.isErrorField;
        }
        set
        {
            this.isErrorField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("item", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    public Bapiret2[] Messages
    {
        get
        {
            return this.messagesField;
        }
        set
        {
            this.messagesField = value;
        }
    }
}