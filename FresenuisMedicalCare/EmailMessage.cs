using System;
using System.Net;
using System.Net.Mail;

namespace FresenuisMedicalCare
{
    public class EmailMessage
    {
        const string emailSenderAdress = "i-borisenok@mail.ru";
        const string emailSenderPassword = "cf29WUNrYgQMh96DgvzT";
        const string displayName = "FresenuisMedicalCare";
        const string host = "smtp.mail.ru";
        const int port = 587;
        const string messageSubject = "Восстановление доступа Fresenius Medical Care";
        const int minPin = 1000;
        const int maxPin = 9999;

        private int pin = new Random().Next(minPin,maxPin);

        private string mailTo;
        public string EmailAdress
        {
            get => mailTo; 
            set
            {
                if (value.Contains("@") == true)
                {
                    mailTo = value;
                }
            }
        }
 
        public EmailMessage(string EmailAdress)
        {
            this.EmailAdress = EmailAdress;
        }

        public void SendMessage()
        {
            MailAddress from = new MailAddress(emailSenderAdress, displayName);  // адрес отправителя
            MailAddress to = new MailAddress(mailTo);  // адрес получателя

            MailMessage message = new MailMessage(from, to);
  
            message.Subject = messageSubject;  // тема письма

            // текст письма
            message.Body =
                "<h2 align=\"center\">Для восстановления доступа в программу введите следующий пинкод</h2>" +
                    $"<a align=\"center\"><h1> {pin} </h1></a>";
            
            message.IsBodyHtml = true;  // письмо представляет код html

            // адрес smtp-сервера и порт, с которого будет отправлено письмо
            SmtpClient smtp = new SmtpClient(host, port);
            smtp.Credentials = new NetworkCredential(emailSenderAdress, emailSenderPassword);
            smtp.EnableSsl = true;
            smtp.Send(message);
        }

        public int GetPin()
        {
            return pin;
        }

    }
}
