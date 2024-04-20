using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using BlueLearnAPI.Model;
using BlueLearnAPI.Context;




namespace BlueLearnAPI.Repositories
{
    public interface IJugadorRepository
    {
        Task<List<Jugador>> GetAll();
        Task<Jugador> GetJugador(int IdJugador);
        Task<Jugador> CreateJugador(int Puntaje, int Nivel);
        Task<Jugador> UpdateJugador(Jugador jugador);
        Task<Jugador> DeleteJugador(Jugador jugador);
    }

    public class JugadorRepository : IJugadorRepository
    {

        private readonly BLDbContext _db;

        public JugadorRepository(BLDbContext db)
        {
            _db = db;
        }
        public async Task<Jugador> CreateJugador(int Puntaje, int Nivel)
        {
            Jugador newJugador = new Jugador
            {
                Puntaje = Puntaje,
                Nivel = Nivel


            };
            await _db.Jugador.AddAsync(newJugador);
            _db.SaveChanges();
            return newJugador;

        }

        public async Task<Jugador> DeleteJugador(Jugador jugador)
        {
            await _db.Jugador.AddAsync(jugador);
            _db.SaveChanges();
            return jugador;
        }

        public async Task<List<Jugador>> GetAll()
        {
            return await _db.Jugador.ToListAsync();
        }

        public async Task<Jugador> GetJugador(int IdJugador)
        {
            return await _db.Jugador.FirstOrDefaultAsync(a => a.IdJugador == IdJugador);
        }

        public async Task<Jugador> UpdateJugador(Jugador jugador)
        {
            Jugador ConsultUpdate = await _db.Jugador.FindAsync(jugador.IdJugador);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.Puntaje = jugador.Puntaje;
                ConsultUpdate.Nivel = jugador.Nivel;


                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            //throw new NotImplementedException();
        }
    }
}

