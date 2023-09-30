using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace EmployeeManagement
{
    internal class EmployeeManager
    {
        private List<Employee> employees;
        private int nextEmployeeId = 1;
        private const string filepath = "employeelist.txt";

        public EmployeeManager()
        //create new list
        {
            employees = new List<Employee>();
            if (File.Exists(filepath))
            {
                string[] lines = File.ReadAllLines(filepath);
                int employeeId = 0;
                string firstName = null;
                string lastName = null;
                double salary = 0;
                string startDate = null;

                foreach (string line in lines)
                {
                    if (line.Trim().Length ==0)
                    {
                        Employee employee = new Employee(firstName, lastName, salary, DateTime.Parse(startDate));
                        employee.EmployeeId = employeeId;
                        employees.Add(employee);
                        if(employeeId >= nextEmployeeId)
                        {
                            nextEmployeeId = employeeId + 1;
                        }

                        continue;
                    }
                    string[] keyLabelPairs = line.Split(':');
   
                    string label = keyLabelPairs[0].Trim();
                    string value = keyLabelPairs[1].Trim();

                    if (label == "Employee ID")
                    {
                        employeeId = Int32.Parse(value);
                    }
                    else if (label == "First Name")
                    {
                        firstName = value;
                    }
                    else if (label == "Last Name")
                    {
                        lastName = value;
                    }
                    else if (label == "Salary")
                    {
                        salary = double.Parse(value.Substring(1));
                    }
                    else if (label == "Start Date")
                    {
                        startDate = (value);
                    }
                       
                }
            }
        }

        public void AddEmployee() 
        {
            //receive input on new employee

            int newEmployeeId = nextEmployeeId++;

            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Salary: ");
            double salary = double.Parse(Console.ReadLine());

            Console.Write("Enter Start Date (MM/dd/yyyy): ");
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);

            //create new employee 
            Employee employee = new Employee(firstName, lastName, salary, startDate) { EmployeeId = newEmployeeId};
            employees.Add(employee);
            Console.WriteLine("Employee added successfully!");
            foreach (Employee e in employees)
            {
                Console.WriteLine(e.ToString());      
            }
            Console.WriteLine("Click Enter to continue...");
            Console.ReadLine();


            using (StreamWriter writer = new StreamWriter(filepath,true))
            {
                WriteEmployeeToStream(writer, employee);
            }
        }

        public void DisplayEmployees()
        {
            Console.WriteLine("Employee List:");
            //if (File.Exists(filepath))
            //{
            //    using (StreamReader reader = new StreamReader(filepath))
            //    {
            //        string loadedText = reader.ReadToEnd();
            //        Console.WriteLine("Updated from file");
            //        Console.WriteLine(loadedText);
            //    }
            //}
            if (employees.Count > 0)
            {
                foreach (Employee e in employees)
                {
                    Console.Write(e.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No employee records found.");
            }
            Console.WriteLine("Click Enter to continue...");
            Console.ReadLine();
        }

        public void DeleteEmployee(int id)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i] != null && employees[i].EmployeeId == id)
                {
                    employees.RemoveAt(i); // Remove the employee from the list.
                    using (StreamWriter writer = new StreamWriter(filepath, false))
                    {
                        foreach(Employee e in employees)
                        {
                            WriteEmployeeToStream(writer, e);
                        }   
                    }

                    Console.WriteLine($"Employee with ID {id} deleted successfully!");
                    Console.WriteLine("Click Enter to continue...");
                    Console.ReadLine();
                    return;
                }
            }
            Console.WriteLine($"Employee with ID {id} not found.");
        }

        private void WriteEmployeeToStream(StreamWriter writer, Employee employee)
        {
            writer.Write(employee.ToString());
            //writer.WriteLine($"Employee ID: {employee.EmployeeId}");
            //writer.WriteLine($"First Name: {employee.FirstName}");
            //writer.WriteLine($"Last Name: {employee.LastName}");
            //writer.WriteLine($"Salary: ${employee.Salary:F2}");
            //writer.WriteLine($"Start Date: {employee.StartDate.ToShortDateString()}");
            writer.WriteLine();
        }

    }
}
