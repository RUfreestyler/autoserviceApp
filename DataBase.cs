using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoserviceAppication
{
    /// <summary>
    /// Entity of database
    /// </summary>
    public class DataBase
    {
        public MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=autoservicedb;SslMode=none");

        /// <summary>
        /// Opens database connection
        /// </summary>
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        /// <summary>
        /// Closes database connection
        /// </summary>
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Returns database connection
        /// </summary>
        /// <returns></returns>
        public MySqlConnection GetConnection()
        {
            return connection;
        }

        /// <summary>
        /// Updates the list of clients
        /// </summary>
        /// <param name="customers">List of clients</param>
        public void UpdateData(List<Customer> customers)
        {
            customers.Clear();
            var sqlAdapter = new MySqlDataAdapter("SELECT * FROM `cards` WHERE `isFinished` = 0", GetConnection());
            var customersTable = new DataTable();
            sqlAdapter.Fill(customersTable);
            var reader = customersTable.CreateDataReader();
            while (reader.Read())
            {
                var customer = new Customer();
                customer.Car = new Car();
                if(!reader.IsDBNull(reader.GetOrdinal("card_id")))
                    customer.Id = reader.GetInt32(reader.GetOrdinal("card_id"));
                if(!reader.IsDBNull(reader.GetOrdinal("client_name")))
                    customer.Name = reader.GetString(reader.GetOrdinal("client_name"));
                if(!reader.IsDBNull(reader.GetOrdinal("client_phonenumber")))
                    customer.Phone = reader.GetString(reader.GetOrdinal("client_phonenumber"));
                if(!reader.IsDBNull(reader.GetOrdinal("mark")))
                    customer.Car.Mark = reader.GetString(reader.GetOrdinal("mark"));
                if(!reader.IsDBNull(reader.GetOrdinal("model")))
                    customer.Car.Model = reader.GetString(reader.GetOrdinal("model"));
                if(!reader.IsDBNull(reader.GetOrdinal("license_plate")))
                    customer.Car.Number = reader.GetString(reader.GetOrdinal("license_plate"));
                if(!reader.IsDBNull(reader.GetOrdinal("problem_description")))
                    customer.Problem = reader.GetString(reader.GetOrdinal("problem_description"));
                if(!reader.IsDBNull(reader.GetOrdinal("employee_name")))
                    customer.EmployeeName = reader.GetString(reader.GetOrdinal("employee_name"));
                if(!reader.IsDBNull(reader.GetOrdinal("used_details")))
                    customer.Details = reader.GetString(reader.GetOrdinal("used_details"));
                if(!reader.IsDBNull(reader.GetOrdinal("services")))
                    customer.Services = reader.GetString(reader.GetOrdinal("services"));
                customers.Add(customer);
            }
        }
    }
}
