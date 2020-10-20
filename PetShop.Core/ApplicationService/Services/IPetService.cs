using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;
using PetShop.Core.Filter;

namespace PetShop.Core.ApplicationService.Services
{
    public interface IPetService
    {
        List<Pet> GetAllPets();

        Pet ReadPetById(int id);

        Pet Create(Pet pet);

        Pet Delete(int id);

        Pet Update(Pet petToUpdate);

        FilteredList<Pet> ReadPetsFilter(Filter.Filter filter);
        List<Pet> GetFilteredPets(PageFilter pageFilter);
        int Count();
    }
}
