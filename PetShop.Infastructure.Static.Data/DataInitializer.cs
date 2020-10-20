using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.ApplicationService.Services;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using PetShop.Core.Security;

namespace PetShop.Infastructure.Static.Data
{
    public class DataInitializer
    {
        private readonly IUserRepository _userRepository;
        private readonly IPetRepository _petRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly ITypePetRepository _typePetRepository;
        private IAuthenticationHelper _authHelper;

        public DataInitializer(IPetRepository petRepository, IOwnerRepository ownerRepository, ITypePetRepository typePetRepository, 
                                                           IUserRepository userRepository, IAuthenticationHelper authenticationHelper)
        {
            _userRepository = userRepository;
            _petRepository = petRepository;
            _ownerRepository = ownerRepository;
            _typePetRepository = typePetRepository;
            _authHelper = authenticationHelper;
        }

        public void InitData()
        {
            #region Owners
            var owner1 = new Owner()
            {
                //Id = FakeDB.ownerId++,
                FirstName = "Arnold",
                SecondName = "Gus",
                Age = 45,
                Address = "Gronningen 24",
                PhoneNumber = 61564432
            };
            _ownerRepository.Create(owner1);

            var owner2 = new Owner()
            {
                FirstName = "Slim",
                SecondName = "Shaddy",
                Age = 22,
                Address = "Salute 2",
                PhoneNumber = 56477124
            };
            _ownerRepository.Create(owner2);


            var owner3 = new Owner()
                {
                FirstName = "Bob",
                SecondName = "McCalckin",
                Age = 31,
                Address = "Rabstroy 7",
                PhoneNumber = 56477124
            };
            _ownerRepository.Create(owner3);

            var owner4 = new Owner()
            {
                FirstName = "Nicklas",
                SecondName = "Brideman",
                Age = 31,
                Address = "Semenyak 28",
                PhoneNumber = 56237124
            };
            _ownerRepository.Create(owner4);
            #endregion
            #region Pet Types
            TypePet type1 = new TypePet()
            {
                Type = "Cat",

            };
            _typePetRepository.Create(type1);


            TypePet type2 = new TypePet()
            {
                Type = "Dog"
            };
            _typePetRepository.Create(type2);

            TypePet type3 = new TypePet()
            {
                Type = "Mouse"
            };
            _typePetRepository.Create(type3);
            #endregion
            #region Pets
            var pet1 = new Pet()
            {
                Name = "Pees",
                Color = "Yellow",
                BirthdayDate = new DateTime(2020, 06, 15),
                Price = 120.00,
                TypePetId = 2,
                OwnerId = 1

            };
            _petRepository.Create(pet1); 

            var pet2 = new Pet()
            {
                Name = "Lolkins",
                Color = "Red",
                BirthdayDate = new DateTime(2020, 02, 01),
                Price = 133.00,
                TypePetId = 1,
                OwnerId = 1

            };
            _petRepository.Create(pet2);
            #endregion
            #region Users
            string password = "1234";
            byte[] passwordHashJohn, passwordSaltJohn, passwordHashAnna, passwordSaltAnna;
            _authHelper.CreatePasswordHash(password, out passwordHashJohn, out passwordSaltJohn);
            _authHelper.CreatePasswordHash(password, out passwordHashAnna, out passwordSaltAnna);

            var JohnAdmin = new User()
            {
                Username = "John",
                PasswordHash = passwordHashJohn,
                PasswordSalt = passwordSaltJohn,
                IsAdmin = true
            };
            _userRepository.Create(JohnAdmin);

            var AnnaNotAdmin = new User()
            {
                Username = "Anna",
                PasswordHash = passwordHashAnna,
                PasswordSalt = passwordSaltAnna,
                IsAdmin = false
            };
            _userRepository.Create(AnnaNotAdmin);
            #endregion
        }
    }
}
