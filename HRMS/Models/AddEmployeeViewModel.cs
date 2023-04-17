﻿using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class AddEmployeeViewModel
    {
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
        public string Department { get; set; }
    }
}
