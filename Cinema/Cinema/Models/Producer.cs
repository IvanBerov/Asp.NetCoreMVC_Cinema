using CinemaApp.Data.BaseRepo;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string PictureUrl { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "FullName is required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "FullName must be between 3 and 60 chars")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
