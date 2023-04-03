using DomainServices.IServices;
using DomainServices.Services;
using Dtos;
using ErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    public class DonationController : Controller
    {
        public IDonationServices _DonationServices;

        public DonationController(IDonationServices DonationServices)
        {
            this._DonationServices = DonationServices;
        }

        [HttpGet("~/Donation")]
        public IActionResult GetAll()
        {
            var Donations = from Donation in _DonationServices.ReadAll()
                        select Donation;

            return Ok(Donations);
        }

        [HttpGet("~/Donation/byId/{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                DonationDto? byId = _DonationServices.Read(Id);
                return Ok(byId);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }

        [HttpPost("~/Donation")]
        public IActionResult Create([FromBody] DonationDto create)
        {
            if (ModelState.IsValid)
            {
                _DonationServices.Create(create);
                return Ok("Donation is added succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }

        [HttpPut("~/Donation/{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] DonationDto theNew)
        {
            if (ModelState.IsValid)
            {
                DonationDto? theOld = _DonationServices.Read(Id);
                DonationDto? result = _DonationServices.Update(theOld, theNew);
                return Ok(result);
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }

        [HttpDelete("~/Donation/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            if (ModelState.IsValid)
            {
                _DonationServices.Delete(Id);
                return Ok("Donation is deleted succesfully!");
            }
            else
            {
                throw new ValidationException("Unable to save changes. Please try again!");
            }
        }
    }
}
