using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    public class TypePet
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public List<Pet> Pets { get; set; }

    }
}
