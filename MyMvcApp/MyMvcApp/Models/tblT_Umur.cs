using System.ComponentModel.DataAnnotations;

namespace MyMvcApp.Models
{
    public class tblT_Umur
    {
        [Key]
        public int Umur { get; set; }
        public int Total { get; set; }
    }
}
