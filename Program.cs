using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

public class Employee
{
    public int ID {get; set;}//col 1
    public string FirstName {get; set;} = "";//col 2
    public string LastName {get; set;} = "";//col 3
    public string Department {get; set;} = "";//col 4
    public string JobTitle {get; set;} = "";//col 5
    public decimal MonthlySalary {get; set;}//col 6
    public double TaxRate { get; set; }//col 7
    public DateTime HireDate { get; set; }//col 8
    public bool IsActive {get; set;}//col 9
    public string Email {get; set;} = "";//col 10
}

class Program
{
    static List<Employee> employees = new List<Employee>();
    static int nextID = 1001;


    static void Main(string[] args)
    {
        bool runningFlag = true;
        while (runningFlag)
        {
            Console.Clear();
            Console.WriteLine("=== EMPLOYEE PAYROLL & HR MANAGEMENT SYSTEM ===");
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
                case "1": CreateEmployee(); break;
                case "2": ReadEmpolyee(); break;
                case "3": SearchEmpolyee(); break;
                case "4": UpdateEmpolyee(); break;
                case "5": DeleteEmpolyee(); break;
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

    static void ReadEmpolyee()
    {
        Console.WriteLine("Read");
    }

    static void SearchEmpolyee()
    {
        Console.WriteLine("Search");
    }
    static void UpdateEmpolyee()
    {
        Console.WriteLine("Update");
    }

    static void DeleteEmpolyee()
    {
        Console.WriteLine("Delete");
    }
}