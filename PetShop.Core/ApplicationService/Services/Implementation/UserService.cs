using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        public User Create(User user)
        {
            return _userRepo.Create(user);
        }

        public User Delete(int id)
        {
            return _userRepo.Delete(id);
        }

        public User getUserById(int id)
        {
            return _userRepo.GetUserById(id);
        }

        public IEnumerable<User> getUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public User Update(User userToUpdate)
        {
            return _userRepo.Update(userToUpdate);
        }
    }
}
