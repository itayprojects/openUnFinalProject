using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Item
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "The Description is required")]
        [RegularExpression(@"^(.|\s)*[a-zA-Z]+(.|\s)*$",ErrorMessage = "The Description shuld start with a sentence first")]
        public string Description { get; set; }
        public DateTime AddDate { get; set; }
    }
}
