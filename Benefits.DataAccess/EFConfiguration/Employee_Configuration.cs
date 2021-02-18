using Benefits.DataAccess.EFModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benefits.DataAccess.EFConfiguration
{
    internal class Employee_Configuration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .Property(b => b.FirstName)
                .IsRequired();

            builder
                .Property(b => b.LastName)
                .IsRequired();
        }
    }
}
