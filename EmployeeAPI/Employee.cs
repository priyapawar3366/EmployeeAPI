using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; } = String.Empty;

        [Required]
        public int Age { get; set; }

        [Required]
        public string? Designation { get; set; } = String.Empty;

        [Required]
        public string? MobileNumber { get; set; }
    }
}
