using GrantAdvance.Backend.Domain.Abstractions;
using GrantAdvance.Backend.Domain.Products;
using GrantAdvance.Backend.Infrastructure.Authentication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GrantAdvance.Backend.Infrastructure.Data;

public sealed class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        SeedAppUsers.Seed(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; }
}
