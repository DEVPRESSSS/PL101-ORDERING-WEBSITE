using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Models
{
    public class AppUser:IdentityUser
    {
        [Required(ErrorMessage ="Name is required")]
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
