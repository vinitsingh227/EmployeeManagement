using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppContexts _appContexts;

        public SQLEmployeeRepository(AppContexts appContexts)
        {
            this._appContexts = appContexts;
        }
        public Employee Add(Employee employee)
        {
            //Add method add teh changes 
            _appContexts.Employees.Add(employee);
            //SaveChanges method save the details in teh database
            _appContexts.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _appContexts.Employees.Find(id);
            if(employee!= null)
            {
                _appContexts.Employees.Remove(employee);
                _appContexts.SaveChanges();
            }

            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _appContexts.Employees;
        }

        public Employee GetEmployee(int id)
        {
            return _appContexts.Employees.Find(id);
        }

        public Employee Update(Employee employeeChnages)
        {
            var employee = _appContexts.Employees.Attach(employeeChnages);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _appContexts.SaveChanges();
            return employeeChnages;
        }
    }
}
