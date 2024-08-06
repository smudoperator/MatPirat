using Dinners2.CommandHandlers;
using Dinners2.Commands;
using Dinners2.Dtos;
using Dinners2.Queries;
using Dinners2.QueryHandlers;
using Microsoft.AspNetCore.Mvc;

namespace Dinners2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DinnerController : ControllerBase
    {
        private readonly ILogger<DinnerController> _logger;

        private readonly AddDinnerCommandHandler _addDinnerHandler;
        private readonly GetDinnerQueryHandler _getDinnerHandler;
        private readonly GetDinnersQueryHandler _getDinnersHandler;
        private readonly DeleteDinnerCommandHandler _deleteDinnerHandler;
        private readonly EditDinnerCommandHandler _editDinnerHandler;

        public DinnerController(ILogger<DinnerController> logger)
        {
            _logger = logger;
        }

        // QUERIES

        [HttpGet(Name = "GetDinner")]
        public async Task<IActionResult> GetDinner(GetDinnerQuery query)
        {
            return Ok();
        }

        [HttpGet(Name = "GetDinners")]
        public async Task<IActionResult> GetDinners(GetDinnersQuery query)
        {
            // await _getDinnersHandler
            return Ok();
        }


        // COMMANDS

        [HttpPost(Name = "AddDinner")]
        public async Task<IActionResult> AddDinner(AddDinnerCommand command)
        {
            await _addDinnerHandler.Handle(command);
            
            return Ok(); 
        }

        [HttpPost(Name = "EditDinner")]
        public async Task<IActionResult> EditDinner(EditDinnerCommand command)
        {
            await _editDinnerHandler.Handle(command);

            return Ok();
        }

        [HttpPost(Name = "DeleteDinner")]
        public async Task<IActionResult> DeleteDinner(DeleteDinnerCommand command)
        {
            await _deleteDinnerHandler.Handle(command);

            return Ok();
        }
    }
}
