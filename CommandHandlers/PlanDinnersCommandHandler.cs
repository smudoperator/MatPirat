using Dinners2.Commands;
using Dinners2.Dtos;

namespace Dinners2.CommandHandlers
{
    public class PlanDinnersCommandHandler
    {
        public DinnerPlanDto Handle(PlanDinnersCommand command)
        {
            // Some database stuff

            var dinnerList = new List<DinnerDto>();
            var dinnerPlan = new DinnerPlanDto(
                dinners: dinnerList,
                startDay: DayOfWeek.Monday,
                numberOfDays: 5
                );
            
            return dinnerPlan;
        }
    }
}
