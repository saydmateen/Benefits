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
        private IBenefitsService _benefitsService;

        public BenefitsController(ILogger<BenefitsController> logger, IBenefitsService benefitsService)
        {
            _logger = logger;
            _benefitsService = benefitsService;
        }

        [HttpPost]
        [Route("preview")]
        public async Task<IActionResult> PreviewCosts(Employee[] employees)
        {
            // TODO update controller 
            try
            {
                _benefitsService.CalculateCosts(employees);
                return Ok("test");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
