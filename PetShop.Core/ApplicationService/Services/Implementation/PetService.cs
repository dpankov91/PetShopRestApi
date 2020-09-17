using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Services.Implementation
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public List<Pet> GetAllPets()
        {
            return _petRepository.ReadAllPets().ToList();
        }

        public Pet FindPetById(int id)
        {
            return _petRepository.ReadPetById(id);
        }

        public Pet Create(Pet pet)
        {
            return _petRepository.Create(pet);
        }

        //public Pet CreateNewPet(string Name, string Color, double Price, DateTime BirthdayDate, DateTime SoldDate)
        //{
        //    Pet pet = new Pet
        //    {
        //        Name = Name,
        //        Color = Color,
        //        Price = Price,
        //        BirthdayDate = BirthdayDate,
        //        SoldDate = SoldDate    
        //    };
        //    _petRepository.Create(pet);
        //    return pet;
        //}

        public Pet Delete(int id)
        {
            return _petRepository.DeletePet(id);
        }

        public Pet Update(Pet petToUpdate)
        {
            return _petRepository.UpdatePet(petToUpdate);
        }
    }
}
