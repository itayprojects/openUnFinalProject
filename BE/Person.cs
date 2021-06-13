using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Person
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "The First Name is required")]
        [RegularExpression(@"^(?=.{1,40}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$", ErrorMessage = "Please enter valid First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The Last Name is required")]
        [RegularExpression(@"^(?=.{1,40}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$", ErrorMessage = "Please enter valid Last Name")]
        public string LasttName { get; set; }
        [Required(ErrorMessage = "The Password is required")]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "The Phone is required")]
        [RegularExpression(@"^[0-9]{9,10}$",ErrorMessage = "Please enter valid Phone number ")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "The Address is required")]
        public string Address { get; set; }
        public bool BuisnessWorker { get; set; }
        public DateTime AddDate { get; set; }
    }
}
