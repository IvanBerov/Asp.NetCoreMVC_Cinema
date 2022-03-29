using CinemaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaApp.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAll();

        Actor GetById(int id);

        void Add(Actor actor);

        Actor Update(int id, Actor actor);

        Actor Delete(int id);
    }
}
