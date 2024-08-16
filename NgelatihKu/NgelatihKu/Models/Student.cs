using System.ComponentModel.DataAnnotations;

namespace NgelatihKu.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prodi { get; set; }
        public string Address { get; set; }
    }
}
