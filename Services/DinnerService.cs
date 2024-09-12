using Dinners2.Database;
using Dinners2.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Dinners2.Services
{
    public class DinnerService : IDinnerService
    {

        private readonly DinnerDb _dinnerDb;
        private readonly ILogger<DinnerService> _logger;

        public DinnerService(
            DinnerDb dinnerDb,
            ILogger<DinnerService> logger)
        {
            _dinnerDb = dinnerDb;
            _logger = logger;
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

        public async Task<DinnerDto> GetDinner(Guid id)
        {
            var dinner = await _dinnerDb.Dinners.FirstOrDefaultAsync(x => x.Id == id);

            if (dinner is null)
            {
                _logger.Log(LogLevel.Error, $"Dinner with id {id} is null");
                throw new Exception();
            }
            return dinner;
        }

        public async Task AddDinner(CreateDinnerDto dinner)
        {
            var newDinner = new DinnerDto
            {
                Id = Guid.NewGuid(),
                Name = dinner.Name,
                Description = dinner.Description,
                Type = dinner.Type,
                MeatType = dinner.MeatType,
                SkillLevel = dinner.SkillLevel,
                Ingredients = dinner.Ingredients,
                Tags = dinner.Tags,
                ImageData = dinner.ImageData
            };

            _dinnerDb.Dinners.Add(newDinner);

            await _dinnerDb.SaveChangesAsync();
        }

        public async Task<bool> EditDinner(DinnerDto newDinner)
        {
            var dinner = await _dinnerDb.Dinners.FindAsync(newDinner.Id);

            if (dinner is null)
            {
                return false;
            }

            // Maybe add a proper mapper to deal with null values
            // or maybe not hehe
            dinner.Name = newDinner.Name;
            dinner.Description = newDinner.Description;
            dinner.Type = newDinner.Type;
            dinner.MeatType = newDinner.MeatType;
            dinner.SkillLevel = newDinner.SkillLevel;
            dinner.Ingredients = newDinner.Ingredients;
            dinner.Tags = newDinner.Tags;
            dinner.ImageData = newDinner.ImageData;

            await _dinnerDb.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteDinner(Guid id)
        {
            var dinner = await _dinnerDb.Dinners
                .FirstOrDefaultAsync(x => x.Id == id);

            if (dinner is null)
            {
                return false;
            }

            _dinnerDb.Dinners.Remove(dinner);
            await _dinnerDb.SaveChangesAsync();


            return true;
        }

        public async Task<List<DinnerDto>> GetDinnersByTag(string tag)
        {
            // since i don't want to bother creating a separate table for tags, we'll have to settle for 
            // client side filtering here due to sql's lack of support for any useful string comparer
            var result = await _dinnerDb.Dinners.ToListAsync();
                
            result = result
                .Where(x => x.Tags.Any(t => t.ToLower().Contains(tag.ToLower())))
                .ToList();    

            if (result is not null)
            {
                return result;
            }

            return result;
        }

        public async Task<DinnerDto> GetTaco()
        {
            var taco = await _dinnerDb.Dinners.FirstOrDefaultAsync(x => x.Name.ToLower().Contains("taco"));
            return taco;
        }
    }
}
