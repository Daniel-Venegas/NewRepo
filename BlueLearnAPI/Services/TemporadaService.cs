using BlueLearnAPI.Model;
using BlueLearnAPI.Repositories;
using Microsoft.Identity.Client;

namespace BlueLearnAPI.Services
{
    public interface ITemporadaService
    {
        Task<List<Temporadas>> GetAll();
        Task<Temporadas> GetTemporadas(int IdTemporada);
        Task<Temporadas> CreateTemporadas(string Temporada);
        Task<Temporadas> UpdateTemporadas(int IdTemporada, string? Temporada=null);
        Task<Temporadas> DeleteTemporadas(int IdTemporada);
    }
    public class TemporadaService : ITemporadaService
    {
        public readonly ITemporadasRepository _temporadasRepository;

        public TemporadaService(ITemporadasRepository temporadasRepository)
        {
            _temporadasRepository = temporadasRepository;
        }

        public async Task<Temporadas> CreateTemporadas(string Temporada)
        {
            return await _temporadasRepository.CreateTemporadas(Temporada);
        }

        public async Task<Temporadas> DeleteTemporadas(int IdTemporada)
        {
            Temporadas temporadas = await _temporadasRepository.GetTemporadas(IdTemporada);
            return await _temporadasRepository.DeleteTemporadas(temporadas);
        }

        public async Task<List<Temporadas>> GetAll()
        {
            return await _temporadasRepository.GetAll();
        }

        public async Task<Temporadas> GetTemporadas(int IdTemporada)
        {
            return await _temporadasRepository.GetTemporadas(IdTemporada);
        }

        public async Task<Temporadas> UpdateTemporadas(int IdTemporada, string? Temporada = null)
        {
            Temporadas newTemporadas = await _temporadasRepository.GetTemporadas(IdTemporada);
            if(newTemporadas!= null)
            {
                if(Temporada != null)
                {
                    newTemporadas.Temporada = Temporada;
                }
                return await _temporadasRepository.UpdateTemporadas(newTemporadas);
            }
            throw new InvalidOperationException("Registro no encontrado.");
        }
    }
}
