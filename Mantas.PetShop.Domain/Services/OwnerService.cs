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

        public Owner Create(Owner owner)
        {
            return _ownerRepository.Create(owner);
        }

        public List<Owner> ReadAll()
        {
            return _ownerRepository.ReadAll().ToList();
        }

        public Owner Read(int id)
        {
            return _ownerRepository.Read(id);
        }

        public Owner Update(Owner owner)
        {
            return _ownerRepository.Update(owner);
        }

        public Owner Delete(int id)
        {
            return _ownerRepository.Delete(id);
        }
    }
}