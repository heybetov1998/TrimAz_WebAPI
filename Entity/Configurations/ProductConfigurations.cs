using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Configurations;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(n => n.Title)
            .IsRequired(true)
            .HasMaxLength(100);
        builder.Property(n => n.Price)
            .IsRequired(true)
            .HasColumnName("decimal(18,2)");
        builder.Property(n => n.IsDeleted)
            .HasDefaultValue(false);
        builder.Property(n => n.CreatedDate)
            .IsRequired(true)
            .HasDefaultValueSql("GETUTCDATE()");
    }
}
