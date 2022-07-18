using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAnCuoiKy_Medias.Domain
{
    public class EmailForgotPasswordRule : ValidationRule
    {
        bool CheckEmail(string Email)
        {
            return Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult(false, "Email is required!");
            else
            {
                if (CheckEmail(value.ToString()) == false)
                    return new ValidationResult(false, "Please enter a valid email address");
            }
            return ValidationResult.ValidResult;
        }
    }
}
