using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualOffice
{
    public class Employee : Person
    {
        public Decimal Salary { get; set; }
        public string Bio { get; set; }
        public string Department { get; set; }
        public int DateOfBirth { get; set; }

        public Employee(string firstName, string lastName, int age, decimal salary, string department, int dateOfBirth) : base(firstName, lastName, age)
        {
            Salary = salary;
            Department = department;
            DateOfBirth = dateOfBirth;
        }

        public override string ShowBio()
        {
            if (Bio == "")
            {
                return base.ShowBio();
            }
            else
            {
                return Bio;
            }
        }

        
        public string ShowEmployee()
        {
            return $"{FullName} || Department: {Department} ";
        }

       
    }
}
