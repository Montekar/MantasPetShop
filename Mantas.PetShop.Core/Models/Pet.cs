using System;

namespace Mantas.PetShop.Core.Models
{
    public class Pet
    {
        public int Id;
        public string Name;
        public string? PetType;
        public DateTime Birthdate;
        public DateTime SoldDate;
        public string Color;
        public double Price;
    }
}