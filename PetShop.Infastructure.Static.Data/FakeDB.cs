using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Infastructure.Static.Data
{
    public class FakeDB
    {
        public static int petId = 1;
        public static readonly List<Pet> Pets = new List<Pet>();

        public static int ownerId = 1;
        public static readonly List<Owner> Owners = new List<Owner>();

        public static int typeId = 1;
        public static readonly List<TypePet> Types = new List<TypePet>();
    }
}
