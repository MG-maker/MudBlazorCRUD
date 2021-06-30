using Microsoft.EntityFrameworkCore;
using MudBlazorCRUD_Dialog_App.Data.Context;
using MudBlazorCRUD_Dialog_App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MudBlazorCRUD_Dialog_App.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerContext db;
        public CustomerService(CustomerContext context)
        {
            db = context;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return db.Customers
                .Include(e => e.Information)
                .ThenInclude(s => s.Social)
                .Include(w => w.Work)
                .Include(comp=>comp.Company)
                .ToList();
        }

        public Customer GetCustomerById(int id)
        {
            var customer = db.Customers
                .Include(e => e.Information)
                .ThenInclude(s => s.Social)
                .Include(w => w.Work)
                .Include(comp => comp.Company)
                .SingleOrDefault(x => x.Id == id);
            return customer;
        }

        public Customer SaveCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            db.Customers.Update(customer);
            db.SaveChanges();
            return customer;
        }

        public void DeleteCustomer(int id)
        {
            var customer = db.Customers.FirstOrDefault(x => x.Id == id);
            if (customer != null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }

        public void DeleteAllCustomers(List<Customer> customers)
        {
            if(customers!=null)
                foreach(var cust in customers)
                {
                    db.Customers.Remove(cust);
                }
            db.SaveChanges();
        }
    }
}
