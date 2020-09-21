using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Services
{
    public interface IOwnerService
    {
        List<Owner> GetAllOwners();

        Owner FindOwnerById(int id);

        Owner GetOwnerByIdIncludePets(int id);

        Owner Create(Owner owner);

        Owner Delete(int id);

        Owner Update(Owner ownerToUpdate);
    }
}
