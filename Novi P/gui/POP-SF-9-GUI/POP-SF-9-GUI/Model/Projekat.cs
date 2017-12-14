using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_9_GUI.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();
        public ObservableCollection<TipNamestaja> TN ;
        public ObservableCollection<Namestaj> namestaj ;
        public ObservableCollection<AkcijskaProdaja> akcija; 
        public ObservableCollection<DodatnaUsluga> DU ;
        public ObservableCollection<Korisnik> korisnik ;
        public ObservableCollection<Racun> pn;
        private Projekat()
        {
            TN = TipNamestaja.GetAll();
            namestaj = new ObservableCollection<Namestaj>(GenericSerializer.Deserialize<Namestaj>("namestaj.xml"));
            korisnik = new ObservableCollection<Korisnik>(GenericSerializer.Deserialize<Korisnik>("korisnik.xml"));
            DU = new ObservableCollection<DodatnaUsluga>(GenericSerializer.Deserialize<DodatnaUsluga>("dodatnausluga.xml"));
            pn = new ObservableCollection<Racun>(GenericSerializer.Deserialize<Racun>("prodajanamestaja.xml"));
            akcija = new ObservableCollection<AkcijskaProdaja>(GenericSerializer.Deserialize<AkcijskaProdaja>("akcija.xml"));
        }
        
        
    }
}
