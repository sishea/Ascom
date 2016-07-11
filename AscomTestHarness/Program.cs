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
        private const string LOGFILE = @"Data\TestLog.txt";

        static void Main(string[] args)
        { 
            string filePath;
            // ********** UPDATE ME! **********
            TestScript script = TestScript.PTS;
            // ********************************

            switch (script)
            {
                //PTS Test
                case TestScript.PTS:
                    filePath = @"Data\PTSTest.xml";
                    break;
                //FPS Test
                case TestScript.FPS:
                    filePath = @"Data\FPSTest.xml";
                    break;
                //Nurse Call Test
                case TestScript.NurseCall:
                    filePath = @"Data\NurseCallTest.xml";
                    break;
                //BMS Test
                case TestScript.BMS:
                    filePath = @"Data\BMSTest.xml";
                    break;
                //SMS Test
                case TestScript.SMS:
                    filePath = @"Data\SMSTest.xml";
                    break;
                //Integration Test
                default:
                    filePath = @"Data\IntegrationTest.xml";
                    break;
            }

            TestHarness harness = TestHarness.Instance;
            harness.SetupLog(DebugLevel.High, args.Length > 1 ? args[1] : LOGFILE);
            harness.LoadXml(args.Length > 0 ? args[0] : filePath);
            harness.RunScript();
        }
    }
}