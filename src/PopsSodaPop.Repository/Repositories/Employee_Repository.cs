using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Employee_Repository
    {
        private readonly List<Employee> _employeeDatabase = new List<Employee>();
        private int _count; 
        public bool AddEmployeeToDatabase(Employee employee)
        {
            if(employee != null)
            {
                _count++;
                employee.ID=_count;
                _employeeDatabase.Add(employee);
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Employee> GetAllEmployees()
        {
            return _employeeDatabase;
        }
        public Employee GetEmployeeByID(int id)
        {
            foreach(var employee in _employeeDatabase)
            {
                if(employee.ID == id)
                {
                    return employee;
                }
            }
            return null;
        }

        //Challenge: do update and delet methods
    }
