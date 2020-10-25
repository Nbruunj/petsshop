using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using PetShop.Core.Entity;
using PetShop.Infrastructure.Database.Helpers;

namespace PetShop.Infrastructure.Database
{
    public class DBInitializer : IDBInitializer
    {
        private IAuthenticationHelper authenticationHelper;

        public DBInitializer(IAuthenticationHelper authHelper)
        {
            authenticationHelper = authHelper;
        }
        public void SeedDB(PetShopContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            var owner1 = ctx.Owners.Add(new Owner()
            {
                Name = "Darth Vader",
                Address = "death star"
            }).Entity;
            var owner2 = ctx.Owners.Add(new Owner()
            {
                Name = "random dude",
                Address = "the street"
            }).Entity;
            var pet1 = ctx.Pets.Add(new Pet()
            {
                Name = "yoda",
                Type = "mutant",
                Color = "grøn",
                BirthDate = new DateTime(896, 6, 10),
                Price = 5000,
                SoldDate = new DateTime(1652, 7, 10),
                PreviousOwner = "ingen",
                Owner = owner1
            }).Entity;
            var pet2 = ctx.Pets.Add(new Pet()

            {
                Name = "Nem",
                Type = "fish",
                Color = "gold",
                BirthDate = new DateTime(2003, 4, 22),
                Price = 20,
                SoldDate = new DateTime(2003, 6, 1),
                PreviousOwner = "petshop",
                Owner = owner2
            }).Entity;


            if (ctx.TodoItems.Any())
            {
                return;   // DB has been seeded
            }

            List<TodoItem> items = new List<TodoItem>
            {
                new TodoItem { IsComplete=true, Name="Make homework"},
                new TodoItem { IsComplete=false, Name="Sleep"},
                new TodoItem { IsComplete=false, Name="<h3>Message from a Black Hat! Ha, ha, ha...<h3>"}
            };

            // Create two users with hashed and salted passwords
            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            authenticationHelper.CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            authenticationHelper.CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            List<User> users = new List<User>
            {
                new User {
                    Username = "UserJoe",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = false
                },
                new User {
                    Username = "AdminAnn",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn,
                    IsAdmin = true
                }
            };

            ctx.TodoItems.AddRange(items);
            ctx.Users.AddRange(users);
            ctx.SaveChanges();
        }
    }
}
