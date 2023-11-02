using DemoAPI.Models;
using DemoAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase // Class responsible for handling requests at endpoints
    {
        private readonly IEmpRepository _empRepository;

        public EmployeesController(IEmpRepository empRepository)
        {
            _empRepository = empRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _empRepository.Get();
        }

        [HttpGet("{EmpId}")]
        public async Task<ActionResult<Employee>> GetEmployees(int EmpId)
        {
            return await _empRepository.Get(EmpId);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployees([FromBody] Employee employee)
        {
            var newEmployee = await _empRepository.Create(employee);
            return CreatedAtAction(nameof(GetEmployees), new {newEmployee.EmpId});
        }

        [HttpPut]
        public async Task<ActionResult> PutEmployees(int EmpId, [FromBody] Employee employee)
        {
            if(EmpId != employee.EmpId)
            {
                return BadRequest();
            }
            await _empRepository.Update(employee);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int EmpId)
        {
            var employeeToDelete = await _empRepository.Get(EmpId);
            if (employeeToDelete == null)
                return NotFound();
            await _empRepository.Delete(employeeToDelete.EmpId);
            return NoContent();
        }
    }
}
