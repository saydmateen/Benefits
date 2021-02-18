using Benefits.Web.Repositories;
using Benefits.Web.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Benefits.Web.Models.Interfaces;
using Benefits.Web.Models;

namespace Benefits.Web.Services
{
    public class BenefitsService : IBenefitsService
    {
        private IBenefitsRepository _benefitsRepository;
        private const int _yearlyPaychecks = 26;
        private const int _benefitsCostEmployee = 1000;
        private const int _benefitsCostDependent = 500;

        public BenefitsService(IBenefitsRepository benefitsRepository)
        {
            _benefitsRepository = benefitsRepository;
        }

        public async Task<object> GetAllEmployees()
        {
            return await _benefitsRepository.SelectAllEmployees();
        }

        public async Task<object> GetEmployee(int id)
        {
            return await _benefitsRepository.SelectEmployee(id);
        }

        public async Task<object> CreateEmployee(IEmployee employee)
        {
            var employeeCalc = CalculateBenefitCost(employee);
            return await _benefitsRepository.CreateEmployee(employeeCalc);
        }

        public async Task<object> UpdateEmployee(IEmployee employee)
        {
            var employeeCalc = CalculateBenefitCost(employee);
            return await _benefitsRepository.UpdateEmployee(employeeCalc);
        }

        public async Task<object> DeleteEmployee(int id)
        {
            return await _benefitsRepository.DeleteEmployee(id);
        }

        public IEmployee CalculateBenefitCost(IEmployee employee)
        {
            const int paycheckAmount = 2000;
            const string discountLetter = "A";
            const double discountPercent = 0.1;
            int yearlySalary = paycheckAmount * _yearlyPaychecks;

            if (employee.Dependents == null)
            {
                employee.Dependents = new Person[0];
            }

            double employeeBenefitsCost = employee.FirstName.StartsWith(discountLetter, StringComparison.OrdinalIgnoreCase) ?
                    _benefitsCostEmployee - (_benefitsCostEmployee * discountPercent) :
                    _benefitsCostEmployee;
            double dependentsTotalCost = employee.Dependents.Length * _benefitsCostDependent;

            int dependentsNameDiscount = employee.Dependents.Count(d => d.FirstName.StartsWith(discountLetter, StringComparison.OrdinalIgnoreCase));
            dependentsTotalCost -= dependentsNameDiscount * (_benefitsCostDependent * discountPercent);

            employee.BenefitsCost = employeeBenefitsCost + dependentsTotalCost;
            employee.Salary = yearlySalary;
           
            return employee;
        }
    }
}
