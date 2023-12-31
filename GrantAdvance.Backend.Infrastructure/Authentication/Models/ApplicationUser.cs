﻿using Microsoft.AspNetCore.Identity;

namespace GrantAdvance.Backend.Infrastructure.Authentication.Models;

public sealed class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}