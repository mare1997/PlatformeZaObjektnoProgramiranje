﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        public static object ConfigurationManager { get; private set; }

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
        #region
        public static ObservableCollection<TipNamestaja> GetAll()
        {
            var tipoviNamestaja = new ObservableCollection<TipNamestaja>();
            using (var con = new SqlConection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlConection cmd = con.CreateCommand();
                cmd.CommandText = "Select * From TipNamestaja Where Obrisan=0";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds,"TipNamestaja"); //izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["TipNamestaja"].Rows)
                {
                    var tn = new TipNamestaja();
                    tn.Id = int.Parse(row["Id"].ToString());
                    tn.Naziv = row["Naziv"].ToString();
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    tipoviNamestaja.Add(tn);                }
                 
                
            }
        }
        return tipoviNamestaja;
        #endregion
    }
}
