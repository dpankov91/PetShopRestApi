using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Services
{
    interface IPetService
    {
        List<Pet> GetAllPets();

        Pet FindPetById(int id);

        Pet CreateNewPet(string Name, string Color, Double Price, DateTime BirthdayDate, DateTime SoldDate);

        Pet Create(Pet pet);

        Pet Delete(int id);

        Pet Update(Pet petToUpdate);

    }
}
