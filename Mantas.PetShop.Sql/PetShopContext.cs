using Mantas.PetShop.Sql.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mantas.PetShop.Sql
{
    public class PetShopContext: DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> opt) : base(opt)
        {
            
        }
        
        public DbSet<PetEntity> Pet { get; set; }
        public DbSet<OwnerEntity> Owner { get; set; }
    }
}