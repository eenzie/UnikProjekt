namespace UnikProjekt.Domain.DomainService;

public interface IUserDomainService
{
    bool UserExistsWithEmail(string email);
}
