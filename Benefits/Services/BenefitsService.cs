using Benefits.Models;
using Benefits.Models.Interfaces;
using Benefits.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benefits.Services
{
    public class BenefitsService : IBenefitsService
    {
        private const int _yearlyPaychecks = 26;
        private const int _benefitsCostEmployee = 1000;
        private const int _benefitsCostDependent = 500;

        public async Task<object> CalculateCost(IEmployee[] employees)
        {
           return await Task.Run<object>(() =>
           {
               const int paycheckAmount = 2000;
               const string discountLetter = "A";
               const double discountPercent = 0.1;
               int yearlySalary = paycheckAmount * _yearlyPaychecks;

               foreach (var employee in employees)
               {
                   // TODO handle empty dependents
                   double employeeBenefitsCost = employee.FirstName.StartsWith(discountLetter, StringComparison.OrdinalIgnoreCase) ?
                           _benefitsCostEmployee - (_benefitsCostEmployee * discountPercent) :
                           _benefitsCostEmployee;
                   double dependentsTotalCost = employee.Dependents.Length * _benefitsCostDependent;

                   int dependentsNameDiscount = employee.Dependents.Count(d => d.FirstName.StartsWith(discountLetter, StringComparison.OrdinalIgnoreCase));                   
                   dependentsTotalCost -= dependentsNameDiscount * (_benefitsCostDependent * discountPercent);

                   employee.BenefitsCost = employeeBenefitsCost + dependentsTotalCost;
                   employee.Salary = yearlySalary;
               }

               return employees;
           });
        }

        public async Task<object> GetEmployees()
        {
            return await Task.Run<object>(() =>
            {
                var employees = new Employee[] {
                    new Employee { FirstName = "Luke", LastName = "Skywalker", EmployeeId = 1, Salary = 5000, Age = 30 },
                    new Employee { FirstName = "Rick", LastName = "Sanchez", EmployeeId = 2, Salary = 6000, Age = 50 }
                };

                return employees;
            });
        }
    }
}
