using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace API_Livros.Helpers
{
    public class SendEmail : ISendEmail
    {
        //Utilizando o SMTP para enviar o email
        //gerenciadordeleitura@hotmail.com
        //8Efbtt4,

        private readonly IConfiguration _configuration;
        public SendEmail(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Send(string email, string subject, string compose)
        {
            try
            {
                string host = _configuration.GetValue<string>("SMTP:Host");
                string name = _configuration.GetValue<string>("SMTP:Name");
                string username = _configuration.GetValue<string>("SMTP:UserName");
                string password = _configuration.GetValue<string>("SMTP:Password");
                int port = _configuration.GetValue<int>("SMTP:Port");

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(username, name)
                };

                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = compose;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(host, port))
                {
                    smtp.Credentials = new NetworkCredential(username, password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    return true;
                }
            }
            catch (Exception)
            {
                //{"Value cannot be null. (Parameter 'address')"}
                return false;
            }
        }
    }
}
