
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace POP_SF_9_GUI.Model
{
    [Serializable]
    public class Namestaj: INotifyPropertyChanged

    {
        private int id;
        public int Id
        {
            get { return id; }
            set {
                id = value;
                OnPropertyChanged("Id");
            }

        }
        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; OnPropertyChanged("Naziv"); }
        }
        private int cena;
        public int Cena
        {
            get { return cena; }
            set { cena = value; OnPropertyChanged("Cena"); }
        }
        private int kolicina;
        public int Kolicina
        {
            get { return kolicina; }
            set { kolicina = value;  OnPropertyChanged("Kolicina"); }
        }
        private bool obrisan;
        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; OnPropertyChanged("Obrisan"); }
        }
        private TipNamestaja tipNamestaja;
        [XmlIgnore]
        public TipNamestaja TipNamestaja
        {
            get
            {   if (tipNamestaja == null)
                {
                    tipNamestaja = TipNamestaja.GetById(tipN);

                }
                return tipNamestaja;
            }
            set
            {
                tipNamestaja = value;
                tipN = tipNamestaja.Id;
                OnPropertyChanged("TipNamestaja");
            }
        }
        private int tipN;
        public int TipN
        {
            get { return tipN; }
            set { tipN = value; OnPropertyChanged("TipN"); }
        }

        private int a;
        public int ak
        {
            get { return a; }
            set { a = value; OnPropertyChanged("ak"); }
        }
        private AkcijskaProdaja akcija;
        [XmlIgnore]
        public AkcijskaProdaja Akcija
        {
            get
            {
                if (akcija == null)
                {
                    akcija = AkcijskaProdaja.GetById(ak);

                }
                return akcija;
            }
            set
            {
                akcija = value;
                a = akcija.Id;
                OnPropertyChanged("Akcija");
            }
        }

        public override string ToString()
        {


            return $"Naziv: {Naziv},{Cena},{TipNamestaja.GetById(TipN).Naziv}";
        }
        public static Namestaj GetById(int id)
        {
            foreach (var Namestaja in Projekat.Instance.namestaj)
            {
                if (Namestaja.Id == id)
                {
                    return Namestaja;
                }

            }
            return null;

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
