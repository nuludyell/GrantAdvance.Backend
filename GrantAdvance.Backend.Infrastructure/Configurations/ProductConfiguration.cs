using GrantAdvance.Backend.Domain.Products;
using GrantAdvance.Backend.Domain.Products.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrantAdvance.Backend.Infrastructure.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasConversion(e => e.Value, value => new Id(value));

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .HasConversion(e => e.Value, value => new Name(value));

        builder.Property(e => e.Price)
            .HasPrecision(30, 2)
            .HasConversion(e => e.Value, value => new Price(value));

        builder.Property(e => e.CreationDate)
            .HasDefaultValueSql("GETUTCDATE()")
            .HasConversion(e => e.Value, value => new CreationDate(value));

        builder.HasIndex(e => e.Name).IsUnique();

        builder.HasData(ProductSeed.Seed());
    }
}

internal static class ProductSeed
{
    public static List<Product> Seed()
    {
        return new List<Product>
        {
            Product.Create(new Name("Product 1"), new Price(200)),
            Product.Create(new Name("Product 2"), new Price(300)),
            Product.Create(new Name("Product 3"), new Price(400)),
            Product.Create(new Name("Product 4"), new Price(500)),
            Product.Create(new Name("Product 5"), new Price(600))
        };
    }
}