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
    public partial class Articles : Form
    {
        public Articles()
        {
            InitializeComponent();
        }
        articles_class c = new articles_class();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home NHome = new Home();
            NHome.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fournisseurs NFournisseurs = new Fournisseurs();
            NFournisseurs.Show();
        }
        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }
        private void button3_Click(object sender, EventArgs e)
        {
            c.article = textBox2.Text;
            c.client = textBox3.Text;
            c.désignation = textBox4.Text;
            c.prix_unitaire = textBox5.Text;


            bool success = c.Insert(c);
            if (success == true)
            {
                MessageBox.Show("L'enregistrement a été ajouté avec succés !");
                clear();
            }
            else
            {
                MessageBox.Show("Echec d'ajouter cet Enregistrement !!");
            }
            DataTable dt = c.Select();
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                c.id = int.Parse(textBox1.Text);
                c.article = textBox2.Text;
                c.client = textBox3.Text;
                c.désignation = textBox4.Text;
                c.prix_unitaire = textBox5.Text;

                bool success = c.Update(c);
                if (success == true)
                {
                    MessageBox.Show("Les modifications ont été enregistrées avec succés !");
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

        private void button5_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Echec de la suppression, Veuillez réssayer !!");
                }
                c.article = textBox2.Text;
                c.client = textBox3.Text;
                c.désignation = textBox6.Text;
                c.prix_unitaire = textBox5.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veuillez choisir un enregistrement !!");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            string keyword = textBox6.Text;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAHDI\Desktop\achatprometi_c_sharp\achat_prometi\DemoDatabase.mdf;Integrated Security=True;");
            SqlDataAdapter sda = new SqlDataAdapter("select * from Articles where article_id like '%" + keyword + "%' or article like '%" + keyword + "%' or client like '%" + keyword + "%' or désignation like '%" + keyword + "%' or prix_unitaire like '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
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
        }

        private void Articles_Load(object sender, EventArgs e)
        {
            DataTable dt = c.Select();
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
