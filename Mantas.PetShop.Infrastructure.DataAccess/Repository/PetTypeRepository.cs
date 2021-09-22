using System.Collections.Generic;
using Mantas.PetShop.Core.Models;
using Mantas.PetShop.Domain.IRepositories;

namespace Mantas.PetShop.Infrastructure.DataAccess.Repository
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private static List<PetType> _petTypes = new List<PetType>();
        
        public PetTypeRepository()
        {
            _petTypes.Add(new PetType()
            {
                Id = 1,
                Type = "Cat"
            });
            _petTypes.Add(new PetType()
            {
                Id = 2,
                Type = "Dog"
            });
            _petTypes.Add(new PetType()
            {
                Id = 3,
                Type = "Goat"
            });
        }

        public PetType CreatePetType(PetType owner)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PetType> GetPetTypes()
        {
            return _petTypes;
        }

        public PetType ReadPetType(int id)
        {
            throw new System.NotImplementedException();
        }

        public PetType UpdatePetType(PetType owner)
        {
            throw new System.NotImplementedException();
        }

        public PetType DeletePetType(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}