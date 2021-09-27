using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SynetecAssessmentApi.Bl.Services;
using SynetecAssessmentApi.Domain.Dtos;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BonusPoolController : ControllerBase
    {
        private readonly IBonusPoolService _bonusPoolService;

        public BonusPoolController(IBonusPoolService bonusPoolService)
        {
            _bonusPoolService = bonusPoolService;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateBonus([FromBody] CalculateBonusDto request)
        {
            if (request?.SelectedEmployeeId == null)
            {
                return BadRequest();
            }

            var response =
                await _bonusPoolService.CalculateAsync(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }


            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var response = await _bonusPoolService.GetAllEmployeesAsync();

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
