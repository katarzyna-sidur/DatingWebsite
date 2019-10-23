using System.Threading.Tasks;
using DatingWebsiteBackend.Data;
using DatingWebsiteBackend.Dtos;
using DatingWebsiteBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingWebsiteBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo repository;
        public AuthController(IAuthRepo repository)
        {
            this.repository = repository;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await repository.UserExsist(userForRegisterDto.Username))
                return BadRequest("Użytkownik o takiej nazwie już istnieje");

            var userToCreate = new User
            {
                UserName = userForRegisterDto.Username
            };

            var createdUser = await repository.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }
    }
}