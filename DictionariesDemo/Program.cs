using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace DictionariesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees =
            {
                new Employee("CEO","Gwyn",95,200),
                new Employee("Manager","Joe", 35,25),
                new Employee("HR","Lora",2,21),
                new Employee("Secretary","Petra",28,18),
                new Employee("Lead Developer","Artorias",55,35),
                new Employee("Intern","Ernest",22,8)
            };

            Dictionary<int, string> myDictionary = new Dictionary<int, string>();

            Dictionary<string, Employee> employeesDirectory = new Dictionary<string, Employee>();
            foreach (Employee emp in employees) 
            {
                employeesDirectory.Add(emp.Role, emp);
            }

            // Update
            string KeyToUpdate = "HR";
            if (employeesDirectory.ContainsKey(KeyToUpdate))
            {
                employeesDirectory[KeyToUpdate] = new Employee("HR", "Rebecca", 26, 18);
                Console.WriteLine("Employee with Role/Key {0} was updated!.", KeyToUpdate);
            }
            else
            {
                Console.WriteLine("No employee found with this Key {0}", KeyToUpdate);
            }


            // Remove 
            string KeyToRemove = "Intern";
            if (employeesDirectory.Remove(KeyToRemove)) 
            {
                Console.WriteLine("Employee with Role/Key {0} was Removed!.", KeyToRemove);
            }

            for (int i = 0; i < employeesDirectory.Count; i++)
            {
                KeyValuePair<string, Employee> KeyValuePair = employeesDirectory.ElementAt(i);
                Console.WriteLine("Key: {0}", KeyValuePair.Key);

                Employee employeeValue = KeyValuePair.Value;

                Console.WriteLine("Employee Name: {0}", employeeValue.Name);
                Console.WriteLine("Employee Role: {0}", employeeValue.Role);
                Console.WriteLine("Employee Age: {0}", employeeValue.Age);
                Console.WriteLine("Employee Salary: {0}", employeeValue.Salary);
            }


            string key = "CEO";
            if (employeesDirectory.ContainsKey(key)) 
            {
                Employee empl = employeesDirectory["CEO"];
                Console.WriteLine("Employee Name: {0}, Role: {1}, Salary: {2}", empl.Name, empl.Role, empl.Salary);
            } 
            else
            {
                Console.WriteLine("No employee found with this key {0}", key);
            }






            Employee result = null;

            if (employeesDirectory.TryGetValue("Intern", out result)) 
            {
                Console.WriteLine("Value Retrieved!.");

                Console.WriteLine("Employee Name: {0}", result.Name);
                Console.WriteLine("Employee Role: {0}", result.Role);
                Console.WriteLine("Employee Age: {0}", result.Age);
                Console.WriteLine("Employee Salary: {0}", result.Salary);

            }
            else 
            {
                Console.WriteLine("The key does not exist");
            }
        }
    }

    class Employee
    {
        public string Role { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float Rate { get; set; }
        
        public float Salary
        { 
            get
            {
                return Rate * 8 * 5 * 4 * 12;
            }
        }

        public Employee(string role, string name, int age, float rate)
        {
            this.Role = role;
            this.Name = name;
            this.Age = age;
            this.Rate = rate;
        }
    }
}