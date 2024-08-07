﻿using Dinners2.Commands;
using Dinners2.Dtos;
using Dinners2.Services;

namespace Dinners2.CommandHandlers
{
    public class PlanDinnersCommandHandler
    {
        private readonly DinnerService _dinnerService;

        public PlanDinnersCommandHandler(
            DinnerService dinnerService)
        {
            _dinnerService = dinnerService;
        }

        public DinnerPlanDto Handle(PlanDinnersCommand command)
        {
            // Fetch all dinners
            var dinners = _dinnerService.GetAllDinners();

            // Apply filters?
            // DinnerType diversity
            // TacoFriday
            // FishCount
            // 

            // Distribute dinners over weekday


            //  

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
