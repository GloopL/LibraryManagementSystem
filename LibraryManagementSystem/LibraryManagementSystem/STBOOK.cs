using LibraryManagementSystem.STBBOOKS_SECTION;
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
    public partial class STBOOK : Form
    {
        // Constructor for the STBOOK form
        public STBOOK()
        {
            InitializeComponent();
        }

        // Button click event to open ST_CAS_BOOKS form
        private void button1_Click(object sender, EventArgs e)
        {
            ST_CAS_BOOKScs STBOOK = new ST_CAS_BOOKScs();
            STBOOK.Show();
            this.Close();
        }

        // Button click event to open ST_CABE_BOOKS form
        private void button2_Click(object sender, EventArgs e)
        {
            ST_CABE_BOOKS STBOOK = new ST_CABE_BOOKS();
            STBOOK.Show();
            this.Close();
        }

        // Button click event to open ST_CICS_BOOKS form
        private void button3_Click(object sender, EventArgs e)
        {
            ST_CICS_BOOKS STBOOK = new ST_CICS_BOOKS();
            STBOOK.Show();
            this.Close();
        }

        // Button click event to open ST_CTE_BOOKS form
        private void button5_Click(object sender, EventArgs e)
        {
            ST_CTE_BOOKS STBOOK = new ST_CTE_BOOKS();
            STBOOK.Show();
            this.Close();
        }

        // Button click event to open ST_CIT_BOOKS form
        private void button4_Click(object sender, EventArgs e)
        {
            ST_CIT_BOOKS STBOOK = new ST_CIT_BOOKS();
            STBOOK.Show();
            this.Close();
        }

        // Button click event to open ST_COE_BOOKS form
        private void button6_Click(object sender, EventArgs e)
        {
            ST_COE_BOOKS STBOOK = new ST_COE_BOOKS();
            STBOOK.Show();
            this.Close();
        }

        // Button click event to open StudentInterface form
        private void button7_Click(object sender, EventArgs e)
        {
            StudentInterface STBOOK = new StudentInterface();
            STBOOK.Show();
            this.Close();
        }

        // Load event for the STBOOK form
        private void STBOOK_Load(object sender, EventArgs e)
        {
            // You can add any additional initialization code here if needed
        }
    }
}

