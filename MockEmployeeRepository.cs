using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private static List<Employee> employeesList;
        public MockEmployeeRepository()
        {
            employeesList = new List<Employee>()
            {
                new Employee() {Id=101, Name="Vinit", Email="vks@gmail.com", Department=Dept.IT },
                new Employee() {Id=102, Name="Amit", Email="ak@gmail.com", Department=Dept.HR },
                new Employee() {Id=103, Name="Sumit", Email="su@gmail.com", Department=Dept.IT },
                new Employee() {Id=104, Name="Ravi", Email="ra@gmail.com", Department=Dept.Payroll }
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = employeesList.Max(e => e.Id) + 1;
            employeesList.Add(employee);
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeesList;
        }

        public Employee GetEmployee(int id)
        {
            return employeesList.FirstOrDefault(e => e.Id == id);
        }
        public Employee Delete(int id)
        {
           Employee employee = employeesList.FirstOrDefault(e => e.Id == id);
            if(employee != null)
            {
                employeesList.Remove(employee);
            }
            return employee;
        }

        public Employee Update(Employee employeeChnage)
        {
            Employee employee = employeesList.FirstOrDefault(e => e.Id == employeeChnage.Id);
            if (employee != null)
            {
                employee.Name = employeeChnage.Name;
                employee.Email = employeeChnage.Email;
                employee.Department = employeeChnage.Department;
            }
            return employee;
        }
    }
}
