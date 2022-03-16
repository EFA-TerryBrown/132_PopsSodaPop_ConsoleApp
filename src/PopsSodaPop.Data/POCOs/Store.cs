using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Store
{
    //1st overload
    public Store() { }

    //2nd overload
    public Store(string name)
    {
        Name = name;
    }

    //3rd overload full constructor
    public Store(string name, List<Employee> employees, List<Vendor> vendors)
    {
        Name = name;
        Employees = employees;
        Vendors = vendors;
    }


    //unique identifier
    public int ID { get; set; }
    public string Name { get; set; }
    public List<Employee> Employees { get; set; } = new List<Employee>();
    public List<Vendor> Vendors { get; set; } = new List<Vendor>();
}
