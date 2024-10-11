using Dinners2.Dtos;

namespace Dinners2.Services
{
    public interface IDinnerService
    {
        Task<List<DinnerDto>> GetAllDinners();

        Task<List<SimpleDinnerDto>> GetAllSimpleDinners();

        Task<DinnerDto> GetDinner(Guid id);

        Task<DinnerDto> GetTaco();

        Task AddDinner(CreateDinnerDto dto);

        Task<bool> EditDinner(DinnerDto dto);

        Task<bool> DeleteDinner(Guid id);
        
        Task<List<DinnerDto>> GetDinnersByTag(string tag);
    }
}
