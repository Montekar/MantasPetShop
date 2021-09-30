using System.Collections.Generic;
using Mantas.PetShop.Core.Filtering;
using Mantas.PetShop.Core.Models;

namespace Mantas.PetShop.Domain.IRepositories
{
    public interface IPetRepository
    {
        IEnumerable<Pet> GetPets(Filter filter); 
        
        Pet CreatePet(Pet pet);
        Pet DeletePet(int id);
        Pet UpdatePet(Pet pet);
        Pet SearchPet(int id);
        int Count();
    }
}