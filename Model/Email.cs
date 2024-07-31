using System.ComponentModel.DataAnnotations;
namespace EmailSendTask.Model
{
    public class Email
    {
        [Required(ErrorMessage = "Enter Recipent Address")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}
