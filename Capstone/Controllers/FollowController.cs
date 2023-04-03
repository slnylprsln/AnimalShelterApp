using DomainServices.IServices;
using Dtos;
using ErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    public class FollowController : Controller
    {
        public IFollowServices _FollowServices;

        public FollowController(IFollowServices FollowServices)
        {
            _FollowServices = FollowServices;
        }

        [HttpGet("~/Follow")]
        public IActionResult GetAll()
        {
            var Follows = from Follow in _FollowServices.ReadAll()
                            select Follow;

            return Ok(Follows);
        }

        [HttpGet("~/Follow/byId/{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                FollowDto? byId = _FollowServices.Read(Id);
                return Ok(byId);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }

        [HttpGet("~/Follow/byUserId/{Id}")]
        public IActionResult GetByUserId([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<FollowDto>? byId = _FollowServices.ReadByUserId(Id);
                return Ok(byId);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }

        [HttpGet("~/Follow/byUserId/Cat/{Id}")]
        public IActionResult GetCatsByUserId([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<FollowDto>? byId = _FollowServices.ReadCatsByUserId(Id);
                return Ok(byId);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }

        [HttpGet("~/Follow/byUserId/Dog/{Id}")]
        public IActionResult GetDogsByUserId([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<FollowDto>? byId = _FollowServices.ReadDogsByUserId(Id);
                return Ok(byId);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }

        [HttpPost("~/Follow")]
        public IActionResult Create([FromBody] FollowDto create)
        {
            if (ModelState.IsValid)
            {
                _FollowServices.Create(create);
                return Ok("Follow is added succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }

        [HttpDelete("~/Follow/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                _FollowServices.Delete(Id);
                return Ok("Follow is deleted succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
    }
}
