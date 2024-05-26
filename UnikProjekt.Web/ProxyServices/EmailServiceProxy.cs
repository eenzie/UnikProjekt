
using System.Net;
using System.Net.Mail;

namespace UnikProjekt.Web.ProxyServices
{
    public class EmailServiceProxy : IEmailServiceProxy
    {
        private readonly HttpClient _httpClient;

        public EmailServiceProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        async Task IEmailServiceProxy.SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("127.0.0.1", 1025)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("test@live.com", "Password1234!")
            };

            await client.SendMailAsync(
                new MailMessage(from: "test@live.com",
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}
