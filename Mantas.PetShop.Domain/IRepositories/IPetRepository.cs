﻿using System.Collections.Generic;
using Mantas.PetShop.Core.Models;

namespace Mantas.PetShop.Domain.IRepositories
{
    public interface IPetRepository
    {
        List<Pet> GetPets(); 
        
        Pet CreatePet(Pet pet);
        Pet DeletePet(Pet pet);
        Pet UpdatePet(Pet pet);
    }
}