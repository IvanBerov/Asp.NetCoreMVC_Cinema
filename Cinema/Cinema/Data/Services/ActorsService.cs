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

        public void Add(Actor actor)
        {
            _appDbContext.Actors.Add(actor);

            _appDbContext.SaveChanges();
        }

        public Actor Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var result = await _appDbContext
                .Actors
                .ToListAsync();

            return result;
        }

        public Actor GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Actor Update(int id, Actor actor)
        {
            throw new System.NotImplementedException();
        }
    }
}
