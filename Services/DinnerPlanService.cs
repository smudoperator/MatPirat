using Dinners2.Dtos;

namespace Dinners2.Services
{
    public class DinnerPlanService : IDinnerPlanService
    {
        private readonly IDinnerService _dinnerService;
        private static Random rng = new Random();

        public DinnerPlanService(IDinnerService dinnerService)
        {
            _dinnerService = dinnerService;
        }

        public async Task<DinnerPlanDto> PlanDinners(CreateDinnerPlanDto request)
        {
            
            var dinners = await _dinnerService.GetAllDinners();

            var shuffledDinners = dinners.OrderBy(_ => rng.Next()).ToList(); // Trying this shuffle stuff

            var filteredDinners = await FilterDinners(request, shuffledDinners);

            var result = new DinnerPlanDto
            {
                Dinners = filteredDinners,
                StartDay = request.StartDay,
                NumberOfDays = filteredDinners.Count()
            };
            
            return result;
        }

        private async Task<List<DinnerDto>> FilterDinners(CreateDinnerPlanDto request, List<DinnerDto> dinners)
        {
            var result = new List<DinnerDto>();


            // Taco
            if (request.TacoFriday)
            {
                var taco = await _dinnerService.GetTaco();
                result.Add(taco);
            } 


            // Fish
            var fishDinners = dinners
                .Take(request.NumberOfFish)
                .Where(x => x.Type == DinnerType.Fish);

            if (fishDinners is not null)
            {
                result.AddRange(fishDinners);
            }


            // Add missing dinners
            var potentialDinners = dinners
                .Take(request.NumberOfDays * 2)
                .Where(x => x.Type != DinnerType.Fish);


            foreach (var dinner in potentialDinners)
            {
                if (result.Count() < request.NumberOfDays && !result.Contains(dinner))
                {
                    if (!dinner.Name.ToLower().Contains("taco"))
                    {
                        result.Add(dinner);
                    }
                }
            }

            return result;
        }

    }
}
