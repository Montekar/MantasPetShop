using System.Collections.Generic;
using Mantas.PetShop.Core.Models;

namespace Mantas.PetShop.Core.IServices
{
    public interface IPetTypeService
    {
        PetType CreatePetType(PetType petType);
        List<PetType> GetPetTypes();
        PetType ReadPetType(int id);
        PetType UpdatePetType(PetType petType);
        PetType DeletePetType(int id);
        
        
    }
}