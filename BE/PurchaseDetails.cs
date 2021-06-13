using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PurchaseDetails: Purchase
    {
     
        public int ID_User { get; set; }
        public decimal Grand_Total { get; set; }
        [Required(ErrorMessage = "The Card Number is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Card Number")]
        [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11}|[0-9](?:[ -]?[0-9]){7,8})$", ErrorMessage = "Please enter valid Card Number")]
        public int CardNumber { get; set; }
        [Required(ErrorMessage = "The CVV is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [RegularExpression(@"^([0-9]{3,4})$", ErrorMessage = "Must contain 3 or 4 digit number")]
        public int CVV { get; set; }
        public string CardExpirationDate { get; set; }
        public bool PurchaseComplete { get; set; }


    }
}
