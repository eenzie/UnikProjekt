using UnikProjekt.Domain.Value;

namespace UnikProjekt.Domain.DomainService;

public interface IUserDomainService
{
    bool UserExistsWithEmail(EmailAddress email);
}
