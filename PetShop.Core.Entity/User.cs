using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PetShop.Core.Entity
{
    class User
    {
        public long id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
