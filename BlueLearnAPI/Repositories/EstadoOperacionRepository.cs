using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using BlueLearnAPI.Model;
using BlueLearnAPI.Context;


namespace BlueLearnAPI.Repositories
{

    public interface IEstadoOperacionRepository
    {
        Task<List<EstadoOperacion>> GetAll();
        Task<EstadoOperacion> GetEstadoOperacion(int IdEstadoOperacion);
        Task<EstadoOperacion> CreateEstadoOperacion(string Descripcion);
        Task<EstadoOperacion> UpdateEstadoOperacion(EstadoOperacion estadoOperacion);
        Task<EstadoOperacion> DeleteEstadoOperacion(EstadoOperacion estadoOperacion);
    }
    public class EstadoOperacionRepository : IEstadoOperacionRepository
    {

        private readonly BLDbContext _db;

        public EstadoOperacionRepository(BLDbContext db)
        {
            _db = db;
        }
        public async Task<EstadoOperacion> CreateEstadoOperacion(string Descripcion)
        {
            EstadoOperacion newEstadoOperacion = new EstadoOperacion
            {
                Descripcion = Descripcion
            };
            await _db.EstadoOperacion.AddAsync(newEstadoOperacion);
            _db.SaveChanges();
            return newEstadoOperacion;
        }

        public async Task<EstadoOperacion> DeleteEstadoOperacion(EstadoOperacion estadoOperacion)
        {
            await _db.EstadoOperacion.AddAsync(estadoOperacion);
            _db.SaveChanges();
            return estadoOperacion;
        }

        public async Task<EstadoOperacion> GetEstadoOperacion(int IdEstadoOperacion)
        {
            return await _db.EstadoOperacion.FirstOrDefaultAsync(e => e.IdEstadoOperacion == IdEstadoOperacion);
        }

        public async Task<List<EstadoOperacion>> GetAll()
        {
            return await _db.EstadoOperacion.ToListAsync();
        }

        public async Task<EstadoOperacion> UpdateEstadoOperacion(EstadoOperacion estadoOperacion)
        {
            EstadoOperacion ConsultUpdate = await _db.EstadoOperacion.FindAsync(estadoOperacion.IdEstadoOperacion);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.Descripcion = estadoOperacion.Descripcion;


                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            //throw new NotImplementedException();
        }
    }
}
