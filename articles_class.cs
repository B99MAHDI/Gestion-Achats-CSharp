using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchatPrometi
{
    class articles_class
    {
        public int id { get; set; }
        public string article { get; set; }

        public string client { get; set; }
        public string désignation { get; set; }
        public string prix_unitaire { get; set; }



        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAHDI\Desktop\achatprometi_c_sharp\AchatPrometi\DemoDatabase.mdf;Integrated Security=True;");
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from Articles";
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
        public bool Insert(articles_class c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAHDI\Desktop\achatprometi_c_sharp\AchatPrometi\DemoDatabase.mdf;Integrated Security=True;");
            try
            {
                string sql = "insert into Articles (article,client,désignation,prix_unitaire) values (@article,@client,@désignation,@prix_unitaire)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@article", c.article);
                cmd.Parameters.AddWithValue("@client", c.client);
                cmd.Parameters.AddWithValue("@désignation", c.désignation);
                cmd.Parameters.AddWithValue("@prix_unitaire", c.prix_unitaire);


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
        public bool Update(articles_class c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAHDI\Desktop\achatprometi_c_sharp\AchatPrometi\DemoDatabase.mdf;Integrated Security=True;");
            try
            {
                string sql = "update Articles set article=@article ,client=@client,désignation=@désignation,prix_unitaire=@prix_unitaire where article_id=@article_id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@article_id", c.id);
                cmd.Parameters.AddWithValue("@article", c.article);
                cmd.Parameters.AddWithValue("@client", c.client);
                cmd.Parameters.AddWithValue("@désignation", c.désignation);
                cmd.Parameters.AddWithValue("@prix_unitaire", c.prix_unitaire);
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
        public bool Delete(articles_class c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAHDI\Desktop\achatprometi_c_sharp\AchatPrometi\DemoDatabase.mdf;Integrated Security=True;");
            try
            {
                string sql = "delete from Articles where article_id=@article_id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@article_id", c.id);
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
