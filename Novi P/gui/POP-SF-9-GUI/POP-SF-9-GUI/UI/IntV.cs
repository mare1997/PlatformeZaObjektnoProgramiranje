using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POP_SF_9_GUI.UI
{
    class IntV : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string v = value as string;
            if (v == null)
                return new ValidationResult(false, "Polje ne sme biti prazno");
            try
            {
                int i;
                bool rezultat = Int32.TryParse(v, out i);
                if (!rezultat)
                {

                    return new ValidationResult(false, "Unesite pozitivan ceo broj");
                }
                else if (i < 0)
                {

                    return new ValidationResult(false, "Unesite pozitivan ceo broj");
                }
                else
                {

                    return new ValidationResult(true, null);
                }
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Unesite pozitivan ceo broj");
            }




        }
    }
}
