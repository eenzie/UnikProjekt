using UnikProjekt.Web.Models;
using UnikProjekt.Web.ProxyServices;

namespace UnikProjekt.Web.Services;

public class EmailService /*: IEmailService*/
{
    //public Task SendEmailAsync(string email, string subject, string message)
    //{
    //    var client = new SmtpClient("127.0.0.1", 1025)
    //    {
    //        EnableSsl = true,
    //        UseDefaultCredentials = false,
    //        Credentials = new NetworkCredential("test@live.com", "Password1234!")
    //    };

    //    return client.SendMailAsync(
    //        new MailMessage(from: "test@live.com",
    //                        to: email,
    //                        subject,
    //                        message
    //                        ));
    //}

    private readonly IEmailServiceProxy _emailServiceProxy;

    public EmailService(IEmailServiceProxy emailServiceProxy)
    {
        _emailServiceProxy = emailServiceProxy;

    }

    public async Task<bool> SendEmailAsync(EmailViewModel emailViewModel)
    {
        try
        {
            await _emailServiceProxy.SendEmailAsync(emailViewModel.RecipientEmail, emailViewModel.Subject, emailViewModel.Message);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fejl ved afsendelse af email: {ex.Message}");
            return false;
        }
    }

}
