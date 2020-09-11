using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);

        Pet ReadPetById(int id);

        IEnumerable<Pet> ReadAllPets();

        Pet UpdatePet(Pet petToUpdate);

        Pet DeletePet(int id);

    }
}
