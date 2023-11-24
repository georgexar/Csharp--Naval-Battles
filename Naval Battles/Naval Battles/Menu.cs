using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naval_Battles
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Play_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "Enter Username" && textBox1.Text!="")
            {
                this.Hide();
                new Form1().Show();
                Program.getUsername = textBox1.Text;
            }
            else { MessageBox.Show("ΒΑΛΕ username");return; }
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text != "Enter Username") return;
            textBox1.Text = "";
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
