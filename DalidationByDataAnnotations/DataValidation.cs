using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace DalidationByDataAnnotations
{
    public class DataValidation : BaseValidator
    {
        public string PropertyName { get; set; } //Exposes the Property Name that we want to validate against.
        public string SourceType { get; set; }//Exposes the SourceType for Data Annotation lookup that we want to validate against.

        /*
         * Performs the real Validation process
         * sets the isValid flag on the BaseValidator class
         * return If the property if Valid or Not
         * This implementation will break on the first attribute fail and will only return the first error found.
         * the foreach and the where clause to allow for easier transition into an implementation that
         * tracks and displays all the errors found and not just the first one!
         */
        protected override bool EvaluateIsValid()
        {
            var objectType = Type.GetType(SourceType, true, true);
            var property = objectType.GetProperty(PropertyName);

            var control = base.FindControl(ControlToValidate) as TextBox;

            if (control == null)
                throw new InvalidOperationException("This implementation can only be used to validate Textbox controls, attempting to validate something else will fail!");

            foreach (var attr in property.GetCustomAttributes(typeof(ValidationAttribute), true)
                                         .OfType<ValidationAttribute>()
                                         .Where(attr => !attr.IsValid(control.Text)))
            {

                var displayNameAttr = property.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                                              .OfType<DisplayNameAttribute>()
                                              .FirstOrDefault();

                var displayName = displayNameAttr == null ? property.Name : displayNameAttr.DisplayName;
                ErrorMessage = attr.FormatErrorMessage(displayName);
                return false;
            }

            return true;
        }
    }
}
