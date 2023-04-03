using DomainServices.IServices;
using DomainServices.Services;
using Dtos;
using ErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly IUserServices _UserServices;

        public LoginController(IUserServices UserServices)
        {
            this._UserServices = UserServices;
        }

        [HttpGet("~/UserLogin/{username}/{password}")]
        public IActionResult UserLogin([FromRoute] string username, [FromRoute] string password)
        {
            UserDto? existence = _UserServices.ReadByUsername(username);
			if (existence == null)
			{
				throw new NotFoundException("This user doesn't exist!");
			}
            else
            {
				var result = SecurePasswordHasher.Verify(password, existence.Password);
				if (result == true)
				{
					return Ok(existence);
				}
				else
				{
					throw new BadRequestException("Wrong password!");
				}
			}
        }
    }
}
