using DomainServices.IServices;
using Dtos;
using ErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        public IUserServices _UserServices;
        public UserController(IUserServices UserServices)
        {
            this._UserServices = UserServices;
        }
        [HttpGet("~/User")]
        public IActionResult GetAll()
        {
            var Users = from User in _UserServices.ReadAll()
                               select User;
            return Ok(Users);
        }
        [HttpGet("~/User/{username}")]
        public IActionResult GetByUsername([FromRoute] string username)
        {
            if (ModelState.IsValid)
            {
                UserDto? byUsername = _UserServices.ReadByUsername(username);
                return Ok(byUsername);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        
        [HttpGet("~/User/byId/{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                UserDto? byId = _UserServices.Read(Id);
                return Ok(byId);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpPost("~/User")]
        public IActionResult Create([FromBody] UserDto create)
        {
            if (ModelState.IsValid)
            {
                _UserServices.Create(create);
                return Ok("User is added succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpPut("~/User/{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] UserDto theNew)
        {
            if (ModelState.IsValid)
            {
                UserDto? theOld = _UserServices.Read(Id);
                UserDto? result = _UserServices.Update(theOld, theNew);
                return Ok(result);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpDelete("~/User/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                _UserServices.Delete(Id);
                return Ok("User is deleted succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
    }
}
