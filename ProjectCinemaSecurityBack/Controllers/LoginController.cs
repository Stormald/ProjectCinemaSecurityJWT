using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCinemaSecurityBack.Models;
using ProjectCinemaSecurityBack.Services;

namespace ProjectCinemaSecurityBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly LoginService service;

        public LoginController(LoginService Service)
        {
            service = Service;
        }

        [HttpPost]
        public LoginModel AddUser(LoginModel user)
        {
            return this.service.AddUser(user);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            AuthResponse reponse = this.service.Login(user);
            if(reponse == null)
            {
                return BadRequest("Invalid request");
            }
            if(reponse != null)
            {
                
                return Ok(reponse);
            }
            return Unauthorized();
        }


        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public IActionResult DeleteUser(long id)
        {
            try
            {
                this.service.DeleteUser(id);
                return Ok("The user got deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public LoginModel GetUserById(long id)
        {
            return this.service.GetUserById(id);
        }

        [HttpGet]
        public IEnumerable<LoginModel> GetUsers()
        {
            return this.service.GetUsers();
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public LoginModel UpdateUser(LoginModel user)
        {
            return this.service.UpdateUser(user);
        }
    }
}
