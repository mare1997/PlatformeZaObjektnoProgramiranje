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
    public class StavkaProdajeDU: INotifyPropertyChanged
    
    {   private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }

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
        private int duid;
        public int DUId
        {
            get { return duid; }
            set
            {
                duid = value;
                OnPropertyChanged("DUId");
            }

        }
        public string Naziv
        {
            get { return DodatnaUsluga.GetById(duid).Naziv; }
            set
            {
                DodatnaUsluga.GetById(duid).Naziv =value;
                OnPropertyChanged("Naziv");

            }
        }

        public object Clone()
        {
            return new StavkaProdajeDU()
            {
                id = Id,
                Naziv=Naziv,
                racunid=RacunId,
                duid=DUId,
            };
        }
        public static StavkaProdajeDU GetById(int id)
        {
            foreach (var Namestaja in Projekat.Instance.spdu)
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
        public static ObservableCollection<StavkaProdajeDU> GetAll()
        {
            var spn = new ObservableCollection<StavkaProdajeDU>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM  StavkaDUsluge ";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "StavkaDUsluge"); // Query se izvrsava
                foreach (DataRow row in ds.Tables["StavkaDUsluge"].Rows)
                {
                    var s = new StavkaProdajeDU();
                    s.Id = int.Parse(row["Id"].ToString());
                    s.RacunId = int.Parse(row["RacunId"].ToString());
                    s.DUId = int.Parse(row["DUId"].ToString());
                    

                    spn.Add(s);

                }
                return spn;
            }
        }
        public static StavkaProdajeDU Create(StavkaProdajeDU s)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"Insert into  StavkaDUsluge (RacunId,DUId) Values(@RacunId,@DUId);";//razmisli o ne unosenju obrisan pri dodavanju vec to u bazi 
                cmd.CommandText += "Select scope_identity();";
                cmd.Parameters.AddWithValue("RacunId", s.RacunId);
                cmd.Parameters.AddWithValue("DUId", s.DUId);
                
                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //es izvrsava query
                s.Id = newId;


            }
            Projekat.Instance.spdu.Add(s);//obrati paznju {azurira i stanje modela}
            return s;
        }
        public static void Update(StavkaProdajeDU s)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Update  StavkaDUsluge set RacunId=@RacunId,DUId=@DUId, where Id=@Id";
                cmd.Parameters.AddWithValue("Id", s.Id);
                cmd.Parameters.AddWithValue("DUId", s.DUId);
                cmd.Parameters.AddWithValue("RacunId", s.RacunId);

                cmd.ExecuteNonQuery();

                foreach (var spn in Projekat.Instance.spdu)
                {
                    if (spn.Id == s.Id)
                    {
                        spn.RacunId = s.RacunId;
                        spn.DUId = s.DUId;

                        break;
                    }
                }
            }
        }
        public static void Delete(StavkaProdajeDU n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Update  StavkaDUsluge where Id=@Id";
                cmd.Parameters.AddWithValue("Id", n.Id);
                cmd.ExecuteNonQuery();
                foreach (var spdu in Projekat.Instance.spdu)
                {
                    if (spdu.Id == n.Id)
                    {
                        Projekat.Instance.spdu.Remove(spdu);
                        break;
                    }
                }
            }
        }


    

        #endregion
    }
}
