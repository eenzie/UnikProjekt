namespace UnikProjekt.Domain.DomainService;

public interface IAddressDomainService
{
    bool ValidateAddress(string street, string streetNumber, string postCode, string city);
}
