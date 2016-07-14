using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Diagnostics;

namespace AscomIntegration
{
    public class SMTPInterface : ConnectInterface, IDisposable
    {
        private SmtpClient _client;
        private MailMessage _email;

        public SMTPInterface(string xml) : base(xml) { }

        //public SMTPInterface(string ipAddress, int port) : base(ipAddress, port) { }

        public override void Send(ConnectMessage message)
        {
            Connect();
            MailAddress from = new MailAddress(((SMTPMessage)message).To);
            MailAddress to = new MailAddress(((SMTPMessage)message).From);
            _email = new MailMessage(from, to);
            _email.Body = message.ToString();
            _email.Subject = ((SMTPMessage)message).Subject;
            Debug.WriteLineIf(_debugLevel == DebugLevel.High, "Sending email with subject: " + _email.Subject);
            _numMessages++;
            SendData(message.ToString());
            Close();
        }

        protected override void Connect()
        {
            _client = new SmtpClient(_address, _port);
        }

        protected override void Close() { } // no smtp close


        protected override void SendData(string message)
        {
            try
            {
                // Send the message to the connected TcpServer. 
                _client.Send(_email);
                _email.Dispose();
                _numSends++;
            }
            catch (ArgumentNullException e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString(), "ArgumentNullException");
                _numFails++;
            }
            catch (SmtpException e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString(), "SmtpException");
                _numFails++;
            }
        }

        public void Dispose()
        {
            _email.Dispose();
            _client.Dispose();
        }
    }
}