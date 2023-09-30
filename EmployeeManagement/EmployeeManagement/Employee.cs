using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Employee
    {
        //initialize employee details and get and set values
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }


        //Constructor - set up new object
         public Employee( string firstName, string lastName, double salary, DateTime startDate) 
            { 
                
                FirstName = firstName;
                LastName = lastName;
                Salary = salary;
                StartDate = startDate;

            }
        public override string ToString()
        {
            return $"Employee ID: {EmployeeId}\nFirst Name: {FirstName}\nLast Name: {LastName}\nSalary: ${Salary:F2}\nStart Date: {StartDate.ToShortDateString()}\n";


        }
    }
}
