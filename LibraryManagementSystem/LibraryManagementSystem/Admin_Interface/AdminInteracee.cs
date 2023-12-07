using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class AdminInteracee : Form
    {
        public AdminInteracee()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin AdminInteracee = new Admin ();
            AdminInteracee.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // SHOW STUDENT ACC TO THE ADMIN INTERFACE
            ST_ADINTERFACEE AdminInteracee = new ST_ADINTERFACEE ();
            AdminInteracee.Show();
            this.Close();


        }

        private void AdminInteracee_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
             LIBBOOK AdminInteracee = new LIBBOOK ();
            AdminInteracee.Show();
            this.Close();
        }
    }
}
