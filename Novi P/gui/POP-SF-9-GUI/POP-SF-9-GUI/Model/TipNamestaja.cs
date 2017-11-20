using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_9_GUI.Model
{
    [Serializable]
    public class TipNamestaja: INotifyPropertyChanged
    {
        private int id;
        public int Id
        { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        private bool obrisan;
        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; OnPropertyChanged("Obrisan"); }
        }
        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; OnPropertyChanged("Naziv"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static TipNamestaja GetById(int id)
        {
            foreach (var tipNamestaja in Projekat.Instance.TN)
            {
                if (tipNamestaja.Id == id)
                {
                    return tipNamestaja;
                }

            }
            return null;

        }
        public override string ToString()
        {
            return Naziv;
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
