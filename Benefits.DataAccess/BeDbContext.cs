using Benefits.DataAccess.EFConfiguration;
using Benefits.DataAccess.EFModels;
using Benefits.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Benefits.DataAccess
{
    public class BeDbContext : DbContext, IBeDbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Person> Person { get; set; }

        public BeDbContext(DbContextOptions<BeDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Employee_Configuration());
            modelBuilder.ApplyConfiguration(new Person_Configuration());
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public override EntityEntry Remove(object entity)
        {
            return base.Remove(entity);
        }

        public override void RemoveRange(params object[] entities)
        {
            base.RemoveRange(entities);
        }

        public override void RemoveRange(IEnumerable<object> entities)
        {
            base.RemoveRange(entities);
        }
    }
}
