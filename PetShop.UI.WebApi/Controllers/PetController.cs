using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService.Services;
using PetShop.Core.Entity;
using PetShop.Core.Filter;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop.UI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }
        ////GET: api/<PetController>
        //[HttpGet]
        //public ActionResult<FilteredList<Pet>> Get([FromQuery] Filter filter)
        //{
        //    try
        //    {
        //        if (_petService.ReadPetsFilter(filter) != null)
        //            return Ok(_petService.ReadPetsFilter(filter));
        //        else
        //            return BadRequest("SearchValue not defined. Default SearchField = Name \n" +
        //                "Example: \"/api/pet?SearchField=Type&SearchValue=Cat\"");
        //    }
        //    catch (System.Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}

        //GET: api/<PetController>
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get([FromQuery] PageFilter pageFilter)
        {
            try
            {   
                if (pageFilter.CurrentPage < 0 || pageFilter.ItemsPerPage < 0)
                {
                    throw new InvalidDataException("CurrentPage and ItemsPerPage have to be higher than 0");
                }
                if ((pageFilter.CurrentPage - 1 * pageFilter.ItemsPerPage) >= _petService.Count())
                {
                    throw new InvalidDataException("Index out of bounds");
                }
                if (_petService.GetFilteredPets(pageFilter) != null)
                {
                    return Ok(_petService.GetFilteredPets(pageFilter));
                }
                //if (_petService.GetAllPets() != null)
                //{
                //    return Ok(_petService.GetAllPets());
                //}
                return NotFound();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when looking for list of pets");
            }
        }

        // GET api/<PetController>/5
        //[Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ActionResult<Pet>Get(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("Id must be greater than 0");
                }
                else if (_petService.ReadPetById(id) == null)
                {
                    return NotFound();
                }
                else return _petService.ReadPetById(id);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when looking for a pet by ID");
            }
        }

        // POST api/<PetController>
        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {   
                _petService.Create(pet);
                return StatusCode(201, $"Yes Sir! Pet {pet.Name} created");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when creating pet");
            }
        }

        // PUT api/<PetController>/5
        //[Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            try
            {
                if (pet.Id != id || id < 0)
                {
                    return BadRequest("ID Error! Please check id");
                }
                if (string.IsNullOrEmpty(pet.Name))
                {
                    throw new InvalidDataException("Error in Name Field. Check Name Field");
                }
                if (string.IsNullOrEmpty(pet.Color))
                {
                    throw new InvalidDataException("Error in Color Field. Check Color Field");
                }
                if (pet.Price <= 0 || pet.Price.Equals(null))
                {
                    throw new InvalidDataException("Error in Price Field. Check Price Field");
                }
                _petService.Update(pet);
                return StatusCode(200, "Yes Sir! Pet is updated.");
            }
            catch (System.Exception e)
            {
                return StatusCode(500, "Error when updating pet");
            }
        }

        // DELETE api/<PetController>/5
        //[Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Pet>Delete(int id)
        {
            try
            {
                var petToDelete = _petService.Delete(id);
                if (petToDelete == null)
                {
                    return NotFound();
                }
                return Accepted(petToDelete);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when deleting pet");
            }
        }
    }
}
