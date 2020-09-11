using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAllOwners();

        Owner GetOwnerById(int id);

        Owner Create(Owner owner);

        Owner Delete(int id);

        Owner Update(Owner ownerToUpdate);

    }
}
