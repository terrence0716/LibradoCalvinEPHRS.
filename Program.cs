using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int ID {get; set;}//col 1
    public string FirstName {get; set;}//col 2
    public string LastName {get; set;}//col 3
    public string Department {get; set;}//col 4
    public string JobTitle {get; set;}//col 5
    public decimal MonthlySalary {get; set;}//col 6
    public double TaxRate { get; set; }//col 7
    public DateTime HireDate { get; set; }//col 8
    public bool IsActive {get; set;}//col 9
    public string Email {get; set;}//col 10
}

class Program
{
    static List<Employee> employees = new List<Employee>();
    static int nextID = 1001;
    static int DummyID = 9001;
    static bool useDummyData = false;

    



    static void Main(string[] args)
    {
        if (useDummyData)
        {
            LoadDummyData();
        }

        bool runningFlag = true;
        while (runningFlag)
        {
            Console.Clear();

            Console.WriteLine("=== EMPLOYEE PAYROLL & HR MANAGEMENT SYSTEM Merged ===");

            Console.WriteLine("1. Create (Add Employee)");
            Console.WriteLine("2. Read (View All Employees)");
            Console.WriteLine("3. Search / Filter");
            Console.WriteLine("4. Update Employee");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Exit");
            Console.Write("\nSelect an option: ");
 
            string choice = Console.ReadLine();
            Console.WriteLine();
 
            switch (choice)
            {
                case "1": RunRepeatedly(CreateEmployee); break;
                case "2": ReadEmpolyee(); break;                  
                case "3": RunRepeatedly(SearchEmpolyee); break;
                case "4": RunRepeatedly(UpdateEmpolyee); break;
                case "5": ReadEmpolyee(); RunRepeatedly(DeleteEmpolyee); break;
                case "6": runningFlag = false; break;
                default: Console.WriteLine("Invalid choice."); break;
            }
 
            if (runningFlag)
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }



//CREATE===========================================
    static void CreateEmployee()
    {
        //Console.WriteLine("Create");
        Console.WriteLine("--- Add New Employee ---");
        Console.Write("Enter First Name: ");
        string firstName = Console.ReadLine();
 
        Console.Write("Enter Last Name: ");
        string lastName = Console.ReadLine();
 
        Console.Write("Enter Department (IT, HR, Sales, Finance): ");
        string department = Console.ReadLine();
 
        Console.Write("Enter Job Title: ");
        string jobTitle = Console.ReadLine();
 
        Console.Write("Enter Monthly Salary: ");
        decimal.TryParse(Console.ReadLine(), out decimal salary);
 
        Console.Write("Enter Tax Rate (e.g., 0.12 for 12%): ");
        double.TryParse(Console.ReadLine(), out double taxRate);
 
        Console.Write("Enter Hire Date (yyyy-MM-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime hireDate))
        {
            hireDate = DateTime.Today;
        }
 
        Console.Write("Is Active? (y/n): ");
        bool isActive = Console.ReadLine().Trim().ToLower() == "y";
 
        Console.Write("Enter Email: ");
        string email = Console.ReadLine();
 
        Employee newEmployee = new Employee
        {
            ID = nextID++,
            FirstName = firstName,
            LastName = lastName,
            Department = department,
            JobTitle = jobTitle,
            MonthlySalary = salary,
            TaxRate = taxRate,
            HireDate = hireDate,
            IsActive = isActive,
            Email = email
        };
        employees.Add(newEmployee);
 
        Console.WriteLine("\nEmployee added successfully!");
    }
//READ===========================================
    static void ReadEmpolyee()
    {
        //Console.WriteLine("Read");
        Console.WriteLine("--- Employee Records ---");
        DisplayEmployees(employees.OrderBy(e => e.ID).ToList());
    }
 //DISPLAY==============================================
    static void DisplayEmployees(List<Employee> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("No employees found.");
            return;
        }
 
        Console.WriteLine($"{"ID",-5} | {"First",-10} | {"Last",-10} | {"Dept",-8} | {"Job Title",-16} | {"Salary",12} | {"Tax",5} | {"Hired",-10} | {"Active",-6} | {"Email",-24}");
        Console.WriteLine(new string('-', 135));
 
        foreach (Employee e in list)
        {
            Console.WriteLine($"{e.ID,-5} | {e.FirstName,-10} | {e.LastName,-10} | {e.Department,-8} | {e.JobTitle,-16} | {e.MonthlySalary,12:N2} | {e.TaxRate,5:P0} | {e.HireDate:yyyy-MM-dd} | {(e.IsActive ? "Yes" : "No"),-6} | {e.Email,-24}");
        }
 
        Console.WriteLine($"\nTotal records: {list.Count}");
    }
//SEARCH====================================================
    static void SearchEmpolyee()
    {
        //Console.WriteLine("Search");
        Console.WriteLine("--- Search / Filter ---");
        Console.WriteLine("1. By Name");
        Console.WriteLine("2. By Department");
        Console.WriteLine("3. By Salary Range");
        Console.WriteLine("4. By Status (Active/Inactive)");
        Console.WriteLine("5. By ID");
        Console.Write("\nSelect a filter: ");
        string option = Console.ReadLine();
        Console.WriteLine();
 
        List<Employee> results = new List<Employee>();
 
        switch (option)
        {
            case "1":
                Console.Write("Enter name to search: ");
                string name = Console.ReadLine().ToLower();
                results = employees
                    .Where(e => e.FirstName.ToLower().Contains(name) || e.LastName.ToLower().Contains(name))
                    .ToList();
                break;
            case "2":
                Console.Write("Enter department: ");
                string dept = Console.ReadLine().ToLower();
                results = employees.Where(e => e.Department.ToLower() == dept).ToList();
                break;
            case "3":
                Console.Write("Enter minimum salary: ");
                decimal.TryParse(Console.ReadLine(), out decimal min);
                Console.Write("Enter maximum salary: ");
                decimal.TryParse(Console.ReadLine(), out decimal max);
                results = employees.Where(e => e.MonthlySalary >= min && e.MonthlySalary <= max).ToList();
                break;
            case "4":
                Console.Write("Show active employees? (y/n): ");
                bool active = Console.ReadLine().Trim().ToLower() == "y";
                results = employees.Where(e => e.IsActive == active).ToList();
                break;
            case "5":
                Console.Write("Enter ID: ");
                int.TryParse(Console.ReadLine(), out int id);
                results = employees.Where(e => e.ID == id).ToList();
                break;
            default:
                Console.WriteLine("Invalid filter.");
                return;
        }
 
        Console.WriteLine();
        DisplayEmployees(results);
    }
//UPDATE====================================================
    static void UpdateEmpolyee()
    {
        //Console.WriteLine("Update");
        ReadEmpolyee();
        Console.Write("\nEnter the ID of the employee to update: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Employee emp = employees.FirstOrDefault(e => e.ID == id);
            if (emp != null)
            {
                Console.WriteLine("(Press Enter to keep the current value)");
 
                Console.Write($"Enter new first name (current: {emp.FirstName}): ");
                string firstName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(firstName)) emp.FirstName = firstName;
 
                Console.Write($"Enter new last name (current: {emp.LastName}): ");
                string lastName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(lastName)) emp.LastName = lastName;
 
                Console.Write($"Enter new department (current: {emp.Department}): ");
                string department = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(department)) emp.Department = department;
 
                Console.Write($"Enter new job title (current: {emp.JobTitle}): ");
                string jobTitle = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(jobTitle)) emp.JobTitle = jobTitle;
 
