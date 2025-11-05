using GameManagement.Data;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace GameManagement.Components.Account
{
    public class TokenProvider(IConfiguration configuration)
    {
        public string Create(GameManagementUser user) 
        {
            string secretKey = configuration["JwtConfig:Secret"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor 
            {
                Subject = new ClaimsIdentity(
                    [
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email.ToString()),
                        new Claim("email_verified", user.EmailConfirmed.ToString())
                    ]),
                Expires = DateTime.UtcNow.AddMinutes(configuration.GetValue<int>("JwtConfig:ExpirationInMinutes")),
                SigningCredentials = credentials,
                Issuer = configuration["JwtConfig:Issuer"],
                Audience = configuration["JwtConfig:Audience"]
            };

            var handler = new JsonWebTokenHandler();

            string token = handler.CreateToken(tokenDescriptor);

            return token;
        }
    }
}
