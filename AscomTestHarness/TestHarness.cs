using AscomIntegration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace AscomTestHarness
{
    public enum DebugLevel { High, Normal, None };
    
    public class TestHarness : INotifyPropertyChanged
    {
        private static readonly TestHarness _instance = new TestHarness();
        private Queue<ConnectInterface> _integrations;
        private DebugLevel _debugLevel;
        //private static bool _running = false;

        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;

        static TestHarness() { }

        private TestHarness() { }

        public static TestHarness Instance
        {
            get { return _instance; }
        }

        public DebugLevel DebugLevel
        {
            get
            {
                return _debugLevel;
            }

            set
            {
                _debugLevel = value;
            }
        }

        public void SetupLog(DebugLevel lvl, string logFile)
        {
            DebugLevel = lvl;
            TextWriterTraceListener listener = new TextWriterTraceListener(logFile);
            listener.TraceOutputOptions |= TraceOptions.DateTime;
            Debug.Listeners.Add(listener);
            Debug.AutoFlush = true;
        }

        public void LoadXml(string fileName)
        {
            _integrations = new Queue<ConnectInterface>();

            XDocument doc = XDocument.Load(XmlReader.Create(fileName));
            XElement root = doc.Element("Test");
            _name = root.Attribute("name").Value;

            // build object for connections and messages from XML definition
            foreach (XElement element in root.Elements("Integration"))
            {
                if (Convert.ToBoolean(element.Attribute("active").Value))
                {
                    // create connection object
                    StringBuilder interfaceType = new StringBuilder("AscomIntegration.");
                    interfaceType.Append(element.Attribute("type").Value);
                    interfaceType.Append(", AscomIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
                    ConnectInterface integration = (ConnectInterface)Activator.CreateInstance(Type.GetType(interfaceType.ToString()), element);

                    // add to collection                
                    _integrations.Enqueue(integration);
                    Debug.WriteLineIf(DebugLevel > DebugLevel.None, integration.ToString(), "Loaded");
                }
            }
        }

        public void RunScript()
        {
            StringBuilder str = new StringBuilder();
            str.Append(_name);
            str.Append(" Started at: ");
            str.Append(DateTime.Now.ToString());
            Debug.WriteLine(str.ToString());

            // concurrent thread for each integration
            Parallel.ForEach(_integrations, integration => integration.SendMessages());

            str.Clear();
            str.Append(_name);
            str.Append(" Ended at: ");
            str.Append(DateTime.Now.ToString());
            Debug.WriteLine(str.ToString());
            Debug.Flush();
        }

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
