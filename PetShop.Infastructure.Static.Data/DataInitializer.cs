using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.ApplicationService.Services;
using PetShop.Core.Entity;

namespace PetShop.Infastructure.Static.Data
{
    public class DataInitializer
    {
        private readonly IPetService _petService;
        private readonly IOwnerService _ownerService;
        private readonly ITypePetService _typePetService;

        public DataInitializer(IPetService petService, IOwnerService ownerService, ITypePetService typePetService)
        {
            _petService = petService;
            _ownerService = ownerService;
            _typePetService = typePetService;
        }

        public void InitOwner()
        {
            var owner1 = new Owner()
            {
                //Id = FakeDB.ownerId++,
                FirstName = "Arnold",
                SecondName = "Gus",
                Age = 45,
                Address = "Gronningen 24",
                PhoneNumber = 61564432
            };
            //FakeDB.Owners.Add(owner1);
            _ownerService.Create(owner1);

            var owner2 = new Owner()
            {
                //Id = FakeDB.ownerId++,
                FirstName = "Slim",
                SecondName = "Shaddy",
                Age = 22,
                Address = "Salute 2",
                PhoneNumber = 56477124
            };
            //FakeDB.Owners.Add(owner2);
            _ownerService.Create(owner2);


            var owner3 = new Owner()
                {
                //Id = FakeDB.ownerId++,
                FirstName = "Bob",
                SecondName = "McCalckin",
                Age = 31,
                Address = "Rabstroy 7",
                PhoneNumber = 56477124
            };
            //FakeDB.Owners.Add(owner3);
            _ownerService.Create(owner3);
        }

        public void InitPet()
        {
            var pet1 = new Pet()
            {
                //Id = FakeDB.petId++,
                Name = "Pees",
                Color = "Yellow",
                BirthdayDate = new DateTime(2020, 06, 15),
                Price = 120.00,
                Owner = _ownerService.FindOwnerById(2),
                TypePet = _typePetService.getTypeById(1)
            };
            //FakeDB.Pets.Add(pet1);
            _petService.Create(pet1);

            var pet2 = new Pet()
            {
                //Id = FakeDB.petId++,
                Name = "Lolkins",
                Color = "Red",
                BirthdayDate = new DateTime(2020, 02, 01),
                Price = 133.00,
                Owner = _ownerService.FindOwnerById(2),
                TypePet = _typePetService.getTypeById(2)
            };
            //FakeDB.Pets.Add(pet2);
            _petService.Create(pet2);
        }

        public void InitTypePet()
        {
            TypePet type1 = new TypePet()
            {
                //Id = FakeDB.typeId++,
                Type = "Cat"
            };
            //FakeDB.Types.Add(type1);
            _typePetService.Create(type1);


            TypePet type2 = new TypePet()
            {
                //Id = FakeDB.typeId++,
                Type = "Dog"
            };
            //FakeDB.Types.Add(type2);
            _typePetService.Create(type2);

            TypePet type3 = new TypePet()
            {
                //Id = FakeDB.typeId++,
                Type = "Mouse"
            };
            //FakeDB.Types.Add(type3);
            _typePetService.Create(type3);
        }


    }
}
