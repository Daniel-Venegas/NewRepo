using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using BlueLearnAPI.Model;
using BlueLearnAPI.Context;


namespace BlueLearnAPI.Repositories
{

    public interface IEtapaRepository
    {
        Task<List<Etapa>> GetAll();
        Task<Etapa> GetEtapa(int IdEtapa);
        Task<Etapa> CreateEtapa(string Descripcion);
        Task<Etapa> UpdateEtapa(Etapa etapa);
        Task<Etapa> DeleteEtapa(Etapa etapa);
    }
    public class EtapaRepository : IEtapaRepository
    {

        private readonly BLDbContext _db;

        public EtapaRepository(BLDbContext db)
        {
            _db = db;
        }
        public async Task<Etapa> CreateEtapa(string Descripcion)
        {
            Etapa newEtapa = new Etapa
            {
                Descripcion = Descripcion,
            };
            await _db.Etapa.AddAsync(newEtapa);
            _db.SaveChanges();
            return newEtapa;
        }

        public async Task<Etapa> DeleteEtapa(Etapa etapa)
        {
            await _db.Etapa.AddAsync(etapa);
            _db.SaveChanges();
            return etapa;
        }

        public async Task<List<Etapa>> GetAll()
        {
            return await _db.Etapa.ToListAsync();
        }

        public async Task<Etapa> GetEtapa(int IdEtapa)
        {
            return await _db.Etapa.FirstOrDefaultAsync(e => e.IdEtapa == IdEtapa);
        }

        public async Task<Etapa> UpdateEtapa(Etapa etapa)
        {
            Etapa ConsultUpdate = await _db.Etapa.FindAsync(etapa.IdEtapa);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.Descripcion = etapa.Descripcion;


                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            //throw new NotImplementedException();
        }
    }
}
