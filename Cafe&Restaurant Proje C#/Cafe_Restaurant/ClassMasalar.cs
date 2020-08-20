using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
namespace Cafe_Restaurant
{
    class ClassMasalar
    {
        private int _ID;
        private int _KAPASİTE;
        private int _SERVİSTURU;
        private int _DURUM;
        private int _ONAY;
        private string _MasaBilgi;

        public int ID { get => _ID; set => _ID = value; }
        public int KAPASİTE { get => _KAPASİTE; set => _KAPASİTE = value; }
        public int SERVİSTURU { get => _SERVİSTURU; set => _SERVİSTURU = value; }
        public int DURUM { get => _DURUM; set => _DURUM = value; }
        public int ONAY { get => _ONAY; set => _ONAY = value; }
        public string MasaBilgi { get => _MasaBilgi; set => _MasaBilgi = value; }

        ClassGenel gnl = new ClassGenel();
        public string SessionSum(int state, string masaId)
        {
            string dt = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select TARİH,MasaId From Adisyon Right Join MASA on Adisyon.MasaId=MASA.ID Where MASA.DURUM=@durum and Adisyon.DURUM=0 and MASA.ID=@masaId",con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@durum", SqlDbType.Int).Value = state;
            cmd.Parameters.Add("@masaId", SqlDbType.Int).Value = Convert.ToInt32(masaId);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dt = Convert.ToDateTime(dr["TARİH"]).ToString();
                }

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
            return dt;
        
        
        
        
        }

        public int TableGetbyNumber(string TableValue)
        {
            string aa = TableValue;
            int length = aa.Length;

            if (length > 8)
            {
                return Convert.ToInt32(aa.Substring(length - 2, 2));
            }
            else
            {
                return Convert.ToInt32(aa.Substring(length - 1, 1));
            }

            
        }
        public bool TableGetbyState(int ButtonName, int state) 
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select DURUM From MASA Where Id=@TableId and DURUM=@state", con);

            cmd.Parameters.Add("TableId", SqlDbType.Int).Value = ButtonName;
            cmd.Parameters.Add("state", SqlDbType.Int).Value = state;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                result = Convert.ToBoolean(cmd.ExecuteScalar());

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                
            }
            finally 
            {
                con.Dispose();
                con.Close();
            }
            return result;
        }
        public void setChangeTableState(string ButtonName, int state)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update MASA Set DURUM=@Durum where ID=@MasaNo", con);
            string masaNo = "";

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string aa = ButtonName;
            int uzunluk = aa.Length;
            cmd.Parameters.Add("@Durum", SqlDbType.Int).Value = state;
            if (uzunluk>8)
            {
                masaNo = aa.Substring(uzunluk - 2, 2);
            }
            else
            {
                masaNo = aa.Substring(uzunluk - 1, 1);
            }

            cmd.Parameters.Add("@MasaNo", SqlDbType.Int).Value = aa.Substring(uzunluk - 1, 1);
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }

        /*internal bool TableGetbyState(bool v)
        {
            throw new NotImplementedException();
        }*/
        public void MasaKapasitesiveDurumGetir(ComboBox cm)
        {
            cm.Items.Clear();
            string durum = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from MASA", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ClassMasalar c = new ClassMasalar();
                if (c._DURUM == 2)
                    durum = "DOLU";
                else if (c._DURUM == 3)  
                    durum = "Rezerve";
                c._KAPASİTE = Convert.ToInt32(dr["KAPASİTE"]);
                c._MasaBilgi = "Masa No: " + dr["ID"].ToString() + "Kapasitesi: " + dr["KAPASİTE"].ToString();
                c._ID = Convert.ToInt32(dr["ID"]);
                cm.Items.Add(c);
                

            }

            dr.Close();
            con.Dispose();
            con.Close();
        }

        public override string ToString()
        {
            return MasaBilgi;
        }
    }
}
