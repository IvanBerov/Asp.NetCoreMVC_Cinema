using CinemaApp.Models;
using System.Collections.Generic;

namespace CinemaApp.Data.ViewModels
{
    public class NewMovieDropdownsViewModel
    {
        public List<Producer> Producers { get; set; } = new List<Producer>();

        public List<Cinema> Cinemas { get; set; } = new List<Cinema>();

        public List<Actor> Actors { get; set; } = new List<Actor>();
    }
}
