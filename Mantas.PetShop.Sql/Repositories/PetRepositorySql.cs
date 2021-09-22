using System.Collections.Generic;
using System.Linq;
using Mantas.PetShop.Core.Models;
using Mantas.PetShop.Domain.IRepositories;
using Mantas.PetShop.Sql.Entities;

namespace Mantas.PetShop.Sql.Repositories
{
    public class PetRepositorySql : IPetRepository
    {
        private readonly PetShopContext _ctx;
        
        public PetRepositorySql(PetShopContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Pet> GetPets()
        {
            return _ctx.Pet
                .Select(savedEntity => new Pet
                {
                    Id = savedEntity.Id,
                    Name = savedEntity.Name,
                    Color = savedEntity.Color,
                    Price = savedEntity.Price,
                    Owner = new Owner
                    {
                        Id = savedEntity.OwnerId.HasValue ? savedEntity.OwnerId.Value : 0
                    }
                })
                .ToList();
        }

        public Pet CreatePet(Pet pet)
        {
            var entity = new PetEntity
            {
                Name = pet.Name,
                Color = pet.Color,
                Price = pet.Price,
                OwnerId = pet.Owner.Id
            };
            var savedEntity = _ctx.Pet.Add(entity).Entity;
            _ctx.SaveChanges();
            return new Pet
            {
                Id = savedEntity.Id,
                Name = savedEntity.Name,
                Color = savedEntity.Color,
                Price = savedEntity.Price,
                Owner = new Owner
                {
                    Id = savedEntity.OwnerId ?? 0
                }
            };
        }

        public Pet DeletePet(int id)
        {
            var savedEntity = _ctx.Pet.Remove(new PetEntity { Id = id }).Entity;
            _ctx.SaveChanges();
            return new Pet
            {
                Id = savedEntity.Id,
                Name = savedEntity.Name,
                Color = savedEntity.Color,
                Price = savedEntity.Price,
                Owner = new Owner
                {
                    Id = savedEntity.OwnerId ?? 0
                }
            };
        }

        public Pet UpdatePet(Pet pet)
        {
            var entity = new PetEntity()
            {
                Id = pet.Id,
                Name = pet.Name,
                Color = pet.Color,
                Price= pet.Price,
                OwnerId = pet.Owner.Id
            };
            var savedEntity = _ctx.Pet.Update(entity).Entity;
            _ctx.SaveChanges();
            return new Pet
            {
                Id = savedEntity.Id,
                Name = savedEntity.Name,
                Color = savedEntity.Color,
                Price = savedEntity.Price,
                Owner = new Owner
                {
                    Id = savedEntity.OwnerId ?? 0
                }
            };
        }

        public Pet SearchPet(int id)
        {
            return _ctx.Pet
                .Select(savedEntity => new Pet
                {
                    Id = savedEntity.Id,
                    Name = savedEntity.Name,
                    Color = savedEntity.Color,
                    Price = savedEntity.Price,
                    Owner = new Owner()
                    {
                        Id = savedEntity.OwnerId ?? 0
                    }
                })
                .FirstOrDefault(v => v.Id == id);
        }
    }
}