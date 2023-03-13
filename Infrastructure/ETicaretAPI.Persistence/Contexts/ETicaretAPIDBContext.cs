using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDBContext : DbContext
    {
        public ETicaretAPIDBContext(DbContextOptions options) : base(options) {}

        public DbSet<Product> Products{ get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Order> Orders{ get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added =>data.Entity.CreateDate=DateTime.Now,
                    EntityState.Modified=>data.Entity.UpdateDate=DateTime.Now,
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
