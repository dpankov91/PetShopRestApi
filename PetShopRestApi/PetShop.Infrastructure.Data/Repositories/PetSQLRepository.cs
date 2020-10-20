using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using PetShop.Core.Filter;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetSQLRepository : IPetRepository
    {
        readonly PetAppDBContext _ctx;
        public PetSQLRepository(PetAppDBContext context)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _ctx = context;
        }

        

        public Pet ReadPetById(int id)
        {
            return _ctx.Pets
                .Include(pet => pet.TypePet)
                         .Include(pet => pet.Owner)
                                 .FirstOrDefault(pet => pet.Id == id);
        }

        public Pet Create(Pet pet)
        {
            //code for tracking problem atach/detach when adding new object
            //foreach (var entry in _ctx.ChangeTracker.Entries())
            //    entry.State = EntityState.Detached;
            ////possible to create pet without owner, but not without type
            //if (pet.Owner != null)
            //    _ctx.Entry(pet.Owner).State = EntityState.Unchanged;
            //_ctx.Entry(pet.TypePet).State = EntityState.Unchanged;
            //_ctx.Add(pet);

            //var petEntry = _ctx.Add(pet);
            //_ctx.SaveChanges();
            //return petEntry.Entity;

            _ctx.Attach(pet).State = EntityState.Added;
            _ctx.SaveChanges();
            return pet;
        }

        public Pet UpdatePet(Pet petToUpdate) 
        {
            //foreach (var entry in _ctx.ChangeTracker.Entries())
            //    entry.State = EntityState.Detached;

            //var petEntry = _ctx.Update(petToUpdate);

            //if (petToUpdate.Owner == null)
            //{
            //    _ctx.Entry(petToUpdate).Reference(p => p.Owner).IsModified = true;
            //}
            //if (petToUpdate.TypePetId < 1)
            //{
            //    throw new Exception("Pet must have type");
            //}
            //return petEntry.Entity;

            _ctx.Attach(petToUpdate).State = EntityState.Modified;
            if (petToUpdate.Owner == null)
            {
                _ctx.Entry(petToUpdate).Reference(p => p.Owner).IsModified = true;
            }
            if (petToUpdate.TypePetId < 1)
            {
                throw new Exception("Pet must have type");
            }
            _ctx.SaveChanges();
            return petToUpdate;
        }
        public Pet DeletePet(int id)
        {
            var pet = _ctx.Remove(new Pet() { Id = id });
            _ctx.SaveChanges();
            return pet.Entity;
        }

        public FilteredList<Pet> ReadPetsFilter(Filter filter)
        {
            var filteredlist = new FilteredList<Pet>();

            filteredlist.TotalCount = _ctx.Pets.Count();
            filteredlist.List = _ctx.Pets
                .Include(c => c.TypePet)
                .Skip((filter.CurrentPage - 1) * filter.ItemsPerPage)
                .Take(filter.ItemsPerPage).ToList();
            return filteredlist;
        }

        public List<Pet> Filter(string orderDir)
        {
            return "ASC".Equals(orderDir)
                ? _ctx.Pets.OrderBy(c => c.Name).ToList()
                : _ctx.Pets.OrderByDescending(c => c.Name).ToList();
        }

        public IEnumerable<Pet> ReadAllPets(PageFilter pageFilter)
        {
            if (pageFilter == null)
            {
                return _ctx.Pets;
            }
            return _ctx.Pets
                .Skip((pageFilter.CurrentPage - 1) * pageFilter.ItemsPerPage)
                .Take(pageFilter.ItemsPerPage);
        }

        public IEnumerable<Pet> ReadPetsWithoutOwner(int id)
        {
            throw new NotImplementedException();

        }

        public List<Pet> ReadPetsWithoutOwner(FilteredList<Pet> filteredList)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            return _ctx.Pets.Count();
        }
    }
}
