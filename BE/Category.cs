using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Category : Item
    {
        [Required(ErrorMessage = "The Title is required")] 
        [RegularExpression(@"^(?=.{1,40}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$",ErrorMessage = "Please enter valid Title")]
        public string Title { get; set; }
    }
}
