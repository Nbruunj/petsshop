using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace petshop.infrastructure.SQL.data.repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private readonly TodoContext _ctx;
        public PetTypeRepository(TodoContext ctx)
        {
            _ctx = ctx;
        }
        public PetType Create(PetType petType)
        {
            var createdPetType = _ctx.Add(petType).Entity;
            _ctx.SaveChanges();
            return createdPetType;
        }

        public PetType Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PetType ReadById(int id)
        {
            return _ctx.PetTypes.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<PetType> ReadPetTypes()
        {
            return _ctx.PetTypes;
        }

        public PetType Update(PetType petTypeUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
