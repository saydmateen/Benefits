using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benefits.Web.Models.Interfaces
{
    public interface IEmployee : IPerson
    {
        public int EmployeeId { get; set; }
        public double Salary { get; set; }
        public double BenefitsCost { get; set; }
        public Person[] Dependents { get; set; }
    }
}
