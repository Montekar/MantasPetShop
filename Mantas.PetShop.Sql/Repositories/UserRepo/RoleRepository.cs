using System.Collections.Generic;
using System.Linq;
using Mantas.PetShop.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Mantas.PetShop.Sql.Repositories.UserRepo
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly PetShopContext db;

        public RoleRepository(PetShopContext context)
        {
            db = context;
        }
        
        public IEnumerable<Role> GetAll()
        {
            return db.Roles;
        }

        public Role Get(long id)
        {
            return db.Roles.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Role entity)
        {
            db.Roles.Add(entity);
            db.SaveChanges();
        }

        public void Edit(Role entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Remove(long id)
        {
            var item = Get(id);
            db.Roles.Remove(item);
            db.SaveChanges();
        }
    }
}