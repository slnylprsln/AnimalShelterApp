using DomainServices.IServices;
using Dtos;
using ErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    public class ShelterController : Controller
    {
        public IShelterServices _ShelterServices;
        public ShelterController(IShelterServices ShelterServices)
        {
            this._ShelterServices = ShelterServices;
        }
        [HttpGet("~/Shelter")]
        public IActionResult GetAll()
        {
            var Shelters = from Shelter in _ShelterServices.ReadAll()
                               select Shelter;
            return Ok(Shelters);
        }
        [HttpGet("~/Shelter/byId/{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                ShelterDto? byId = _ShelterServices.Read(Id);
                return Ok(byId);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpPost("~/Shelter")]
        public IActionResult Create([FromBody] ShelterDto create)
        {
            if (ModelState.IsValid)
            {
                _ShelterServices.Create(create);
                return Ok("Shelter is added succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpPut("~/Shelter/{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] ShelterDto theNew)
        {
            if (ModelState.IsValid)
            {
                ShelterDto? theOld = _ShelterServices.Read(Id);
                ShelterDto? result = _ShelterServices.Update(theOld, theNew);
                return Ok(result);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpDelete("~/Shelter/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                _ShelterServices.Delete(Id);
                return Ok("Shelter is deleted succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
    }
}
