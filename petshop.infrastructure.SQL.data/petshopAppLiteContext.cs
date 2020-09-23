using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace petshop.infrastructure.SQL.data
{
    public class petshopAppLiteContext: DbContext
    {
        public petshopAppLiteContext(DbContextOptions<petshopAppLiteContext> opt) : base(opt) { }
        public DbSet<Pet> pets { get; set; }
        public DbSet<Owner> owners { get; set; }
    }
}
