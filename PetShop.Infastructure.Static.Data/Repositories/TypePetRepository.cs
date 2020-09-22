using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Infastructure.Static.Data.Repositories
{
    public class TypePetRepository : ITypePetRepository
    {
        public TypePetRepository()
        {
            //if (FakeDB.Types.Count > 0) return;

            //TypePet type1 = new TypePet()
            //{
            //    Id = FakeDB.typeId++,
            //    Type = "Cat"
            //};
            //FakeDB.Types.Add(type1);


            //TypePet type2 = new TypePet()
            //{
            //    Id = FakeDB.typeId++,
            //    Type = "Dog"
            //};
            //FakeDB.Types.Add(type2);

            //TypePet type3 = new TypePet()
            //{
            //    Id = FakeDB.typeId++,
            //    Type = "Mouse"
            //};
            //FakeDB.Types.Add(type3);
        }
        //static List<TypePet> _petTypes = new List<TypePet>();
        //static  int id = 1;

        public List<TypePet> GetAllPetTypes()
        {
            return FakeDB.Types;
        }

        public TypePet GetPetTypeById(int id)
        {
            foreach(var type in FakeDB.Types)
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
            typePet.Id = FakeDB.typeId++;
            FakeDB.Types.Add(typePet);
            return typePet;
        }

        public TypePet Delete(int id)
        {
            TypePet typeToDelete = GetPetTypeById(id);
            if(typeToDelete != null)
            {
                FakeDB.Types.Remove(typeToDelete);
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
