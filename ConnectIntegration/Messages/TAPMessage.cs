using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AscomIntegration
{
    public class TAPMessage : ConnectMessage
    {
        protected string _address;

        public TAPMessage(string xml) : base(xml)
        {
            XElement element = XElement.Parse(xml);
            _address = element.Element("CAPCode").Value;
        }

        public override string ToString()
        {
            return TAPInterface.TAPString(_address, base.ToString());
        }
    }
}
