using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_9.Model
{
    class ProdajaNamestaja
    {
        public int Id { get; set; }
        public int BrojKomadaNamestaja { get; set; }
        public DateTime DatumProdaje { get; set; }
        public string BrojRacuna { get; set; }
        public string Kupac { get; set; }
        public List<DodatnaUsluga> DodatneUsluge { get; set; }
        public const double PDV = 0.02;
        public double UkupnaCena { get; set; }
    }
}
