using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class AddEmployeeViewModel
    {
        [Required]
        public string EmployeeNo { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string ContactNo { get; set; } = null!;
        [Required]
        public long Salary { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Department { get; set; } = null!;
    }
}
