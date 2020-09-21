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
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        // GET: api/<PetShopController>
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            try
            {
                return (_ownerService.GetAllOwners());
            }
            catch (Exception e)
            {
                return StatusCode(500, "Id must be greater than 0");
            }
            
        }

        // GET api/<PetShopController>/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            var owner = _ownerService.FindOwnerById(id);
            if (owner == null)
            {
                return StatusCode(404, "Did not find Customer with ID " + id);
            }

            try
            {
                return _ownerService.FindOwnerById(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, "task failed successfully");
            }
        }

        // POST api/<PetShopController>
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            if (string.IsNullOrEmpty(owner.Name))
            {
                return StatusCode(500, "someting went wrong");
            }
            return _ownerService.CreateOwner(owner);

            
        }

        // PUT api/<PetShopController>/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            var updateowner = _ownerService.CreateOwner(owner);
            if (updateowner == null)
            {
                StatusCode(404, "owner was not found!");
            }

            try
            {
                return updateowner;
            }
            catch (Exception e)
            {
                return StatusCode(500, "do much better plz");
            }
        }

        // DELETE api/<PetShopController>/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            var owner = _ownerService.DeleteOwner(id);
            if (owner == null)
            {
                return StatusCode(404, "Did not find Customer with ID " + id);
            }

            try
            {
                return owner;
            }
            catch (Exception e)
            {
                return StatusCode(500, "something went wrong");
            }
        }
        [HttpGet("{name}")]
        [Route("[action]/{name}")]
        public ActionResult<List<Owner>> GetFilteredName(string name)
        {
            var ownername = _ownerService.GetAllByName(name);

            try
            {
                return ownername;
            }
            catch (Exception e)
            {
                return StatusCode(500, "something went wrong");
            }
        }
    }
}
