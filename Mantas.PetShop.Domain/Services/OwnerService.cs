using System.Collections.Generic;
using System.Linq;
using Mantas.PetShop.Core.IServices;
using Mantas.PetShop.Core.Models;
using Mantas.PetShop.Domain.IRepositories;

namespace Mantas.PetShop.Domain.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepository.CreateOwner(owner);
        }

        public List<Owner> GetOwners()
        {
            return _ownerRepository.GetOwners().ToList();
        }

        public Owner ReadOwner(int id)
        {
            return _ownerRepository.ReadOwner(id);
        }

        public Owner UpdateOwner(Owner owner)
        {
            return _ownerRepository.UpdateOwner(owner);
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepository.DeleteOwner(id);
        }
    }
}