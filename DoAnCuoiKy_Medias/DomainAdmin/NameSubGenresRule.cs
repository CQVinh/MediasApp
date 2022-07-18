using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAnCuoiKy_Medias.DomainAdmin
{
    public class NameSubGenresRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            if (string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult(false, "Plan is required!");
            return ValidationResult.ValidResult;
        }
    }
}
