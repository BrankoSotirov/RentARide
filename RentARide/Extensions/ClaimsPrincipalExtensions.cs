﻿using System.Security.Claims;

namespace RentARide.Extensions
{
    public static class ClaimsPrincipalExtensions
    {

        public static string? Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
