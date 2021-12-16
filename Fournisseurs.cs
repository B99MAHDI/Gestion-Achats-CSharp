using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AchatPrometi
{
    public partial class Fournisseurs : Form
    {
        public Fournisseurs()
        {
            InitializeComponent();
        }
        fournisseurs_class c = new fournisseurs_class();
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home NHome = new Home();
            NHome.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Articles NArticles = new Articles();
            NArticles.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            c.ct_num = textBox1.Text;
            c.dl_design = textBox2.Text;
            c.prix_unitaire = textBox3.Text;
            c.commerciale = textBox4.Text;
            c.numero = textBox5.Text;
            c.email = textBox7.Text;

            bool success = c.Insert(c);
            if (success == true)
            {
                MessageBox.Show("L'enreistrement a été ajouté avec succés !");
                clear();
            }
            else
            {
                MessageBox.Show("Echec d'ajouter cet Enregistrement !!");
            }
            DataTable dt = c.Select();
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                c.id = int.Parse(textBox1.Text);
                c.ct_num = textBox2.Text;
                c.dl_design = textBox3.Text;
                c.prix_unitaire = textBox4.Text;
                c.commerciale = textBox5.Text;
                c.numero = textBox6.Text;
                c.email = textBox7.Text;
                bool success = c.Update(c);
                if (success == true)
                {
                    MessageBox.Show("L'enregistrement a été Modifié avec succés !");
                    DataTable dt = c.Select();
                    dataGridView1.DataSource = dt;
                    clear();

                }
                else
                {
                    MessageBox.Show("Echec de la modification !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veuillez choisir un enregistrement !!");
            }
        }
        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                c.id = Convert.ToInt32(textBox1.Text);
                bool success = c.Delete(c);
                if (success == true)
                {
                    MessageBox.Show("L'enregistrement a été supprimé avec succés !");
                    DataTable dt = c.Select();
                    dataGridView1.DataSource = dt;
                    clear();
                }
                else
                {
                    MessageBox.Show("Echec de la suppression, Veuillez réessayer !!");
                }
                c.ct_num = textBox2.Text;
                c.dl_design = textBox3.Text;
                c.prix_unitaire = textBox4.Text;
                c.commerciale = textBox5.Text;
                c.numero = textBox6.Text;
                c.email = textBox7.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veuillez choisir un enregistrement !!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void Fournisseurs_Load(object sender, EventArgs e)
        {
            DataTable dt = c.Select();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox8.Text;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAHDI\Desktop\achatprometi_c_sharp\AchatPrometi\DemoDatabase.mdf;Integrated Security=True;");
            SqlDataAdapter sda = new SqlDataAdapter("select * from Fournisseurs where supplier_id like '%" + keyword + "%' or ct_num like '%" + keyword + "%' or dl_design like '%" + keyword + "%' or prix_unitaire like '%" + keyword + "%' or commerciale like '%" + keyword + "%' or numero like '%" + keyword + "%' or email like '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
