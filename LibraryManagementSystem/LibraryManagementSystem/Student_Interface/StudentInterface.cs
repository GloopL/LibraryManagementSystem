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
    public partial class StudentInterface : Form
    {
        public StudentInterface()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Student1 StudentInterface = new Student1();
            StudentInterface.Show();
            this.Close();
        }
    }
}
