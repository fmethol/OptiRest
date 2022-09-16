using OptiRest.Data.Models;
using OptiRest.Models.Dtos;

namespace OptiRest.Service.Interfaces
{
    public interface IPlatoService
    {
        Task<int> DeletePlato(int id);
        Task<PlatoDto> CreatePlato(PlatoDto plato);
        Task<PlatoDto> GetPlato(int id);
        Task<IEnumerable<PlatoDto>> GetPlatos();
        Task<PlatoDto> UpdatePlato(PlatoDto request);
    }
}