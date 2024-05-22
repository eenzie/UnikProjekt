namespace UnikProjekt.Domain.Shared;

public abstract class Entity
{
    public Guid Id { get; init; }

    //[Timestamp]  //Note: Annotation ændret til Fluent API i EF config
    public byte[] RowVersion { get; set; }

}
