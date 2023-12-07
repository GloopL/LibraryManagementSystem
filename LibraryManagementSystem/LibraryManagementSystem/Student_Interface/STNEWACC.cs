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
       

        //create a function to add student
        public bool AddStudent(string Sname, string Srcode, string dept, string phonenum, string add, string pass)
        {
            string query = "INSERT INTO librarymanagementsystem.student (`SRCode`,`StudentName`, `Department`, `StudentPhoneNumber`,  `Address`, `Password`) VALUES (@Sname,@Srcode,@dept,@phonenum,@add,@pass)";

            using (MySqlConnection connection = db.GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.Add("@sn", MySqlDbType.VarChar).Value = Sname;
                    command.Parameters.Add("@src", MySqlDbType.VarChar).Value = Srcode;
                    command.Parameters.Add("@dept", MySqlDbType.VarChar).Value = dept;
                    command.Parameters.Add("@pnm", MySqlDbType.VarChar).Value = phonenum;
                    command.Parameters.Add("@add", MySqlDbType.VarChar).Value = add;
                    command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;

                    try
                    {
                        connection.Open();
                        // ExecuteNonQuery returns the number of rows affected
                        int rowsAffected = command.ExecuteNonQuery();

                        Console.WriteLine($"Rows affected: {rowsAffected}");

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
