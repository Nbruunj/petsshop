using PetShop.Core.DomainServices;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class DataInit
    {
        private readonly IPetRepository _petRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IPetTypeRepository _petTypeRepository;

        public static readonly List<Pet> Pets = new List<Pet>();
        public static readonly List<PetType> PetTypes = new List<PetType>();

        public DataInit(IPetRepository petRepository, IOwnerRepository ownerRepository, IPetTypeRepository petTypeRepository)
        {
            _petRepository = petRepository;
            _ownerRepository = ownerRepository;
            _petTypeRepository = petTypeRepository;
        }

        public void InitData()
        {
            var petType = new PetType
            {
                Type = "hund"

            };
            _petTypeRepository.Create(petType);
            PetTypes.Add(petType);

            var pet1 = new Pet
            {
                Name = "hundenmads",
                Type = "hund",
                Color = "brun",
                BirthDate = new DateTime(2019, 3, 10),
                Price = 100,
                SoldDate = new DateTime(2020, 2, 11),
                PreviousOwner = "mikkel"
            };

            var owner1 = new Owner
            {
                Name = "frost",
                Address = "vinter"
            };
            _petRepository.Create(pet1);
            _ownerRepository.Create(owner1);
        }
    }
}
