using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using System.Net;

namespace Business.Auth;

public class EmailSender : IEmailSender
{
    private readonly SmtpSettings _smtpSettings;
    public EmailSender(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;
    }
    public async Task<string> SendEmailAsync(string recipientEmail, string recipientFirstName, string Link)
    {
        MimeMessage message = new();
        message.From.Add(MailboxAddress.Parse(_smtpSettings.SenderEmail));
        message.To.Add(MailboxAddress.Parse(recipientEmail));
        message.Subject = "Confrim your account";
        message.Body = new TextPart("html")
        {
            Text = "test test",
        };

        var client = new SmtpClient();

        try
        {
            await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, true);
            await client.AuthenticateAsync(new NetworkCredential(_smtpSettings.SenderEmail, _smtpSettings.Password));
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
            return "Email sent successfully";
        }
        catch (Exception ex)
        {
            return ex.Message;

        }
        finally
        {
            client.Dispose();
        }
    }

    //    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    //    {
    //        string fromMail = "adil.heybetov@yandex.com";
    //        string fromPassword = "gpcswzojfwzrqyfq";

    //        using MailMessage message = new();
    //        message.From = new MailAddress(fromMail);
    //        message.Subject = subject;
    //        message.To.Add(new MailAddress(email));
    //        message.Body = "<html><body> " + htmlMessage + " </body></html>";
    //        message.IsBodyHtml = true;

    //        using var smtpClient = new SmtpClient("smtp.yandex.com")
    //        {
    //            Port = 465,
    //            Credentials = new NetworkCredential(fromMail, fromPassword),
    //            EnableSsl = true,
    //        };
    //        await smtpClient.SendMailAsync(message);
    //    }
}
