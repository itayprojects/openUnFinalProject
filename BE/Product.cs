using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Product : Item
    {
        [Required(ErrorMessage = "The Title is required")]
        [RegularExpression(@"^(?=.{1,40}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$", ErrorMessage = "Please enter valid Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Category is required")]
        public string Category { get; set; }
        [Required(ErrorMessage = "The Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid Price")]
        [RegularExpression(@"^\d{0,8}(\.\d{1,4})?$", ErrorMessage = "Please enter valid Price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The Inventory is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Quantity { get; set; }
        [RegularExpression(@"/\.(gif|jpe? g|tiff?|png|webp|bmp)$/i", ErrorMessage = "The file is not an image file")]
        public string Product_Img_Link { get; set; }
    }
}
