using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_9.Model
{
    public class Namestaj
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public double JedinicnaCena { get; set; }
        public int KolicinivaUMagacinu { get; set; }
        public bool Obrisan { get; set; }
        public TipNamestaja TipNamestaja { get; set;}

    }
}
