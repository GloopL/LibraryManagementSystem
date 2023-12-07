using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace LibraryManagementSystem.DATABASE
{
    internal class MYDB
    {
        // CONNECTIONS
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=librarymanagementsystem");

        // Function to open the connection
        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        // Function to close the connection
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // Function to return the connection
        public MySqlConnection GetConnection()
        {
            return connection;
        }

        // Function to return a table of data
        // Parameters: query = the SQL query, parameters = the parameters of the query
        public DataTable GetData(string query, List<MySqlParameter> parameters)
        {
            DataTable dataTable = new DataTable();
            OpenConnection(); // Open the connection before executing the command

            try
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters.ToArray());
                    }

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetData: {ex.Message}");
            }
            finally
            {
                CloseConnection(); // Close the connection after executing the command
            }

            return dataTable;
        }

        // Function to execute a command that modifies data (e.g., INSERT, UPDATE, DELETE)
        // Parameters: command = the MySqlCommand to execute
        public int SetData(MySqlCommand command)
        {
            int rowsAffected = 0;
            OpenConnection(); // Open the connection before executing the command
            command.Connection = connection;
            rowsAffected = command.ExecuteNonQuery();
            CloseConnection(); // Close the connection after executing the command
            return rowsAffected;
        }
    }
}
