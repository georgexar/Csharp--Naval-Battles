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
    public partial class RestartMenu : Form
    {


        public long wins;
        public int loses;

        public RestartMenu()
        {
            InitializeComponent();
              
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Playagain_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();

        }

        private void RestartMenu_Load(object sender, EventArgs e)
        {
        }
    }
}
