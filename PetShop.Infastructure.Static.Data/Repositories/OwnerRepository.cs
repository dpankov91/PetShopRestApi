using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Infastructure.Static.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    { 
        public OwnerRepository()
        {
            if (FakeDB.Owners.Count > 0) return;

            var owner1 = new Owner()
            {
                Id = FakeDB.ownerId++,
                FirstName = "Arnold",
                SecondName = "Gus",
                Age = 45,
                Address = "Gronningen 24",
                PhoneNumber = 61564432
            };
            FakeDB.Owners.Add(owner1);

            var owner2 = new Owner()
            {
                Id = FakeDB.ownerId++,
                FirstName = "Slim",
                SecondName = "Shaddy",
                Age = 22,
                Address = "Salute 2",
                PhoneNumber = 56477124
            };
            FakeDB.Owners.Add(owner2);


            var owner3 = new Owner()
            {
                Id = FakeDB.ownerId++,
                FirstName = "Bob",
                SecondName = "McCalckin",
                Age = 31,
                Address = "Rabstroy 7",
                PhoneNumber = 56477124
            };
            FakeDB.Owners.Add(owner3);
        }

        //static List<Owner> _owners = new List<Owner>();
        //static int id = 1;

        public IEnumerable<Owner> GetAllOwners()
        {
            return FakeDB.Owners;
            //return _owners;
        }

        public Owner GetOwnerById(int id)
        {
            foreach(var owner in FakeDB.Owners)
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
            owner.Id = FakeDB.ownerId++;
            FakeDB.Owners.Add(owner);
            return owner;
        }

        public Owner Delete(int id)
        {
            Owner ownerToDelete = GetOwnerById(id);
            if(ownerToDelete != null)
            {
                FakeDB.Owners.Remove(ownerToDelete);
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
