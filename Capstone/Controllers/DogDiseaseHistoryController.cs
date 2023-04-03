using DomainServices.IServices;
using Dtos;
using ErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    public class DogDiseaseHistoryController : Controller
    {
        public IDogDiseaseHistoryServices _DogDiseaseHistoryServices;
        public DogDiseaseHistoryController(IDogDiseaseHistoryServices DogDiseaseHistoryServices)
        {
            this._DogDiseaseHistoryServices = DogDiseaseHistoryServices;
        }
        [HttpGet("~/DogDiseaseHistory")]
        public IActionResult GetAll()
        {
            var DogDiseaseHistorys = from DogDiseaseHistory in _DogDiseaseHistoryServices.ReadAll()
                       select DogDiseaseHistory;
            return Ok(DogDiseaseHistorys);
        }
        [HttpGet("~/DogDiseaseHistory/byId/{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                DogDiseaseHistoryDto? byId = _DogDiseaseHistoryServices.Read(Id);
                return Ok(byId);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpPost("~/DogDiseaseHistory")]
        public IActionResult Create([FromBody] DogDiseaseHistoryDto create)
        {
            if (ModelState.IsValid)
            {
                _DogDiseaseHistoryServices.Create(create);
                return Ok("DogDiseaseHistory is added succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpPut("~/DogDiseaseHistory/{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] DogDiseaseHistoryDto theNew)
        {
            if (ModelState.IsValid)
            {
                DogDiseaseHistoryDto? theOld = _DogDiseaseHistoryServices.Read(Id);
                DogDiseaseHistoryDto? result = _DogDiseaseHistoryServices.Update(theOld, theNew);
                return Ok(result);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpDelete("~/DogDiseaseHistory/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                _DogDiseaseHistoryServices.Delete(Id);
                return Ok("DogDiseaseHistory is deleted succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
    }
}
