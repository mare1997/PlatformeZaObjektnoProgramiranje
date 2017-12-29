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
            Console.WriteLine("1");
            namestaj = Namestaj.GetAll();
            Console.WriteLine("2");
            korisnik =Korisnik.GetAll();
            Console.WriteLine("3");
            DU = DodatnaUsluga.GetAll();
            Console.WriteLine("4");
            pn = Racun.GetAll();
            Console.WriteLine("5");
            akcija = AkcijskaProdaja.GetAll();
            Console.WriteLine("6");
            spn = StavkaProdajeNamestaj.GetAll();
            Console.WriteLine("7");
            spdu = StavkaProdajeDU.GetAll();
            Console.WriteLine("8");
        }
        
        
    }
}
