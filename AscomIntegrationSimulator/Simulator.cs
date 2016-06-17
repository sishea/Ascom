using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AscomTestHarness;

namespace AscomIntegrationSimulator
{
    public partial class Simulator : Form
    {
        private const string INITIAL_DIRECTORY = @"C:\Users\sshea5\Documents\Visual Studio 2015\Projects\AscomTestHarness\AscomTestHarness\Data\";
        private const string FILEPATH = @"C:\Users\sshea5\Documents\Visual Studio 2015\Projects\AscomTestHarness\AscomTestHarness\Data\IntegrationTest.xml";
        private const string LOGFILE = @"C:\Users\sshea5\Documents\Visual Studio 2015\Projects\AscomTestHarness\AscomTestHarness\Data\IntegrationTestLog.txt";

        //private string _testScript;
        //private string _logFile;

        public Simulator()
        {
            InitializeComponent();

            _txtScript.Text = FILEPATH;
            _txtLog.Text = LOGFILE;
        }

        private void ScriptClick(object sender, EventArgs e)
        {
            _txtScript.Text = GetFileName("xml files (*.xml)|*.xml|All files (*.*)|*.*");
        }

        private void LogClick(object sender, EventArgs e)
        {
            _txtLog.Text = GetFileName("txt files (*.txt)|*.txt|All files (*.*)|*.*");
        }

        private void RunClick(object sender, EventArgs e)
        {
            TestHarness harness = TestHarness.Instance;
            harness.SetupLog(DebugLevel.High, _txtLog.Text);
            harness.LoadXml(_txtScript.Text);
            harness.RunScript();
        }

        private string GetFileName(string filter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            string fileName = "";

            dialog.InitialDirectory = INITIAL_DIRECTORY;
            dialog.Filter = filter;
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
            }

            return fileName;
        }
    }
}
