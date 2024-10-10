using Dinners2.Dtos;
using Dinners2.Extensions;

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
            // fetch all dinners
            var dinners = await _dinnerService.GetAllDinners();

            // shuffle dinners to make seletion random
            var shuffledDinners = dinners.OrderBy(_ => rng.Next()).ToList(); // Trying this shuffle stuff

            // make sure dinner types are being handled
            var filteredDinners = await FilterDinners(request, shuffledDinners);

            // make sure dinners are evenly distributed
            var distributedDinners = DistributeDinners(filteredDinners, request.StartDay);

            // create dinner planDto
            var result = new DinnerPlanDto
            {
                Dinners = distributedDinners,
                StartDay = request.StartDay,
                NumberOfDays = distributedDinners.Count()
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
                if (taco is not null)
                {
                    result.Add(taco);
                }
            }


            // Fish
            var allFishDinners = dinners
                .Where(x => x.Type == DinnerType.Fish);

            var fishDinners = allFishDinners
                .Take(request.NumberOfFish);

            if (fishDinners is not null)
            {
                result.AddRange(fishDinners);
            }


            // Add missing dinners
            var potentialDinners = dinners
                .Where(x => x.Type != DinnerType.Fish && !x.Name.ToLower().Contains("taco")) // Prevent adding Taco and fish here
                .Take(request.NumberOfDays * 2);

            foreach (var dinner in potentialDinners)
            {
                if (result.Count() < request.NumberOfDays && !result.Contains(dinner))
                {
                    result.Add(dinner);
                }
            }

            return result;
        }

        // This method is utter dogshit but it works well enough
        private List<DinnerDto> DistributeDinners(List<DinnerDto> dinners, DayOfWeek startDay)
        {
            var result = new List<DinnerDto>();

            // shuffle
            dinners.OrderBy(_ => rng.Next()).ToList();

            // fetch index for taco (friday)
            var tacoIndex = GetTacoIndex(startDay, dinners.Count());

            // remove last dinner and add to new dinner list
            result.Add(dinners.Last());
            dinners.RemoveAt(dinners.Count - 1);
            
            var i = 0;
            var total = dinners.Count();
            while (i < total)
            {
                var dinner = dinners.LastOrDefault();
                if (dinner is null) { break; } // results are fully distributed
                dinners.RemoveAt(dinners.Count - 1);

                var previousType = result[i].Type;

                // horrible solution but good enough for most cases
                if (dinner.Type != previousType)
                {
                    result.Add(dinner);
                }
                else
                {
                    result.Insert(0, dinner);
                }

                i++;
                
            }

            // handle taco
            var taco = result.FirstOrDefault(x => x.Name.ToLower().Contains("taco")); 
            if (taco is not null)
            {
                result.Remove(taco);
                result.Insert(tacoIndex, taco);
            }
            


            return result;
        }

        private int GetTacoIndex(DayOfWeek dayOfWeek, int dinnerCount)
        {
            // if friday is out of reach, just put it last

            var index = 0;
            
            while (index <= dinnerCount)
            {
                if (dayOfWeek == DayOfWeek.Friday)
                {
                    return index;
                }
                else
                {
                    index++;
                    dayOfWeek = dayOfWeek.Next();
                }
            }

            return index; 
        }   
    }
}
