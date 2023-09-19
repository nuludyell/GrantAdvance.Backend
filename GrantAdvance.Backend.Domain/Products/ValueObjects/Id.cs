namespace GrantAdvance.Backend.Domain.Products.ValueObjects;

public record Id(Guid Value)
{
    public static Id New() => new(Guid.NewGuid());
}