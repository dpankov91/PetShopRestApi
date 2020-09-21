using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Infastructure.Static.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        //static int id = 1;
        //static List<Pet> _pets = new List<Pet>();
        public PetRepository()
        {
        if (FakeDB.Pets.Count > 0) return;

            var pet1 = new Pet()
            {
                Id = FakeDB.petId++,
                Name = "Pees",
                Color = "Yellow",
                BirthdayDate = new DateTime(2020, 06, 15),
                Price = 120.00,
                Owner = new Owner()
            };
            FakeDB.Pets.Add(pet1);

            var pet2 = new Pet()
            {
                Id = FakeDB.petId++,
                Name = "Lolkins",
                Color = "Red",
                BirthdayDate = new DateTime(2020, 02, 01),
                Price = 120.00
            };
            FakeDB.Pets.Add(pet2);
        }

        public IEnumerable<Pet> ReadAllPets()
        {
            return FakeDB.Pets;
        }

        public Pet ReadPetById(int id)
        {
            foreach(var pet in FakeDB.Pets)
            {
                if(pet.Id == id)
                {
                    return pet;
                }
            }
            return null;
        }

        public Pet Create(Pet pet)
        {
            pet.Id = FakeDB.petId++;
            FakeDB.Pets.Add(pet);
            return pet;
        }

        public Pet DeletePet(int id)
        {
            Pet petFound = ReadPetById(id);
            if(petFound != null)
            {
                FakeDB.Pets.Remove(petFound);
                return petFound;
            }
            return null;         
        }

        public Pet UpdatePet(Pet petToUpdate)
        {
            Pet petFromDb = ReadPetById(petToUpdate.Id);
            if(petFromDb != null)
            {
                petFromDb.Name = petToUpdate.Name;
                petFromDb.Color = petToUpdate.Color;
                petFromDb.Price = petToUpdate.Price;
                petFromDb.BirthdayDate = petToUpdate.BirthdayDate;
                petFromDb.SoldDate = petToUpdate.SoldDate;

                return petFromDb;
            }
            return null;
        }
    }
}
