using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Models;

namespace Restaurant.Infra.Data.MapperClass;

public class BaseMap<T> : IEntityTypeConfiguration<T> where T: BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).IsRequired().HasColumnName("Id");
    }
}   