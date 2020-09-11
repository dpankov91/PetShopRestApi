using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Infastructure.Static.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        static int id = 1;
        List<Pet> _pets = new List<Pet>();


        public IEnumerable<Pet> ReadAllPets()
        {
            return _pets;
        }

        public Pet ReadPetById(int id)
        {
            foreach(var pet in _pets)
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
            pet.Id = id++;
            _pets.Add(pet);
            return pet;
        }

        public Pet DeletePet(int id)
        {
            Pet petFound = ReadPetById(id);
            if(petFound != null)
            {
                _pets.Remove(petFound);
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
