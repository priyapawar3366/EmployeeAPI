using EmployeeAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;
        public EmployeeController(DataContext context)
        {
            _context = context;
        }
        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployee()
        {
            return Ok(await _context.Employees.ToListAsync());
        }
        
        [HttpPost]
        
        public async Task<ActionResult<List<Employee>>> CreateEmployee(Employee emp)
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee emp)
        {
            var empfind = await _context.Employees.FindAsync(emp.Id);
            if (empfind == null)
                return BadRequest("Employee not found");
            empfind.Name = emp.Name;
            empfind.Age = emp.Age;
            empfind.Designation = emp.Designation;
            empfind.MobileNumber = emp.MobileNumber;
            await _context.SaveChangesAsync();
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int Id)
        {
            var empfind = await _context.Employees.FindAsync(Id);
            if (empfind == null)
                return BadRequest("Employee not found");
            _context.Employees.Remove(empfind);
            await _context.SaveChangesAsync();
            return Ok(await _context.Employees.ToListAsync());
        }
    }
}
