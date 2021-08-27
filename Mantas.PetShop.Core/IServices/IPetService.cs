﻿using System.Collections.Generic;
using Mantas.PetShop.Core.Models;

namespace Mantas.PetShop.Core.IServices
{
    public interface IPetService
    {
        List<Pet> GetPets();

        Pet CreatePet(Pet pet);
        Pet DeletePet(int id);
        Pet UpdatePet(Pet pet);
        
    }
}