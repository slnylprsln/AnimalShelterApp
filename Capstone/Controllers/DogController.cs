using DomainServices.IServices;
using Dtos;
using ErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    public class DogController : Controller
    {
        public IDogServices _DogServices;
        public DogController(IDogServices DogServices)
        {
            this._DogServices = DogServices;
        }
        [HttpGet("~/Dog")]
        public IActionResult GetAll()
        {
            IEnumerable<DogDto>? Dogs = null;

			Dogs = from Dog in _DogServices.ReadAll()
									   select Dog;

            return Ok(Dogs);
        }
        [HttpGet("~/Dog/byId/{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                DogDto? byId = _DogServices.Read(Id);
                return Ok(byId);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpPost("~/Dog")]
        public IActionResult Create([FromBody] DogDto create)
        {
            if (ModelState.IsValid)
            {
                _DogServices.Create(create);
                return Ok("Dog is added succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpPut("~/Dog/{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] DogDto theNew)
        {
            if (ModelState.IsValid)
            {
                DogDto? theOld = _DogServices.Read(Id);
                DogDto? result = _DogServices.Update(theOld, theNew);
                return Ok(result);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpDelete("~/Dog/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                _DogServices.Delete(Id);
                return Ok("Dog is deleted succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
		[HttpGet("~/Dog/Vaccination/{Id}")]
		public IActionResult GetVaccinations([FromRoute] int Id)
		{
			if (ModelState.IsValid)
			{
				var list = _DogServices.GetVaccinations(Id);
				return Ok(list);
			}
			else
			{
				throw new ValidationException("Unable to save changes. Please try again!");
			}
		}
		[HttpGet("~/Dog/Testing/{Id}")]
		public IActionResult GetTestings([FromRoute] int Id)
		{
			if (ModelState.IsValid)
			{
				var list = _DogServices.GetTestings(Id);
				return Ok(list);
			}
			else
			{
				throw new ValidationException("Unable to save changes. Please try again!");
			}
		}
		[HttpGet("~/Dog/DiseaseHistory/{Id}")]
		public IActionResult GetDiseaseHistory([FromRoute] int Id)
		{
			if (ModelState.IsValid)
			{
				var list = _DogServices.GetDiseaseHistory(Id);
				return Ok(list);
			}
			else
			{
				throw new ValidationException("Unable to save changes. Please try again!");
			}
		}
	}
}
