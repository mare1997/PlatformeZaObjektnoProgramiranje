using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_9.Model
{
    [Serializable]
    public class DodatnaUsluga
    {   public int Id { get; set; }
        public string naziv { get; set; }
        public double Cenausluge { get; set; }
        public bool Obrisan { get; set; }
}
}
