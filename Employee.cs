using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDemo
{
    // Class
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    //Structs
    public struct Address
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PIN { get; set; }
    }
    //Interface
    public interface IEmployeeContext<T> where T : class
    {
        void Add(T entity);
        ICollection<T> Get();
        void Delete(T entity);
        T Get(int id);
    }
    // Interface Implementation
    public class EmployeeContext<T>:IEmployeeContext<T> where T : class
    {
        List<T> db = null;

        public EmployeeContext(List<T> dataList)
        {
            db = dataList;
        }

        public void Add(T entity)
        {
            db.Add(entity);
        }

        public void Delete(T entity)
        {
            db.Remove(entity);
        }

        public T Get(int id)
        {
            return db.ElementAt<T>(id-1);
        }
        public ICollection<T> Get()
        {
            return db;
        }
    }

}