                Console.Write($"Enter new monthly salary (current: {emp.MonthlySalary}): ");
                string salaryInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(salaryInput) && decimal.TryParse(salaryInput, out decimal newSalary))
                {
                    emp.MonthlySalary = newSalary;
                }
 
                Console.Write($"Enter new tax rate (current: {emp.TaxRate}): ");
                string taxInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(taxInput) && double.TryParse(taxInput, out double newTax))
                {
                    emp.TaxRate = newTax;
                }
 
                Console.Write($"Enter new hire date (current: {emp.HireDate:yyyy-MM-dd}): ");
                string dateInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(dateInput) && DateTime.TryParse(dateInput, out DateTime newDate))
                {
                    emp.HireDate = newDate;
                }
 
                Console.Write($"Is active? y/n (current: {(emp.IsActive ? "y" : "n")}): ");
                string activeInput = Console.ReadLine().Trim().ToLower();
                if (activeInput == "y") emp.IsActive = true;
                else if (activeInput == "n") emp.IsActive = false;
 
                Console.Write($"Enter new email (current: {emp.Email}): ");
                string email = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(email)) emp.Email = email;
 
                Console.WriteLine("\nEmployee updated successfully!");
            }
            else
            {
                Console.WriteLine("\nEmployee not found.");
            }
        }
        else
        {
            Console.WriteLine("\nInvalid ID format.");
        }
    }
//DELETE====================================================
    static void DeleteEmpolyee()
    {
        //Console.WriteLine("Delete");
        Console.Write("\nEnter the ID of the employee to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            int removed = employees.RemoveAll(e => e.ID == id);
            if (removed > 0)
                Console.WriteLine("\nEmployee deleted successfully!");
            else
                Console.WriteLine("\nEmployee not found.");
        }
        else
        {
            Console.WriteLine("\nInvalid ID format.");
        }
    }
//RUN_REPEAT========================================================
    static void RunRepeatedly(Action action)
    {
        bool repeatFlag = true;
        while (repeatFlag)
        {
            action();

            Console.Write("\nDo this again? (y/n): ");
            repeatFlag = Console.ReadLine().Trim().ToLower() == "y";
            Console.WriteLine();
        }
    }
//DUMMY_DATA_TEST================================================
    static void LoadDummyData()
    {
        employees.Add(new Employee { ID = DummyID++, FirstName = "Juan", LastName = "Santos", Department = "IT", JobTitle = "Software Engineer", MonthlySalary = 65000m, TaxRate = 0.12, HireDate = new DateTime(2022, 3, 15), IsActive = true, Email = "juansantos@company.com" });
        employees.Add(new Employee { ID = DummyID++, FirstName = "Maria", LastName = "Reyes", Department = "HR", JobTitle = "HR Manager", MonthlySalary = 58000m, TaxRate = 0.10, HireDate = new DateTime(2021, 7, 1), IsActive = true, Email = "mariareyes@company.com" });
        employees.Add(new Employee { ID = DummyID++, FirstName = "Pedro", LastName = "Cruz", Department = "Sales", JobTitle = "Sales Associate", MonthlySalary = 32000m, TaxRate = 0.08, HireDate = new DateTime(2023, 1, 10), IsActive = false, Email = "pedrocruz@company.com" });
    }
}