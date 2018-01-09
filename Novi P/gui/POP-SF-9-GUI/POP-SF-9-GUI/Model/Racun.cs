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
    [Serializable]
    public class Racun : INotifyPropertyChanged
    {
        public enum Prikaz
        {
            DatumProdaje,
            Kupac,
            Cena,
        };
        public enum NacinSortiranja
        {
            asc,
            desc,
        };
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

        private double ukupnaCena;
        public double UkupnaCena
        {
            get { return ukupnaCena; }
            set { ukupnaCena = value; OnPropertyChanged("UkupnaCena"); }
        }
        public object Clone()
        {
            return new Racun()
            {
                id = Id,
                datumProdaje=DatumProdaje,
                kupac=Kupac,
                ukupnaCena=UkupnaCena,
            };
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
        public static ObservableCollection<Racun> GetAll()
        {
            var racun = new ObservableCollection<Racun>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Racun";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Racun"); // Query se izvrsava
                foreach (DataRow row in ds.Tables["Racun"].Rows)
                {
                    var r = new Racun();
                    r.Id = int.Parse(row["Id"].ToString());
                    r.datumProdaje = DateTime.Parse(row["Dp"].ToString());
                    r.Kupac = row["Kupac"].ToString();
                    r.UkupnaCena = double.Parse(row["UkupnaCena"].ToString());
                    racun.Add(r);

                }
                return racun;
            }
        }
        public static Racun Create(Racun r)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"Insert into Racun (Dp,Kupac,UkupnaCena) Values(@Dp,@Kupac,@UkupnaCena);";//razmisli o ne unosenju obrisan pri dodavanju vec to u bazi 
                cmd.CommandText += "Select scope_identity();";
                cmd.Parameters.AddWithValue("Dp",r.DatumProdaje);
                cmd.Parameters.AddWithValue("Kupac",r.Kupac);
                cmd.Parameters.AddWithValue("UkupnaCena", r.UkupnaCena);
                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //es izvrsava query
                r.Id = newId;


            }
            Projekat.Instance.pn.Add(r);//obrati paznju {azurira i stanje modela}
            return r;
        }
        public static void Update(Racun r)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Update Racun set Dp=@Dp,Kupac=@Kupac,UkupnaCena=@UkupnaCena where Id=@Id";
                cmd.Parameters.AddWithValue("Id", r.Id);
                cmd.Parameters.AddWithValue("Dp", r.DatumProdaje);
                cmd.Parameters.AddWithValue("Kupac", r.Kupac);
                cmd.Parameters.AddWithValue("UkupnaCena", r.UkupnaCena);

                cmd.ExecuteNonQuery();

                foreach (var racun in Projekat.Instance.pn)
                {
                    if (racun.Id == r.Id)
                    {
                        racun.DatumProdaje = r.DatumProdaje;
                        racun.Kupac = r.Kupac;
                        racun.UkupnaCena = r.UkupnaCena;
                        break;
                    }
                }
            }


        }
        #region Database
        public static ObservableCollection<Racun> Sort(Prikaz p, NacinSortiranja nn)
        {
            var racun = new ObservableCollection<Racun>();
            switch (p)
            {
                case Prikaz.DatumProdaje:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        if (nn == NacinSortiranja.asc)
                        {
                            cmd.CommandText = "SELECT * FROM Racun Order by Dp";
                        }
                        else
                        {
                            cmd.CommandText = "SELECT * FROM Racun Order by Dp desc";
                        }
                       

                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Racun"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Racun"].Rows)
                        {
                            var r = new Racun();
                            r.Id = int.Parse(row["Id"].ToString());
                            r.datumProdaje = DateTime.Parse(row["Dp"].ToString());
                            r.Kupac = row["Kupac"].ToString();
                            r.UkupnaCena = double.Parse(row["UkupnaCena"].ToString());
                            racun.Add(r);

                        }
                        
                    }
                    break;
                case Prikaz.Kupac:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        if (nn == NacinSortiranja.asc)
                        {
                            cmd.CommandText = "SELECT * FROM Racun Order by Kupac";
                        }
                        else
                        {
                            cmd.CommandText = "SELECT * FROM Racun Order by Kupac desc";
                        }


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Racun"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Racun"].Rows)
                        {
                            var r = new Racun();
                            r.Id = int.Parse(row["Id"].ToString());
                            r.datumProdaje = DateTime.Parse(row["Dp"].ToString());
                            r.Kupac = row["Kupac"].ToString();
                            r.UkupnaCena = double.Parse(row["UkupnaCena"].ToString());
                            racun.Add(r);

                        }

                    }
                    break;
                case Prikaz.Cena:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        if (nn == NacinSortiranja.asc)
                        {
                            cmd.CommandText = "SELECT * FROM Racun Order by UkupnaCena";
                        }
                        else
                        {
                            cmd.CommandText = "SELECT * FROM Racun Order by UkupnaCena desc";
                        }


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Racun"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Racun"].Rows)
                        {
                            var r = new Racun();
                            r.Id = int.Parse(row["Id"].ToString());
                            r.datumProdaje = DateTime.Parse(row["Dp"].ToString());
                            r.Kupac = row["Kupac"].ToString();
                            r.UkupnaCena = double.Parse(row["UkupnaCena"].ToString());
                            racun.Add(r);

                        }

                    }
                    break;
            }
            return racun;
        }
        public static ObservableCollection<Racun> Search(Prikaz p, String s)
        {
            var racun = new ObservableCollection<Racun>();
            switch (p)
            {
                case Prikaz.DatumProdaje:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT * FROM Racun WHERE Dp like '%'+@s+'%'";
                        cmd.Parameters.AddWithValue("s", s);


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Racun"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Racun"].Rows)
                        {
                            var r = new Racun();
                            r.Id = int.Parse(row["Id"].ToString());
                            r.datumProdaje = DateTime.Parse(row["Dp"].ToString());
                            r.Kupac = row["Kupac"].ToString();
                            r.UkupnaCena = double.Parse(row["UkupnaCena"].ToString());
                            racun.Add(r);

                        }

                    }
                    break;
                case Prikaz.Kupac:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT * FROM Racun WHERE Kupac like '%'+@s+'%'";
                        cmd.Parameters.AddWithValue("s", s);


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Racun"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Racun"].Rows)
                        {
                            var r = new Racun();
                            r.Id = int.Parse(row["Id"].ToString());
                            r.datumProdaje = DateTime.Parse(row["Dp"].ToString());
                            r.Kupac = row["Kupac"].ToString();
                            r.UkupnaCena = double.Parse(row["UkupnaCena"].ToString());
                            racun.Add(r);

                        }

                    }
                    break;
                case Prikaz.Cena:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT * FROM Racun WHERE UkupnaCena like '%'+@s+'%'";
                        cmd.Parameters.AddWithValue("s", s);


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Racun"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Racun"].Rows)
                        {
                            var r = new Racun();
                            r.Id = int.Parse(row["Id"].ToString());
                            r.datumProdaje = DateTime.Parse(row["Dp"].ToString());
                            r.Kupac = row["Kupac"].ToString();
                            r.UkupnaCena = double.Parse(row["UkupnaCena"].ToString());
                            racun.Add(r);

                        }

                    }
                    break;
            }
            return racun;
        }
        #endregion
    }
}
#endregion