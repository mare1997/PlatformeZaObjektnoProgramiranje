using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_9_GUI.Model
{
    [Serializable]
    public class DodatnaUsluga
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int Cena { get; set; }
    }
}
