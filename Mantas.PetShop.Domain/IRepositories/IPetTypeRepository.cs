using System.Collections.Generic;
using Mantas.PetShop.Core.Models;

namespace Mantas.PetShop.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        List<PetType> GetPetTypes();

        PetType createPetType();
    }
}