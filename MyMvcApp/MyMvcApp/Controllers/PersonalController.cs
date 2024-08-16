using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyMvcApp.Data;
using MyMvcApp.Models;
using System.Data;

namespace MyMvcApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public PersonalController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitData([FromBody] List<PersonalData> personalData)
        {
            if (personalData == null || !personalData.Any())
            {
                return BadRequest("Invalid data.");
            }

            var dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Nama", typeof(string));
            dataTable.Columns.Add("IdGender", typeof(int));
            dataTable.Columns.Add("IdHobi", typeof(string));
            dataTable.Columns.Add("Umur", typeof(int));

            foreach (var data in personalData)
            {
                dataTable.Rows.Add(DBNull.Value, data.Nama, data.IdGender, data.IdHobi, data.Umur);
            }

            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("dbo.InsertPersonalData", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    var param = new SqlParameter
                    {
                        ParameterName = "@PersonalData",
                        SqlDbType = SqlDbType.Structured,
                        Value = dataTable,
                        TypeName = "dbo.PersonalDataType"
                    };
                    command.Parameters.Add(param);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
            return Ok();
        }
    }
}