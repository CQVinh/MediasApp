﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAnCuoiKy_Medias.DomainAdmin
{
    public class DescriptionRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
                return new ValidationResult(false, "Description is required!");
            return ValidationResult.ValidResult;
        }
    }
}