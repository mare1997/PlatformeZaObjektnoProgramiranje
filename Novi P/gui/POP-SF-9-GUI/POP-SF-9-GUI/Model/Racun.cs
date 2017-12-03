using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_9_GUI.Model
{
    [Serializable]
    public class Racun : INotifyPropertyChanged
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
        private DateTime datumProdaje;
        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set { datumProdaje = value; OnPropertyChanged("DatumProdaje"); }
        }

        private string kupac;
        public string Kupac
        {
            get { return kupac; }
            set { kupac = value; OnPropertyChanged("Kupac"); }
        }

        private List<int> dodatnaUsluga;
        public List<int> DodatnaUsluga
        {
            get { return dodatnaUsluga; }
            set { dodatnaUsluga = value; OnPropertyChanged("DodatnaUsluga"); }
        }
        //private Dictionary<int, int> namestaj;
        private List<int> namestaj;
        public List<int> Namestaj
        {
            get { return namestaj; }
            set { namestaj = value; OnPropertyChanged("Namestaj"); }
        }
        public const double PDV = 0.02 ;
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
