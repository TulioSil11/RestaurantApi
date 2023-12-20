using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Models;

namespace Restaurant.Infra.Data.MapperClass
{
    public class DishMap: BaseMap<Dish>
    {
        public override void Configure(EntityTypeBuilder<Dish> builder)
        {
            base.Configure(builder);
            builder.ToTable("dish");
            builder.Property(c => c.Name).IsRequired().HasColumnName("Name").HasMaxLength(100);
            builder.Property(c => c.Price).IsRequired().HasColumnName("Price");
        }
    }
}