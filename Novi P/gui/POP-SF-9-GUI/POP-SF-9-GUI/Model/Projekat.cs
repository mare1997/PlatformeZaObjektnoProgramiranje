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
        
        public ObservableCollection<DodatnaUsluga> DU ;
        public ObservableCollection<Korisnik> korisnik ;
        public ObservableCollection<ProdajaNamestaja> pn;
        private Projekat()
        {
            TN = new ObservableCollection<TipNamestaja>(GenericSerializer.Deserialize<TipNamestaja>("tipnamestaja.xml"));
            namestaj = new ObservableCollection<Namestaj>(GenericSerializer.Deserialize<Namestaj>("namestaj.xml"));
            korisnik = new ObservableCollection<Korisnik>(GenericSerializer.Deserialize<Korisnik>("korisnik.xml"));
            DU = new ObservableCollection<DodatnaUsluga>();
            pn = new ObservableCollection<ProdajaNamestaja>();
        }
        
        
    }
}
