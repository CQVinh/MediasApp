﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAnCuoiKy_Medias.DomainAdmin
{
    public class ImageRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
                return new ValidationResult(false, "Image is required!");
            return ValidationResult.ValidResult;
        }
    }
}