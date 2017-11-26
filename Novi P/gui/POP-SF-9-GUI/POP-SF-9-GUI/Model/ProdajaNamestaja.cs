using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_9_GUI.Model
{
    [Serializable]
    public class ProdajaNamestaja : INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }

        }
        private int kolicina;
        public int Kolicina
        {
            get { return kolicina; }
            set { kolicina = value; OnPropertyChanged("Kolicina"); }
        }
        private DateTime datumProdaje;
        public DateTime DatumProdaje
        {
            get {return datumProdaje ; }
            set { datumProdaje = value; OnPropertyChanged("DatumProdaje"); }
        }
        public string brojRacuna { get; set; }
        private string kupac;
        public string Kupac
        {
            get { return kupac; }
            set { kupac = value;  OnPropertyChanged("Kupac"); }
        }
        private List<int> dodatnaUsluga;
        public List<int> DodatnaUsluga
        {
            get { return dodatnaUsluga; }
            set { dodatnaUsluga = value; OnPropertyChanged("DodatnaUsluga"); }
        }
        public const double PDV = 0.02;
        private double ukupnaCena;
        public double UkupnaCena
        {
            get { return ukupnaCena; }
            set { ukupnaCena = value; OnPropertyChanged("UkupnaCena"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }
    }
}
