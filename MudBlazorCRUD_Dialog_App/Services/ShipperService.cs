using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MudBlazorCRUD_Dialog_App.Data.Context;
using MudBlazorCRUD_Dialog_App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazorCRUD_Dialog_App.Services
{
    // Many-To-Many Relationship
    public class ShipperService : IShipperService
    {
        private readonly CustomerContext db;
        public ShipperService(CustomerContext context)
        {
            db = context;
        }

        public IEnumerable<Shipper> GetShippers()
        {
            var ship = db.Shippers.ToList();

            foreach (var sh in ship)
            {
                sh.CompanyList.Remove(0, sh.CompanyList.Length);

                sh.CompanyShipperList = db.CompanyShippers.Where(g => g.ShipperId == sh.Id).Select(a => a.CompanyId).ToList();
                foreach (var comp in sh.CompanyShipperList)
                {
                    var vwe = db.Companies.SingleOrDefault(x => x.Id == comp);
                    sh.CompanyList.Append(vwe.Name + ", ");
                }
                if(sh.CompanyList.Length !=0)
                sh.CompanyList.Remove(sh.CompanyList.Length - 2, 2);
            }
            return ship;
        }

        public Shipper GetShipperById(int id)
        {
            var ship = db.Shippers
                .Include(comp => comp.CompanyShippers)
                .SingleOrDefault(x => x.Id == id);
            
            if (ship != null)
            {
                ship.CompanyList.Remove(0, ship.CompanyList.Length);
                
                ship.CompanyShipperList=db.CompanyShippers.Where(g=>g.ShipperId==ship.Id).Select(a=>a.CompanyId).ToList();
               
                    foreach (var comp in ship.CompanyShipperList)
                    {
                        var vwe = db.Companies.SingleOrDefault(x => x.Id == comp);
                        ship.CompanyList.Append(vwe.Name + ", ");
                    }
                    ship.CompanyList.Remove(ship.CompanyList.Length - 2, 2);
            }
            return ship;
          
        }

         public Shipper SaveShipper(Shipper shipper)
        {
            
            shipper.Created = DateTime.Now;
            db.Shippers.Add(shipper);
        
            db.SaveChanges();

            foreach (var companyId in shipper.CompanyShipperList)
            {
                var obj = new CompanyShipper() { CompanyId = companyId, ShipperId = shipper.Id, DateDeal=shipper.Created};
                db.CompanyShippers.Add(obj);
            }
            db.SaveChanges();
            return shipper;
        }

        public Shipper UpdateShipper(Shipper shipper)
        {
            //Get a specific user by id with related data from another table
            var ship = db.Shippers
             .Include(comp => comp.CompanyShippers)
             .FirstOrDefault(x => x.Id == shipper.Id);
            db.Shippers.Update(ship);
            // db.SaveChanges();

            var shipRemove = new List<CompanyShipper>();

            foreach(var remove in ship.CompanyShippers)
            {
                shipRemove.Add(remove);
            }
            if (shipRemove != null)
            {
                db.CompanyShippers.RemoveRange(shipRemove);
                db.SaveChanges();
            }

            foreach (var companyId in shipper.CompanyShipperList)
            {
                var obj = new CompanyShipper() { CompanyId = companyId, ShipperId = shipper.Id, DateDeal = shipper.Created };
                db.CompanyShippers.Add(obj);
            }
            db.SaveChanges();
            return ship;
        }

        public void DeleteShipper(int id)
        {
            var shipper = db.Shippers.FirstOrDefault(x => x.Id == id);
            if (shipper != null)
            {
                db.Shippers.Remove(shipper);
                db.SaveChanges();
            }
        }

        public void DeleteAllShippers(List<Shipper> shippers)
        {
            if(shippers!=null)
                foreach(var ship in shippers)
                {
                    db.Shippers.Remove(ship);
                }
            db.SaveChanges();
        }
    }
}
