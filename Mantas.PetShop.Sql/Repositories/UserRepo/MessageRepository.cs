using System.Collections.Generic;
using System.Linq;
using Mantas.PetShop.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Mantas.PetShop.Sql.Repositories.UserRepo
{
    public class MessageRepository : IRepository<Message>
    {

        private readonly PetShopContext db;
        
        public MessageRepository(PetShopContext context)
        {
            db = context;
        }
        
        public IEnumerable<Message> GetAll()
        {
            return db.Messages.ToList();
        }

        public Message Get(long id)
        {
            return db.Messages.FirstOrDefault(message => message.Id == id);
        }

        public void Add(Message entity)
        {
            db.Messages.Add(entity);
            db.SaveChanges();
        }

        public void Edit(Message entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Remove(long id)
        {
            var message = db.Messages.FirstOrDefault(message => message.Id == id);
            if (message == null) return;
            db.Messages.Remove(message);
            db.SaveChanges();
        }
    }
}