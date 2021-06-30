using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MudBlazorCRUD_Dialog_App.Data.Models
{
    public class CompanyShipper
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int ShipperId { get; set; }
        public Shipper Shipper { get; set; }

        public DateTime DateDeal { get; set; }
    }
}
