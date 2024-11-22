
namespace Dinners2.Dtos
{
    public class DinnerPlanDto
    {
        public List<DinnerDto> Dinners { get; set; } = new List<DinnerDto>();
        
        public DayOfWeek StartDay { get; set; }

        public int NumberOfDays { get; set; }

        public List<string>? ShoppingList { get; set; }

    }
}
