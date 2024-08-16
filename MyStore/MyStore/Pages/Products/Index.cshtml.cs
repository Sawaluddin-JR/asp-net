using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MyStore.Pages.Products
{
    public class IndexModel : PageModel
    {
        public List<ProductInfo> listProduct = new List<ProductInfo>();
        public void OnGet()
        {
            try
            {

                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=mystore;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM products";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductInfo productInfo = new ProductInfo();

                                productInfo.id = "" + reader.GetInt32(0);
                                productInfo.name = reader.GetString(1);
                                productInfo.price = reader.GetDecimal(2).ToString();
                                productInfo.stock = reader.GetInt32(3).ToString();
                                productInfo.category = reader.GetString(4);
                                productInfo.created_at = reader.GetDateTime(5).ToString();

                                listProduct.Add(productInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Exception " + ex.ToString());
            }
        }

        public class ProductInfo
        {
            public String id { get; set; }
            public String name { get; set; }
            public String price { get; set; }
            public String stock { get; set; }
            public String category { get; set; }
            public String created_at { get; set; }
        }
    }
}
