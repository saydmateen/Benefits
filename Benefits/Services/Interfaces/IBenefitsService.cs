using Benefits.Web.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benefits.Web.Services.Interfaces
{
    public interface IBenefitsService
    {
        public Task<object> GetAllEmployees();
        public Task<object> GetEmployee(int id);
        public Task<object> UpdateEmployee(IEmployee employee);
        public Task<object> CreateEmployee(IEmployee employee);
        public Task<object> DeleteEmployee(int id);
        public IEmployee CalculateBenefitCost(IEmployee employee);
    }
}
