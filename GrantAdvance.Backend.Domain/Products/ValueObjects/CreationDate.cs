namespace GrantAdvance.Backend.Domain.Products.ValueObjects;

public record CreationDate(DateTime Value)
{
    public static CreationDate New() => new(DateTime.UtcNow);
}