using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static MyStore.Pages.Products.IndexModel;

namespace MyStore.Pages.Products
{
    public class CreateModel : PageModel
    {
        public ProductInfo productInfo = new ProductInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            try
            {
                productInfo.name = Request.Form["name"];
                productInfo.price = Request.Form["price"];
                productInfo.stock = Request.Form["stock"];
                productInfo.category = Request.Form["category"];

                if (productInfo.name.Length == 0 || productInfo.price.Length == 0 ||
                    productInfo.stock.Length == 0 || productInfo.category.Length == 0)
                {
                    errorMessage = "All the fields are requiered";
                    return;
                }

                String connectionstring = "Data Source=.\\sqlexpress;Initial Catalog=mystore;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    String sql = "INSERT INTO products " +
                        "(name,price,stock,category) VALUES " +
                        "(@name,@price,@stock,@category)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", productInfo.name);
                        command.Parameters.AddWithValue("@price", productInfo.price);
                        command.Parameters.AddWithValue("@stock", productInfo.stock);
                        command.Parameters.AddWithValue("@category", productInfo.category);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            productInfo.name = "";
            productInfo.price = "";
            productInfo.stock = "";
            productInfo.category = "";

            successMessage = "New Client Added Correctly";

            Response.Redirect("/Products/Index");
        }
    }
}
