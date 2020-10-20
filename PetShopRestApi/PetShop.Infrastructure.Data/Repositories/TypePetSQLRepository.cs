using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class TypePetSQLRepository : ITypePetRepository
    {
        readonly PetAppDBContext _ctx;
        public TypePetSQLRepository(PetAppDBContext context)
        {
            _ctx = context;
        }

        IEnumerable<TypePet> ITypePetRepository.GetAllPetTypes()
        {
            return _ctx.TypesPet.ToList();
        }
        public TypePet GetPetTypeById(int id)
        {
            return _ctx.TypesPet.AsTracking().
                FirstOrDefault(typeP => typeP.Id == id);
        }
        public TypePet Create(TypePet typePet)
        {
            //var petEntry = _ctx.Add(typePet);
            //_ctx.SaveChanges();
            //return petEntry.Entity;

            _ctx.Attach(typePet).State = EntityState.Added;
            _ctx.SaveChanges();
            return typePet;
        }

        public TypePet Delete(int id)
        {
            var typePet = _ctx.Remove(new TypePet() { Id = id });
            _ctx.SaveChanges();
            return typePet.Entity;
            
        }

        public TypePet Update(TypePet petTypeToUpdate)
        {
            _ctx.Attach(petTypeToUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return petTypeToUpdate;
        }
    }
}
