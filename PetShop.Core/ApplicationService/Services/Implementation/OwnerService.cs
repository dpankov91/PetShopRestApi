using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Services.Implementation
{
    public class OwnerService : IOwnerService
    {
        private IOwnerService _ownerService;

        public OwnerService(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        public List<Owner> GetAllOwners()
        {
           return _ownerService.GetAllOwners();
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerService.FindOwnerById(id);
        }

        public Owner Create(Owner owner)
        {
            return _ownerService.Create(owner);
        }

        public Owner CreateNewOwner(string FirstName, string SecondName, int Age, string Address, int PhoneNumber)
        {
            Owner owner = new Owner()
            {
                FirstName = FirstName,
                SecondName = SecondName,
                Age = Age,
                Address = Address,
                PhoneNumber = PhoneNumber
            };
            _ownerService.Create(owner);
            return owner;

        }

        public Owner Delete(int id)
        {
            return _ownerService.Delete(id);
        }


        public Owner Update(Owner ownerToUpdate)
        {
            Owner owner = FindOwnerById(ownerToUpdate.Id);

            owner.FirstName = ownerToUpdate.FirstName;
            owner.SecondName = ownerToUpdate.SecondName;
            owner.Age = ownerToUpdate.Age;
            owner.Address = ownerToUpdate.Address;
            owner.PhoneNumber = ownerToUpdate.PhoneNumber;

            return owner;
        }
    }
}
