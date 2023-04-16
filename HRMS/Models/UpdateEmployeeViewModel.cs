namespace HRMS.Models
{
    public class UpdateEmployeeViewModel
    {
        public Guid Id { get; set; }
        public string EmployeeNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public long Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }
    }
}
