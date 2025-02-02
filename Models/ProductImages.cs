using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Models
{
    public class ProductImages
    {
        [Key]
        public string? ImageId { get; set; }
        [Required]
        public string? ImageUrl { get; set; }

        [Required]
        public string? ProductID { get; set; }

        [ForeignKey("ProductID")]
        public Products? Products { get; set; }
    }
}
