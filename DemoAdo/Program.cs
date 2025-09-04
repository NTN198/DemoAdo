using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAdo
{
    internal class Program
    {
        const string connectionString = "Server=.;Database=DemoASP;User=sa;Password=123456Aa;TrustServerCertificate=True";
        static void Main(string[] args)
        {
            InsertBook("Book 3", 15);
            GetBooks();
        }

        public static void GetBooks()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT Id, Title, Price FROM Books";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Books");

            DataTable tblBooks = ds.Tables["Books"];
            foreach (DataRow dr in tblBooks.Rows)
            {
                Console.WriteLine($"Id={dr[0]}, Title={dr[1]}, Price={dr[2]}");
            }
        }

        public static void InsertBook(string title, int price)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "INSERT INTO Books (Title, Price) VALUES (@title, @price)";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            // truyền tham số
            cmd.Parameters.Add(new SqlParameter("title", title));
            cmd.Parameters.Add(new SqlParameter("price", price));
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
