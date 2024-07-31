using Microsoft.AspNetCore.Mvc;
using EmailSendTask.Model;
using EmailSendTask.Repository.Contract;

namespace EmailSendTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        [Route("Send")]
        public IActionResult SendEmail([FromBody] Email email)
        {
            return Ok(_emailService.SendEmail(email));
        }
    }

}
