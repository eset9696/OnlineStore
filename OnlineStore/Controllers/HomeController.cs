using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OnlineStore.Models.Domain;
using OnlineStore.Models.View;
using OnlineStore.Services;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromServices] IProductService productService)
        {
            HomePageViewModel viewModel = new HomePageViewModel()
            {
                Products = productService.GetProducts()
            };
            return View(viewModel);
        }

        public IActionResult TestDatabaeConnection([FromServices] IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("Default");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Products";

                SqlDataReader reader =  command.ExecuteReader();

                while (reader.Read())
                {
                    //Разные способы чтения данных из ДБ
                    object id = reader[0]; // Как в массиве
                    object name = reader["Name"]; //По имени колонки в ДБ
                    string description = reader.GetString(2); // Можно сразу получить данные по типу данных в ДБ
                    object price = reader.GetValue(3); // Через метод по номеру колонки
                    Console.WriteLine($"Id - {id}, Name - {name}, Description - {description}, Price - {price}");
                }
            }


            Console.WriteLine(connectionString);
            return Ok();
        }
    }
}
