using DemoAPI.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace DemoAPI.Repositories
{
    public class EmployeeRepository : IEmpRepository
    {
        private EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context) 
        {
            _context = context;
        }

        public async Task<Employee> Create(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task Delete(int EmpId)
        {
            var employeeToDelete = await _context.Employees.FindAsync(EmpId);
            _context.Employees.Remove(employeeToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> Get(int EmpId)
        {
            return await _context.Employees.FindAsync(EmpId);
        }

        public async Task Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
