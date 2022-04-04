using CinemaApp.Data.BaseRepo;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cinema Logo")]
        [Required(ErrorMessage = "Cinema logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 character")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Cinema description is required")]
        [StringLength(200,MinimumLength = 6, ErrorMessage = "Description must be between 6 and 200 character")]
        public string Description { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
