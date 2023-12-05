﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ParkCinema.Application.Abstraction.Services;
using ParkCinema.Application.DTOs.Auth;
using ParkCinema.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ParkCinema.Infrastructure.Services.TokenResponseJwt;

public class TokkenHandler : ITokenHandler
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;

    public TokkenHandler(UserManager<AppUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<TokenResponseDTO> CreateAccessToken(int minutes, int refreshTokenMinutes, AppUser appUser)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, appUser.Id),
            new Claim(ClaimTypes.Email, appUser.Email),
            new Claim(ClaimTypes.Name,appUser.UserName)
        };

        var roles = await _userManager.GetRolesAsync(appUser);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
        SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        DateTime ExpireDate = DateTime.UtcNow.AddMinutes(minutes);
        JwtSecurityToken jwt = new(
            issuer: _configuration["JwtSettings:Issues"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: ExpireDate,
            signingCredentials: credentials
            );

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);
        var refleshToken = GenerateRefreshToken();

        return new TokenResponseDTO(token, ExpireDate, DateTime.UtcNow.AddMinutes(refreshTokenMinutes),
            refleshToken, appUser.UserName, appUser.Email, appUser.Id, appUser.ImagePath);
    }

    private string GenerateRefreshToken()
    {
        byte[] bytes = new byte[64];
        var randomNumber = RandomNumberGenerator.Create();
        randomNumber.GetBytes(bytes);
        return Convert.ToBase64String(bytes);
    }
}
