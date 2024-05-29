using System.Net;
using System.Net.Mail;

namespace UnikProjekt.Web.Services;

public class EmailService : IEmailService
{
    public Task SendEmailAsync(string email, string subject, string message)
    {
        var client = new SmtpClient("127.0.0.1", 1025)
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("test@live.com", "Password1234!")
        };

        return client.SendMailAsync(
            new MailMessage(from: "test@live.com",
                            to: email,
                            subject,
                            message
                            ));
    }
}
