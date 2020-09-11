using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Infastructure.Static.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        List<Owner> _owners = new List<Owner>();
        int id = 1;

        public IEnumerable<Owner> GetAllOwners()
        {
            return _owners;
        }

        public Owner GetOwnerById(int id)
        {
            foreach(var owner in _owners)
            {
                if(owner.Id == id)
                {
                    return owner;
                }
            }
            return null;
        }

        public Owner Create(Owner owner)
        {
            owner.Id = id++;
            _owners.Add(owner);
            return owner;
        }

        public Owner Delete(int id)
        {
            Owner ownerToDelete = GetOwnerById(id);
            if(ownerToDelete != null)
            {
                _owners.Remove(ownerToDelete);
                return ownerToDelete;
            }
            return null;
        }

         public Owner Update(Owner ownerToUpdate)
         {
            Owner ownerFromDb = GetOwnerById(ownerToUpdate.Id);

            if(ownerFromDb != null)
            {
                ownerFromDb.FirstName = ownerToUpdate.FirstName;
                ownerFromDb.SecondName = ownerToUpdate.SecondName;
                ownerFromDb.Age = ownerToUpdate.Age;
                ownerFromDb.Address = ownerToUpdate.Address;
                ownerFromDb.PhoneNumber = ownerToUpdate.PhoneNumber;

                return ownerFromDb;
            }
            return null;
         }
    }
}
