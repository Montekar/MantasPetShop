using System.Collections.Generic;
using Mantas.PetShop.Core.Models;
using Mantas.PetShop.Domain.IRepositories;

namespace Mantas.PetShop.Infrastructure.DataAccess.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private static int _id;
        private static List<Owner> _owners = new List<Owner>();
        
        public Owner CreateOwner(Owner owner)
        {
            owner.Id = ++_id;
            _owners.Add(owner);
            return owner;
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _owners;
        }

        public Owner ReadOwner(int id)
        {
            return _owners.Find(owner => owner.Id == id);
        }

        public Owner UpdateOwner(Owner owner)
        {
            Owner own = _owners.Find(o => o.Id == owner.Id);
            if (own != null)
            {
                own.FirstName = owner.FirstName;
                own.LastName = owner.LastName;
            }

            return own;
        }

        public Owner DeleteOwner(int id)
        {
            Owner owner = _owners.Find(o => o.Id == id);
            if (owner != null)
            {
                _owners.Remove(owner);
            }
            return owner;
        }
    }
}