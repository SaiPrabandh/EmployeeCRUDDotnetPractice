using EmployeeCRUD.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeCRUD.Services
{
    public class EmployeeService : IEmployeeService
    {
        private List<Employee> _employees = new List<Employee>();
        private int _nextId = 1;

        public List<Employee> GetAll()
        {
            return _employees;
        }

        public Employee GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Employee employee)
        {
            employee.Id = _nextId++;
            _employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            var existing = GetById(employee.Id);
            if (existing != null)
            {
                _employees.Remove(existing);
            }
            Add(employee);
        }

        public void Delete(int id)
        {
            var emp = GetById(id);
            if (emp != null)
            {
                _employees.Remove(emp);
            }
        }
    }
}
