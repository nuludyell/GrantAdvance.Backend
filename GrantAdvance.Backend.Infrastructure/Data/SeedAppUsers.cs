using GrantAdvance.Backend.Infrastructure.Authentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GrantAdvance.Backend.Infrastructure.Data;

internal static class SeedAppUsers
{
    public static void Seed(ModelBuilder builder)
    {
        var adminId = Guid.NewGuid();
        var roleId = Guid.NewGuid();
        var adminEmail = "admin1@gmail.com";
        var adminPassword = "P@ssword123";

        // seed admin role
        builder
            .Entity<IdentityRole>()
            .HasData(new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Id = roleId.ToString(),
                ConcurrencyStamp = roleId.ToString()
            });

        // create app user
        var appUser = new ApplicationUser
        {
            Id = adminId.ToString(),
            Email = adminEmail,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            LockoutEnabled = false,
            FirstName = "Ariel",
            LastName = "Nulud",
            UserName = adminEmail,
            NormalizedEmail = adminEmail.Normalize().ToUpperInvariant(),
            NormalizedUserName = adminEmail.Normalize().ToUpperInvariant(),
        };

        // set user password
        PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
        appUser.PasswordHash = ph.HashPassword(appUser, adminPassword);

        // seed user
        builder
            .Entity<ApplicationUser>()
            .HasData(appUser);

        // set user role to admin
        builder
            .Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = roleId.ToString(),
                UserId = adminId.ToString()
            });
    }
}
