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
        private const string NUMBER_PLACEHOLDER = "||number||";
        private const string TIME_PLACEHOLDER = "||time||";

        protected string _body;
        private int _number = 0;

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

        public int Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
            }
        }

        public override string ToString()
        {
            _body = _body.Replace(NUMBER_PLACEHOLDER, Number.ToString());
            _body = _body.Replace(TIME_PLACEHOLDER, DateTime.Now.ToString("HH:mm:ss"));

            return _body;
        }
    }
}
