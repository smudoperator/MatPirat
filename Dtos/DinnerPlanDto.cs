using System.ComponentModel.DataAnnotations;

namespace Dinners2.Dtos
{
    public class DinnerPlanDto
    {
        
        public DinnerPlanDto(
            List<DinnerDto> dinners,
            DayOfWeek startDay,
            int numberOfDays)
        {
            Dinners = dinners;
            StartDay = startDay;
            NumberOfDays = numberOfDays;
        }
        
        public List<DinnerDto> Dinners { get; set; } = new List<DinnerDto>();
        
        public DayOfWeek StartDay { get; set; }

        public int NumberOfDays { get; set; }
    }
}
