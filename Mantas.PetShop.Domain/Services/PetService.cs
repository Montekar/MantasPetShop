using System.Collections.Generic;
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
            return _repo.GetPets();
        }

        public Pet CreatePet(Pet pet)
        {
            return _repo.CreatePet(pet);
        }

        public Pet DeletePet(Pet pet)
        {
            return _repo.DeletePet(pet);        }

        public Pet UpdatePet(Pet pet)
        {
            return _repo.UpdatePet(pet);
        }
    }
}