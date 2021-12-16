using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchatPrometi
{
    class compte_class
    {
        public int id { get; set; }
        public string Nom { get; set; }

        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }


        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAHDI\Desktop\achatprometi_c_sharp\AchatPrometi\DemoDatabase.mdf;Integrated Security=True;");
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from Login";
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


        public bool Update(compte_class c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAHDI\Desktop\achatprometi_c_sharp\AchatPrometi\DemoDatabase.mdf;Integrated Security=True;");
            try
            {
                string sql = "update Login set Nom=@Nom,Prenom=@Prenom,Email=@Email,Pwd=@Pwd where id=1";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nom", c.Nom);
                cmd.Parameters.AddWithValue("@Prenom", c.Prenom);
                cmd.Parameters.AddWithValue("@Email", c.Email);
                cmd.Parameters.AddWithValue("@Pwd", c.Pwd);

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


        /*        public void fetch_data(object sender, EventArgs e)
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=B99\MSSQLSERVER01;Initial Catalog=achatprometi;Integrated Security=True;");
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Login", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        SqlDataAdapter sda1 = new SqlDataAdapter("SELECT COUNT * FROM Login", conn);
                        DataTable dt1 = new DataTable();
                        return dt1;
                    }

                }
        */
    }
}
