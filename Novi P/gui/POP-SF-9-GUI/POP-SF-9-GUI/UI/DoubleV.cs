using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POP_SF_9_GUI.UI
{
    class DoubleV: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string v = value as string;

            
            try
            {
                double broj = 0;
                broj = Double.Parse(v);
                if (broj < 0)
                    return new ValidationResult(false, "Unesite pozitivan broj");
                else
                    return new ValidationResult(true, null);
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Unesite pozitivan ceo broj ");
            }




        }
    }
}
