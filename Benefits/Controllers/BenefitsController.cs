using Benefits.Models;
using Benefits.Models.Interfaces;
using Benefits.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Benefits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitsController : ControllerBase
    {
        private readonly ILogger<BenefitsController> _logger;
        private readonly IBenefitsService _benefitsService;

        public BenefitsController(ILogger<BenefitsController> logger, IBenefitsService benefitsService)
        {
            _logger = logger;
            _benefitsService = benefitsService;
        }

        [HttpGet]
        [Route("employeesAll")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var result = await _benefitsService.GetAllEmployees();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("employee")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var result = await _benefitsService.GetEmployee(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("employees")]
        public async Task<IActionResult> CreateEmployees([FromBody]Employee employee)
        {
            try
            {
                var result = await _benefitsService.CreateEmployee(employee);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("employees")]
        public async Task<IActionResult> UpdateEmployees([FromBody]Employee employee)
        {
            try
            {
                var result = await _benefitsService.UpdateEmployee(employee);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("employees")]
        public async Task<IActionResult> DeleteEmployees(int id)
        {
            try
            {
                var result = await _benefitsService.DeleteEmployee(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("previewcosts")]
        public async Task<IActionResult> PreviewListCosts(Employee[] employees)
        {
            try
            {
                var result = await _benefitsService.CalculateCost(employees);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
