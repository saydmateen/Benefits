using Benefits.DataAccess.Interfaces;
using Benefits.Web.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Benefits.Web.Repositories
{
    public class BenefitsRepository : IBenefitsRepository
    {
        protected IBeDbContext _context;
        public BenefitsRepository(IBeDbContext dbContext) 
        {
            _context = dbContext;
        }

        public async Task<object> SelectAllEmployees()
        {
            var queryData = await _context.Employee
                .Select(s => new
                {
                    EmployeeId = s.EmployeeId,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Age = s.Age,
                    Salary = s.Salary,
                    BenefitsCost = s.BenefitsCost,
                    Dependents = s.Dependents
                })
                .ToListAsync();

            return queryData;
        }

        public async Task<object> SelectEmployee(int id)
        {
            var queryData = await _context.Employee.Where(e => e.EmployeeId == id)
                .Select(s => new
                {
                    EmployeeId = s.EmployeeId,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Age = s.Age,
                    Salary = s.Salary,
                    BenefitsCost = s.BenefitsCost,
                    Dependents = s.Dependents
                })
                .FirstOrDefaultAsync();

            return queryData;
        }

        public async Task<int> CreateEmployee(IEmployee employee)
        {
            _context.Employee.Add(new DataAccess.EFModels.Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Dependents = Array.ConvertAll(employee.Dependents, x => new DataAccess.EFModels.Person
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    Relationship = x.Relationship
                }),
                Age = employee.Age,
                BenefitsCost = employee.BenefitsCost,
                Salary = employee.Salary
            });

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateEmployee(IEmployee employee)
        {
            var employeeRecord = await _context.Employee.Where(e => e.EmployeeId == employee.EmployeeId)
                .Include(e => e.Dependents).FirstOrDefaultAsync();
           
            employeeRecord.FirstName = employee.FirstName;
            employeeRecord.LastName = employee.LastName;
            employeeRecord.Age = employee.Age;
            employeeRecord.BenefitsCost = employee.BenefitsCost;
            employeeRecord.Salary = employee.Salary;

            var deleteList = employeeRecord.Dependents.Where(d => !employee.Dependents.Any(x => x.PersonId == d.PersonId));
            if (deleteList.Any())
            {
                _context.RemoveRange(deleteList);
            }

            foreach (var dependent in employee.Dependents)
            {
                if (dependent.PersonId == 0)
                {
                    employeeRecord.Dependents.Add(new DataAccess.EFModels.Person
                    {
                        FirstName = dependent.FirstName,
                        LastName = dependent.LastName,
                        Age = dependent.Age,
                        Relationship = dependent.Relationship
                    });
                }
                else
                {
                    var findDependent = employeeRecord.Dependents.FirstOrDefault(x => x.PersonId == dependent.PersonId);
                    if (findDependent != null)
                    {
                        findDependent.FirstName = dependent.FirstName;
                        findDependent.LastName = dependent.LastName;
                        findDependent.Age = dependent.Age;
                        findDependent.Relationship = dependent.Relationship;
                    }
                }
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteEmployee(int id)
        {
            var employeeRecord = await _context.Employee.Where(e => e.EmployeeId == id)
                .Include(e => e.Dependents)
                .FirstOrDefaultAsync();

            _context.Remove(employeeRecord);

            return await _context.SaveChangesAsync();
        }
    }
}
