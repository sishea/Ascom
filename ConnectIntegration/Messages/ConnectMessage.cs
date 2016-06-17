using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace AscomIntegration
{
    public class ConnectMessage : ConnectObject
    {
        protected string _body;

        public ConnectMessage(string xml)
        {
            XElement element = XElement.Parse(xml);
            _body = element.Element("Body").Value;
        }

        public string Body
        {
            get { return _body; }
            //set { _body = value; }
        }

        public override string ToString()
        {
            return _body;
        }
    }
}
