

using BuberDinner.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BuberDinner.infrastructure.Authentication;

public class JWTokenGenerator: IJWTokenGenerator
{

    public string GenerateToken(Guid userId,string firstName,string lastName)
    {

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("hello my father I miss you so much")),
            SecurityAlgorithms.HmacSha256
            );
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

        };
            var securityToken=new JwtSecurityToken ( 
                issuer:"BuberDinner",
                expires: DateTime.Now.AddDays(1),
                claims :claims,
                signingCredentials: signingCredentials

                );

        return  new JwtSecurityTokenHandler().WriteToken(securityToken);
              
            
    }


}