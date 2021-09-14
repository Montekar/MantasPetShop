using System.Collections;
using System.Collections.Generic;
using Mantas.PetShop.Core.Models;

namespace Mantas.PetShop.Domain.IRepositories
{
    public interface IOwnerRepository
    {
        Owner Create(Owner owner);
        IEnumerable<Owner> ReadAll();
        Owner Read(int id);
        Owner Update(Owner owner);
        Owner Delete(int id);
    }
}