using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using BlueLearnAPI.Model;
using BlueLearnAPI.Context;
using System.Runtime.CompilerServices;



namespace BlueLearnAPI.Repositories
{

    public interface IDescripcionMonitoreoRepository
    {
        Task<List<DescripcionMonitoreo>> GetAll();
        Task<DescripcionMonitoreo> GetDMonitoreo (int IdDescripcionMonitoreo);
        Task<DescripcionMonitoreo> CreateDMonitoreo(string Variable, string UnidadMedida);
        Task<DescripcionMonitoreo> UpdateDMonitoreo(DescripcionMonitoreo descripcionMonitoreo);
        Task<DescripcionMonitoreo> DeleteDMonitoreo(DescripcionMonitoreo descripcionMonitoreo);
    }
    public class DescripcionMonitoreoRepository : IDescripcionMonitoreoRepository
    {

        private readonly BLDbContext _db;

        public DescripcionMonitoreoRepository(BLDbContext db)
        {
            _db = db;
        }
        public async Task<DescripcionMonitoreo> CreateDMonitoreo(string Variable, string UnidadMedida)
        {
            DescripcionMonitoreo DescripcionMonitoreo = new DescripcionMonitoreo
            {
                Variable = Variable,
                UnidadMedida = UnidadMedida
            };
            await _db.DescripcionMonitoreo.AddAsync(DescripcionMonitoreo);
            _db.SaveChanges();
            return DescripcionMonitoreo;
        }

        public async Task<DescripcionMonitoreo> DeleteDMonitoreo(DescripcionMonitoreo descripcionMonitoreo)
        {
            await _db.DescripcionMonitoreo.AddAsync(descripcionMonitoreo);
            _db.SaveChanges();
            return descripcionMonitoreo;
        }

        public async Task<List<DescripcionMonitoreo>> GetAll()
        {
            return await _db.DescripcionMonitoreo.ToListAsync();
        }

        public async Task<DescripcionMonitoreo> GetDMonitoreo(int IdDescripcionMonitoreo)
        {
            return await _db.DescripcionMonitoreo.FirstOrDefaultAsync(d => d.IdDescripcionMonitoreo == IdDescripcionMonitoreo);
        }

        public async Task<DescripcionMonitoreo> UpdateDMonitoreo(DescripcionMonitoreo descripcionMonitoreo)
        {
            DescripcionMonitoreo ConsultUpdate = await _db.DescripcionMonitoreo.FindAsync(descripcionMonitoreo.IdDescripcionMonitoreo);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.Variable = descripcionMonitoreo.Variable;
                ConsultUpdate.UnidadMedida = descripcionMonitoreo.UnidadMedida;


                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            //throw new NotImplementedException();
        }
    }
}
