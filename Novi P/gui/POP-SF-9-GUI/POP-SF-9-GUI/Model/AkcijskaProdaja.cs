using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_9_GUI.Model
{
    [Serializable]
    public class AkcijskaProdaja : INotifyPropertyChanged
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
        private DateTime dp;
        public DateTime DatumPocetka
        {
            get { return dp; }
            set { dp = value; OnPropertyChanged("DatumPocetka"); }
        }
        private DateTime dk;
        public DateTime DatumKraja
        {
            get { return dk; }
            set { dk = value; OnPropertyChanged("DatumKraja"); }
        }
        private int popust;
        public int Popust
        {
            get { return popust; }
            set { popust = value; OnPropertyChanged("Popust"); }
        }
        private bool obrisan;
        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; OnPropertyChanged("Obrisan"); }
        }


        public static AkcijskaProdaja GetById(int id)
        {
            foreach (var Akcija in Projekat.Instance.akcija)
            {
                if (Akcija.Id == id)
                {
                    return Akcija;
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
        public override string ToString()
        {


            return $"Popust: {Popust} ";
        }

    }
}
