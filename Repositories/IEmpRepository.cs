using DemoAPI.Models;

namespace DemoAPI.Repositories
{
    public interface IEmpRepository // Abstraction layer between application and data access layer (EmployeeContext) 
        // Represents operations to be performed on database
    {
        Task<IEnumerable<Employee>> Get();
        Task<Employee> Get(int EmpId);
        Task<Employee> Create(Employee employee);
        Task Update(Employee employee);
        Task Delete(int EmpId);
    }
}
