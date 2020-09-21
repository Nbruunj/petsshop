using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationServices;
using PetShop.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetTypeController : ControllerBase
    {
        private readonly IPetTypeService _petTypeService;
        public PetTypeController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }
        // GET: api/<PetTypeController>
        [HttpGet]
        public ActionResult<IEnumerable<PetType>> Get()
        {
            try
            {
                return Ok(_petTypeService.GetPetTypes());
            }
            catch (Exception e)
            {
                return StatusCode(500, "Id must be greater than 0");
            }
            
        }

        // GET api/<PetTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<PetType> Get(int id)
        {
            var petType = _petTypeService.FindPetTypeById(id);
            if (petType == null)
            {
                return StatusCode(404, "Did not find Customer with ID " + id);
            }

            try
            {
                return _petTypeService.FindPetTypeById(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, "task failed successfully");
            }
                          
        }

        // POST api/<PetTypeController>
        [HttpPost]
        public ActionResult<PetType> Post([FromBody] PetType petType)
        {
            if (string.IsNullOrEmpty(petType.Type))
            {
                return StatusCode(500, "someting went wrong");
            }
            return _petTypeService.CreatePetType(petType);
        }

        // PUT api/<PetTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<PetType> Put(int id, [FromBody] PetType petType)
        {
             var updatePet = _petTypeService.UpdatePetType(petType);
             if (updatePet == null)
             {
                 StatusCode(404, "pet was not found!");
             }

             try
             {
                 return updatePet;
             }
             catch (Exception e)
             {
                 return StatusCode(500, "do much better plz");
             }
        }

        // DELETE api/<PetTypeController>/5
        [HttpDelete("{id}")]
        public ActionResult<PetType> Delete(int id)
        {
            var deletePetType = _petTypeService.DeletePetType(id);
            if (deletePetType == null)
            {
                return StatusCode(404, "Did not find Customer with ID " + id);
            }

            try
            {
                return deletePetType;
            }
            catch (Exception e)
            {
                return StatusCode(500, "something went wrong");
            }
        }
        [HttpGet("{type}")]
        [Route("[action]/{type}")]
        public ActionResult<List<PetType>> GetFilteredName(string type)
        {
            var pettypename = _petTypeService.GetAllByName(type);
            try
            {
                return pettypename;
            }
            catch (Exception e)
            {
                return StatusCode(500, "something went wrong");
            }
            
        }
    }
}
