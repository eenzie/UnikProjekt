using System.ComponentModel.DataAnnotations;

namespace UnikProjekt.Domain.Shared;

public abstract class Entity(Guid id)
{
    public Guid Id { get; init; } = id;

    [Timestamp]
    public byte[] RowVersion { get; private set; } = [];
}
