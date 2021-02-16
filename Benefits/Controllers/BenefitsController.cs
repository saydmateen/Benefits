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
        [Route("employees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var result = await _benefitsService.GetEmployees();
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
