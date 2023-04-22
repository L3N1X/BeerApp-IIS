﻿using BeerApp.Dao.Models;
using System.Security.Claims;

namespace BeerApp.Web.Authentication.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
