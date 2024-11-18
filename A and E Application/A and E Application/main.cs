using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_and_E_Application
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Rock_Paper_and_Scissors_Game().Show();
            this.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new SpaceRunner().Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new AirCombat().Show();
            this.Close();
        }
    }
}
