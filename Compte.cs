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
    public partial class Compte : Form
    {
        public Compte()
        {
            InitializeComponent();
        }
        compte_class c = new compte_class();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home NHome = new Home();
            NHome.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.Nom = textBox1.Text;
            c.Prenom = textBox2.Text;
            c.Email = textBox3.Text;
            c.Pwd = textBox4.Text;

            bool success = c.Update(c);
            if (success == true)
            {
                MessageBox.Show("Les modification ont été enregistrées avec succés !");
            }
            else
            {
                MessageBox.Show("Echec de la modification !!");
            }
            this.Hide();
            Home Nhome = new Home();
            Nhome.Show();
        }

        private void Compte_Load(object sender, EventArgs e)
        {

        }
    }
}
