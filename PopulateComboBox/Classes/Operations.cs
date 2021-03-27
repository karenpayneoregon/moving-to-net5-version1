using System.Collections.Generic;
using System.Data.SqlClient;

namespace PopulateComboBox.Classes
{
    public class Operations
    {
        public static string ConnectionString = 
            "Data Source=.\\SQLEXPRESS;Initial Catalog=NorthWind2020;Integrated Security=True";

        public static List<Employee> ReadEmployees()
        {
            var list = new List<Employee>();
            using (var cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (var cmd = new SqlCommand() { Connection = cn, CommandText = SelectStatement })
                {
                    cn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new Employee()
                        {
                            EmployeeID = reader.GetInt32(0),
                            LastName = reader.GetString(1),
                            FirstName = reader.GetString(2),
                            Address = reader.GetString(3),
                            City = reader.GetString(4),
                            PostalCode = reader.GetString(5),
                            CountryName = reader.GetString(6),
                            ContactTypeIdentifier = reader.GetInt32(7),
                            CountryIdentifier = reader.GetInt32(8)
                        });
                    }

                }

                return list;
            }
        }

        private static string SelectStatement => @"
SELECT TOP (10) E.EmployeeID, 
                E.LastName, 
                E.FirstName, 
                E.Address, 
                E.City, 
                E.PostalCode, 
                C.Name AS CountryName, 
                E.ContactTypeIdentifier, 
                C.CountryIdentifier
FROM Employees AS E
     INNER JOIN Countries AS C ON E.CountryIdentifier = C.CountryIdentifier;
";
    }
}