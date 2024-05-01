namespace UnikProjekt.Domain.Shared;

public abstract record RecordWithValidation
{
    protected RecordWithValidation()
    {
        Validate();
    }

    protected virtual void Validate()
    {
    }
}
