using System.Collections.Generic;
using System.Linq;
using Mantas.PetShop.Core.Models;
using Mantas.PetShop.Domain.IRepositories;
using Mantas.PetShop.Sql.Entities;

namespace Mantas.PetShop.Sql.Repositories
{
    public class PetTypeRepositorySql : IPetTypeRepository
    {
        private readonly PetShopContext _ctx;

        public PetTypeRepositorySql(PetShopContext ctx)
        {
            _ctx = ctx;
        }

        public PetType CreatePetType(PetType petType)
        {
            var entity = new PetTypeEntity()
            {
                Type = petType.Type
            };
            var savedEntity = _ctx.PetType.Add(entity).Entity;
            _ctx.SaveChanges();
            return new PetType()
            {
                Id = savedEntity.Id,
                Type = savedEntity.Type
            };
        }

        public IEnumerable<PetType> GetPetTypes()
        {
            return _ctx.PetType.Select(petTypeEntity => new PetType()
            {
                Id = petTypeEntity.Id,
                Type = petTypeEntity.Type
            }).ToList();
        }

        public PetType ReadPetType(int id)
        {
            return _ctx.PetType.Select(petTypeEntity => new PetType
                {
                    Id = petTypeEntity.Id,
                    Type = petTypeEntity.Type
                })
                .FirstOrDefault(o => o.Id == id);
        }

        public PetType UpdatePetType(PetType petType)
        {
            var entity = new PetTypeEntity()
            {
                Id = petType.Id,
                Type = petType.Type
            };
            var savedEntity = _ctx.PetType.Update(entity).Entity;
            _ctx.SaveChanges();
            return new PetType();
        }

        public PetType DeletePetType(int id)
        {
            var savedEntity = _ctx.PetType.Remove(new PetTypeEntity { Id = id }).Entity;
            _ctx.SaveChanges();
            return new PetType
            {
                Id = savedEntity.Id,
                Type = savedEntity.Type
            };
        }
    }
}