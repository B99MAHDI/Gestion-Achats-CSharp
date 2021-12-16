using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchatPrometi
{
    class home_class
    {
        public int Note_id { get; set; }
        public string Date { get; set; }
        public string Note { get; set; }

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAHDI\Desktop\achatprometi_c_sharp\AchatPrometi\DemoDatabase.mdf;Integrated Security=True;");
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from Notes";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public bool Insert(home_class c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAHDI\Desktop\achatprometi_c_sharp\AchatPrometi\DemoDatabase.mdf;Integrated Security=True;");
            try
            {
                string sql = "insert into Notes (Date,Note) values (@Date,@Note)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Date", c.Date);
                cmd.Parameters.AddWithValue("@Note", c.Note);


                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        public bool Update(home_class c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAHDI\Desktop\achatprometi_c_sharp\AchatPrometi\DemoDatabase.mdf;Integrated Security=True;");
            try
            {
                string sql = "update Notes set Date=@Date ,Note=@Note where Note_id=@Note_id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Note_id", c.Note_id);
                cmd.Parameters.AddWithValue("@Date", c.Date);
                cmd.Parameters.AddWithValue("@Note", c.Note);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    {
                        isSuccess = true;
                    }
                else
                    {
                        isSuccess = false;
                    }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            
            return isSuccess;
        }
        public bool Delete(home_class c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAHDI\Desktop\achatprometi_c_sharp\AchatPrometi\DemoDatabase.mdf;Integrated Security=True;");
            try
            {
                string sql = "delete from Notes where Note_id=@Note_id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Note_id", c.Note_id);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;

                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
    }
}
