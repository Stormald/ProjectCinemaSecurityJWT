using Microsoft.IdentityModel.Tokens;
using ProjectCinemaSecurityBack.Models;
using ProjectCinemaSecurityBack.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectCinemaSecurityBack.Services
{
    public class LoginService
    {
        private LoginRepository repository;

        public LoginService(LoginRepository repo)
        {
            repository = repo;
        }

        public LoginModel AddUser(LoginModel user)
        {
            return this.repository.AddUser(user);
        }

        public void DeleteUser(long id)
        {
            this.repository.DeleteUser(id);
        }

        public LoginModel GetUserById(long id)
        {
            return this.repository.GetUserById(id);
        }

        public IEnumerable<LoginModel> GetUsers()
        {
            return this.repository.GetUsers();
        }

        public LoginModel UpdateUser(LoginModel user)
        {
            return this.repository.UpdateUser(user);
        }

        public AuthResponse Login( LoginModel user)
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

        private bool CheckCredentials(LoginModel user)
        {
            LoginModel login = this.repository.GetUserByNameAndPassword(user.Username, user.Password);
            if(login == null)
            {
                return false;
            }
            return true;
        }
    }
}
