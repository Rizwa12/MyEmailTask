using EmailSendTask.Model;
using  EmailSendTask.Repository.Contract;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
namespace EmailSendTask.Repository.Implementation
{
    public class ActualEmailService : IEmailService
    {
        readonly EmailSetting _setting;
        public ActualEmailService(IOptions<EmailSetting> setting)
        {
            _setting = setting.Value;
        }
        public string SendEmail(Email email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(_setting.from);
                mail.To.Add(new MailAddress(email.To));
                mail.Subject = email.Subject;
                mail.Body = email.Body;

                SmtpClient smtpClient = new SmtpClient(_setting.smtpServer, _setting.smtpPort.Value)
                {
                    Credentials = new NetworkCredential(_setting.from, _setting.password),
                    EnableSsl = _setting.UseSSL.Value
                };

                // Send the email
                smtpClient.Send(mail);

                return $"Successfully sent email to {email.To}";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
    
}
