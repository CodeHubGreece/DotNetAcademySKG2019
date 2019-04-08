using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Services
{
    public class CustomerDb
    {

        private static IList<Customer> _db = new List<Customer>()
        {
            new Customer() { Id = 1, Name = "Papadopoulos Nikos" },
            new Customer() { Id = 2, Name = "Kikos Kikou" },
            new Customer() { Id = 3, Name = "Helen De Arams" },

        };
        public static IList<Customer> GetAll()
        {
            return _db; 
        }
        public static void Add(Customer customer)
        {
            var rnd = new Random();
            customer.Id = rnd.Next(1, 1000);
            _db.Add(customer);
        }

        public static void Update(Customer customer)
        {
           
        }

        public static void Delete(Customer customer)
        {
            _db.Remove(customer);
        }

        public static Customer GetById(int Id)
        {
            return _db.FirstOrDefault(c=>c.Id == Id);
        }
    }
}