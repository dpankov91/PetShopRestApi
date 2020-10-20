using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class UserSQLRepository : IUserRepository
    {
        readonly PetAppDBContext _ctx;
        public UserSQLRepository(PetAppDBContext context)
        {
            _ctx = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _ctx.Users;
        }

        public User GetUserById(int id)
        {
            return _ctx.Users.AsNoTracking().
                FirstOrDefault(user => user.Id == id);
        }
        public User Create(User user)
        {
            _ctx.Attach(user).State = EntityState.Added;
            _ctx.SaveChanges();
            return user;
        }

        public User Delete(int id)
        {
            var user = _ctx.Remove(new User() { Id = id });
            _ctx.SaveChanges();
            return user.Entity;
        }

        public User Update(User userToUpdate)
        {
            _ctx.Attach(userToUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return userToUpdate;
        }
    }
}
