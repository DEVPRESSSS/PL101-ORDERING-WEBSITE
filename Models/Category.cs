using System.ComponentModel.DataAnnotations;

namespace ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Models
{
    public class Category
    {

        [Key] 
        public string? CategoryID { get; set; }

        [Required]
        public string? Name{ get; set; }

        public DateOnly? CreatedAt{ get; set; }
    }
}