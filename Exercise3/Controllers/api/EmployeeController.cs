using Exercise3.Models;
using Exercise3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exercise3.Controllers.api
{
    [Route("api/employee")]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [Route("")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = employeeService.GetAll();
            return Ok(new { data });
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetById([FromRoute] int id)
        {
            var data = employeeService.GetById(id);
            return Ok(new { data });
        }

        [Route("")]
        [HttpPost]
        public IActionResult Create([FromBody] Employee employee)
        {
            employeeService.Create(employee);
            return Ok(new { message = "Created." });
        }

        [Route("")]
        [HttpPut]
        public IActionResult Update([FromBody] Employee employee)
        {
            employeeService.Update(employee);
            return Ok(new { message = "Updated." });
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete([FromRoute] int id)
        {
            employeeService.Delete(id);
            return Ok(new { message = "Deleted." });
        }
    }
}
