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
    public enum TestScript {Integration, PTS, FPS, NurseCall, BMS, SMS};
    
    class Program
    {         
        private const string LOGFILE = @"C:\Users\sshea5\Documents\Visual Studio 2015\Projects\AscomTestHarness\AscomTestHarness\Data\IntegrationTestLog.txt";

        static void Main(string[] args)
        { 
            string filePath;
            // *** UPDATE ME! ***
            TestScript script = TestScript.SMS;

            switch(script)
            {
                //PTS Test
                case TestScript.PTS:
                    filePath = @"C:\Users\sshea5\Documents\CSC\AscomTestHarness\Data\PTSTest.xml";
                    break;
                //FPS Test
                case TestScript.FPS:
                    filePath = @"C:\Users\sshea5\Documents\CSC\AscomTestHarness\Data\FPSTest.xml";
                    break;
                //Nurse Call Test
                case TestScript.NurseCall:
                    filePath = @"C:\Users\sshea5\Documents\CSC\AscomTestHarness\Data\NurseCallTest.xml";
                    break;
                //BMS Test
                case TestScript.BMS:
                    filePath = @"C:\Users\sshea5\Documents\CSC\AscomTestHarness\Data\BMSTest.xml";
                    break;
                //SMS Test
                case TestScript.SMS:
                    filePath = @"C:\Users\sshea5\Documents\CSC\AscomTestHarness\Data\SMSTest.xml";
                    break;
                //Integreation Test
                default:
                    filePath = @"C:\Users\sshea5\Documents\Visual Studio 2015\Projects\AscomTestHarness\AscomTestHarness\Data\IntegrationTest.xml";
                    break;
            }

            TestHarness harness = TestHarness.Instance;
            harness.SetupLog(DebugLevel.High, args.Length > 1 ? args[1] : LOGFILE);
            harness.LoadXml(args.Length > 0 ? args[0] : filePath);
            harness.RunScript();
        }
    }
}