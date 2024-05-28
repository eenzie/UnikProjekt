using UnikProjekt.Domain.Value;

namespace UnikProjekt.Domain.DomainService;

public interface IAddressDomainService
{
    bool ValidateAddress(Address address);
}
