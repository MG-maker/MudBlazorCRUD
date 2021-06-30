using MudBlazorCRUD_Dialog_App.Data.Context;
using MudBlazorCRUD_Dialog_App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MudBlazorCRUD_Dialog_App.Services.BaseRepo
{
    //ICompanyRepository
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        private readonly CustomerContext db;
        public CompanyRepository(CustomerContext context) : base(context)
        {
            db = context;
        }
        

        public IEnumerable<Company> GetCompanies()
        {
            return GetAll();
        }

        public Company GetCompanyById(int id)
        {
            return GetById(id);
        }

        public Company SaveCompany(Company company)
        {
            Create(company);
            db.SaveChanges();
            return company;
        }

        public Company UpdateCompany(Company company)
        {
            Update(company);
            db.SaveChanges();
            return company;
        }

        public void DeleteCompany(int id)
        {
            Delete(id);
            db.SaveChanges();
        }
    }
}
