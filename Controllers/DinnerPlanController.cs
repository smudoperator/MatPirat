using Dinners2.CommandHandlers;
using Dinners2.Commands;
using Dinners2.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Dinners2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DinnerPlanController : ControllerBase
    {
        private readonly ILogger<DinnerPlanController> _logger;
        private readonly PlanDinnersCommandHandler _commandHandler;

        public DinnerPlanController(ILogger<DinnerPlanController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "PlanDinners")]
        public ActionResult<DinnerPlanDto> PlanDinners(CreateDinnerPlanDto request)
        {
            var command = new PlanDinnersCommand();
            var result = _commandHandler.Handle(command);

            if (result is null)
            {
                return BadRequest(); // Fix this
            }
            return Ok(result);
        }
    }
}
