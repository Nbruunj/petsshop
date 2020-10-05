using System;
using System.Collections.Generic;
using System.Text;

namespace petshop.infrastructure.SQL.data
{
    public interface IDbInitializer
    {
        void Initialize(TodoContext context);
    }
}
