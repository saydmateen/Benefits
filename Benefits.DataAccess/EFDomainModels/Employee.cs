using System.Collections.Generic;

namespace Benefits.DataAccess.EFModels
{
    public partial class Employee 
    {
        public int EmployeeId { get; set; }
        public double Salary { get; set; }
        public double BenefitsCost { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Person> Dependents { get; set; }
    }
}
