using System.Collections.Generic;
using System.Linq;
using Mantas.PetShop.Core.Filtering;
using Mantas.PetShop.Core.Models;
using Mantas.PetShop.Domain.IRepositories;
using Mantas.PetShop.Sql.Entities;

namespace Mantas.PetShop.Sql.Repositories
{
    public class PetRepositorySql : IPetRepository
    {
        private readonly PetShopContext _ctx;
        private IPetRepository _petRepositoryImplementation;

        public PetRepositorySql(PetShopContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Pet> GetPets(Filter filter)
        {
            var selectQuery = _ctx.Pet
                .Select(pe => new Pet
                {
                    Id = pe.Id,
                    Name = pe.Name,
                    Color = pe.Color
                });
            var paging = selectQuery.Skip(filter.Count * (filter.Page - 1))
                .Take(filter.Count); //How many to get back in the Query
            
            if (string.IsNullOrEmpty(filter.SortOrder) || filter.SortOrder.Equals("asc"))
            {
                switch (filter.SortBy)
                {
                    case "id": 
                        paging = paging.OrderBy(p => p.Id);
                        break;
                    case "name":
                        paging = paging.OrderBy(p => p.Name);
                        break;
                }
            }
            else
            {
                switch (filter.SortBy)
                {
                    case "id": 
                        paging = paging.OrderByDescending(p => p.Id);
                        break;
                    case "name":
                        paging = paging.OrderByDescending(p => p.Name);
                        break;
                }
            }
            return paging.ToList();
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

        public int Count()
        {
            return _ctx.Pet.Count();
        }
    }
}