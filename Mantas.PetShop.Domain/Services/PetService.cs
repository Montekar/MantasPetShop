using System.Collections.Generic;
using System.Linq;
using Mantas.PetShop.Core.IServices;
using Mantas.PetShop.Core.Models;
using Mantas.PetShop.Domain.IRepositories;

namespace Mantas.PetShop.Domain.Services
{
    public class PetService : IPetService

    {
        private IPetRepository _petRepo;

        public PetService(IPetRepository petRepo)
        {
            _petRepo = petRepo;
        }
        
        public List<Pet> GetPets()
        {
            return _petRepo.GetPets().ToList();
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepo.CreatePet(pet);
        }

        public Pet DeletePet(int id)
        {
            return _petRepo.DeletePet(id);        
        }

        public Pet UpdatePet(Pet pet)
        {
            return _petRepo.UpdatePet(pet);
        }

        public Pet SearchPet(int id)
        {
            return _petRepo.SearchPet(id);
        }

        public List<Pet> GetFiveCheapestPets()
        {
            IEnumerable<Pet> list = _petRepo.GetPets();
            return list.OrderBy(pet => pet.Price).Take(5).ToList();
        }

        public List<Pet> GetPetsByPrice()
        {
            IEnumerable<Pet> list = _petRepo.GetPets();
            return list.OrderBy(pet => pet.Price).ToList();
        }
    }
}