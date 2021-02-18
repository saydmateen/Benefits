using Benefits.DataAccess.EFModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Benefits.DataAccess.Interfaces
{
    public interface IBeDbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Person> Person { get; set; }
        public int SaveChanges();
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        public EntityEntry Remove(object entity);
        public void RemoveRange(params object[] entities);
        public void RemoveRange(IEnumerable<object> entities);
    }
}
