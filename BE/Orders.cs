using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Orders: Purchase
    {
        
        public int ProductId { get; set; }
        [Required(ErrorMessage = "The Product Name is required")]
        [RegularExpression(@"^(?=.{1,40}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$",ErrorMessage = "Please enter valid Product Name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "The Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid Price")]
        [RegularExpression(@"^\d{0,8}(\.\d{1,4})?$",ErrorMessage = "Please enter valid Price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The Quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Quantity { get; set; }
        
    }
}
