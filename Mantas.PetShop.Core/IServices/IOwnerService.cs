using System.Collections.Generic;
using Mantas.PetShop.Core.Models;

namespace Mantas.PetShop.Core.IServices
{
    public interface IOwnerService
    {
        Owner Create(Owner owner);
        List<Owner> ReadAll();
        Owner Read(int id);
        Owner Update(Owner owner);
        Owner Delete(int id);
    }
}