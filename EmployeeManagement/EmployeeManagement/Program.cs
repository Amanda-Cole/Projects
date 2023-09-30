using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EmployeeManagement
{
    //EmployeeManagement Program :  Add, Delete, and View employees with
    //generated Employee ID, First Name, Last Name, Salary, and Start date
    internal class Program
    {
        static void Main(string[] args)
        {
            //create new manager instance
            EmployeeManager manager = new EmployeeManager();

            //continue to show menu options until "0" is chosen
            while (true)
            {
                MainMenu(manager);
            }
        }
        //Main Menu  - choices and switch case
        static void MainMenu(EmployeeManager manager)
        {
            {
                Console.WriteLine("Select from the folowing:");
                Console.WriteLine("1. Add an Employee");
                Console.WriteLine("2. View all Employees");
                Console.WriteLine("3. Delete an Employee");
                Console.WriteLine("0. Exit");

                //convert input to int
                int x = Convert.ToInt32(Console.ReadLine());

                switch (x)
                {
                    case 1://Add new employee
                        Console.WriteLine("Enter information for the new employee:");
                        manager.AddEmployee();
                        break;
                    case 2: //Display Employees 
                        manager.DisplayEmployees();
                        break;
                    case 3: //Delete Employee
                        bool validId = false;
                        int id = -1;
                        while (!validId)
                        {
                            Console.Write("Enter the Employee id to delete: ");
                            string idStr = Console.ReadLine();
                            validId = Int32.TryParse(idStr, out id);
                        }
                        manager.DeleteEmployee(id);
                        break; 
                    case 0: //Exit program
                        Console.WriteLine("Press enter to close program.....");
                        Console.ReadLine();
                        Environment.Exit(0);
                        break;
                        

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }

            }
        }
    }
}
