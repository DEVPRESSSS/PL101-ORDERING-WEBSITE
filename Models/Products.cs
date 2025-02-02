using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Models
{
    public class Products
    {

        [Key]
        public string? ProductID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Size is required")]
        public string? Size { get; set; }

        [Required (ErrorMessage ="Stock is required")]
        public int Stock { get; set; }

        [Required]
        public string? Category_ID { get; set; }
        [ForeignKey("Category_ID")]
        public Category? Category { get; set; }

        public DateOnly? CreatedAt { get; set; }

    


        [ValidateNever]
        public List<ProductImages>? ListOfProductImages { get; set; }
    }
}
