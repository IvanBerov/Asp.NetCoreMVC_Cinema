using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{
    public class AppUser : IdentityUser
    {
        [Display(Name = "Full name")]
        public string FullName { get; set;}
    }
}
