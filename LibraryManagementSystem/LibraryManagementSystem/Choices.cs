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
    public partial class Choices : Form
    {
        // Constructor for the Choices form
        public Choices()
        {
            InitializeComponent();
        }

        // Event handler for the 'Student' button click
        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the Student1 form
            Student1 form3 = new Student1();
            // Show the Student1 form
            form3.Show();
            // Hide the current Choices form
            this.Hide();
        }

        // Event handler for the 'Admin' button click
        private void button2_Click(object sender, EventArgs e)
        {
            // Create an instance of the Admin form
            Admin form4 = new Admin();
            // Show the Admin form
            form4.Show();
            // Hide the current Choices form
            this.Hide();
        }

        // Event handler for the form load event
        private void Choices_Load(object sender, EventArgs e)
        {
            // This method can be used for any additional setup when the form loads
            // Currently, it's empty
        }
    }
}

