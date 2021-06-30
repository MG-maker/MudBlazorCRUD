using MudBlazorCRUD_Dialog_App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MudBlazorCRUD_Dialog_App.Services.BaseRepo
{
   public interface ICompanyRepository : IBaseRepository<Company>
    {
        IEnumerable<Company> GetCompanies();
        Company GetCompanyById(int id);
        Company SaveCompany(Company company);
        Company UpdateCompany(Company company);
        void DeleteCompany(int id);
    }
}
