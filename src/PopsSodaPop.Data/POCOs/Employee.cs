using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    //blueprint of what we think an employee should be
    public class Employee
    {
        //ctor -> how the Employee obj can be made in the application
        public Employee(){}

        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        
        //properties: just describes the obj (Employee)
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
