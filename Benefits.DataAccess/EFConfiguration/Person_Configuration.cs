using Benefits.DataAccess.EFModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benefits.DataAccess.EFConfiguration
{
    internal class Person_Configuration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .Property(b => b.FirstName)
                .IsRequired();

            builder
                .Property(b => b.LastName)
                .IsRequired();

            builder.HasOne<Employee>(s => s.Employee)
                .WithMany(g => g.Dependents)
                .HasForeignKey(s => s.RelatedEmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
