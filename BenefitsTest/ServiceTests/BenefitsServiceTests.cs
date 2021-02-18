using Benefits.Web.Models;
using Benefits.Web.Models.Interfaces;
using Benefits.Web.Repositories;
using Benefits.Web.Services;
using Benefits.Web.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsTest
{
    [TestFixture]
    public class BenefitsServiceTests
    {
        private IBenefitsService _benefitsService;

        [SetUp]
        public void Setup()
        {
            var emp1 = new Employee
            {
                FirstName = "Luke",
                LastName = "Skywalker",
                Age = 22,
                BenefitsCost = 1000,
                Dependents = new Person[0],
                EmployeeId = 1,
                Salary = 52000
            };

            var emp2 = new Employee
            {
                FirstName = "Anakin",
                LastName = "Skywalker",
                Age = 38,
                BenefitsCost = 900,
                Dependents = new Person[0],
                EmployeeId = 2,
                Salary = 52000
            };

            List<Employee> empList = new List<Employee> { emp1, emp2 };
                
            var benefitsRepository = new Mock<IBenefitsRepository>();
            benefitsRepository.Setup(x => x.SelectAllEmployees())
                .ReturnsAsync(empList);
            benefitsRepository.Setup(x => x.DeleteEmployee(3))
                .ReturnsAsync(1);

            _benefitsService = new BenefitsService(benefitsRepository.Object);
        }

        [Test]
        public async Task SelectAllEmployees_Success()
        {
            var results = (List<Employee>)await _benefitsService.GetAllEmployees();
            var employee = results.FirstOrDefault(e => e.EmployeeId == 1);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(1000, employee.BenefitsCost);
        }

        [Test]
        public async Task SelectAllEmployees_Failure()
        {
            var results = (List<Employee>)await _benefitsService.GetAllEmployees();
            var employee = results.FirstOrDefault(e => e.EmployeeId == 2);
            Assert.AreEqual(2, results.Count);
            Assert.AreNotEqual(1000, employee.BenefitsCost);
        }

        [Test]
        public async Task DeleteEmployee_Success()
        {
            var id = 3;
            var results = (int)await _benefitsService.DeleteEmployee(id);
            Assert.AreEqual(1, results);
        }

        [Test]
        public void CalculateCosts_NoNameDiscount_Success()
        {
            Employee emp = new Employee { FirstName = "Luke", LastName = "Skywalker", Dependents = new Person[0] };
            var results = _benefitsService.CalculateBenefitCost(emp);
            Assert.AreEqual(1000, results.BenefitsCost);
        }

        [Test]
        public void CalculateCosts_NoNameDiscount_Failure()
        {
            Employee emp = new Employee { FirstName = "Luke", LastName = "Skywalker", Dependents = new Person[0] };
            var results = _benefitsService.CalculateBenefitCost(emp);
            Assert.AreNotEqual(900, results.BenefitsCost);
        }

        [Test]
        public void CalculateCosts_WithNameDiscount_Successs()
        {
            Employee emp = new Employee { FirstName = "Anakin", LastName = "Skywalker", Dependents = new Person[0] };

            var results = _benefitsService.CalculateBenefitCost(emp);
            Assert.AreEqual(900, results.BenefitsCost);
        }

        [Test]
        public void CalculateCosts_WithNameDiscount_Failure()
        {
            Employee emp = new Employee { FirstName = "Anakin", LastName = "Skywalker", Dependents = new Person[0] };

            var results = _benefitsService.CalculateBenefitCost(emp);
            Assert.AreNotEqual(1000, results.BenefitsCost);
        }


        [Test]
        public void CalculateCosts_Dependents_WithDiscount_Success()
        {
            Employee emp = new Employee {
                FirstName = "Anakin",
                LastName = "Skywalker",
                Dependents = new Person[] {
                    new Person { FirstName = "Baby", LastName = "Yoda", Age = 1000, Relationship = "other" }
                }
            };

            var results = _benefitsService.CalculateBenefitCost(emp);
            Assert.AreEqual(1400, results.BenefitsCost);
        }

        [Test]
        public void CalculateCosts_Dependents_WithDiscount_Failure()
        {
            Employee emp = new Employee
            {
                FirstName = "Anakin",
                LastName = "Skywalker",
                Dependents = new Person[] {
                    new Person { FirstName = "Baby", LastName = "Yoda", Age = 1000, Relationship = "other" }
                }
            };

            var results = _benefitsService.CalculateBenefitCost(emp);
            Assert.AreNotEqual(1500, results.BenefitsCost);
        }
    }
}