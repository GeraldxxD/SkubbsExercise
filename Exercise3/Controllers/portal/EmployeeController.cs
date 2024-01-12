using Exercise3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exercise3.Controllers.portal
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public IActionResult List()
        {
            return View();
        }

       
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update([FromRoute] int id)
        {
            var employee = employeeService.GetById(id);
            return View(employee);
        }

    }
}
