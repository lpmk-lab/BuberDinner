

using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Domain.Entities;
using BuberDinner.Infrastructure.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BuberDinner.infrastructure.Authentication;

public class JWTokenGenerator: IJWTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSetting _jwtSetting;

    public JWTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSetting> JwtOptions)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSetting = JwtOptions.Value;
    }

    public string GenerateToken(User user)
    {

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSetting.Secret)),
            SecurityAlgorithms.HmacSha256
            );
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

        };
            var securityToken=new JwtSecurityToken ( 
                issuer: _jwtSetting.Issuer,
                audience: _jwtSetting.Audience,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSetting.ExpirationMinutes),
                claims :claims,
                signingCredentials: signingCredentials

                );

        return  new JwtSecurityTokenHandler().WriteToken(securityToken);
              
            
    }


}