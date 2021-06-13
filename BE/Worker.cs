using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Worker : Person
    {
        [Required(ErrorMessage = "The Persona lID is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Personal ID")]
        [RegularExpression(@"^[0-9]{9,10}$", ErrorMessage = "Please enter valid Personal ID ")]
        public int PersonalID { get; set; }
        public string Authorization { get; set; }
    }
}
