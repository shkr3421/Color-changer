using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata.Ecma335;
namespace ADODemo.Models
{
    public class ProductRepository
    {
        private readonly string _connectionString;
        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public List<Product> GetAll()
        {
            var products = new List<Product>();
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select * FROM Product", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                products.Add(new Product
                {
                    ProdId = (int)reader["ProdId"],
                    ProdName = reader["ProdName"].ToString(),
                    ProdPrice = Convert.ToSingle(reader["ProdPrice"]),
                    ProdQty = (int)reader["ProdQty"]
                });
            }
         reader.Close();
         conn.Close();

         return products;
        }
        public Product GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var cmd = new SqlCommand("Select * FROM Product WHERE ProdId=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                return new Product
                {
                    ProdId = (int)reader["ProdId"],
                    ProdName = reader["ProdName"].ToString(),
                    ProdPrice = Convert.ToSingle(reader["ProdPrice"]),
                    ProdQty = (int)reader["ProdQty"]
                };
            }
            return null;
        }
        public void Add(Product product)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Product (ProdName, ProdPrice, ProdQty) VALUES (@Name, @Price, @Qty)",
                conn);
            cmd.Parameters.AddWithValue("@Name", product.ProdName);
            cmd.Parameters.AddWithValue("@Price", product.ProdPrice);
            cmd.Parameters.AddWithValue("@Qty", product.ProdQty);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Update(Product product)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            var cmd = new SqlCommand(
                "UPDATE Product SET ProdName=@Name, ProdPrice=@Price, ProdQty=@Qty where ProdId = @Id",
                conn);
            cmd.Parameters.AddWithValue("@Id", product.ProdId); 
            cmd.Parameters.AddWithValue("@Name", product.ProdName);
            cmd.Parameters.AddWithValue("@Price", product.ProdPrice);
            cmd.Parameters.AddWithValue("@Qty", product.ProdQty);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Delete(int id)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            var cmd = new SqlCommand("DELETE FROM Product WHERE ProdId=@id",conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
