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
    public class AkcijskaProdaja : INotifyPropertyChanged
    {
        public enum Prikaz
        {
            DatumPocetka,
            DatumKraja,
            Popust
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
        public object Clone()
        {
            return new AkcijskaProdaja()
            {
                id = Id,
                obrisan = Obrisan,
                dp = DatumPocetka,
                dk = DatumKraja,
                popust = Popust,

                
            };
        }
        public AkcijskaProdaja()
        {
            DatumPocetka = DateTime.Today;
            DatumKraja = DateTime.Today;

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
        public static void AkcijeClean()
        {
            foreach (AkcijskaProdaja akcija in Projekat.Instance.akcija)
            {
                if (akcija.DatumKraja < DateTime.Now)
                {
                    Projekat.Instance.akcija.Remove(akcija);
                    AkcijskaProdaja.Delete(akcija);
                }
            }
        }
        #region Database
        public static ObservableCollection<AkcijskaProdaja> GetAll()
        {
            var akcija= new ObservableCollection<AkcijskaProdaja>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Akcija WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Akcija"); // Query se izvrsava
                foreach (DataRow row in ds.Tables["Akcija"].Rows)
                {
                    var a = new AkcijskaProdaja();
                    a.Id = int.Parse(row["Id"].ToString());
                    a.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    a.DatumPocetka = DateTime.Parse(row["Dp"].ToString());
                    a.DatumKraja = DateTime.Parse(row["Dk"].ToString());
                    a.popust = int.Parse(row["Popust"].ToString());
                    akcija.Add(a);

                }
                return akcija;
            }
        }
        public static AkcijskaProdaja Create(AkcijskaProdaja a)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"Insert into Akcija (Obrisan,Dp,Dk,Popust) Values(@Obrisan,@Dp,@Dk,@Popust);";
                cmd.CommandText += "Select scope_identity();";
                cmd.Parameters.AddWithValue("Dp", a.dp);
                cmd.Parameters.AddWithValue("Dk", a.dk);
                cmd.Parameters.AddWithValue("Popust", a.popust);
                cmd.Parameters.AddWithValue("Obrisan", a.Obrisan);
                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //es izvrsava query
                a.Id = newId;


            }
            Projekat.Instance.akcija.Add(a);//obrati paznju {azurira i stanje modela}
            return a;
        }
        public static void Update(AkcijskaProdaja a)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Update Akcija set Dp=@Dp,Dk=@Dk,Popust=@Popust,Obrisan=@Obrisan where Id=@Id";
                cmd.Parameters.AddWithValue("Id", a.Id);
                cmd.Parameters.AddWithValue("Dp", a.dp);
                cmd.Parameters.AddWithValue("Dk", a.dk);
                cmd.Parameters.AddWithValue("Popust", a.popust);
                cmd.Parameters.AddWithValue("Obrisan", a.Obrisan);

                cmd.ExecuteNonQuery();

                foreach (var akcija in Projekat.Instance.akcija)
                {
                    if (akcija.Id == a.Id)
                    {
                        akcija.dp = a.dp;
                        akcija.dk = a.dk;
                        akcija.popust = a.popust;
                        akcija.Obrisan = a.Obrisan;
                        break;
                    }
                }
            }


        }
        public static void Delete(AkcijskaProdaja a)
        {
            a.Obrisan = true;
            Update(a);
        }
        public static ObservableCollection<AkcijskaProdaja> Sort(Prikaz p, NacinSortiranja nn)
        {
            var akcija = new ObservableCollection<AkcijskaProdaja>();
            switch (p)
            {
                case Prikaz.DatumKraja:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        if (nn == NacinSortiranja.asc)
                        {
                            cmd.CommandText = "SELECT * FROM Akcija WHERE Obrisan=0 Order by Dk";
                        }
                        else
                        {
                            cmd.CommandText = "SELECT * FROM Akcija WHERE Obrisan=0 Order by Dk desc";
                        }


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Akcija"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Akcija"].Rows)
                        {
                            var a = new AkcijskaProdaja();
                            a.Id = int.Parse(row["Id"].ToString());
                            a.Obrisan = bool.Parse(row["Obrisan"].ToString());
                            a.DatumPocetka = DateTime.Parse(row["Dp"].ToString());
                            a.DatumKraja = DateTime.Parse(row["Dk"].ToString());
                            a.popust = int.Parse(row["Popust"].ToString());
                            akcija.Add(a);

                        }
                    }
                        break;
                case Prikaz.DatumPocetka:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        if (nn == NacinSortiranja.asc)
                        {
                            cmd.CommandText = "SELECT * FROM Akcija WHERE Obrisan=0 Order by Dp";
                        }
                        else
                        {
                            cmd.CommandText = "SELECT * FROM Akcija WHERE Obrisan=0 Order by Dp desc";
                        }


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Akcija"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Akcija"].Rows)
                        {
                            var a = new AkcijskaProdaja();
                            a.Id = int.Parse(row["Id"].ToString());
                            a.Obrisan = bool.Parse(row["Obrisan"].ToString());
                            a.DatumPocetka = DateTime.Parse(row["Dp"].ToString());
                            a.DatumKraja = DateTime.Parse(row["Dk"].ToString());
                            a.popust = int.Parse(row["Popust"].ToString());
                            akcija.Add(a);

                        }
                    }
                    break;
                case Prikaz.Popust:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        if (nn == NacinSortiranja.asc)
                        {
                            cmd.CommandText = "SELECT * FROM Akcija WHERE Obrisan=0 Order by Popust";
                        }
                        else
                        {
                            cmd.CommandText = "SELECT * FROM Akcija WHERE Obrisan=0 Order by Popust desc";
                        }


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Akcija"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Akcija"].Rows)
                        {
                            var a = new AkcijskaProdaja();
                            a.Id = int.Parse(row["Id"].ToString());
                            a.Obrisan = bool.Parse(row["Obrisan"].ToString());
                            a.DatumPocetka = DateTime.Parse(row["Dp"].ToString());
                            a.DatumKraja = DateTime.Parse(row["Dk"].ToString());
                            a.popust = int.Parse(row["Popust"].ToString());
                            akcija.Add(a);

                        }
                    }
                    break;
            }
            return akcija;
        }
        public static ObservableCollection<AkcijskaProdaja> Search(Prikaz p, String s)
        {
            var akcija = new ObservableCollection<AkcijskaProdaja>();
            switch (p)
            {
                case Prikaz.DatumKraja:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT * FROM Akcija WHERE Obrisan=0 and Dk like '%'+@s+'%'";
                        cmd.Parameters.AddWithValue("s", s);


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Akcija"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Akcija"].Rows)
                        {
                            var a = new AkcijskaProdaja();
                            a.Id = int.Parse(row["Id"].ToString());
                            a.Obrisan = bool.Parse(row["Obrisan"].ToString());
                            a.DatumPocetka = DateTime.Parse(row["Dp"].ToString());
                            a.DatumKraja = DateTime.Parse(row["Dk"].ToString());
                            a.popust = int.Parse(row["Popust"].ToString());
                            akcija.Add(a);

                        }
                    }
                    break;
                case Prikaz.DatumPocetka:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT * FROM Akcija WHERE Obrisan=0 and Dp like '%'+@s+'%'";
                        cmd.Parameters.AddWithValue("s", s);


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Akcija"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Akcija"].Rows)
                        {
                            var a = new AkcijskaProdaja();
                            a.Id = int.Parse(row["Id"].ToString());
                            a.Obrisan = bool.Parse(row["Obrisan"].ToString());
                            a.DatumPocetka = DateTime.Parse(row["Dp"].ToString());
                            a.DatumKraja = DateTime.Parse(row["Dk"].ToString());
                            a.popust = int.Parse(row["Popust"].ToString());
                            akcija.Add(a);

                        }
                    }
                    break;
                case Prikaz.Popust:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT * FROM Akcija WHERE Obrisan=0 and Popust like '%'+@s+'%'";
                        cmd.Parameters.AddWithValue("s", s);


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Akcija"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Akcija"].Rows)
                        {
                            var a = new AkcijskaProdaja();
                            a.Id = int.Parse(row["Id"].ToString());
                            a.Obrisan = bool.Parse(row["Obrisan"].ToString());
                            a.DatumPocetka = DateTime.Parse(row["Dp"].ToString());
                            a.DatumKraja = DateTime.Parse(row["Dk"].ToString());
                            a.popust = int.Parse(row["Popust"].ToString());
                            akcija.Add(a);

                        }
                    }
                    break;
            }
            return akcija;
        }
        #endregion

    }
}
