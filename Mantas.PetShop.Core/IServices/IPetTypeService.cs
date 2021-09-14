using System.Collections.Generic;
using Mantas.PetShop.Core.Models;

namespace Mantas.PetShop.Core.IServices
{
    public interface IPetTypeService
    {
        PetType Find(string type);
        List<PetType> GetPetTypes();

        string GetAvailableTypesString();
    }
}