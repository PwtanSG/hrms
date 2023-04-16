using HRMS.Data;
using HRMS.Models;
using HRMS.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly HRMSDbContext hrmsDbContext;

        public EmployeesController(HRMSDbContext hrmsDbContext)
        {
            this.hrmsDbContext = hrmsDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await hrmsDbContext.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                EmployeeNo = addEmployeeRequest.EmployeeNo,
                Email = addEmployeeRequest.Email,
                ContactNo = addEmployeeRequest.ContactNo,
                Salary = addEmployeeRequest.Salary,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
                Department = addEmployeeRequest.Department,
            };
            await hrmsDbContext.Employees.AddAsync(employee);
            await hrmsDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var employee = await hrmsDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    EmployeeNo = employee.EmployeeNo,
                    Email = employee.Email,
                    ContactNo = employee.ContactNo,
                    Salary = employee.Salary,
                    DateOfBirth = employee.DateOfBirth,
                    Department = employee.Department,
                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel model)
        {
            var employee = await hrmsDbContext.Employees.FindAsync(model.Id);

            if (employee != null)
            {
                employee.Name = model.Name;
                employee.EmployeeNo = model.EmployeeNo;
                employee.Email = model.Email;
                employee.ContactNo = model.ContactNo;
                employee.Salary = model.Salary;
                employee.DateOfBirth = model.DateOfBirth;
                employee.Department = model.Department;
                await hrmsDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var employee = await hrmsDbContext.Employees.FindAsync(model.Id);
            if (employee != null)
            {
                hrmsDbContext.Employees.Remove(employee);
                await hrmsDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
