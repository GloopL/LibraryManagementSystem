using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagementSystem;

namespace LibraryManagementSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Enable visual styles for the application
            Application.EnableVisualStyles();

            // Set compatible text rendering
            Application.SetCompatibleTextRenderingDefault(false);

            // Run the main form (Form1)
            Application.Run(new Form1());
        }
    }
}




