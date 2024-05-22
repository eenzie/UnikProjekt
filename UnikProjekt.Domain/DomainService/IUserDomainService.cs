using UnikProjekt.Domain.Value;

namespace UnikProjekt.Domain.DomainService;

public interface IUserDomainService
{
    //TODO: INA: Implement email checking feature
    bool UserExistsWithEmail(EmailAddress email);
}
