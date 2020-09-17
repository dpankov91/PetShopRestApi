using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainService
{
    public interface ITypePetRepository
    {
        List<TypePet> GetAllPetTypes();

        TypePet GetPetTypeById(int id);

        TypePet Create(TypePet typePet);

        TypePet Delete(int id);

        TypePet Update(TypePet petTypeToUpdate);
    }
}
