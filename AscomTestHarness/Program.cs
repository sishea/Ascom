using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using AscomIntegration;
using System.Diagnostics;

namespace AscomTestHarness
{
    class Program
    {
        private const string FILEPATH = @"C:\Users\sshea5\Documents\Visual Studio 2015\Projects\AscomTestHarness\AscomTestHarness\Data\IntegrationTest.xml";
        private const string LOGFILE = @"C:\Users\sshea5\Documents\Visual Studio 2015\Projects\AscomTestHarness\AscomTestHarness\Data\IntegrationTestLog.txt";

        static void Main(string[] args)
        {
            TestHarness harness = TestHarness.Instance;
            harness.SetupLog(DebugLevel.High, args.Length > 1 ? args[1] : LOGFILE);
            harness.LoadXml(args.Length > 0 ? args[0] : FILEPATH);
            harness.RunScript();
        }
    }
}