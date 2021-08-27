using System.Collections.Generic;
using System.Linq;
using Mantas.PetShop.Core.Models;
using Mantas.PetShop.Domain.IRepositories;

namespace Mantas.PetShop.Infrastructure.DataAccess.Repository
{
    public class PetRepository : IPetRepository
    {
        private static List<Pet> _petTable = new List<Pet>();
        private static int _id = 0;

        public List<Pet> GetPets()
        {
            return _petTable;
        }

        public Pet CreatePet(Pet pet)
        {
            pet.Id = ++_id;
            _petTable.Add(pet);
            return pet;
        }

        public Pet DeletePet(int id)
        {
            Pet pet = _petTable.Find(pet => pet.Id == id);
            if (pet != null)
            {
                _petTable.Remove(pet);
            }

            return pet;
        }

        public Pet UpdatePet(Pet pet)
        {
            throw new System.NotImplementedException();
        }
    }
}