using System.Collections.Generic;
using Mantas.PetShop.Core.Models;

namespace Mantas.PetShop.Core.IServices
{
    public interface IOwnerService
    {
        Owner CreateOwner(Owner owner);
        List<Owner> GetOwners();
        Owner ReadOwner(int id);
        Owner UpdateOwner(Owner owner);
        Owner DeleteOwner(int id);
    }
}