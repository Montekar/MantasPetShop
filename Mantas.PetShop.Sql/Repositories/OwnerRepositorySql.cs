using System.Collections.Generic;
using System.Linq;
using Mantas.PetShop.Core.Models;
using Mantas.PetShop.Domain.IRepositories;
using Mantas.PetShop.Sql.Entities;

namespace Mantas.PetShop.Sql.Repositories
{
    public class OwnerRepositorySql: IOwnerRepository
    {
        private readonly PetShopContext _ctx;

        public OwnerRepositorySql(PetShopContext ctx)
        {
            _ctx = ctx;
        }

        public Owner CreateOwner(Owner owner)
        {
            var entity = new OwnerEntity
            {
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Email = owner.Email
            };
            var savedEntity = _ctx.Owner.Add(entity).Entity;
            _ctx.SaveChanges();
            return new Owner()
            {
                Id = savedEntity.Id,
                FirstName = savedEntity.FirstName,
                LastName = savedEntity.LastName,
                Email = owner.Email
            };
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _ctx.Owner.Select(ownerEntity => new Owner
            {
                Id = ownerEntity.Id,
                FirstName = ownerEntity.FirstName,
                LastName = ownerEntity.LastName,
                Email = ownerEntity.Email
            }).ToList();
        }

        public Owner ReadOwner(int id)
        {
            return _ctx.Owner.Select(ownerEntity => new Owner
            {
                Id = ownerEntity.Id,
                FirstName = ownerEntity.FirstName,
                LastName = ownerEntity.LastName,
                Email = ownerEntity.Email
            })
                .FirstOrDefault(o => o.Id == id);
            //link query with lambda expression //default to return null if nothing is found
        }

        public Owner UpdateOwner(Owner owner)
        {
            var entity = new OwnerEntity()
            {
                Id = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Email = owner.Email
            };
            var savedEntity = _ctx.Owner.Update(entity).Entity;
            _ctx.SaveChanges();
            return new Owner();
        }

        public Owner DeleteOwner(int id)
        {
            var savedEntity = _ctx.Owner.Remove(new OwnerEntity { Id = id }).Entity;
            _ctx.SaveChanges();
            return new Owner
            {
                Id = savedEntity.Id,
                FirstName = savedEntity.FirstName,
                LastName = savedEntity.LastName,
                Email = savedEntity.Email
            };
        }
    }
}