using GrantAdvance.Backend.Domain.Abstractions;
using GrantAdvance.Backend.Domain.Products.ValueObjects;

namespace GrantAdvance.Backend.Domain.Products;

public sealed class Product : Entity<Id>
{
    private Product()
    {
    }

    private Product(Id id,
        Name name,
        Price price,
        CreationDate creationDate)
        : base(id)
    {
        Name = name;
        Price = price;
        CreationDate = creationDate;
    }

    public Name Name { get; private set; }
    public Price Price { get; private set; }
    public CreationDate CreationDate { get; private set; }

    public static Product Create(
        Name name,
        Price price)
    {
        var product = new Product(
            Id.New(),
            name,
            price,
            CreationDate.New());

        return product;
    }
}