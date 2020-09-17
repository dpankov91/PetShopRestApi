using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Services.Implementation
{
    public class TypePetService : ITypePetService
    {
        private readonly ITypePetRepository _typePetRepository;

        public TypePetService(ITypePetRepository typePetRepository)
        {
            _typePetRepository = typePetRepository;
        }
        public List<TypePet> getAllTypePets()
        {
            return _typePetRepository.GetAllPetTypes();
        }

        public TypePet getTypeById(int id)
        {
            return _typePetRepository.GetPetTypeById(id);
        }

        public TypePet Create(TypePet typePet)
        {
            return _typePetRepository.Create(typePet);
        }

        public TypePet CreateNewType(string Type)
        {
            TypePet type = new TypePet()
            {
                Type = Type,
            };
            _typePetRepository.Create(type);
            return type;
        }

        public TypePet Delete(int id)
        {
            return _typePetRepository.Delete(id);
        }


        public TypePet Update(TypePet typeToUpdate)
        {
            return _typePetRepository.Update(typeToUpdate);
        }
    }
}
