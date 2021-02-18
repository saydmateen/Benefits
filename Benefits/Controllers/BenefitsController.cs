using Benefits.Web.Models;
using Benefits.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Benefits.Web.Controllers
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
        [Route("employee/{id}")]
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
        [Route("employee")]
        public async Task<IActionResult> CreateEmployee([FromBody]Employee employee)
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
        [Route("employee")]
        public async Task<IActionResult> UpdateEmployee([FromBody]Employee employee)
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
        [Route("employee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
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
    }
}
