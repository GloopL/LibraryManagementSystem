using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace LibraryManagementSystem
{
    internal class ST_ADINTERFACE
    {
        DATABASE.MYDB db = new DATABASE.MYDB();
        private DataTable table;

        // Function to add a student
        public bool AddStudent(string Srcode, string Sname, string dept, string phonenum, string add, string pass)
        {
            string query = "INSERT INTO librarymanagementsystem.student (`SRCode`,`StudentName`, `Department`, `StudentPhoneNumber`,  `Address`, `Password`) VALUES (@srcode,@sn,@dept,@phonenum,@add,@pass)";

            using (MySqlConnection connection = db.GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.Add("@srcode", MySqlDbType.VarChar).Value = Srcode;
                    command.Parameters.Add("@sn", MySqlDbType.VarChar).Value = Sname;
                    command.Parameters.Add("@dept", MySqlDbType.VarChar).Value = dept;
                    command.Parameters.Add("@phonenum", MySqlDbType.VarChar).Value = phonenum;
                    command.Parameters.Add("@add", MySqlDbType.VarChar).Value = add;
                    command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;

                    // Execute the command directly since it's an INSERT operation
                    int rowsAffected = db.SetData(command);

                    return rowsAffected == 1;
                }
            }
        }

        // Function to edit a student info
        public bool EditStudent(int id, string Srcode, string Sname, string dept, string phonenum, string add, string pass)
        {
            string query = "UPDATE `student` SET `SRCode`= @src, `StudentName`= @sn, `Department`= @dep, `StudentPhoneNumber`= @spn, `Address`= @add, `Password`= @pass WHERE `StudentID`= @sid";

            using (MySqlConnection connection = db.GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.Add("@sid", MySqlDbType.Int32).Value = id;
                    command.Parameters.Add("@src", MySqlDbType.VarChar).Value = Srcode;
                    command.Parameters.Add("@sn", MySqlDbType.VarChar).Value = Sname;
                    command.Parameters.Add("@dep", MySqlDbType.VarChar).Value = dept;
                    command.Parameters.Add("@spn", MySqlDbType.VarChar).Value = phonenum;
                    command.Parameters.Add("@add", MySqlDbType.VarChar).Value = add;
                    command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;

                    // Execute the command directly since it's an UPDATE operation
                    int rowsAffected = db.SetData(command);

                    return rowsAffected == 1;
                }
            }
        }

        // Function to remove a student info
        public bool RemoveStudent(int id)
        {
            string query = "DELETE FROM `student` WHERE `StudentID`= @sid";

            using (MySqlConnection connection = db.GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.Add("@sid", MySqlDbType.Int32).Value = id;

                    // Execute the command directly since it's a DELETE operation
                    int rowsAffected = db.SetData(command);

                    return rowsAffected == 1;
                }
            }
        }

        // Function to get a list of students
        public DataTable StudentList()
        {
            string query = "SELECT * FROM student";
            DataTable table = db.GetData(query, null);
            Console.WriteLine("Number of rows retrieved: " + table.Rows.Count);
            return table;
        }

        // Function to search for a student
        public DataTable SearchStudent(string searchQuery)
        {
            string selectQuery = $"SELECT * FROM student WHERE SRC LIKE '%{searchQuery}%' OR StudentName LIKE '%{searchQuery}%'";
            return db.GetData(selectQuery, null);
        }
    }
}
