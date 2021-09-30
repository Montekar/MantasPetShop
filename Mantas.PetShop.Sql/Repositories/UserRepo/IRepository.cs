using System.Collections.Generic;

namespace Mantas.PetShop.Sql.Repositories.UserRepo
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Add(T entity);
        void Edit(T entity);
        void Remove(long id);
    }
}