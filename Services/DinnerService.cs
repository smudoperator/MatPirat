using Dinners2.Database;
using Dinners2.Dtos;
using Dinners2.Queries;
using Microsoft.EntityFrameworkCore;

namespace Dinners2.Services
{
    public class DinnerService
    {

        private readonly DinnerDb _dinnerDb;

        public DinnerService(DinnerDb dinnerDb)
        {
            _dinnerDb = dinnerDb;
        }

        public async Task<List<DinnerDto>> GetAllDinners()
        {
            var dinners = await _dinnerDb.Dinners.ToListAsync();

            if (dinners is null)
            {
                // handle exceptions
            }

            return dinners;
        }
    }
}
