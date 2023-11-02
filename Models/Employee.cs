using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
    }
}
