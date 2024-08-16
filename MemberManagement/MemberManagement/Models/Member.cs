using System.ComponentModel.DataAnnotations;

namespace MemberManagement.Models
{
    public class Member
    {
        [Key]
        public int PersonalID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Member), nameof(ValidateAge))]
        public DateTime DateOfBirth { get; set; }
        public bool IsPriority { get; set; }

        [Range(0, int.MaxValue)]
        public int Order { get; set; }

        public static ValidationResult ValidateAge(DateTime dateOfBirth, ValidationContext context)
        {
            var age = DateTime.Now.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Now.AddYears(-age)) age--;

            return age >= 5 ? ValidationResult.Success : new ValidationResult("Umur anda harus lebih dari 5 tahun");
        }
    }
}
