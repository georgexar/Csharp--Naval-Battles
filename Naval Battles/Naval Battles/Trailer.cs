using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Naval_Battles
{
    public partial class Trailer : Form
    {
        public Trailer()
        {
            InitializeComponent();
        }

        private void Trailer_Load(object sender, EventArgs e)
        {

            axWindowsMediaPlayer1.URL = @"trailer.mp4";

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }
        int skip = 0;
        private void button1_Click(object sender, EventArgs e)
        {   
            this.Hide();
            new Menu().Show();
            skip++;

        }

        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {  if (skip == 0)
            {
                if (i == 0)
                {
                    this.Hide();
                    new Menu().Show();
                    i++;
                }
            }
        }
    }
}
