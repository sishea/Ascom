using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Xml.Linq;


namespace AscomIntegration
{
    public enum DebugLevel { High, Normal, None };

    public abstract class ConnectInterface
    {
        private const int NUM_ATTEMPTS = 36;
        private const string NUMBER_PLACEHOLDER = "||number||";
        private const string TIME_PLACEHOLDER = "||time||";

        private XElement _element;
        private string _name;
        protected string _address;
        protected int _port;
        protected DebugLevel _debugLevel;
        protected int _numMessages;
        protected int _numSends;
        protected int _numFails;

        //protected Queue<ConnectMessage> _messages = new Queue<ConnectMessage>();

        protected ConnectInterface(XElement element)
        {
            _element = element;
            _name = _element.Attribute("name").Value;
            SetupConnection(_element.Element("Connection"));

            ResetStatistics();
        }

        private void SetupConnection(XElement paramXML)
        {
            _address = paramXML.Element("Address").Value;
            _port = Int32.Parse(paramXML.Element("Port").Value);
        }

        //public abstract void Send(ConnectMessage message);
        //protected abstract void Connect();
        //protected abstract void Close();

        public void SetDebugLevel(DebugLevel lvl)
        {
            _debugLevel = lvl;
        }

        public void ResetStatistics()
        {
            _numMessages = 0;
            _numSends = 0;
            _numFails = 0;
        }

        public void ReportStatistics()
        {
            StringBuilder str = new StringBuilder();
            str.Append(this.GetType().ToString());
            str.Append(" Messages to: ");
            str.Append(_address);
            str.Append(":");
            str.Append(_port);
            str.Append(" Num messages: ");
            str.Append(_numMessages);
            str.Append(" Sends OK: ");
            str.Append(_numSends);
            str.Append(" Errors: ");
            str.Append(_numFails);
            Debug.WriteLine(str.ToString());
            ResetStatistics();
        }

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

        public void SendMessages()
        {
            //int uid = 0;

            Debug.Indent();

            // each message collection
            foreach (XElement messages in _element.Elements("Messages"))
            {
                // only active message collections
                if (Convert.ToBoolean(messages.Attribute("active").Value))
                {
                    StringBuilder messageType = new StringBuilder("AscomIntegration.");
                    messageType.Append(messages.Attribute("type").Value);
                    messageType.Append(", AscomIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
                    Type msgType = Type.GetType(messageType.ToString());
                    string collectionName = messages.Attribute("name").Value;

                    Debug.Indent();

                    int id = 0;

                    // message collection repeats
                    for (int colRpt = 0; colRpt < Int32.Parse(messages.Attribute("repeat").Value); colRpt++)
                    {
                        // each message in this collection
                        foreach (XElement message in messages.Elements("Message"))
                        {
                            // only active messages
                            if (Convert.ToBoolean(message.Attribute("active").Value))
                            {
                                // message repeats
                                for (int msgRpt = 0; msgRpt < Int32.Parse(message.Attribute("repeat").Value); msgRpt++)
                                {
                                    // parse placeholders
                                    StringBuilder str = new StringBuilder(message.ToString());
                                    str.Replace(NUMBER_PLACEHOLDER, (++id).ToString());
                                    str.Replace(TIME_PLACEHOLDER, DateTime.Now.ToString("HH:mm:ss"));

                                    // send message
                                    ConnectMessage msg = (ConnectMessage)Activator.CreateInstance(msgType, new object[] { this, collectionName, XElement.Parse(str.ToString()) });
                                    msg.SendData();
                                    Thread.Sleep(Int32.Parse(message.Attribute("delay").Value));
                                }
                            }
                        }

                        Thread.Sleep(Int32.Parse(messages.Attribute("delay").Value));
                        Debug.Unindent();
                    }
                }

                Debug.Unindent();
            }
        }
    }
}
