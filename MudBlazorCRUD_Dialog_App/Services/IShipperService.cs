using MudBlazorCRUD_Dialog_App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MudBlazorCRUD_Dialog_App.Services
{
    public interface IShipperService
    {
        IEnumerable<Shipper> GetShippers();
        Shipper GetShipperById(int id);
        Shipper SaveShipper(Shipper shipper);
        Shipper UpdateShipper(Shipper shipper);
        void DeleteShipper(int id);
        void DeleteAllShippers(List<Shipper> shippers);
    }
}
