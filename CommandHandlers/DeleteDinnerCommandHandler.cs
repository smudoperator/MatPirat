using Dinners2.Commands;
using Dinners2.Database;

namespace Dinners2.CommandHandlers
{
    public class DeleteDinnerCommandHandler
    {
        private readonly DinnerDb _dinnerDb;

        public DeleteDinnerCommandHandler(DinnerDb dinnerDb)
        {
            _dinnerDb = dinnerDb;
        }

        public async Task<bool> Handle(DeleteDinnerCommand command)
        {
            var dinner = await _dinnerDb.Dinners
                .FindAsync(command.Id);

            if (dinner == null)
            {
                return false;
            }

            _dinnerDb.Dinners.Remove(dinner);
            await _dinnerDb.SaveChangesAsync();
            return true;

        }
    }
}
