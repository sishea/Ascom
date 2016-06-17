using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Xml.Linq;
using System.Diagnostics;

namespace AscomIntegration
{
    public abstract class ConnectInterface : ConnectObject
    {
        protected string _address;
        protected int _port;


        protected Queue<ConnectMessage> _messages = new Queue<ConnectMessage>();

        protected ConnectInterface(string xml)
        {
            LoadXml(xml);
        }

        private void LoadXml(string xml)
        {
            XElement element = XElement.Parse(xml);
            _address = element.Element("Address").Value;
            _port = Int32.Parse(element.Element("Port").Value);
        }

        public abstract void Send(ConnectMessage message);
        protected abstract void Connect();
        protected abstract void Close();
        protected abstract void SendData(string message);

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        public Queue<ConnectMessage> Messages
        {
            get { return _messages; }
        }

        public void EnqueueMessage(ConnectMessage msg)
        {
            _messages.Enqueue(msg);
        }

        public void SendAllMessages()
        {
            StringBuilder str = new StringBuilder();
            str.Append(this.GetType().ToString());
            str.Append(" Started at: ");
            str.Append(DateTime.Now.ToString());
            Debug.WriteLine(str.ToString());

            for (int repeat = 0; repeat < Repeat; repeat++)
            {
                foreach (ConnectMessage message in _messages)
                {
                    for (int msgRepeat = 0; msgRepeat < message.Repeat; msgRepeat++)
                    {
                        Send(message);
                        Thread.Sleep(message.Delay);
                    }
                }

                Thread.Sleep(Delay);
            }

            str.Clear();
            str.Append(this.GetType().ToString());
            str.Append(" Ended at: ");
            str.Append(DateTime.Now.ToString());
            Debug.WriteLine(str.ToString());
        }
    }
}
