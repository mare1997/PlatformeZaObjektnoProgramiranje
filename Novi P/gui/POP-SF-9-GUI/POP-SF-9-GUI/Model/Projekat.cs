using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_9_GUI.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();
        private List<TipNamestaja> TN = new List<TipNamestaja>();
        private List<Namestaj> namestaj = new List<Namestaj>();
        
        private List<DodatnaUsluga> DU = new List<DodatnaUsluga>();
        private List<Korisnik> korisnik = new List<Korisnik>();
        private List<ProdajaNamestaja> pn = new List<ProdajaNamestaja>();
        public List<Namestaj> Namestaj
        {
            get {
                this.namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
                return this.namestaj;
            }
            set {
                this.namestaj = value;
                GenericSerializer.Serialize<Namestaj>("namestaj.xml",this.namestaj);
            }
        }
        public List<TipNamestaja> TipNamestaja
        {
            get {
                this.TN = GenericSerializer.Deserialize<TipNamestaja>("tipnamestaja.xml");
                return this.TN;
            }
            set {
                this.TN = value;
                GenericSerializer.Serialize<TipNamestaja>("tipnamestaja.xml", this.TN);
            }
        }
        
        public List<DodatnaUsluga> dadatnaUsluga
        {
            get
            {
                this.DU = GenericSerializer.Deserialize<DodatnaUsluga>("dadatnausluga.xml");
                return this.DU;
            }
            set
            {
                this.DU = value;
                GenericSerializer.Serialize<DodatnaUsluga>("dodatnausluga.xml", this.DU);
            }
        }
        public List<Korisnik> korisnikK
        {
            get
            {
                this.korisnik = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
                return this.korisnik;
            }
            set
            {
                this.korisnik = value;
                GenericSerializer.Serialize<Korisnik>("korisnik.xml", this.korisnik);
            }
        }
        public List<ProdajaNamestaja> prodajaNamestaja
        {
            get
            {
                this.pn = GenericSerializer.Deserialize<ProdajaNamestaja>("prodajanamestaja.xml");
                return this.pn;
            }
            set
            {
                this.pn = value;
                GenericSerializer.Serialize<ProdajaNamestaja>("prodajanamestaja.xml", this.pn);
            }
        }
    }
}
