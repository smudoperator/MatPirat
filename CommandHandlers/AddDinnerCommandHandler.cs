using Dinners2.Commands;
using Dinners2.Database;
using Dinners2.Dtos;

namespace Dinners2.CommandHandlers
{
    public class AddDinnerCommandHandler
    {
        private readonly DinnerDb _dinnerDb;

        public AddDinnerCommandHandler(DinnerDb dinnerDb) // database dinnerDb stuff)
        {
            _dinnerDb = dinnerDb;
        }

        public async Task Handle(AddDinnerCommand command)
        {
            var dinner = new DinnerDto
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Description = command.Description,
                Type = command.Type,
                MeatType = command.MeatType,
                Ingredients = command.Ingredients,
                Tags = command.Tags,
                ImageData = command.ImageData
            };

            _dinnerDb.Dinners.Add(dinner);
            await _dinnerDb.SaveChangesAsync();
        }
    }
}
