using System;
using System.Collections.Generic;
using System.Linq;
using Mantas.PetShop.Core.Filtering;
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
        
        public List<Pet> GetPets(Filter filter)
        {
            if (filter.Count <= 0 || filter.Count > 500)
            {
                throw new ArgumentException("You need to put in a filter count between 1 and 500");
            }

            var totalCount =  _petRepo.Count();
            if (filter.Page < 1 || filter.Count * (filter.Page - 1) > totalCount)
            {
                throw new ArgumentException($"You need to put in a filter page between 1 and max page size, max page size allowed now: {(totalCount / filter.Count) + 1}");
            }
            
            return _petRepo.GetPets(filter).ToList();
        }
        
        public int GetTotalPetCount()
        {
            return _petRepo.Count();
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

        public List<Pet> GetFiveCheapestPets(Filter filter)
        {
            IEnumerable<Pet> list = _petRepo.GetPets(filter);
            return list.OrderBy(pet => pet.Price).Take(5).ToList();
        }

        public List<Pet> GetPetsByPrice(Filter filter)
        {
            IEnumerable<Pet> list = _petRepo.GetPets(filter);
            return list.OrderBy(pet => pet.Price).ToList();
        }
    }
}