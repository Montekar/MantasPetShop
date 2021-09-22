using System.Collections.Generic;
using Mantas.PetShop.Core.Models;

namespace Mantas.PetShop.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        PetType CreatePetType(PetType petType);
        IEnumerable<PetType> GetPetTypes();
        PetType ReadPetType(int id);
        PetType UpdatePetType(PetType petType);
        PetType DeletePetType(int id);
    }
}