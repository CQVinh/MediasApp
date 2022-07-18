using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAnCuoiKy_Medias.Domain
{
    public class CVVPaymentRule : ValidationRule
    {
        bool CVV(string CVV)
        {
            return Regex.IsMatch(CVV, @"^[0-9]{4}$");
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult(false, "CVV is required!");
            else
            {
                if (CVV(value.ToString()) == false)
                    return new ValidationResult(false, "Please enter a valid CVV code");
            }
            return ValidationResult.ValidResult;
        }
    }
}
