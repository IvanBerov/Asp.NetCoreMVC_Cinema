using CinemaApp.Data.BaseRepo;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Pictire")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string PictureUrl { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(60,MinimumLength = 2, ErrorMessage = "Full Name must be between 2 and 60 character")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biographi is required")]
        public string Bio { get; set; }

        public List<Actor_Movie> Actors_Movies{ get; set; }
    }
}
