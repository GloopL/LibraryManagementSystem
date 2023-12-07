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
    public partial class Form1 : Form
    {
        // Total number of steps for the progress
        private int totalSteps = 100;
        // Current step in the progress
        private int currentStep = 0;

        // Constructor for the Form1 class
        public Form1()
        {
            InitializeComponent();
        }

        // Event handler for the timer tick event
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Check if the current step is less than the total steps
            if (currentStep < totalSteps)
            {
                // Calculate the percentage of completion
                double percentage = (double)currentStep / totalSteps * 100;
                // Update the label text with the percentage
                label1.Text = $"{percentage}%";

                // Increment the current step
                currentStep++;
            }
            else
            {
                // Stop the timer when all steps are completed
                timer1.Stop();

                // Create an instance of the Choices form
                Choices form2 = new Choices();

                // Show the Choices form
                form2.Show();
                // Hide the current Form1 form
                this.Hide();
            }
        }

        // Event handler for the form load event
        private void Form1_Load(object sender, EventArgs e)
        {
            // Start the timer when the form loads
            timer1.Start();
        }

        // Event handler for the button click event
        private void button1_Click(object sender, EventArgs e)
        {
            // Start the timer when the button is clicked
            timer1.Start();
        }
    }
}

