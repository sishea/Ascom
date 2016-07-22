using System;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace AscomIntegration
{
    public abstract class ConnectMessage
    {
        private const string SEPARATOR = " | ";

        protected string _collection;
        protected string _name;
        protected string _body;

        protected ConnectInterface _interface;

        public ConnectMessage(ConnectInterface conn, string collectionName, XElement element)
        {
            _interface = conn;
            _collection = collectionName;
            _name = element.Attribute("name").Value;
            _body = element.Element("Body").Value;
        }

        public abstract void SendData();

        public override string ToString()
        {
            StringBuilder str = new StringBuilder(_collection);
            str.Append(SEPARATOR);
            str.Append(_name);
            str.Append(": ");
            str.Append(_body);

            return str.ToString();
        }
    }
}
