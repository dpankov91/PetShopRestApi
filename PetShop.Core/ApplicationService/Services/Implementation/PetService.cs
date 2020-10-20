using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using PetShop.Core.Filter;

namespace PetShop.Core.ApplicationService.Services.Implementation
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly ITypePetRepository _typePetRepository;

        public PetService(IPetRepository petRepository, IOwnerRepository ownerRepository, ITypePetRepository typePetRepository)
        {
            _petRepository = petRepository;
            _ownerRepository = ownerRepository;
            _typePetRepository = typePetRepository;
        }

        public List<Pet> GetAllPets()
        {
            return _petRepository.ReadAllPets().ToList();
        }

        public Pet ReadPetById(int id)
        {
            return _petRepository.ReadPetById(id);
        }

        public Pet Create(Pet pet)
        {
            return _petRepository.Create(pet);
        }

        public Pet Delete(int id)
        {
            return _petRepository.DeletePet(id);
        }

        public Pet Update(Pet petToUpdate)
        {
            return _petRepository.UpdatePet(petToUpdate);
        }

        public FilteredList<Pet> ReadPetsFilter(Filter.Filter filter)
        {
            if (string.IsNullOrEmpty(filter.SearchField) && !string.IsNullOrEmpty(filter.SearchValue))
            {
                filter.SearchField = "Name";
            }
            else if (!string.IsNullOrEmpty(filter.SearchField) && string.IsNullOrEmpty(filter.SearchValue))
            {
                return null;
            }
            return _petRepository.ReadPetsFilter(filter);
        }

        public List<Pet> GetFilteredPets(PageFilter pageFilter)
        {
            return _petRepository.ReadAllPets(pageFilter).ToList();
        }

        public int Count()
        {
            return _petRepository.Count();
        }

        //public Pet GetPetByIdIncludeType(int id)
        //{
        //    var pet = _petRepository.ReadPetById(id);

        //    pet.TypePet = _typePetRepository.GetAllPetTypes().Where(type =>
        //                                    pet.TypePet != null && type.Pets.Idx == pet.Id);
        //    return pet;
        //}

    }
}
