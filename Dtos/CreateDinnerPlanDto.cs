namespace Dinners2.Dtos
{
    public class CreateDinnerPlanDto
    {
        public bool TacoFriday { get; set; } = true;

        public DayOfWeek StartDay { get; set; } = DayOfWeek.Monday;

        public int NumberOfDays { get; set; } = 5;

        public int NumberOfFish { get; set; } = 0;
    }
}
