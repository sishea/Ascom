using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AscomIntegration.Messages
{
    class SerialMessage : ConnectMessage
    {
        public SerialMessage(TCPInterface conn, string collectionName, XElement element) : base(conn, collectionName, element) { }

        public override void SendData()
        {
            ((TCPInterface)_interface).SendMessage(_body);
        }
    }
}
