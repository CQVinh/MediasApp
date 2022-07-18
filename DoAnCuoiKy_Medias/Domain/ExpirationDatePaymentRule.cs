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
    public class ExpirationDatePaymentRule : ValidationRule
    {
        bool ExpirationDate(string ExpirationDate)
        {
            return Regex.IsMatch(ExpirationDate, @"(0[1-9]|10|11|12)/[0-9]{2}$");
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult(false, "Expiration Date is required!");
            else
            {
                if (ExpirationDate(value.ToString()) == false)
                    return new ValidationResult(false, "Please enter a valid expiration date");
            }
            return ValidationResult.ValidResult;
        }
    }
}
