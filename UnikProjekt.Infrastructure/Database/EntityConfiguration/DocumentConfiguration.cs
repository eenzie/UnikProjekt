using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Infrastructure.Database.EntityConfiguration;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.Property(e => e.RowVersion).IsRowVersion();
    }
}
