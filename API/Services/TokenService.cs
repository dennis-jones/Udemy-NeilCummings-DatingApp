using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using API.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
  public class TokenService : ITokenService
  {
    private readonly SymmetricSecurityKey _key;
    public TokenService(IConfiguration config)
    {
      _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
    }
    public string CreateToken(AppUser user)
    {
      var claims = new List<Claim> {
          new Claim(JwtRegisteredClaimNames.NameId, user.UserName),
        //   new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
        //   new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
          new Claim(JwtRegisteredClaimNames.Email, user.UserName + "@here.com")
      };

      var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(7),
        SigningCredentials = creds
      };

      var tokenHandler = new JwtSecurityTokenHandler();

      //   var token = tokenHandler.CreateToken(tokenDescriptor);
      var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(7),
        SigningCredentials = creds
      });

      return tokenHandler.WriteToken(token);

      //    var tokenHandler = new JwtSecurityTokenHandler();
      //   return tokenHandler.WriteToken(tokenHandler.CreateToken(new SecurityTokenDescriptor
      //   {
      //     Subject = new ClaimsIdentity(new List<Claim>
      //     {
      //       new Claim(JwtRegisteredClaimNames.NameId, user.UserName),
      //       new Claim(JwtRegisteredClaimNames.Website, "bob*@here.com")
      //     }),
      //     Expires = DateTime.Now.AddDays(7),
      //     SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature)
      //   }));
    }
  }
}