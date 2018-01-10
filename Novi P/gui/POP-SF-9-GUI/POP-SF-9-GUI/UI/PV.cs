using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POP_SF_9_GUI.UI
{
    class PV: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var v = value as string;

            try
            {

                int i;
                bool rezultat = int.TryParse(v, out i);
                if (!rezultat)
                    return new ValidationResult(false, "Morate uneti broj");
                else if (i < 0)
                    return new ValidationResult(false, "Morate uneti pozitivan broj");
                else if (i < 1 || i > 90)
                    return new ValidationResult(false, "Nije odobren popust");
                else
                    return new ValidationResult(true, null);
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Unesi pozitivan ceo broj");
            }
        }
    }
}
