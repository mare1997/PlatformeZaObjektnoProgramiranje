using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_9_GUI.Model
{
    [Serializable]
    public class ProdajaNamestaja
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public DateTime DatumProdaje { get; set; }
        public string brojRacuna { get; set; }
        public string Kupac { get; set; }
        public List<int> DodatnaUsluga { get; set; }
        public const double PDV = 0.02;
        public double UkupnaCena { get; set; }


        public static DodatnaUsluga GetById(int id)
        {
            foreach (var du in Projekat.Instance.dadatnaUsluga)
            {
                if (du.Id == id)
                {
                    return du;
                }

            }
            return null;

        }
    }
}
