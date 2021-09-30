using System.Collections.Generic;
using System.Linq;
using Mantas.PetShop.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Mantas.PetShop.Sql.Repositories.UserRepo

{
    public class UserRepository : IRepository<User>
    {

        private readonly PetShopContext db;

        public UserRepository(PetShopContext context)
        {
            db = context;
        }
        
        public IEnumerable<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User Get(long id)
        {
            return db.Users.FirstOrDefault(b => b.Id == id);    
        }

        public void Add(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
        }

        public void Edit(User entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Remove(long id)
        {
            var item = Get(id);
            db.Users.Remove(item);
            db.SaveChanges();
        }
    }
}