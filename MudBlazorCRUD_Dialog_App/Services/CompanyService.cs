using Microsoft.EntityFrameworkCore;
using MudBlazorCRUD_Dialog_App.Data.Context;
using MudBlazorCRUD_Dialog_App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MudBlazorCRUD_Dialog_App.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CustomerContext db;
        public CompanyService(CustomerContext context)
        {
            db = context;
        }

        public IEnumerable<Company> GetCompanies()
        {
            return  db.Companies
                .ToList();
        }

        public Company GetCompanyById(int id)
        {
            var company = db.Companies
                .SingleOrDefault(x => x.Id == id);
            return  company;
        }

        public Company SaveCompany(Company company)
        {
           db.Companies.Add(company);
           db.SaveChanges();
            return company;
        }

        public Company UpdateCompany(Company company)
        {
            db.Companies.Update(company);
            db.SaveChanges();
            return company;
        }

        //When deleting a company, all Customers associated with it will be deleted .
        public void DeleteCompany(int id)
        {
            var company = db.Companies.FirstOrDefault(x => x.Id == id);
            if (company != null)
            {
                db.Companies.Remove(company);
                db.SaveChanges();
            }
        }

        public void DeleteAllCompanies(List<Company> companies)
        {
            if(companies!=null)
            foreach(var comp in companies)
            {
                    db.Companies.Remove(comp);
            }
            db.SaveChanges();
        }
    }
}
