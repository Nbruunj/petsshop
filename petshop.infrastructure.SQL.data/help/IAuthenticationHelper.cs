using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace petshop.infrastructure.SQL.data.help
{
    public interface IAuthenticationHelper
    {
        string GenerateToken(User user);
    }
}
