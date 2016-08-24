using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Diagnostics;
using System.ComponentModel;
using System.Xml.Linq;

namespace AscomIntegration
{
    public class SMTPInterface : ConnectInterface//, IDisposable
    {
        //private SmtpClient _client;
        //private MailMessage _email;

        public SMTPInterface(XElement element) : base(element) { }

        public void SendEmail(MailMessage message)
        {
            _numMessages++;

            using (SmtpClient client = new SmtpClient(_address, _port))
            {
                try
                {
                    client.Send(message);
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
        }
    }
}