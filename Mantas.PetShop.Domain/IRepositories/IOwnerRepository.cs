using System.Collections;
using System.Collections.Generic;
using Mantas.PetShop.Core.Models;

namespace Mantas.PetShop.Domain.IRepositories
{
    public interface IOwnerRepository
    {
        Owner CreateOwner(Owner owner);
        IEnumerable<Owner> GetOwners();
        Owner ReadOwner(int id);
        Owner UpdateOwner(Owner owner);
        Owner DeleteOwner(int id);
    }
}