using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetShop.Core.ApplicationService.Services;
using PetShop.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop.UI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET: api/<OwnerController>
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            try
            {
                if(_ownerService.GetAllOwners() != null)
                {
                    return Ok(_ownerService.GetAllOwners());
                }
                return NotFound();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when looking for list of owners");
            }
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            try
            {
                if (id < 1) {
                    return BadRequest("Id must be greater than 0");
                }
                else if ( _ownerService.GetOwnerByIdIncludePets(id) == null)
                {
                    return NotFound();
                }
                else  return _ownerService.GetOwnerByIdIncludePets(id); 
            }
            catch (System.Exception )
            {
                return StatusCode(500, "Error when looking for a owner by ID");
            }
        }

        // POST api/<OwnerController>
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            try
            {
                if (string.IsNullOrEmpty(owner.FirstName))
                {
                    return BadRequest("First Name Error! Check FirstName field.");
                }
                if (string.IsNullOrEmpty(owner.SecondName))
                {
                    return BadRequest("Second Name Error! Check SecondName field.");
                }
                if (string.IsNullOrEmpty(owner.Address))
                {
                    return BadRequest("Address Error! Check Address field.");
                }
                if (owner.Age <= 0 || owner.Age.Equals(null))
                {
                    return BadRequest("Age Error! Check Age field");
                }
                if (owner.PhoneNumber <= 0 || owner.PhoneNumber.Equals(null))
                {
                    return BadRequest("Phone Number Error! Check PhoneNumber Field");
                }
                _ownerService.Create(owner);
                return StatusCode(201, "Yes Sir! Owner is created.");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when creating owner");
            }
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            try
            {
                if (owner.Id != id || id < 0)
                {
                    return BadRequest("ID Error! Please check id");
                }
                _ownerService.Update(owner);
                return StatusCode(200, "Yes Sir! Owner is updated.");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when updating owner");
            }
        }

        // DELETE api/< OwnerController>/5
        [HttpDelete("{id}")]
        public ActionResult<Owner>Delete(int id)
        {
            try
            {
                var ownerToDelete = _ownerService.Delete(id);
                if(ownerToDelete == null)
                {
                    return NotFound();
                }
                return Accepted(ownerToDelete);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when deleting owner");
            }
        }
    }
}
