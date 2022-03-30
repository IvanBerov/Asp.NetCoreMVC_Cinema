using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaApp.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _appDbContext;

        public ActorsService(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task AddAsync(Actor actor)
        {
            await _appDbContext.Actors.AddAsync(actor);

            await _appDbContext.SaveChangesAsync();
        }

        public Actor Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result = await _appDbContext
                .Actors
                .ToListAsync();

            return result;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var actor = await _appDbContext.Actors
                .FirstOrDefaultAsync(a => a.Id == id);

            return actor;
        }

        public Actor Update(int id, Actor actor)
        {
            throw new System.NotImplementedException();
        }
    }
}
