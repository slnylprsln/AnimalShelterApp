using DomainServices.IServices;
using Dtos;
using ErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    public class CatDiseaseHistoryController : Controller
    {
        public ICatDiseaseHistoryServices _CatDiseaseHistoryServices;
        public CatDiseaseHistoryController(ICatDiseaseHistoryServices CatDiseaseHistoryServices)
        {
            this._CatDiseaseHistoryServices = CatDiseaseHistoryServices;
        }
        [HttpGet("~/CatDiseaseHistory")]
        public IActionResult GetAll()
        {
            var CatDiseaseHistorys = from CatDiseaseHistory in _CatDiseaseHistoryServices.ReadAll()
                               select CatDiseaseHistory;
            return Ok(CatDiseaseHistorys);
        }
        [HttpGet("~/CatDiseaseHistory/byId/{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                CatDiseaseHistoryDto? byId = _CatDiseaseHistoryServices.Read(Id);
                return Ok(byId);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpPost("~/CatDiseaseHistory")]
        public IActionResult Create([FromBody] CatDiseaseHistoryDto create)
        {
            if (ModelState.IsValid)
            {
                _CatDiseaseHistoryServices.Create(create);
                return Ok("CatDiseaseHistory is added succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpPut("~/CatDiseaseHistory/{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] CatDiseaseHistoryDto theNew)
        {
            if (ModelState.IsValid)
            {
                CatDiseaseHistoryDto? theOld = _CatDiseaseHistoryServices.Read(Id);
                CatDiseaseHistoryDto? result = _CatDiseaseHistoryServices.Update(theOld, theNew);
                return Ok(result);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
        [HttpDelete("~/CatDiseaseHistory/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                _CatDiseaseHistoryServices.Delete(Id);
                return Ok("CatDiseaseHistory is deleted succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
    }
}
