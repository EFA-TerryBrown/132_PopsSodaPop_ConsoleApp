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
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("=== Welcome to Pops Soda Pop ===");
            System.Console.WriteLine("Please Make a Selection: \n" +
            "1.  Add Store to Database\n" +
            "2.  View All Stores\n" +
            "3.  View Store By ID\n" +
            "4.  Update Store Data\n" +
            "5.  Delete Store Data\n" +
            "------------------------------------\n" +
            "=== Employee Database ===\n" +
            "6.  Add Employee To Database\n" +
            "7.  View All Employees\n" +
            "8.  View Employee By ID\n" +
            "--------------------------------------\n" +
            "=== Vendor Database ===\n" +
            "9.  Add Vendor to Database\n" +
            "10. View All Vendors\n" +
            "11. View Vendor By ID\n" +
            "-------------------------------------\n" +
            "50. Close Application\n"
            );

            //get the userInput..
            var userInput = Console.ReadLine();

            switch (userInput)
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

    //--Vendor stuff
    private void ViewVendorByID()
    {
        Console.Clear();
        System.Console.WriteLine("=== Vendor Detail Menu ===\n");
        System.Console.WriteLine("Please enter a Vendor ID: \n");
        var userInputVendorID = int.Parse(Console.ReadLine());

        var vendor = _vRepo.GetVendorByID(userInputVendorID);

        if (vendor != null)
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
        foreach (var vendor in vendors)
        {
            //display the data w/ this helper method9

            DisplayVendorData(vendor);
        }
        //stops the cpu from "going too fast" -> things will 
        //work but we won't be able to see them in action.
        PressAnyKeyToContinue();
    }

    // Vendor helper method
    private void DisplayVendorData(Vendor vendor)
    {
        System.Console.WriteLine($"VendorID: {vendor.ID}\n" +
        $"VendorName: {vendor.Name}\n" +
        "------------------------------------------------\n");
    }
    private void AddVendorToDatabase()
    {
        Console.Clear();

        var newVendor = new Vendor();
        System.Console.WriteLine("=== Vendor Enlist Form ===\n");

        System.Console.WriteLine("Please enter a Vendor Name: ");
        newVendor.Name = Console.ReadLine();

        bool isSuccessful = _vRepo.AddVendorToDatabase(newVendor);
        if (isSuccessful)
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
        Console.Clear();
        System.Console.WriteLine("=== Employee Detail Menu ===\n");
        System.Console.WriteLine("Please enter a Employee ID: \n");
        var userInputEmployeeID = int.Parse(Console.ReadLine());

        var employee = _eRepo.GetEmployeeByID(userInputEmployeeID);

        if (employee != null)
        {
            DisplayEmployeeInfo(employee);
        }
        else
        {
            System.Console.WriteLine($"The Employee with the ID: {userInputEmployeeID} doesn't exist.");
        }
        PressAnyKeyToContinue();
    }

    private void DisplayEmployeeInfo(Employee employee)
    {
        System.Console.WriteLine($"EmployeeID: {employee.ID}\n" +
        $"EmployeeName: {employee.FirstName} {employee.LastName}\n" +
        "-------------------------------------------------\n");
    }

    private void ViewAllEmployees()
    {
        Console.Clear();

        List<Employee> employeesInDb = _eRepo.GetAllEmployees();

        if (employeesInDb.Count > 0)
        {
            foreach (Employee employee in employeesInDb)
            {
                DisplayEmployeeInfo(employee);
            }
        }
        else
        {
            System.Console.WriteLine("There are no employees.");
        }

        PressAnyKeyToContinue();
    }
    //-- Employee Stuff
    private void AddEmployeeToDatabase()
    {
        Console.Clear();
        var newEmployee = new Employee();
        System.Console.WriteLine("=== Employee Enlisting Form ===\n");

        System.Console.WriteLine("Please Enter an Employee First Name:");
        newEmployee.FirstName = Console.ReadLine();

        System.Console.WriteLine("Please Enter an Employee Last Name:");
        newEmployee.LastName = Console.ReadLine();

        //here is the point where we utilize the bool return value w/n _eRepo.AddEmployeeToDatabase()
        bool isSuccessful = _eRepo.AddEmployeeToDatabase(newEmployee);
        if (isSuccessful)
        {
            System.Console.WriteLine($"{newEmployee.FirstName} - {newEmployee.LastName} was Added to the Database.");
        }
        else
        {
            System.Console.WriteLine("Employee Failed to be Added to the Database.");
        }


        PressAnyKeyToContinue();
    }

    private void DeleteStoreData()
    {
        Console.Clear();
        System.Console.WriteLine("=== Store Removal Page ===");


        var stores = _sRepo.GetAllStores();
        foreach (Store store in stores)
        {
            DisplayStoreListing(store);
        }

        try
        {
            System.Console.WriteLine("Please select a store by its ID:");
            var userInputSelectedStore = int.Parse(Console.ReadLine());
            bool isSuccessful = _sRepo.RemoveStoreFromDatabase(userInputSelectedStore);
            if (isSuccessful)
            {
                System.Console.WriteLine("Store was Successfully Deleted.");
            }
            else
            {
                System.Console.WriteLine("Store Failed to be Deleted.");
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry, invalid selection.");
        }

        PressAnyKeyToContinue();
    }

    private void UpdateStoreData()
    {
        Console.Clear();

        var avialStores = _sRepo.GetAllStores();
        foreach (var store in avialStores)
        {
            DisplayStoreListing(store);
        }

        System.Console.WriteLine("Please enter a valid Store ID:");
        var userInputStoreID = int.Parse(Console.ReadLine());
        var userSelectedStore = _sRepo.GetStoreByID(userInputStoreID);

        if (userSelectedStore != null)
        {
            Console.Clear();
            var newStore = new Store();

            //temp. Container that holds currentEmployees
            var currentEmployees = _eRepo.GetAllEmployees();
            //temp. Container that holds currentVendors
            var currentVendors = _vRepo.GetAllVendors();
            //why?
            //b/c I want the ability to make a selction and remove the employee/vendor from the selction list

            System.Console.WriteLine("Please enter a Store Name:");
            newStore.Name = Console.ReadLine();

            bool hasAssignedEmployees = false;
            while (!hasAssignedEmployees)
            {
                System.Console.WriteLine("Do you have any Employees? y/n");
                var userInputHasEmployees = Console.ReadLine();

                if (userInputHasEmployees == "Y".ToLower())
                {
                    //display available employees
                    foreach (var employee in currentEmployees)
                    {
                        System.Console.WriteLine($"{employee.ID} {employee.FirstName} {employee.LastName}");
                    }

                    var userInputEmployeeSelection = int.Parse(Console.ReadLine());
                    var selectedEmployee = _eRepo.GetEmployeeByID(userInputEmployeeSelection);

                    if (selectedEmployee != null)
                    {
                        newStore.Employees.Add(selectedEmployee);
                        currentEmployees.Remove(selectedEmployee); //removes employee from the slection list
                    }
                    else
                    {
                        System.Console.WriteLine($"Sorry, the employee with the ID: {userInputEmployeeSelection} dosen't exist.");
                    }
                }
                else
                {
                    hasAssignedEmployees = true;
                }
            }
            bool hasAssignedVendors = false;
            while (!hasAssignedVendors)
            {
                System.Console.WriteLine("Do you  have any Vendors? y/n");
                var userInputHasVendors = Console.ReadLine();
                if (userInputHasVendors == "Y".ToLower())
                {
                    //display avilable vendors
                    foreach (var vendor in currentVendors)
                    {
                        System.Console.WriteLine($"{vendor.ID} {vendor.Name}");
                    }

                    var userinputVendorSelection = int.Parse(Console.ReadLine());
                    var selectedVendor = _vRepo.GetVendorByID(userinputVendorSelection);

                    if (selectedVendor != null)
                    {
                        newStore.Vendors.Add(selectedVendor);
                        currentVendors.Remove(selectedVendor);
                    }
                    else
                    {
                        System.Console.WriteLine($"Sorry, the Vendor with the ID: {userinputVendorSelection} dosen't exist.");
                    }
                }
                else
                {
                    hasAssignedVendors = true;
                }
            }

            var isSuccessful = _sRepo.UpdateStoreData(userSelectedStore.ID, newStore);
            if(isSuccessful)
            {
                System.Console.WriteLine("SUCCESS!");
            }
            else
            {
                System.Console.WriteLine("FAILURE!");
            }

        }
        else
        {
            System.Console.WriteLine($"Sorry the store with the ID: {userInputStoreID} doesn't exist.");
        }


        PressAnyKeyToContinue();
    }

    private void ViewStoreByID()
    {
        Console.Clear();
        System.Console.WriteLine("=== Store Details ===");


        var stores = _sRepo.GetAllStores();
        foreach (Store store in stores)
        {
            DisplayStoreListing(store);
        }

        try
        {
            System.Console.WriteLine("Please select a store by its ID:");
            var userInputSelectedStore = int.Parse(Console.ReadLine());
            var selectedStore = _sRepo.GetStoreByID(userInputSelectedStore);
            if (selectedStore != null)
            {
                DisplayStoreDetails(selectedStore);
            }
            else
            {
                System.Console.WriteLine($"Sorry the Store with the ID: {userInputSelectedStore} dosen't exist.");
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry, invalid selection.");
        }

        PressAnyKeyToContinue();
    }

    private void DisplayStoreDetails(Store selectedStore)
    {
        Console.Clear();
        System.Console.WriteLine($"StoreID: {selectedStore.ID}\n" +
        $"StoreName: {selectedStore.Name}\n");

        System.Console.WriteLine("-- Employees --");
        if (selectedStore.Employees.Count > 0)
        {
            foreach (var employee in selectedStore.Employees)
            {
                DisplayEmployeeInfo(employee);
            }
        }
        else
        {
            System.Console.WriteLine("There are no Employees.");
        }

        System.Console.WriteLine("-----------------------------------------\n");

        System.Console.WriteLine("-- Vendors --");

        if (selectedStore.Vendors.Count > 0)
        {
            foreach (var vendor in selectedStore.Vendors)
            {
                DisplayVendorInfo(vendor);
            }
        }
        else
        {
            System.Console.WriteLine("There are no Vendors.");
        }
        PressAnyKeyToContinue();
    }

    private void ViewAllStores()
    {
        Console.Clear();
        System.Console.WriteLine("=== Store Listing ===\n");
        var storesInDb = _sRepo.GetAllStores();

        foreach (var store in storesInDb)
        {
            DisplayStoreListing(store);
        }

        PressAnyKeyToContinue();
    }

    private void DisplayStoreListing(Store store)
    {
        System.Console.WriteLine($" StoreID: {store.ID}\n StoreName: {store.Name}\n" +
        "------------------------------------------\n");
    }

    private void AddStoreToDatabase()
    {
        Console.Clear();
        var newStore = new Store();

        //temp. Container that holds currentEmployees
        var currentEmployees = _eRepo.GetAllEmployees();
        //temp. Container that holds currentVendors
        var currentVendors = _vRepo.GetAllVendors();
        //why?
        //b/c I want the ability to make a selction and remove the employee/vendor from the selction list

        System.Console.WriteLine("Please enter a Store Name:");
        newStore.Name = Console.ReadLine();

        bool hasAssignedEmployees = false;
        while (!hasAssignedEmployees)
        {
            System.Console.WriteLine("Do you have any Employees? y/n");
            var userInputHasEmployees = Console.ReadLine();

            if (userInputHasEmployees == "Y".ToLower())
            {
                //display available employees
                foreach (var employee in currentEmployees)
                {
                    System.Console.WriteLine($"{employee.ID} {employee.FirstName} {employee.LastName}");
                }

                var userInputEmployeeSelection = int.Parse(Console.ReadLine());
                var selectedEmployee = _eRepo.GetEmployeeByID(userInputEmployeeSelection);

                if (selectedEmployee != null)
                {
                    newStore.Employees.Add(selectedEmployee);
                    currentEmployees.Remove(selectedEmployee); //removes employee from the slection list
                }
                else
                {
                    System.Console.WriteLine($"Sorry, the employee with the ID: {userInputEmployeeSelection} dosen't exist.");
                }
            }
            else
            {
                hasAssignedEmployees = true;
            }
        }
        bool hasAssignedVendors = false;
        while (!hasAssignedVendors)
        {
            System.Console.WriteLine("Do you  have any Vendors? y/n");
            var userInputHasVendors = Console.ReadLine();
            if (userInputHasVendors == "Y".ToLower())
            {
                //display avilable vendors
                foreach (var vendor in currentVendors)
                {
                    System.Console.WriteLine($"{vendor.ID} {vendor.Name}");
                }

                var userinputVendorSelection = int.Parse(Console.ReadLine());
                var selectedVendor = _vRepo.GetVendorByID(userinputVendorSelection);

                if (selectedVendor != null)
                {
                    newStore.Vendors.Add(selectedVendor);
                    currentVendors.Remove(selectedVendor);
                }
                else
                {
                    System.Console.WriteLine($"Sorry, the Vendor with the ID: {userinputVendorSelection} dosen't exist.");
                }
            }
            else
            {
                hasAssignedVendors = true;
            }
        }

        bool isSuccessful = _sRepo.AddStoreToDatabase(newStore);
        if (isSuccessful)
        {
            System.Console.WriteLine($"Store: {newStore.Name} was Added to the Database.");
        }
        else
        {
            System.Console.WriteLine("Store Failed to be Added to the Database.");
        }

        PressAnyKeyToContinue();
    }

    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    private void SeedData()
    {
        //create employees....
        var jim = new Employee("Jim", "Dandy");
        var beth = new Employee("Beth", "Dandy");
        var greg = new Employee("Gregg", "Gooding");
        var magoo = new Employee("Mr.", "Magoo");
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

        var storeB = new Store("Mammas Sodas!!!");

        //add them to the database _sRepo
        _sRepo.AddStoreToDatabase(storeA);
        _sRepo.AddStoreToDatabase(storeB);
    }
}
