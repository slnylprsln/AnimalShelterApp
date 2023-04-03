using DomainServices.IServices;
using Dtos;
using ErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    public class CatController : Controller
    {
        public ICatServices _CatServices;
		public CatController(ICatServices CatServices)
        {
            this._CatServices = CatServices;
        }
        [HttpGet("~/Cat")]
        public IActionResult GetAll()
        {
            var Cats = from Cat in _CatServices.ReadAll()
                               select Cat;
            return Ok(Cats);
        }
        [HttpGet("~/Cat/byId/{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                CatDto? byId = _CatServices.Read(Id);
                return Ok(byId);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpPost("~/Cat")]
        public IActionResult Create([FromBody] CatDto create)
        {
            if (ModelState.IsValid)
            {
                _CatServices.Create(create);
                return Ok("Cat is added succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpPut("~/Cat/{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] CatDto theNew)
        {
            if (ModelState.IsValid)
            {
                CatDto? theOld = _CatServices.Read(Id);
                CatDto? result = _CatServices.Update(theOld, theNew);
                return Ok(result);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpDelete("~/Cat/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                _CatServices.Delete(Id);
                return Ok("Cat is deleted succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpGet("~/Cat/Vaccination/{Id}")]
        public IActionResult GetVaccinations([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
				var list = _CatServices.GetVaccinations(Id);
                return Ok(list);
			}
            else
            {
				throw new ValidationException("Unable to save changes. Please try again!");
			}
        }
		[HttpGet("~/Cat/Testing/{Id}")]
		public IActionResult GetTestings([FromRoute] int Id)
		{
			if (ModelState.IsValid)
			{
				var list = _CatServices.GetTestings(Id);
				return Ok(list);
			}
			else
			{
				throw new ValidationException("Unable to save changes. Please try again!");
			}
		}
		[HttpGet("~/Cat/DiseaseHistory/{Id}")]
		public IActionResult GetDiseaseHistory([FromRoute] int Id)
		{
			if (ModelState.IsValid)
			{
				var list = _CatServices.GetDiseaseHistory(Id);
				return Ok(list);
			}
			else
			{
				throw new ValidationException("Unable to save changes. Please try again!");
			}
		}
	}
}
