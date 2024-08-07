using Dinners2.Dtos;

namespace Dinners2.Commands
{
    public class PlanDinnersCommand
    {
        public int Days { get; set; }
        public DayOfWeek StartDay { get; set; }
        public int FishAmount { get; set; }
        public bool TacoFriday { get; set; } = false;
        public List<DinnerType> DinnerTypePreferences { get; set; } = new List<DinnerType>();
    }
}
