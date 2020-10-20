using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class OwnerSQLRepository : IOwnerRepository
    {
        readonly PetAppDBContext _ctx;
        public OwnerSQLRepository(PetAppDBContext context)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            _ctx = context;
        }
        public IEnumerable<Owner> GetAllOwners()
        {
            return _ctx.Owners;
        }

        public Owner GetOwnerById(int id)
        {
            return _ctx.Owners.Include(owner => owner.Pets)
                .AsNoTracking().FirstOrDefault(ow => ow.Id == id);
            //return _ctx.Owners.FirstOrDefault(ow => ow.Id == id);

        }
        public Owner Create(Owner owner)
        {
            //    if (_ctx.Entry(owner.Pets).State == EntityState.Detached)
            //    {
            //        _ctx.Attach(owner.Pets).State = EntityState.Unchanged;
            //    }
            //    else
            //    {
            //        _ctx.Entry(owner.Pets).State = EntityState.Unchanged;
            //    }

            //_ctx.Attach(owner.Pets).State = EntityState.Unchanged;

            //var petEntry = _ctx.Add(owner);
            //_ctx.SaveChanges();
            //petEntry.State = EntityState.Detached;
            //return petEntry.Entity;

            _ctx.Attach(owner).State = EntityState.Added;
            _ctx.SaveChanges();
            return owner;
        }

        public Owner Delete(int id)
        {
            var owner = _ctx.Remove(new Owner() { Id = id });
            _ctx.SaveChanges();
            return owner.Entity;
        }

        public Owner Update(Owner ownerToUpdate)
        {
            //var ownerEntry = _ctx.Update(ownerToUpdate);
            //_ctx.SaveChanges();
            //return ownerEntry.Entity;
            _ctx.Attach(ownerToUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return ownerToUpdate;
        }
    }
}
