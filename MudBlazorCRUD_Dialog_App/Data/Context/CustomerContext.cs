using Microsoft.EntityFrameworkCore;
using MudBlazorCRUD_Dialog_App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MudBlazorCRUD_Dialog_App.Data.Context
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        //work because bound by foreign keys
       // public DbSet<Work> Works { get; set; }
       // public DbSet<Social> Socials { get; set; }
        public DbSet<CompanyShipper> CompanyShippers { get; set; }

        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }

    }
}
