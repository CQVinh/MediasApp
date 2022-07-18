using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAnCuoiKy_Medias.Domain
{
    public class PasswordForgotPasswordRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult(false, "Password is required!");
            else
            {
                if (value.ToString().Length < 4 || value.ToString().Length > 60)
                    return new ValidationResult(false, "Password should be between 4 and 60 characters");
            }
            return ValidationResult.ValidResult;
        }
    }
}
