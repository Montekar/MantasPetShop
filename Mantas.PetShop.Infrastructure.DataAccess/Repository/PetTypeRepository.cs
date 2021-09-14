using System.Collections.Generic;
using Mantas.PetShop.Core.Models;
using Mantas.PetShop.Domain.IRepositories;

namespace Mantas.PetShop.Infrastructure.DataAccess.Repository
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private static List<PetType> petTypes = new List<PetType>();
        
        public PetTypeRepository()
        {
            petTypes.Add(new PetType()
            {
                Id = 1,
                Name = "Cat"
            });
            petTypes.Add(new PetType()
            {
                Id = 2,
                Name = "Dog"
            });
            petTypes.Add(new PetType()
            {
                Id = 3,
                Name = "Goat"
            });
        }

        public IEnumerable<PetType> GetPetTypes()
        {
            return petTypes;
        }
    }
}