using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService.Services;
using PetShop.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop.UI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypePetController : ControllerBase
    {
        private readonly ITypePetService _typePetService;

        public TypePetController(ITypePetService typePetService)
        {
            _typePetService = typePetService;
        }


        // GET: api/<TypePetControllerr>
        [HttpGet]
        public ActionResult<IEnumerable<TypePet>> Get()
        {
            try
            {
                if (_typePetService.getAllTypePets() != null)
                {
                    return Ok(_typePetService.getAllTypePets());
                }
                return NotFound();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when looking for list of pet types");
            }
        }

        // GET api/<TypePetControllerr>/5
        [HttpGet("{id}")]
        public ActionResult<TypePet> Get(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("Id must be greater than 0");
                }
                else if (_typePetService.getTypeById(id) == null)
                {
                    return NotFound();
                }
                else return _typePetService.getTypeById(id);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when looking for a pet type by ID");
            }
        }

        // POST api/<TypePetControllerr>
        [HttpPost]
        public ActionResult<TypePet> Post([FromBody] TypePet typePet)
        {
            try
            {
                if (string.IsNullOrEmpty(typePet.Type))
                {
                    BadRequest("Type Error! Check Type field.");
                }
                _typePetService.Create(typePet);
                return StatusCode(202, "Yes Sir! Pet Type is created.");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when creating pet type");
            }
        }

        // PUT api/<TypePetControllerr>/5
        [HttpPut("{id}")]
        public ActionResult<TypePet> Put(int id, [FromBody] TypePet typePet)
        {
            try
            {
                if (typePet.Id != id || id < 0)
                {
                    return BadRequest("ID Error! Please check id");
                }
                _typePetService.Update(typePet);
                return StatusCode(200, "Yes Sir! Pet type is updated.");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when updating pet type");
            }
        }

        // DELETE api/<TypePetControllerr>/5
        [HttpDelete("{id}")]
        public ActionResult<TypePet>Delete(int id)
        {
            try
            {
                var typeToDelete = _typePetService.Delete(id);
                if (typeToDelete == null)
                {
                    return NotFound();
                }
                return Accepted(typeToDelete);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when deleting pet type");
            }
        }
    }
}
