using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Services
{
    public interface ITypePetService
    {
        List<TypePet> getAllTypePets();

        TypePet getTypeById(int id);

        TypePet Create(TypePet typePet);

        TypePet Delete(int id);

        TypePet Update(TypePet typeToUpdate);


    }
}
