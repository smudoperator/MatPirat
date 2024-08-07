using Dinners2.CommandHandlers;
using Dinners2.Commands;
using Dinners2.Dtos;
using Dinners2.Queries;
using Dinners2.QueryHandlers;
using Dinners2.Services;
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
        private readonly DinnerService _dinnerService;
        private readonly DeleteDinnerCommandHandler _deleteDinnerHandler;
        private readonly EditDinnerCommandHandler _editDinnerHandler;

        public DinnerController(
            ILogger<DinnerController> logger,
            AddDinnerCommandHandler addDinnerHandler,
            GetDinnerQueryHandler getDinnerHandler,
            DinnerService dinnerService,
            DeleteDinnerCommandHandler deleteDinnerHandler,
            EditDinnerCommandHandler editDinnerHandler)
        {
            _logger = logger;
            _addDinnerHandler = addDinnerHandler;
            _getDinnerHandler = getDinnerHandler;
            _dinnerService = dinnerService;
            _deleteDinnerHandler = deleteDinnerHandler;
            _editDinnerHandler = editDinnerHandler;
        }

        // QUERIES

        [HttpPost("GetDinner", Name = "GetDinner")]
        public async Task<IActionResult> GetDinner(GetDinnerQuery query)
        {
            var dinner = await _getDinnerHandler.Handle(query);

            if (dinner == null)
            {
                return NotFound();
            }
            return Ok(dinner);
        }

        [HttpGet("GetDinners", Name = "GetDinners")]
        public async Task<IActionResult> GetDinners()
        {
            var dinners = await _dinnerService.GetAllDinners();

            if (dinners == null)
            {
                return NotFound();
            }
            return Ok(dinners);
        }


        // COMMANDS

        [HttpPost("AddDinner", Name = "AddDinner")]
        public async Task<IActionResult> AddDinner(AddDinnerCommand command)
        {
            await _addDinnerHandler.Handle(command);
            
            return Ok(); 
        }

        [HttpPost("EditDinner", Name = "EditDinner")]
        public async Task<IActionResult> EditDinner(EditDinnerCommand command)
        {
            await _editDinnerHandler.Handle(command);

            return Ok();
        }

        [HttpPost("DeleteDinner", Name = "DeleteDinner")]
        public async Task<IActionResult> DeleteDinner(DeleteDinnerCommand command)
        {
            await _deleteDinnerHandler.Handle(command);

            return Ok();
        }
    }
}
