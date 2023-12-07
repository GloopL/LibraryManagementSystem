using LibraryManagementSystem.LIBBOOKSSECTION;
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
    public partial class LIBBOOK : Form
    {
        public LIBBOOK()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            COE_BOOKS LIBBOOK = new COE_BOOKS();
            LIBBOOK.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdminInteracee LIBBOOK = new AdminInteracee();
            LIBBOOK.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CAS_BOOKS LIBBOOK = new CAS_BOOKS();
            LIBBOOK.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CABE_BOOKS LIBBOOK = new CABE_BOOKS();
            LIBBOOK.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CICS_BOOKS LIBBOOK = new CICS_BOOKS();
            LIBBOOK.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CTE_BOOKS LIBBOOK = new CTE_BOOKS();
            LIBBOOK.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CIT_BOOKS LIBBOOK = new CIT_BOOKS();
            LIBBOOK.Show(); 
            this.Close();
        }
    }
}
