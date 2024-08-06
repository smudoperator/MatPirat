namespace Dinners2.Dtos
{
    public class CreateDinnerPlanDto
    {
        public bool TacoFriday { get; set; }

        public DayOfWeek StartDay { get; set; }

        public int NumberOfDays { get; set; }
    }
}
