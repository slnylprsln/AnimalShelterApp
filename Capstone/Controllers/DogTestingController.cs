using DomainServices.IServices;
using DomainServices.Services;
using Dtos;
using ErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    public class DogTestingController : Controller
    {
        public IDogTestingServices _DogTestingServices;
        public DogTestingController(IDogTestingServices DogTestingServices)
        {
            this._DogTestingServices = DogTestingServices;
        }
        [HttpGet("~/DogTesting")]
        public IActionResult GetAll()
        {
            var DogTestings = from DogTesting in _DogTestingServices.ReadAll()
                               select DogTesting;
            return Ok(DogTestings);
        }
        [HttpGet("~/DogTesting/byId/{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                DogTestingDto? byId = _DogTestingServices.Read(Id);
                return Ok(byId);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpPost("~/DogTesting")]
        public IActionResult Create([FromBody] DogTestingDto create)
        {
            if (ModelState.IsValid)
            {
                _DogTestingServices.Create(create);
                return Ok("DogTesting is added succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpDelete("~/DogTesting/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                _DogTestingServices.Delete(Id);
                return Ok("DogTesting is deleted succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
		[HttpPut("~/DogTesting/{Id}")]
		public IActionResult Update([FromRoute] int Id, [FromBody] DogTestingDto theNew)
		{
            if (ModelState.IsValid)
            {
				DogTestingDto? theOld = _DogTestingServices.Read(Id);
				DogTestingDto? result = _DogTestingServices.Update(theOld, theNew);
				return Ok(result);
			}
			else
			{
				throw new ValidationException("Unable to save changes. Please try again!");
			}
		}
	}
}
