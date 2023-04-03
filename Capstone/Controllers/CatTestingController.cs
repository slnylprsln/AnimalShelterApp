using DomainServices.IServices;
using DomainServices.Services;
using Dtos;
using ErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    public class CatTestingController : Controller
    {
        public ICatTestingServices _CatTestingServices;
        public CatTestingController(ICatTestingServices CatTestingServices)
        {
            this._CatTestingServices = CatTestingServices;
        }
        [HttpGet("~/CatTesting")]
        public IActionResult GetAll()
        {
            var CatTestings = from CatTesting in _CatTestingServices.ReadAll()
                               select CatTesting;
            return Ok(CatTestings);
        }
        [HttpGet("~/CatTesting/byId/{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                CatTestingDto? byId = _CatTestingServices.Read(Id);
                return Ok(byId);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpPost("~/CatTesting")]
        public IActionResult Create([FromBody] CatTestingDto create)
        {
            if (ModelState.IsValid)
            {
                _CatTestingServices.Create(create);
                return Ok("CatTesting is added succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpDelete("~/CatTesting/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                _CatTestingServices.Delete(Id);
                return Ok("CatTesting is deleted succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
		[HttpPut("~/CatTesting/{Id}")]
		public IActionResult Update([FromRoute] int Id, [FromBody] CatTestingDto theNew)
		{
            if (ModelState.IsValid)
            {
				CatTestingDto? theOld = _CatTestingServices.Read(Id);
				CatTestingDto? result = _CatTestingServices.Update(theOld, theNew);
				return Ok(result);
			}
			else
			{
				throw new ValidationException("Unable to save changes. Please try again!");
			}
		}
	}
}
