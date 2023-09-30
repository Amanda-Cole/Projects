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
    internal class Program
    {
        static void Main(string[] args)
        {
            //create new manager instance
            EmployeeManager manager = new EmployeeManager();

            while (true)
            {
                MainMenu(manager);
            }
        }
        static void MainMenu(EmployeeManager manager)
        {
            {
                //Console.Clear();
                Console.WriteLine("Select from the folowing:");
                Console.WriteLine("1. Add an Employee");
                Console.WriteLine("2. View all Employees");
                Console.WriteLine("3. Delete an Employee");
                Console.WriteLine("0. Exit");

                int x = Convert.ToInt32(Console.ReadLine());

                switch (x)
                {
                    case 1:
                        Console.WriteLine("Enter information for the new employee:");
                        manager.AddEmployee();
                        break;
                    case 2:
                        manager.DisplayEmployees();
                        break;
                    case 3:
                        bool validId = false;
                        int id = -1;
                        while (!validId)
                        {
                            Console.Write("Enter the Employee id to delete: ");
                            string idStr = Console.ReadLine();
                            validId = Int32.TryParse(idStr, out id);
                        }
                        manager.DeleteEmployee(id);
                        break; // Exit the program
                    case 0:
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
