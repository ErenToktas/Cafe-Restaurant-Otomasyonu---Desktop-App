using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Cafe_Restaurant
{
    class ClassPaketler
    {
        ClassGenel gnl = new ClassGenel();
        /*-------------------------------------------------------------------------------*/
        private int _ID;
        private int _AdditionID;
        private int _ClientId;
        private string _Description;
        private int _State;
        private int __Paytypeid;
        /*-------------------------------------------------------------------------------*/
        public int ID { get => _ID; set => _ID = value; }
        public int AdditionID { get => _AdditionID; set => _AdditionID = value; }
        public int ClientId { get => _ClientId; set => _ClientId = value; }
        public string Description { get => _Description; set => _Description = value; }
        public int State { get => _State; set => _State = value; }
        public int Paytypeid { get => __Paytypeid; set => __Paytypeid = value; }
        /*-------------------------------------------------------------------------------*/

        // Paket Servis Açma
        public bool OrderServiceOpen(ClassPaketler order)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into PaketSiparis(ADİSYONID,MUSTERİID,ODEMETURID,ACİKLAMA)values(@ADİSYONID,@MUSTERİID,@ODEMETURID,@ACİKLAMA)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ADİSYONID", SqlDbType.Int).Value = order._AdditionID;
                cmd.Parameters.Add("@MUSTERİID", SqlDbType.Int).Value = order._ClientId;
                cmd.Parameters.Add("@ODEMETURID", SqlDbType.Int).Value = order.__Paytypeid;
                cmd.Parameters.Add("@ACİKLAMA", SqlDbType.Int).Value = order._Description;
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

        /*-------------------------------------------------------------------------------*/

        // Paket Servis Kapatma
        public void OrderServiceClose(int AdditionID)
        {
            
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update PaketSiparis set PaketSiparis.durum=1 where PaketSiparis.ADİSYONID=@AdditionID", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@AdditionID", SqlDbType.Int).Value = AdditionID;
                
                Convert.ToBoolean(cmd.ExecuteNonQuery());
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
            
        }

        /*-------------------------------------------------------------------------------*/

        // Açılan Adisyon ve Paket Siparis ait ön girilen ödeme tur ID
        public int OdemeTurIdGetir(int adisyonId)
        {
            int odemeTurID = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select PaketSiparis.ODEMETURıd from PaketSiparis Inner Join Adisyon on PaketSiparis.ADİSYONID=Adisyon.ID where Adisyon.ID=@adisyonId", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@adisyonId", SqlDbType.Int).Value = adisyonId;
                
                odemeTurID = Convert.ToInt32(cmd.ExecuteScalar());
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
            return odemeTurID;
        }

        /*-------------------------------------------------------------------------------*/

        //Siparis kontrol için müsteriye ait açık olan en son adisyon no su getirme
        //Bir müsteriye ait 2 tane siparis açık olmamalı
        public int musteriSonAdisyonIDGetir(int musteriID)
        {
            int no = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Adisyon.ID from Adisyon Inner Join PaketSiparis on PaketSiparis.ADİSYONID=Adisyon.ID where (Adisyon.DURUM=0)" +
                " and (PaketSiparis.DURUM=0) and PaketSiparis.MUSTERİID=@musteriID)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@musteriID", SqlDbType.Int).Value = musteriID;

                no = Convert.ToInt32(cmd.ExecuteScalar());
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

            return no;
        }

        /*-------------------------------------------------------------------------------*/

        //Müsteri arama ekranında adisyon butonu açık kapalı kontrolü
        public bool getCheckOpenAdditionID(int additionID)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Adisyon where (DURUM=0) and (ID=@additionID)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@additionID", SqlDbType.Int).Value = additionID;
                
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

        /*-------------------------------------------------------------------------------*/


    }

}
