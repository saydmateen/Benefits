using Benefits.Web.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benefits.Web.Repositories
{
    public interface IBenefitsRepository
    {
        public Task<object> SelectAllEmployees();
        public Task<object> SelectEmployee(int id);
        public Task<int> CreateEmployee(IEmployee employee);
        public Task<int> UpdateEmployee(IEmployee employee);
        public Task<int> DeleteEmployee(int id);
    }
}
