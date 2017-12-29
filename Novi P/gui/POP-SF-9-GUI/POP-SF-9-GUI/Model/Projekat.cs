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
        public ObservableCollection<StavkaProdajeNamestaj> spn;
        public ObservableCollection<StavkaProdajeDU> spdu;
        private Projekat()
        {
            TN = TipNamestaja.GetAll();
            namestaj = Namestaj.GetAll();
            korisnik =Korisnik.GetAll();
            DU = DodatnaUsluga.GetAll();
            pn = Racun.GetAll();
            akcija = AkcijskaProdaja.GetAll();
            spn = StavkaProdajeNamestaj.GetAll();
            spdu = StavkaProdajeDU.GetAll();
        }
        
        
    }
}
