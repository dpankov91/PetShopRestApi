using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Services
{
    public interface IUserService
    {
        IEnumerable<User> getUsers();

        User getUserById(int id);

        User Create(User user);

        User Delete(int id);

        User Update(User userToUpdate);


    }
}
