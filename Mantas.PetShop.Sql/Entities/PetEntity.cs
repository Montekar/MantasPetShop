using System;

namespace Mantas.PetShop.Sql.Entities
{
    public class PetEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PetType { get; set; }
        public DateTime Birthdate { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        
        public int OwnerId { get; set; }
    }
}