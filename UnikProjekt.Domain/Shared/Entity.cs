namespace UnikProjekt.Domain.Shared;

public abstract class Entity(Guid id)
{
    public Guid Id { get; init; } = id;

    //[Timestamp]  //Note: Annotation ændret til Fluent API i EF config
    public byte[] RowVersion { get; set; }

}
