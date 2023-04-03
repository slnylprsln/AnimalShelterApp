using DomainServices.IServices;
using DomainServices.Services;
using Dtos;
using ErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    public class DogVaccinationController : Controller
    {
        public IDogVaccinationServices _DogVaccinationServices;
        public DogVaccinationController(IDogVaccinationServices DogVaccinationServices)
        {
            this._DogVaccinationServices = DogVaccinationServices;
        }
        [HttpGet("~/DogVaccination")]
        public IActionResult GetAll()
        {
            var DogVaccinations = from DogVaccination in _DogVaccinationServices.ReadAll()
                              select DogVaccination;
            return Ok(DogVaccinations);
        }
        [HttpGet("~/DogVaccination/byId/{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                DogVaccinationDto? byId = _DogVaccinationServices.Read(Id);
                return Ok(byId);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpPost("~/DogVaccination")]
        public IActionResult Create([FromBody] DogVaccinationDto create)
        {
            if (ModelState.IsValid)
            {
                _DogVaccinationServices.Create(create);
                return Ok("DogVaccination is added succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpDelete("~/DogVaccination/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                _DogVaccinationServices.Delete(Id);
                return Ok("DogVaccination is deleted succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
		[HttpPut("~/DogVaccination/{Id}")]
		public IActionResult Update([FromRoute] int Id, [FromBody] DogVaccinationDto theNew)
		{
            if (ModelState.IsValid)
            {
				DogVaccinationDto? theOld = _DogVaccinationServices.Read(Id);
				DogVaccinationDto? result = _DogVaccinationServices.Update(theOld, theNew);
				return Ok(result);
			}
			else
			{
				throw new ValidationException("Unable to save changes. Please try again!");
			}
		}
	}
}
