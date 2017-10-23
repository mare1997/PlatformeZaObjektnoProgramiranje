using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_9.Model
{
    class Akcija
    {
        public int Id { get; set; }
        public DateTime pocetak { get; set; }
        public decimal popust { get; set; }
        public DateTime kraj { get; set; }
        public bool Obrisan { get; set; }
    }
}
