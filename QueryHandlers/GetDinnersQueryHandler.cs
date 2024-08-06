using Dinners2.Database;
using Dinners2.Dtos;
using Dinners2.Queries;
using Microsoft.EntityFrameworkCore;

namespace Dinners2.QueryHandlers
{
    public class GetDinnersQueryHandler
    {
        private readonly DinnerDb _dinnerDb;

        public GetDinnersQueryHandler(DinnerDb dinnerDb)
        {
            _dinnerDb = dinnerDb;
        }

        public Task<List<DinnerDto>> Handle(GetDinnersQuery query)
        {
            var dinnersList = _dinnerDb.Dinners.ToListAsync();

            if (dinnersList is null)
            {
                // handle exceptions
            }

            return dinnersList;
        }
    }
}
