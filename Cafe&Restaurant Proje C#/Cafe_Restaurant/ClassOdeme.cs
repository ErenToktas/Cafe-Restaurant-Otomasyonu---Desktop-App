using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient; 

namespace Cafe_Restaurant
{
    class ClassOdeme
    {
        ClassGenel gnl = new ClassGenel();
        /*------------------------------------------------------------------------*/
        private int _OdemeID;
        private int _AdisyonID;
        private int _OdemeTurId;
        private decimal _AraToplam;
        private decimal _Inidirm;
        private decimal _Kdvtutari;
        private decimal _GenelToplam;
        private DateTime _Tarih;
        private int _MusteriId;
        /*------------------------------------------------------------------------*/
        public int OdemeID { get => _OdemeID; set => _OdemeID = value; }
        public int AdisyonID { get => _AdisyonID; set => _AdisyonID = value; }
        public int OdemeTurId { get => _OdemeTurId; set => _OdemeTurId = value; }
        public decimal AraToplam { get => _AraToplam; set => _AraToplam = value; }
        public decimal Inidirm { get => _Inidirm; set => _Inidirm = value; }
        public decimal Kdvtutari { get => _Kdvtutari; set => _Kdvtutari = value; }
        public decimal GenelToplam { get => _GenelToplam; set => _GenelToplam = value; }
        public DateTime Tarih { get => _Tarih; set => _Tarih = value; }
        public int MusteriId { get => _MusteriId; set => _MusteriId = value; }
        /*------------------------------------------------------------------------*/

        // Müşterinin Masa Hesabını Kapat
        public bool billClose(ClassOdeme bill)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into HesapOdemeleri(ADİSYONID,ODEMETURID,MUSTERİID,ARATOPLAM,KDVTUTARİ,TOPLAMTUTAR,İNDİRİM) " +
                "values(@ADİSYONID,@ODEMETURID,@MUSTERİID,@ARATOPLAM,@KDVTUTARİ,@TOPLAMTUTAR,@İNDİRİM)",con);

            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@ADİSYONID", SqlDbType.Int).Value = bill._AdisyonID;
                cmd.Parameters.Add("@ODEMETURID", SqlDbType.Int).Value = bill._OdemeTurId;
                cmd.Parameters.Add("@MUSTERİID", SqlDbType.Int).Value = bill._MusteriId;
                cmd.Parameters.Add("@ARATOPLAM", SqlDbType.Int).Value = bill._AraToplam;
                cmd.Parameters.Add("@KDVTUTARİ", SqlDbType.Int).Value = bill._Kdvtutari;
                cmd.Parameters.Add("@TOPLAMTUTAR", SqlDbType.Int).Value = bill._GenelToplam;
                cmd.Parameters.Add("@İNDİRİM", SqlDbType.Int).Value = bill._Inidirm;

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());

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

        /*------------------------------------------------------------------------*/

        // Müşterinin toplam harcamasını bul
        public decimal sumTotalforClientId(int clientId)
        {
            decimal total = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select sum(TOPLAMTUTAR) as total from HesapOdemeleri Where MUSTERİID=@clientId", con);

            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("clientId", SqlDbType.Int).Value = clientId;
                total = Convert.ToDecimal(cmd.ExecuteScalar());
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

            return total;
        }

        /*------------------------------------------------------------------------*/
    }
}
