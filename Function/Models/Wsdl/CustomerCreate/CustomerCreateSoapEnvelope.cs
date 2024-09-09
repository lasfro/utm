#nullable disable
using System.Xml.Serialization;

namespace RU_NO_CRM_Functions.Models.Wsdl.CustomerCreate
{
    [XmlRoot(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", ElementName = "Envelope")]
    public class CustomerCreateSoapEnvelope
    {
        [XmlElement(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public string Header { get; set; } = "";   // hack 2 serialize empty header
        public Body Body { get; set;}
    }


    [XmlType(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Body
    {
        [XmlElement(Namespace = "urn:sap-com:document:sap:soap:functions:mc-style", ElementName = "ZfmCustomerMasterCreate")]
        public ZfmCustomerMasterCreate Content { get; set; }
    }
}
