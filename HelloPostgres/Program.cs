using System;
using Npgsql; // Install-Package Npgsql -Version 4.1.3.1

namespace HelloPostgres
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connString = "Host=crt.sh;Username=guest;Password=certwatch;Database=certwatch";
            var conn = new NpgsqlConnection(connString);
            conn.Open();
            // List all certificate authorities
            var cmd = new NpgsqlCommand("select name from ca", conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["name"]);
            }   
            conn.Close();
            Console.ReadLine();
        }
    }
}
