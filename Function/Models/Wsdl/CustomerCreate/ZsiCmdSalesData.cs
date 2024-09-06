#nullable disable
namespace RU_NO_CRM_Functions.Models.Wsdl.CustomerCreate;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:sap-com:document:sap:soap:functions:mc-style")]
public partial class ZsiCmdSalesData
{

    private string vkorgField;

    private string vtwegField;

    private string spartField;

    private CmdsEiSalesData salesDataField;

    private ZsiCmdSalesPartner[] partnersField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Vkorg
    {
        get
        {
            return this.vkorgField;
        }
        set
        {
            this.vkorgField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Vtweg
    {
        get
        {
            return this.vtwegField;
        }
        set
        {
            this.vtwegField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Spart
    {
        get
        {
            return this.spartField;
        }
        set
        {
            this.spartField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public CmdsEiSalesData SalesData
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
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("item", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    public ZsiCmdSalesPartner[] Partners
    {
        get
        {
            return this.partnersField;
        }
        set
        {
            this.partnersField = value;
        }
    }
}