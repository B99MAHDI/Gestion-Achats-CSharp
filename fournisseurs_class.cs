using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchatPrometi
{
    class fournisseurs_class
    {
        public int id { get; set; }
        public string ct_num { get; set; }

        public string dl_design { get; set; }
        public string prix_unitaire { get; set; }
        public string commerciale { get; set; }
        public string numero { get; set; }
        public string email { get; set; }
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAHDI\Desktop\achatprometi_c_sharp\AchatPrometi\DemoDatabase.mdf;Integrated Security=True;");
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from Fournisseurs";
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
        public bool Insert(fournisseurs_class c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAHDI\Desktop\achatprometi_c_sharp\AchatPrometi\DemoDatabase.mdf;Integrated Security=True;");
            try
            {
                string sql = "insert into Fournisseurs (ct_num,dl_design,prix_unitaire,commerciale,numero,email) values (@ct_num,@dl_design,@prix_unitaire,@commerciale,@numero,@email)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ct_num", c.ct_num);
                cmd.Parameters.AddWithValue("@dl_design", c.dl_design);
                cmd.Parameters.AddWithValue("@prix_unitaire", c.prix_unitaire);
                cmd.Parameters.AddWithValue("@commerciale", c.commerciale);
                cmd.Parameters.AddWithValue("@numero", c.numero);
                cmd.Parameters.AddWithValue("@email", c.email);

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

        public bool Update(fournisseurs_class c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAHDI\Desktop\achatprometi_c_sharp\AchatPrometi\DemoDatabase.mdf;Integrated Security=True;");
            try
            {
                string sql = "update Fournisseurs set ct_num=@ct_num ,dl_design=@dl_design,prix_unitaire=@prix_unitaire,commerciale=@commerciale,numero=@numero,email=@email where supplier_id=@supplier_id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ct_num", c.ct_num);
                cmd.Parameters.AddWithValue("@dl_design", c.dl_design);
                cmd.Parameters.AddWithValue("@prix_unitaire", c.prix_unitaire);
                cmd.Parameters.AddWithValue("@commerciale", c.commerciale);
                cmd.Parameters.AddWithValue("@numero", c.numero);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@supplier_id", c.id);
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


        public bool Delete(fournisseurs_class c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAHDI\Desktop\achatprometi_c_sharp\AchatPrometi\DemoDatabase.mdf;Integrated Security=True;");
            try
            {
                string sql = "delete from Fournisseurs where supplier_id=@supplier_id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@supplier_id", c.id);
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
