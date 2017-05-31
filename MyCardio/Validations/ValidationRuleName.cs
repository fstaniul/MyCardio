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
    public class ValidationRuleName : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var strValue = Convert.ToString(value);

            if (string.IsNullOrEmpty(strValue)) return new ValidationResult(false, Resources.EmptyNameTextBox);

            var checkRegex = new Regex("^[A-Za-z\\sĄąĘęÓóŚśŁłŻżŹźĆćŃń]+$");

            return !checkRegex.IsMatch(strValue) ? new ValidationResult(false, Resources.InvalidNameErrorTip) : new ValidationResult(true, null);
        }
    }
}
