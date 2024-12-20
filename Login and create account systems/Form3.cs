using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_and_create_account_systems
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            HideNav();
        }


        //Application Exit

        private void exit_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

            if (panel_hidden.Visible == false)
            {
                panel_hidden.Visible = true;
                this.Size = new Size(1400, 800);
            }
            else
            {
                panel_hidden.Visible = false;
                this.Size = new Size(1240, 800);
            }
        }

        private void panel_hidden_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HideNav()
        {
            panel_hidden.Visible = true;
        }

    }
}
