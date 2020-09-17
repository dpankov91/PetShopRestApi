using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Services
{
    public interface IPetService
    {
        List<Pet> GetAllPets();

        Pet FindPetById(int id);

        Pet Create(Pet pet);

        Pet Delete(int id);

        Pet Update(Pet petToUpdate);

    }
}
