﻿using BlueLearnAPI.Model;
using BlueLearnAPI.Repositories;
using System.Globalization;

namespace BlueLearnAPI.Services
{

    public interface IEstadoCultivoService
    {
        Task<List<EstadoCultivo>> GetAll();
        Task<EstadoCultivo> GetEstadoCultivo(int IdEstadoCultivo);
        Task<EstadoCultivo> CreateEstadoCultivo(string Descripcion);
        Task<EstadoCultivo> UpdateEstadoCultivo(int IdEstadoCultivo, string? Descripcion=null);
        Task<EstadoCultivo> DeleteEstadoCultivo(int IdEstadoCultivo);
    }
    public class EstadoCultivoService : IEstadoCultivoService
    {
        public readonly IEstadoCultivoRepository _estadoCultivoRepository;

        public EstadoCultivoService(IEstadoCultivoRepository estadoCultivoRepository)
        {
            _estadoCultivoRepository = estadoCultivoRepository;
        }

        public async Task<EstadoCultivo> CreateEstadoCultivo(string Descripcion)
        {
            return await _estadoCultivoRepository.CreateEstadoCultivo(Descripcion);
        }

        public async Task<EstadoCultivo> DeleteEstadoCultivo(int IdEstadoCultivo)
        {
            EstadoCultivo estadoCultivo = await _estadoCultivoRepository.GetEstadoCultivo(IdEstadoCultivo);
            return await _estadoCultivoRepository.DeleteEstadoCultivo(estadoCultivo);
        }

        public async Task<List<EstadoCultivo>> GetAll()
        {
            return await _estadoCultivoRepository.GetAll();
        }

        public async Task<EstadoCultivo> GetEstadoCultivo(int IdEstadoCultivo)
        {
            return await _estadoCultivoRepository.GetEstadoCultivo(IdEstadoCultivo);
        }

        public async Task<EstadoCultivo> UpdateEstadoCultivo(int IdEstadoCultivo, string? Descripcion = null)
        {
            EstadoCultivo newEstadoCultivo = await _estadoCultivoRepository.GetEstadoCultivo(IdEstadoCultivo);
            if(newEstadoCultivo != null)
            {
                if(Descripcion != null)
                {
                    newEstadoCultivo.Descripcion = Descripcion;
                }
                return await _estadoCultivoRepository.UpdateEstadoCultivo(newEstadoCultivo);
            }
            throw new InvalidOperationException("Registro no encontrado.");
        }
    }
}
