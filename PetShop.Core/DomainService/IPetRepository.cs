using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using PetShop.Core.Entity;
using PetShop.Core.Filter;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);

        Pet ReadPetById(int id);

        IEnumerable<Pet> ReadAllPets(PageFilter pageFilter = null);

        Pet UpdatePet(Pet petToUpdate);

        Pet DeletePet(int id);

        IEnumerable<Pet> ReadPetsWithoutOwner(int id);

        List<Pet> ReadPetsWithoutOwner(FilteredList<Pet> filteredList);

        FilteredList<Pet> ReadPetsFilter(Filter.Filter filter);
        int Count();
    }
}
