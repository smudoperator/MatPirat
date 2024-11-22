using Dinners2.Dtos;
using Dinners2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dinners2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DinnerController : ControllerBase
    {
        private readonly ILogger<DinnerController> _logger;
        private readonly IDinnerService _dinnerService;

        public DinnerController(
            ILogger<DinnerController> logger,
            IDinnerService dinnerService
            )
        {
            _logger = logger;
            _dinnerService = dinnerService;
        }

        [HttpPost("GetDinner", Name = "GetDinner")]
        public async Task<IActionResult> GetDinner(Guid id)
        {
            var dinner = await _dinnerService.GetDinner(id);

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

        [HttpGet("GetSimpleDinners", Name = "GetSimpleDinners")]
        public async Task<IActionResult> GetSimpleDinners()
        {
            var dinners = await _dinnerService.GetAllSimpleDinners();

            if (dinners == null)
            {
                return NotFound();
            }

            return Ok(dinners);
        }


        [HttpPost("AddDinner", Name = "AddDinner")]
        public async Task<IActionResult> AddDinner(CreateDinnerDto dinner)
        {
            await _dinnerService.AddDinner(dinner);
            
            return Ok(); 
        }

        [HttpPost("EditDinner", Name = "EditDinner")]
        public async Task<IActionResult> EditDinner(DinnerDto newDinner)
        {
            var result = await _dinnerService.EditDinner(newDinner);

            if (!result)
            {
                return BadRequest(); //better handling of errors
            } 

            return Ok();
        }

        [HttpPost("DeleteDinner", Name = "DeleteDinner")]
        public async Task<IActionResult> DeleteDinner(Guid id)
        {
            await _dinnerService.DeleteDinner(id);

            return Ok();
        }

        [HttpPost("GetDinnersByTag", Name = "GetDinnersByTag")]
        public async Task<IActionResult> GetDinnersByTag(string tag)
        {
            var result = await _dinnerService.GetDinnersByTag(tag);

            if (result is null)
            {
                return BadRequest();
            }
            
            return Ok(result);
        }

        //[HttpPost("GetSimilarDinner", Name = "GetSimilarDinner")]
        //public async Task<IActionResult> GetSimilarDinner(SimpleDinnerDto dinner, List<DinnerType> dinnerTypes)
        //{
        //    var result = await _dinnerService.GetDinner(Guid.NewGuid());

        //    return Ok(dinner);
        //}
    }
}

