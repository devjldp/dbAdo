
using Npgsql;
using DbAdo.data; // importing namespace with the class DbConnection

namespace DbAdo.Controller
{
    public class CrudOperations
    {
        // Create a private conexion
        private NpgsqlConnection _connection;

        // constructor
        public CrudOperations(){
            // hold in the field _connection what we return from the method GetConnection()
            _connection = new DbConnection().GetConnection();
        }

        // Insert method
        public void InsertBook(string title, string author, string category, int year)
        {
            // Open the connection between our program and the database
            _connection.Open();

            // Write SQL statement
            string query = "INSERT INTO books (title, author, category, year) VALUES(@title, @author, @category, @year)";

            using(var cmd = new NpgsqlCommand(query, _connection))
            {   
                cmd.Parameters.AddWithValue("title", title);
                cmd.Parameters.AddWithValue("author", author);
                cmd.Parameters.AddWithValue("category", category);
                cmd.Parameters.AddWithValue("year", year);

                cmd.ExecuteNonQuery();

            }
            Console.WriteLine("Book added!");

            // close the connection
            _connection.Close();
        }
    

        // Read data

        public void GetBooks()
        {
            // open the conexion
            _connection.Open();

            string query = "SELECT * FROM books";

            using(var cmd = new NpgsqlCommand(query, _connection)) // Create Command
            using( var reader = cmd.ExecuteReader()) // Execute the query using ExecuteReader returns an object: NpgsqlDataReader
            {
                while(reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]} | Title: {reader["title"]} | Author: {reader["author"]} | Category: {reader["category"]} | Year of publish: {reader["year"]}");
                }
            }
            _connection.Close();
        }

    }
}