using EmailSendTask.Model;
namespace EmailSendTask.Repository.Contract
{
    public interface IEmailService
    {
        string SendEmail(Email email);
    }
}
