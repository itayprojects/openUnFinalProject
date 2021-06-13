using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class StoreSet
    {
        [Required(ErrorMessage = "The Store Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Phone is required")]
        [RegularExpression(@"^[0-9]{9,10}$", ErrorMessage = "Please enter valid Phone number ")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "The email address is required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Email Acssess is required")]
        public string EmailConfig { get; set; }
        [Required(ErrorMessage = "The Address is required")]
        public string Address { get; set; }
        public string Facebook { get; set; }
        public string Instegram { get; set; }
        public string Twitter { get; set; }

    }
}
