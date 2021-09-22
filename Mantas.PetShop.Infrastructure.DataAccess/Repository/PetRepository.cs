using System;
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

        public PetRepository()
        {
            CreatePet(new Pet
            {
                Name = "pukis",
                Color = "black",
                Price = 100
            });
            CreatePet(new Pet
            {
                Name = "jonas",
                Color = "black",
                Price = 200
            });
            CreatePet(new Pet
            {
                Name = "jolanta",
                Color = "black",
                Price = 999
            });
        }

        public IEnumerable<Pet> GetPets()
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
            Pet petUpdate = _petTable.Find(p => p.Id == pet.Id);
            if (petUpdate != null)
            {
                petUpdate.Name = pet.Name;
                petUpdate.Color = pet.Color;
                petUpdate.PetType = pet.PetType;
                petUpdate.Birthdate = pet.Birthdate;
                petUpdate.Price = pet.Price;
            }

            return petUpdate;
        }

        public Pet SearchPet(int id)
        {
            return _petTable.Find(pet => pet.Id == id);
        }
    }
}