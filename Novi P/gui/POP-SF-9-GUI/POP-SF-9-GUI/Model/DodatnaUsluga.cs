using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_9_GUI.Model
{
    [Serializable]
    public class DodatnaUsluga : INotifyPropertyChanged
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
        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; OnPropertyChanged("Naziv"); }
        }
        private int cena;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Cena
        {
            get { return cena; }
            set { cena = value; OnPropertyChanged("Cena"); }
        }

        private bool obrisan;
        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; OnPropertyChanged("Obrisan"); }
        }
        public static DodatnaUsluga GetById(int id)
        {
            foreach (var du in Projekat.Instance.DU)
            {
                if (du.Id == id)
                {
                    return du;
                }

            }
            return null;

        }
        
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }
    }
}
