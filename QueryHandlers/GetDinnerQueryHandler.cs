using Dinners2.Database;
using Dinners2.Dtos;
using Dinners2.Queries;
using Microsoft.EntityFrameworkCore;

namespace Dinners2.QueryHandlers
{
    public class GetDinnerQueryHandler
    {
        private readonly DinnerDb _dinnerDb;

        public GetDinnerQueryHandler(DinnerDb dinnerDb)
        {
            _dinnerDb = dinnerDb;
        }

        public async Task<DinnerDto> Handle(GetDinnerQuery query)
        {
            var dinner = await _dinnerDb.Dinners
                .FirstOrDefaultAsync(x => x.Id == query.Id);

            if (dinner is null)
            {
                // handle exceptions
            }

            return dinner;
        } 
    }
}
