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

    }
}
