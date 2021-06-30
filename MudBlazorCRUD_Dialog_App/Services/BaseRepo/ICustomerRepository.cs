using MudBlazorCRUD_Dialog_App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MudBlazorCRUD_Dialog_App.Services.BaseRepo
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(int id);
        Customer SaveCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
        void DeleteAllCustomers(List<Customer> customers);
    }
}
