using System.Net.Mail;
using System.Xml.Linq;

namespace AscomIntegration
{
    public class SMTPMessage : ConnectMessage
    {
        private MailMessage _email;

        public SMTPMessage(SMTPInterface conn, string collectionName, XElement element) : base(conn, collectionName, element)
        {
            _email = new MailMessage(element.Element("From").Value, element.Element("To").Value);
            _email.Subject = element.Element("Subject").Value;
            _email.Body = _body;
        }

        public override void SendData()
        {
                ((SMTPInterface)_interface).SendEmail(_email);
        }
    }
}
