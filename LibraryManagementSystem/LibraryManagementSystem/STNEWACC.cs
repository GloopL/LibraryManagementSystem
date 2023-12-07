using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class STNEWACC
    {
        DATABASE.MYDB db = new DATABASE.MYDB();

        // Function to add a new student to the database
        public bool AddStudent(string Sname, string Srcode, string dept, string phonenum, string add, string pass)
        {
            string query = "INSERT INTO librarymanagementsystem.student (`SRCode`,`StudentName`, `Department`, `StudentPhoneNumber`,  `Address`, `Password`) VALUES (@Sname,@Srcode,@dept,@phonenum,@add,@pass)";

            // Using statement ensures proper disposal of resources
            using (MySqlConnection connection = db.GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Add parameters to the SQL command
                    command.Parameters.Add("@Sname", MySqlDbType.VarChar).Value = Sname;
                    command.Parameters.Add("@Srcode", MySqlDbType.VarChar).Value = Srcode;
                    command.Parameters.Add("@dept", MySqlDbType.VarChar).Value = dept;
                    command.Parameters.Add("@phonenum", MySqlDbType.VarChar).Value = phonenum;
                    command.Parameters.Add("@add", MySqlDbType.VarChar).Value = add;
                    command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;

                    try
                    {
                        connection.Open();
                        // ExecuteNonQuery returns the number of rows affected
                        int rowsAffected = command.ExecuteNonQuery();

                        Console.WriteLine($"Rows affected: {rowsAffected}");

                        // Return true if at least one row was affected (student added successfully)
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}

