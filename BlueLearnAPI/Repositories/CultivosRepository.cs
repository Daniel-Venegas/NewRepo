﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using BlueLearnAPI.Model;
using BlueLearnAPI.Context;




namespace BlueLearnAPI.Repositories
{

    public interface ICultivosRepository
    {
        Task<List<Cultivos>> GetAll();
        Task<Cultivos> GetCultivos(int IdCultivo);
        Task<Cultivos> CreateCultivos(DateTime FechaPlantacion, int IdEstadoCultivo, int IdCampo);
        Task<Cultivos> UpdateCultivos(Cultivos cultivos);
        Task<Cultivos> DeleteCultvios(Cultivos cultivos);
    }
    public class CultivosRepository : ICultivosRepository
    {

        private readonly BLDbContext _db;

        public CultivosRepository(BLDbContext db)
        {
            _db = db;
        }
        public async Task<Cultivos> CreateCultivos(DateTime FechaPlantacion, int IdEstadoCultivo, int IdCampo)
        {
            Cultivos newCultivos = new Cultivos
            {
                FechaPlantacion = FechaPlantacion,
                IdEstadoCultivo = IdEstadoCultivo,
                IdCampo = IdCampo
            };
            await _db.Cultivos.AddAsync(newCultivos);
            _db.SaveChanges();
            return newCultivos;
        }

        public async Task<Cultivos> DeleteCultvios(Cultivos cultivos)
        {
            await _db.Cultivos.AddAsync(cultivos);
            _db.SaveChanges();
            return cultivos;
        }

        public async Task<List<Cultivos>> GetAll()
        {
            return await _db.Cultivos.ToListAsync();
        }

        public async Task<Cultivos> GetCultivos(int IdCultivo)
        {
            return await _db.Cultivos.FirstOrDefaultAsync(c => c.IdCultivo == IdCultivo);
        }

        public async Task<Cultivos> UpdateCultivos(Cultivos cultivos)
        {
            Cultivos ConsultUpdate = await _db.Cultivos.FindAsync(cultivos.IdCultivo);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.FechaPlantacion = cultivos.FechaPlantacion;
                ConsultUpdate.IdEstadoCultivo = cultivos.IdEstadoCultivo;
                ConsultUpdate.IdCampo = cultivos.IdCampo;


                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            //throw new NotImplementedException();
        }

    }
}
