using ProjectCinemaSecurityBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectCinemaSecurityBack.Services
{
    public class TokenConfigurationService
    {

        private LoginService loginService;

        public TokenConfigurationService(LoginService login)
        {
            loginService = login;
        }

        public AuthResponse Login([FromBody] LoginModel user)
        {
            AuthResponse authResponse = new AuthResponse();

            if (CheckCredentials(user))
            {

                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username)
                };

                if (user.Username == "admin")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                }
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ma clé super secrète"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7153",
                    audience: "https://localhost:7153",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return new AuthResponse { Token = tokenString };
            }
            return authResponse;
        }

        private static bool CheckCredentials(LoginModel user)
        {
            return user.Username == "admin" && user.Password == "admin";
        }
    }
}
