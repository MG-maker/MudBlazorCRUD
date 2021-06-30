//using MudBlazorCRUD_Dialog_App.Data.Context;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MudBlazorCRUD_Dialog_App.Services.BaseRepo
//{
//    public class UnitOfWork : IUnitOfWork
//    {
//        private readonly CustomerContext db;
//        public UnitOfWork(CustomerContext context)
//        {
//            db = context;
//            Customer = new CustomerRepository(db);
//            Company = new CompanyRepository(db);
//        }
//        public ICustomerRepository Customer { get; private set; }
//        public ICompanyRepository Company { get; private set; }
//        public int Complete()
//        {
//            return db.SaveChanges();
//        }

//        public void Dispose()
//        {
//            db.Dispose();
//        }
//    }
//}
