using Dinners2.Dtos;
using Dinners2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dinners2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DinnerPlanController : ControllerBase
    {
        private readonly ILogger<DinnerPlanController> _logger;
        private readonly IDinnerPlanService _dinnerPlanService;

        public DinnerPlanController(
            ILogger<DinnerPlanController> logger,
            IDinnerPlanService dinnerPlanService)
        {
            _logger = logger;
            _dinnerPlanService = dinnerPlanService;
        }


        [HttpPost("PlanDinners", Name = "PlanDinners")]
        public ActionResult<DinnerPlanDto> PlanDinners([FromBody] CreateDinnerPlanDto request)
        {
            var result = _dinnerPlanService.PlanDinners(request);

            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
