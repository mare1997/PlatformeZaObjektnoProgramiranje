using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_9_GUI.Model
{
    public class StavkaProdajeNamestaj: INotifyPropertyChanged
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
        private int racunid;
        public int RacunId
        {
            get { return racunid; }
            set
            {
                racunid = value;
                OnPropertyChanged("RacunId");
            }

        }
        private int namestajid;
        public int NamestajId
        {
            get { return namestajid; }
            set
            {
                namestajid = value;
                OnPropertyChanged("NamestajId");
            }

        }
        public static StavkaProdajeNamestaj GetById(int id)
        {
            foreach (var Namestaja in Projekat.Instance.spn)
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
        #region Database
        public static ObservableCollection<StavkaProdajeNamestaj> GetAll()
        {
            var spn = new ObservableCollection<StavkaProdajeNamestaj>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM  StavkaNametsaja ";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "StavkaNametsaja"); // Query se izvrsava
                foreach (DataRow row in ds.Tables["StavkaNametsaja"].Rows)
                {
                    var s = new StavkaProdajeNamestaj();
                    s.Id = int.Parse(row["Id"].ToString());
                    s.RacunId = int.Parse(row["RacunId"].ToString());
                    s.NamestajId = int.Parse(row["NamestajId"].ToString());
                    s.Kolicina = int.Parse(row["Kolicina"].ToString());

                    spn.Add(s);

                }
                return spn;
            }
        }
        public static StavkaProdajeNamestaj Create(StavkaProdajeNamestaj s)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"Insert into  StavkaNametsaja (RacunId,NamestajId,Kolicina) Values(@RacunId,@NamestajId,@Kolicina);";//razmisli o ne unosenju obrisan pri dodavanju vec to u bazi 
                cmd.CommandText += "Select scope_identity();";
                cmd.Parameters.AddWithValue("RacunId", s.RacunId);
                cmd.Parameters.AddWithValue("NamestajId", s.NamestajId);
                cmd.Parameters.AddWithValue("Kolicina", s.Kolicina);
                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //es izvrsava query
                s.Id = newId;


            }
            Projekat.Instance.spn.Add(s);//obrati paznju {azurira i stanje modela}
            return s;
        }
        public static void Update(StavkaProdajeNamestaj s)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Update  StavkaNametsaja set RacunId=@RacunId,NamestajId=@NamestajId,Kolicina=@Kolicina, where id=@id";
                cmd.Parameters.AddWithValue("Id", s.Id);
                cmd.Parameters.AddWithValue("NamestajId",s.NamestajId);
                cmd.Parameters.AddWithValue("RacunId", s.RacunId);
                cmd.Parameters.AddWithValue("Kolicina", s.Kolicina);
                cmd.ExecuteNonQuery();

                foreach (var spn in Projekat.Instance.spn)
                {
                    if (spn.Id == s.Id)
                    {
                        spn.RacunId = s.RacunId;
                        spn.NamestajId = s.NamestajId;
                        spn.Kolicina = s.Kolicina;
                        break;
                    }
                }
            }


        }
        
        #endregion

    }
}
