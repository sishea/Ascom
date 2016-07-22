using System.Xml.Linq;

namespace AscomIntegration
{
    public class TAPMessage : ConnectMessage
    {
        protected string _capCode;

        public TAPMessage(TAPInterface conn, string collectionName, XElement element) : base(conn, collectionName, element)
        {
            _capCode = element.Element("CAPCode").Value;
        }

        public override void SendData()
        {
            ((TAPInterface)_interface).SendMessage(TAPInterface.TAPString(_capCode, _body));
        }
    }
}
