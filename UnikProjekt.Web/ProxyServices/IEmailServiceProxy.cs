namespace UnikProjekt.Web.ProxyServices
{
    public interface IEmailServiceProxy
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
