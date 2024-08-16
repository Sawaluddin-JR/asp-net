using System.ComponentModel.DataAnnotations;

namespace MyMvcApp.Models
{
    public class tblM_Hobi
    {
        [Key]
        public int Id { get; set; }
        public string Nama { get; set; }
    }
}
