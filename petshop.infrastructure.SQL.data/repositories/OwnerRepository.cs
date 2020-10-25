using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace petshop.infrastructure.SQL.data.repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly TodoContext _ctx;
        public OwnerRepository(TodoContext ctx)
        {
            _ctx = ctx;
        }
        public Owner Create(Owner owner)
        {
            var createdOwner = _ctx.Add(owner).Entity;
            _ctx.SaveChanges();
            return createdOwner;
        }

        public Owner Delete(int id)
        {
            var ownerRemoved = _ctx.Remove(new Owner { Id = id }).Entity;
            _ctx.SaveChanges();
            return ownerRemoved;
        }

        public Owner ReadById(int id)
        {
            return _ctx.Owners.AsTracking().Include(o => o.OwnerPetList).FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return _ctx.Owners;
        }

        public Owner Update(Owner ownerUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
