using Benefits.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benefits.Models
{
    public class Employee : IEmployee
    {
        public int EmployeeId { get; set; }
        public double Salary { get; set; }
        public double BenefitsCost { get; set; }
        public IPerson[] Dependents { get; set; }
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Relationship { get; set; }
    }
}
