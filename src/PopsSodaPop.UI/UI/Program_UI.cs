using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Program_UI
{
    //this is our "CONNNECTION" to ALL of our repoitories
    private readonly Store_Repository _sRepo = new Store_Repository();
    private readonly Employee_Repository _eRepo = new Employee_Repository();
    private readonly Vendor_Repository _vRepo = new Vendor_Repository();

    public void Run()
    {
        //seed Data
        SeedData();
        //RunAppllication
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning= true;
        while(isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("=== Welcome to Pops Soda Pop ===");
            System.Console.WriteLine("Please Make a Selection: \n"+
            "1.  Add Store to Database\n"+
            "2.  View All Stores\n"+
            "3.  View Store By ID\n"+
            "4.  Update Store Data\n"+
            "5.  Delete Store Data\n"+
            "------------------------------------\n"+
            "=== Employee Database ===\n"+
            "6.  Add Employee To Database\n"+
            "7.  View All Employees\n"+
            "8.  View Employee By ID\n"+
            "--------------------------------------\n"+
            "=== Vendor Database ===\n"+
            "9.  Add Vendor to Database\n"+
            "10. View All Vendors\n"+
            "11. View Vendor By ID\n"+
            "-------------------------------------\n"+
            "50. Close Application\n"
            );

            //get the userInput..
            var userInput = Console.ReadLine();

            switch(userInput)
            {
                case "1":
                AddStoreToDatabase();
                break;
                case "2":
                ViewAllStores();
                break;
                case "3":
                ViewStoreByID();
                break;
                case "4":
                UpdateStoreData();
                break;
                case "5":
                DeleteStoreData();
                break;
                case "6":
                AddEmployeeToDatabase();
                break;
                case "7":
                ViewAllEmployees();
                break;
                case "8":
                ViewEmployeeByID();
                break;
                case "9":
                AddVendorToDatabase();
                break;
                case "10":
                ViewAllVendors();
                break;
                case "11":
                ViewVendorByID();
                break;
                case "50":
                isRunning = CloseApplication();
                break;
                default:
                System.Console.WriteLine("Invalid Selection");
                PressAnyKeyToContinue();
                break;
            }
        }
    }

    private bool CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Thanks!!!");
        PressAnyKeyToContinue();
        return false;
    }

    private void ViewVendorByID()
    {
        Console.Clear();
        System.Console.WriteLine("=== Vendor Detail Menu ===\n");
        System.Console.WriteLine("Please enter a Vendor ID: \n");
        var userInputVendorID= int.Parse(Console.ReadLine());

        var vendor = _vRepo.GetVendorByID(userInputVendorID);

        if(vendor != null)
        {
            DisplayVendorInfo(vendor);
        }
        else
        {
            System.Console.WriteLine($"The Vendor with the ID: {userInputVendorID} doesn't exist.");
        }

        PressAnyKeyToContinue();
    }

    private void DisplayVendorInfo(Vendor vendor)
    {
       DisplayVendorData(vendor);
    }

    private void ViewAllVendors()
    {
        //Clears the console (makes everything clean....)
        Console.Clear();
        //go into the vendor repository and grab all of the vendors
        //then store them into the variable 'vendors'
        var vendors = _vRepo.GetAllVendors();

        //loop through all of the vendors to get the data
        foreach(var vendor in vendors)
        {
            //display the data w/ this helper method9

            DisplayVendorData(vendor);
        }
        //stops the cpu from "going too fast" -> things will 
        //work but we won't be able to see them in action.
        PressAnyKeyToContinue();
    }

    //helper method
    private void DisplayVendorData(Vendor vendor)
    {
        System.Console.WriteLine($"VendorID: {vendor.ID}\n"+
        $"VendorName: {vendor.Name}\n"+
        "------------------------------------------------\n");
    }

    private void AddVendorToDatabase()
    {
        Console.Clear();
       
        var newVendor = new Vendor();
        System.Console.WriteLine("=== Vendor Enlist Form ===\n");
       
        System.Console.WriteLine("Please enter a Vendor Name: ");
        newVendor.Name= Console.ReadLine();

        bool isSuccessful = _vRepo.AddVendorToDatabase(newVendor);
        if(isSuccessful)
        {
            System.Console.WriteLine($"{newVendor.Name} was Added to the Database.");
        }
        else
        {
            System.Console.WriteLine("Failed to Add Vendor to the Database.");
        }

        PressAnyKeyToContinue();
    }

    private void ViewEmployeeByID()
    {
        throw new NotImplementedException();
    }

    private void ViewAllEmployees()
    {
        throw new NotImplementedException();
    }

    private void AddEmployeeToDatabase()
    {
        throw new NotImplementedException();
    }

    private void DeleteStoreData()
    {
        throw new NotImplementedException();
    }

    private void UpdateStoreData()
    {
        throw new NotImplementedException();
    }

    private void ViewStoreByID()
    {
        throw new NotImplementedException();
    }

    private void ViewAllStores()
    {
        throw new NotImplementedException();
    }

    private void AddStoreToDatabase()
    {
        throw new NotImplementedException();
    }

    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    private void SeedData()
    {
        //create employees....
        var jim = new Employee("Jim","Dandy");
        var beth = new Employee("Beth","Dandy");
        var greg = new Employee("Gregg","Gooding");
        var magoo = new Employee("Mr.","Magoo");
        //add them to the database _eRepo
        _eRepo.AddEmployeeToDatabase(jim);
        _eRepo.AddEmployeeToDatabase(beth);
        _eRepo.AddEmployeeToDatabase(greg);
        _eRepo.AddEmployeeToDatabase(magoo);

        //create vendors
        var pepsi = new Vendor("Pepsi Cola");
        var jenny = new Vendor("Jenny Cola");
        //add them to the database _vRepo
        _vRepo.AddVendorToDatabase(pepsi);
        _vRepo.AddVendorToDatabase(jenny);

        //create stores
        var storeA = new Store("Pops Soda Shack.",
        new List<Employee>
        {
            jim,
            beth
        },
        new List<Vendor>
        {
            pepsi,
            jenny
        });

        var storeB =new Store("Mammas Sodas!!!");

        //add them to the database _sRepo
        _sRepo.AddStoreToDatabase(storeA);
        _sRepo.AddStoreToDatabase(storeB);
    }
}
