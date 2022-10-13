using Business.Auth;
using Microsoft.AspNetCore.Mvc;

namespace TrimAz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailSenderController : ControllerBase
{
    private readonly IEmailSender _emailSender;

    public EmailSenderController(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    [HttpPost, Route("SendEmail")]
    public async Task<IActionResult> SendEmailAsync(string recipientEmail, string recipientFirstName, string Link)
    {
        try
        {
            string messageStatus = await _emailSender.SendEmailAsync(recipientEmail, recipientFirstName, Link);
            return Ok(messageStatus);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message.ToString());
        }
    }
}
