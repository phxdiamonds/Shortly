using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Shortly_Client.Helpers.Validators
{
    public class CustomEmailValidator : ValidationAttribute
    {
        private const string _emailPattern = @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";


        //we need to override the IsValid method
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //check if the value is null or empty, because you have said that this going to be nullable
            if(value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return ValidationResult.Success;
            }


            string emailAddress = value.ToString();

            //check regex matches

            if(Regex.IsMatch(emailAddress, _emailPattern))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage);

            
        }
    }
}
