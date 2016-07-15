using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AscomIntegration
{
    public class SMTPMessage : ConnectMessage
    {
        protected string _to;
        protected string _from;
        protected string _subject;

        public SMTPMessage(string xml) : base(xml)
        {
            XElement element = XElement.Parse(xml);
            _to = element.Element("To").Value;
            _from = element.Element("From").Value;
            _subject = element.Element("Subject").Value;
        }

        public string To
        {
            get { return _to; }
        }
        public string From
        {
            get { return _from; }
        }

        public string Subject
        {
            get { return _subject; }
        }
    }
}
