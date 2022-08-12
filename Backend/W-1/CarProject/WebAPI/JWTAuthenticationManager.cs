using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace WebApi
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {

        private readonly string _key;
        public JWTAuthenticationManager(string key)
        {
            _key = key;
        }
        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {
            {"us1","ps1" },{"us2","ps2"}
        };
        public string Authenticat(string userName, string Password)
        {
            if (!users.Any(x => x.Key == userName && x.Value == Password))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim("Title", "IBO THE")
                }),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
