using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Entity;
using petshop.infrastructure.SQL.data;
using petshop.infrastructure.SQL.data.help;

namespace PetShop.RestAPI.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : Controller
    {
        private IRepository<User> repository;
        private IAuthenticationHelper authenticationHelper;

        public TokenController(IRepository<User> repos, IAuthenticationHelper authHelper)
        {
            repository = repos;
            authenticationHelper = authHelper;
        }


        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel model)
        {
            var user = repository.GetAll().FirstOrDefault(u => u.Username == model.Username);

            // check if username exists
            if (user == null)
                return Unauthorized();

            // check if password is correct
            if (!authenticationHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.Username,
                token = authenticationHelper.GenerateToken(user)
            });
        }

    }
}