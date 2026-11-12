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
        Console.WriteLine("Create");
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