using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace Capadatos.SQLserver
{
   public abstract class ServerMasteremail
    {
        private SmtpClient SmtpClient; 
        protected string SenderMail { get; set; }
        protected string Password { get; set; }
        protected string Host { get; set; }
        protected int Port { get; set; }
        protected bool Ssl { get; set; }


        protected void Inicializarsmtpcliente()
        {
            SmtpClient = new SmtpClient
            {
                Credentials = new NetworkCredential(SenderMail, Password),
                Host = Host,
                Port = Port,
                EnableSsl = Ssl
            };
        }

        public void SendMail(string Subject, string body, List<string>recipienteMail)
        {
            using (var Mailmessage = new MailMessage())
            {
                try
                {
                    Mailmessage.From = new MailAddress(SenderMail);
                    foreach (string mail in recipienteMail)
                    {
                        Mailmessage.To.Add(mail);
                    }
                    Mailmessage.Subject = Subject;
                    Mailmessage.Body = body;
                    Mailmessage.Priority = MailPriority.Normal;
                    SmtpClient.Send (Mailmessage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo Mandar el mensaje" +ex.Message);
                }
            }
        }


    }
}
