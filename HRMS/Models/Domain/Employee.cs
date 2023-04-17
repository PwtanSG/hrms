using System.ComponentModel.DataAnnotations;

namespace HRMS.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        [Required]
        public string EmployeeNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public long Salary { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Department { get; set;}
    }
}
