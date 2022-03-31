using CinemaApp.Data.BaseRepo;
using CinemaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaApp.Data.Services
{
    public interface IActorsService : IEntityBaseRepository<Actor>
    {
    }
}
