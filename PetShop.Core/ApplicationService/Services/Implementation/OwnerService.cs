using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Services.Implementation
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IPetRepository _petRepository;

        public OwnerService(IOwnerRepository ownerRepository, IPetRepository petRepository)
        {
            _ownerRepository = ownerRepository;
            _petRepository = petRepository;
        }

        public List<Owner> GetAllOwners()
        {
            return _ownerRepository.GetAllOwners().ToList();
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepository.GetOwnerById(id);
        }

        public Owner Create(Owner owner)
        {
            return _ownerRepository.Create(owner);
        }

        public Owner Delete(int id)
        {
            return _ownerRepository.Delete(id);
        }


        public Owner Update(Owner ownerToUpdate)
        {
            return _ownerRepository.Update(ownerToUpdate);
        }

        public Owner GetOwnerByIdIncludePets(int id)
        {
            var owner = _ownerRepository.GetOwnerById(id);
            owner.Pets = _petRepository.ReadAllPets().Where(Pet => Pet.Owner.Id == owner.Id).ToList();
            return owner;   

        }

    }
}
