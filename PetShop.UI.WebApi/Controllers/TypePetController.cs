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
            return _typePetService.getAllTypePets();
        }

        // GET api/<TypePetControllerr>/5
        [HttpGet("{id}")]
        public ActionResult<TypePet> Get(int id)
        {
            return _typePetService.getTypeById(id);
        }

        // POST api/<TypePetControllerr>
        [HttpPost]
        public ActionResult<TypePet> Post([FromBody] TypePet typePet)
        {
            if (string.IsNullOrEmpty(typePet.Type))
            {
                BadRequest("Type Error! Check Type field.");
            }
            _typePetService.Create(typePet);
            return StatusCode(500, "Yes Sir! Pet Type is created.");
        }

        // PUT api/<TypePetControllerr>/5
        [HttpPut("{id}")]
        public ActionResult<TypePet> Put(int id, [FromBody] TypePet typePet)
        {
            if(id<0 || typePet.Id != id)
            {
                return BadRequest("ID Error! Please check id");
            }
            _typePetService.Update(typePet);
            return StatusCode(500, "Yes Sir! Pet Type is updated.");
        }

        // DELETE api/<TypePetControllerr>/5
        [HttpDelete("{id}")]
        public ActionResult<TypePet>Delete(int id)
        {
            return _typePetService.Delete(id);
        }
    }
}
