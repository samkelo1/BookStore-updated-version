using BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        //This is an internal API that supports the Entity Framework Core infrastructure and not subject to the same compatibility standards as public APIs.
        //It may be changed or removed without notice in any release. You should only use it directly in your code with extreme caution and
        //knowing that doing so can result in application failures when updating to a new Entity Framework Core releas
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            // 1 : N => Category : Books
            builder.HasMany(c => c.Books)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId);

            builder.ToTable("Categories");
        }
    }
}