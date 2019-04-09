using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Services;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = CustomerDb.GetAll();
            return View(customers);
        }

        // GET: Customer
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int Id)
        {
            var customerInDb = CustomerDb.GetById(Id);
            return View(customerInDb);
        }


    
        public ActionResult Delete(int Id)
        {
            var customerInDb = CustomerDb.GetById(Id);
            return View(customerInDb);
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            var customerInDb = CustomerDb.GetById(customer.Id);
            // update properties

            CustomerDb.Delete(customerInDb);
            return RedirectToAction("Index", "Customers");
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {

            if (customer.Id == 0)
            {
                CustomerDb.Add(customer);
            }
            else
            {
                var customerInDb = CustomerDb.GetById(customer.Id);
                // update properties
                customerInDb.Name = customer.Name;

                CustomerDb.Update(customerInDb);


            }
            return RedirectToAction("Index", "Customers");

        }
    }
}