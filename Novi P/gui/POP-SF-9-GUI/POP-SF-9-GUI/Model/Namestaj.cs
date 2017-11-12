
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POP_SF_9_GUI.Model
{
    [Serializable]
    public class Namestaj
    {
        public int Id { get; set;}
        public string Naziv { get; set; }
        public int Cena { get; set; }
        public int Kolicina { get; set; }
        public bool Obrisan { get; set; }
        public int TipN { get; set; }
        /*Treba int TipNamestajId*/
        public AkcijskaProdaja Akcija { get; set; }

        public override string ToString()
        {
            
            return $"Naziv: {Naziv},{Cena},{TipNamestaja.GetById(TipN).Naziv}";
        }

    }
}
