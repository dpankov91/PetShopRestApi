    using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace PetShop.Core.Entity
{
    public class Owner
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public int PhoneNumber { get; set; }

        //List<Pet> ownedPets;
    }
}
