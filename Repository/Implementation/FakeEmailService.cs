using EmailSendTask.Model;
using EmailSendTask.Repository.Contract;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace EmailSendTask.Repository.Implementation
{
    public class FakeEmailService : IEmailService
    {
        private readonly IWebHostEnvironment _webHostEnv;
        readonly EmailSetting _setting;
        public FakeEmailService(IWebHostEnvironment webHostEnv, IOptions<EmailSetting> setting)
        {
            _webHostEnv = webHostEnv;
            _setting = setting.Value;
        }
        public string SendEmail(Email email)
        {
            try
            {
                string DirPath = Path.Combine(_webHostEnv.ContentRootPath, "FakeEmails");

                if (!Directory.Exists(DirPath))
                    Directory.CreateDirectory(DirPath);

                string FilePath = Path.Combine(DirPath, "FakeEmails.txt");

                var fakeemail = $"From:{_setting.from}{Environment.NewLine} " +
                    $"To: {email.To}{Environment.NewLine}Subject: " +
                    $"{email.Subject}{Environment.NewLine}Body: " +
                    $"{email.Body}{Environment.NewLine}---{Environment.NewLine}";

                File.AppendAllText(FilePath, fakeemail);

                return "Successfully save fake email";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }
    }
}
