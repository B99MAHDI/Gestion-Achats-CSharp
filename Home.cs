using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AchatPrometi
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        home_class c = new home_class();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fournisseurs NFournisseurs = new Fournisseurs();
            NFournisseurs.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Articles NArticles = new Articles();
            NArticles.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Compte NCompte = new Compte();
            NCompte.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            c.Date = dateTimePicker1.Text;
            c.Note = textBox2.Text;


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

        private void button8_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            dateTimePicker1.Value = DateTime.Now;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                c.Note_id = int.Parse(textBox1.Text);
                c.Date = dateTimePicker1.Text;
                c.Note = textBox2.Text;

                bool success = c.Update(c);

                if (success == true)
                {
                    MessageBox.Show("Les modification ont été enregistrées avec succés !");
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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                c.Note_id = Convert.ToInt32(textBox1.Text);
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
                c.Date = dateTimePicker1.Text;
                c.Note = textBox2.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Veuillez choisir un enregistrement !!");
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            DataTable dt = c.Select();
            dataGridView1.DataSource = dt;
        }
    }
}
