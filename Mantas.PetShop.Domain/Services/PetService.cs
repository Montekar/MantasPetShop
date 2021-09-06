using System.Collections.Generic;
using System.Linq;
using Mantas.PetShop.Core.IServices;
using Mantas.PetShop.Core.Models;
using Mantas.PetShop.Domain.IRepositories;

namespace Mantas.PetShop.Domain.Services
{
    public class PetService : IPetService

    {
        private IPetRepository _repo;

        public PetService(IPetRepository repo)
        {
            _repo = repo;
        }
        
        public List<Pet> GetPets()
        {
            return _repo.GetPets().ToList();
        }

        public Pet CreatePet(Pet pet)
        {
            return _repo.CreatePet(pet);
        }

        public Pet DeletePet(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public Pet DeletePet(int id)
        {
            return _repo.DeletePet(id);        
        }

        public Pet UpdatePet(Pet pet)
        {
            return _repo.UpdatePet(pet);
        }

        public Pet SearchPet(int id)
        {
            return _repo.SearchPet(id);
        }

        public List<Pet> GetFiveCheapestPets()
        {
            IEnumerable<Pet> list = _repo.GetPets();
            return list.OrderBy(pet => pet.Price).Take(5).ToList();
        }

        public List<Pet> GetPetsByPrice()
        {
            IEnumerable<Pet> list = _repo.GetPets();
            return list.OrderBy(pet => pet.Price).ToList();
        }
    }
}