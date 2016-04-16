using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDemo
{
    class Program
    {
       public static List<Employee> data = new List<Employee> {
            new Employee { Id = 1 , Name = "Ramanajee" , Email="ramanajee@qualminds.com"},
            new Employee { Id = 2 , Name ="ram" ,  Email = "ram@live.in" }
            };
       private EmployeeContext<Employee> context = new EmployeeContext<Employee>(data);

        public ICollection<Employee> Get()
        {
            return context.Get();
        }
        // Method Overloading
        public Employee GetById(int id)
        {
            return context.Get(id);
        }

        public void Delete(int id)
        {
            var employee = context.Get(id);
            context.Delete(employee);
        }

        public void Add(Employee employee)
        {
            context.Add(employee);
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Address address = new Address();
            var data = p.Get();
            Console.WriteLine("============================================================================");
            foreach (var item in data)
            {
                Console.WriteLine("Id:" + item.Id + " Name:" + item.Name + " Email:" + item.Email);
            }

            Console.WriteLine("============================================================================");
            Console.WriteLine("Enter employee Address:\n");
            Console.WriteLine("Enter Id:");
            address.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter EmployeeId:");
            address.EmployeeId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Street:");
            address.Street = Console.ReadLine();
            Console.WriteLine("Enter City:");
            address.City = Console.ReadLine();
            Console.WriteLine("Enter Country:");
            address.Country = Console.ReadLine();
            Console.WriteLine("Enter PIN:");
            address.PIN = Console.ReadLine();
            Console.WriteLine("===============================================================================");
            Console.WriteLine("Employee Full Details");
            var employee = p.GetById(address.EmployeeId);
            Console.WriteLine("Id:" + employee.Id + " Name:" + employee.Name + " Email:" + employee.Email);
            Console.WriteLine("Street:" + address.Street + ", City:" + address.City + ", Country:" + address.Country + ", PIN:" + address.PIN);
            Console.ReadLine();
        }
    }
}
