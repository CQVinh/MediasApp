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
    public class CardNumberPaymentRule : ValidationRule
    {
        bool IsCardNumber(string CardNumber)
        {
            return Regex.IsMatch(CardNumber, @"^[0-9]{16}$");
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult(false, "Card Number is required!");
            else
            {
                if (IsCardNumber(value.ToString()) == false)
                    return new ValidationResult(false, "Please enter a valid credit card number");
            }
            return ValidationResult.ValidResult;
        }
    }
}
