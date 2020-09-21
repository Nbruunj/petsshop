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
    public class PetShopController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetShopController(IPetService petService)
        {
            _petService = petService;
        }

        /// <summary>
        /// Returns list of all pets as JSON
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            try
            {
                return _petService.GetPets();
            }

            catch (Exception e)
            {
                return StatusCode(500, "do much better plz");
            }
        }

        /// <summary>
        /// Returns pet with the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            var foundpet = _petService.FindPetById(id);
            if (foundpet == null)
            {
                return StatusCode(404, "pet was not found!");
            }

            try
            {
                return foundpet;
            }
            catch (Exception e)
            {
                return StatusCode(500, "do much better plz");
            }
        }

        /// <summary>
        /// Returns the Pet that was created
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                return StatusCode(500, "someting went wrong");
            }

            return _petService.CreatePet(pet);
        }


        /// <summary>
        /// Returns the Pet that was updated
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pet"></param>
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            var updatePet = _petService.UpdatePet(pet);
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

        /// <summary>
        /// Returns the pet deleted
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            var pet = _petService.DeletePet(id);
            if (pet == null)
            {
                return StatusCode(404, "Did not find Customer with ID " + id);
            }

            try
            {
                return pet;
            }
            catch (Exception e)
            {
                return StatusCode(500, "something went wrong");
            }

        }

        [HttpGet("{type}")]
        [Route("[action]/{type}")]
        public ActionResult<List<Pet>> Getfiltered(string type)
        {
            var pettype = _petService.GetAllByType(type);
            try
            {
                return pettype;
            }
            catch (Exception e)
            {
                return StatusCode(500, "something went wrong");
            }
        }


    }
    
}
