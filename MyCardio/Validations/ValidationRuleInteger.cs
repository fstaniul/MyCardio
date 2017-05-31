using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using MyCardio.Properties;

namespace MyCardio.Validations
{
    public class ValidationRuleInteger : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var strValue = Convert.ToString(value);
            return int.TryParse(strValue, out int i) ? new ValidationResult(true, null) : new ValidationResult(false, Resources.InvalidNumberTip);
        }
    }
}
