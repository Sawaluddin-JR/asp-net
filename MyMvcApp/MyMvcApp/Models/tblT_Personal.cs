using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMvcApp.Models
{
    public class tblT_Personal
    {
        [Key]
        public int Id { get; set; }
        public string Nama { get; set; }

        public int IdGender { get; set; }
        [ForeignKey("IdGender")]
        public tblM_Gender Gender { get; set; }

        public int IdHobi { get; set; }
        [ForeignKey("IdHobi")]
        public tblM_Hobi Hobi { get; set; }

        public int Umur { get; set; }
    }
}
