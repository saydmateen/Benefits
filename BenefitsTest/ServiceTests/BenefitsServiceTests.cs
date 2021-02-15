using Benefits.Models;
using Benefits.Models.Interfaces;
using Benefits.Services;
using Benefits.Services.Interfaces;
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
            _benefitsService = new BenefitsService();
        }

        // TODO add unit tests for dependents
        [Test]
        public async Task CalculateCosts_SingleEmployee_NoDependents_Success()
        {
            Employee[] list = new Employee[]
            {
                new Employee { FirstName = "Luke", LastName = "Skywalker", Dependents = new IPerson[0] }
            };

            var results = (IEmployee[])await _benefitsService.CalculateCost(list);
            var employee = results.FirstOrDefault();
            Assert.AreEqual(1000, employee.BenefitsCost);
        }

        [Test]
        public async Task CalculateCosts_SingleEmployee_NoDependents_Fail()
        {
            Employee[] list = new Employee[]
           {
                new Employee { FirstName = "Luke", LastName = "Skywalker", Dependents = new IPerson[0] }
           };

            var results = (IEmployee[])await _benefitsService.CalculateCost(list);
            var employee = results.FirstOrDefault();
            Assert.AreNotEqual(1000.50, employee.BenefitsCost);
        }

        [Test]
        public async Task CalculateCosts_MultiEmployee_NoDependents_Success()
        {
            Employee[] list = new Employee[]
            {
                new Employee { FirstName = "Luke", LastName = "Skywalker", Dependents = new IPerson[0] },
                new Employee { FirstName = "Spongebob", LastName = "Squarepants", Dependents = new IPerson[0] },
                new Employee { FirstName = "Rick", LastName = "Sanchez", Dependents = new IPerson[0] }
            };

            var results = (IEmployee[])await _benefitsService.CalculateCost(list);
            var employeesTotal = results.Aggregate((total, next) =>
            {
                total.BenefitsCost = total.BenefitsCost + next.BenefitsCost;
                return total;
            });
            Assert.AreEqual(3000, employeesTotal.BenefitsCost);
        }

        [Test]
        public async Task CalculateCosts_MultiEmployee_NoDependents_Fail()
        {
            Employee[] list = new Employee[]
           {
                new Employee { FirstName = "Luke", LastName = "Skywalker", Dependents = new IPerson[0] },
                new Employee { FirstName = "Spongebob", LastName = "Squarepants", Dependents = new IPerson[0] },
                new Employee { FirstName = "Rick", LastName = "Sanchez", Dependents = new IPerson[0] }
           };

            var results = (IEmployee[])await _benefitsService.CalculateCost(list);
            var employeesTotal = results.Aggregate((total, next) =>
            {
                total.BenefitsCost = total.BenefitsCost + next.BenefitsCost;
                return total;
            });
            Assert.AreNotEqual(3000.1, employeesTotal.BenefitsCost);
        }

        [Test]
        public async Task CalculateCosts_SingleEmployee_NoDependents_WithDiscount_Success()
        {
            Employee[] list = new Employee[]
            {
                new Employee { FirstName = "Anakin", LastName = "Skywalker", Dependents = new IPerson[0] }
            };

            var results = (IEmployee[])await _benefitsService.CalculateCost(list);
            var employee = results.FirstOrDefault();
            Assert.AreEqual(900, employee.BenefitsCost);
        }

        [Test]
        public async Task CalculateCosts_SingleEmployee_NoDependents_WithDiscount_Fail()
        {
            Employee[] list = new Employee[]
           {
                new Employee { FirstName = "Anakin", LastName = "Skywalker", Dependents = new IPerson[0] }
           };

            var results = (IEmployee[])await _benefitsService.CalculateCost(list);
            var employee = results.FirstOrDefault();
            Assert.AreNotEqual(1000, employee.BenefitsCost);
        }
    }
}