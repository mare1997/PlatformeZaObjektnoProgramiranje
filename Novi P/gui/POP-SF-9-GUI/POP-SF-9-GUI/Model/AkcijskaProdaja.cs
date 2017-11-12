using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_9_GUI.Model
{
    [Serializable]
    public class AkcijskaProdaja
    {
        public int Id { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavresetka { get; set; }
        public decimal Popust { get; set; }
        public bool Obrisan { get; set; }
        
    }
}
