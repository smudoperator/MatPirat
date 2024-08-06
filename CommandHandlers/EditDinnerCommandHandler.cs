using Dinners2.Commands;
using Dinners2.Database;

namespace Dinners2.CommandHandlers
{
    public class EditDinnerCommandHandler
    {

        private readonly DinnerDb _dinnerDb;

        public EditDinnerCommandHandler(DinnerDb dinnerDb)
        {
            _dinnerDb = dinnerDb;
        }

        public async Task<bool> Handle(EditDinnerCommand command)
        {
            var dinner = await _dinnerDb.Dinners.FindAsync(command.Id);

            if (dinner is null)
            {
                return false;
            }

            // Maybe add a proper mapper to deal with null values
            dinner.Name = command.Name;
            dinner.Description = command.Description;
            dinner.Type = command.Type;
            dinner.MeatType = command.MeatType;
            dinner.Ingredients = command.Ingredients;
            dinner.Tags = command.Tags;
            dinner.ImageData = command.ImageData;

            await _dinnerDb.SaveChangesAsync();

            return true;
        }
    }
}
