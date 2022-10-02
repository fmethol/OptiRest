using OptiRest.Data.Models;
using OptiRest.Models.Dtos;

namespace OptiRest.Service.Interfaces
{
    public interface ITakedRangeService
    {
        Task<int> DeleteTakedRange(int id);
        Task<TakedRangeDto> CreateTakedRange(TakedRangeDto takedRange);
        Task<TakedRangeDto> GetTakedRange(int id);
        Task<IEnumerable<TakedRangeDto>> GetTakedRanges();
        Task<TakedRangeDto> UpdateTakedRange(TakedRangeDto request);
    }
}
