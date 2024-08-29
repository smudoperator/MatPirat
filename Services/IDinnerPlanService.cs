using Dinners2.Dtos;

namespace Dinners2.Services
{
    public interface IDinnerPlanService
    {
        Task<DinnerPlanDto> PlanDinners(CreateDinnerPlanDto request);
    }
}
