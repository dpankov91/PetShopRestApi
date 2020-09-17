using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Infastructure.Static.Data.Repositories
{
    public class TypePetRepository : ITypePetRepository
    {
        static List<TypePet> _petTypes = new List<TypePet>();
        static  int id = 1;

        public List<TypePet> GetAllPetTypes()
        {
            return _petTypes;
        }

        public TypePet GetPetTypeById(int id)
        {
            foreach(var type in _petTypes)
            {
                if(type.Id == id)
                {
                    return type;
                }
            }
            return null;
        }

        public TypePet Create(TypePet typePet)
        {
            typePet.Id = id++;
            _petTypes.Add(typePet);
            return typePet;
        }

        public TypePet Delete(int id)
        {
            TypePet typeToDelete = GetPetTypeById(id);
            if(typeToDelete != null)
            {
                _petTypes.Remove(typeToDelete);
                return typeToDelete;
            }
            return null;
        }

        public TypePet Update(TypePet petTypeToUpdate)
        {
            TypePet typeFromDb = GetPetTypeById(petTypeToUpdate.Id);
            if (typeFromDb != null)
            {
                typeFromDb.Type = petTypeToUpdate.Type;

                return typeFromDb;
            }
            return null;


        }
    }
}
