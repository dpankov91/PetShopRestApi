using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public DateTime BirthdayDate { get; set; }

        public DateTime SoldDate { get; set; }

        public Double Price { get; set; }

        public Owner Owner { get; set; }

        public TypePet TypePet { get; set; }

    }
}
