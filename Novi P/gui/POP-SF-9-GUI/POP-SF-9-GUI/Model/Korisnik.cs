using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF_9_GUI.Model
{
    [Serializable]
    public enum TipKorisnika
    {
        Administrator,
        Prodavac
       
     }
    
    public class Korisnik: INotifyPropertyChanged
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
        private string ime;
        public string Ime
        {
            get { return ime; }
            set { ime = value; OnPropertyChanged("Ime"); }
        }
        private string prezime;
        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; OnPropertyChanged("Prezime"); }
        }
        private string korisnickoIme;
        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set { korisnickoIme = value; OnPropertyChanged("KorisnickoIme"); }
        }
        private string lozinka;
        public string Lozinka
        {
            get { return lozinka; }
            set {lozinka = value; OnPropertyChanged("Lozinka"); }
        }
        
        
        private bool obrisan;
        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; OnPropertyChanged("Obrisan"); }
        }
        private TipKorisnika tip;
        public TipKorisnika TipKorisnika
        {
            get { return tip; }
            set { tip = value; OnPropertyChanged("TipKorisnika"); }
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
