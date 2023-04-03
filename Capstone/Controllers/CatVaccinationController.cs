using DomainServices.IServices;
using DomainServices.Services;
using Dtos;
using ErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    public class CatVaccinationController : Controller
    {
        public ICatVaccinationServices _CatVaccinationServices;
        public CatVaccinationController(ICatVaccinationServices CatVaccinationServices)
        {
            this._CatVaccinationServices = CatVaccinationServices;
        }
        [HttpGet("~/CatVaccination")]
        public IActionResult GetAll()
        {
            var CatVaccinations = from CatVaccination in _CatVaccinationServices.ReadAll()
                              select CatVaccination;
            return Ok(CatVaccinations);
        }
        [HttpGet("~/CatVaccination/byId/{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                CatVaccinationDto? byId = _CatVaccinationServices.Read(Id);
                return Ok(byId);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpPost("~/CatVaccination")]
        public IActionResult Create([FromBody] CatVaccinationDto create)
        {
            if (ModelState.IsValid)
            {
                _CatVaccinationServices.Create(create);
                return Ok("CatVaccination is added succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpDelete("~/CatVaccination/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                _CatVaccinationServices.Delete(Id);
                return Ok("CatVaccination is deleted succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
		[HttpPut("~/CatVaccination/{Id}")]
		public IActionResult Update([FromRoute] int Id, [FromBody] CatVaccinationDto theNew)
		{
            if (ModelState.IsValid)
            {
				CatVaccinationDto? theOld = _CatVaccinationServices.Read(Id);
				CatVaccinationDto? result = _CatVaccinationServices.Update(theOld, theNew);
				return Ok(result);
			}
			else
			{
				throw new ValidationException("Unable to save changes. Please try again!");
			}
		}
	}
}
