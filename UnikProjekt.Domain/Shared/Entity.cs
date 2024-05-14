using System.ComponentModel.DataAnnotations;

namespace UnikProjekt.Domain.Shared;

public abstract class Entity
{
    public Guid Id { get; init; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
}
