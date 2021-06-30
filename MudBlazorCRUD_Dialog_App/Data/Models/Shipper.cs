using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazorCRUD_Dialog_App.Data.Models
{
    public class Shipper
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Shipper Name not specified")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "String length must be from {1} to {2} symbols")]
        public string Name { get; set;}
       
        [Required(ErrorMessage = "Shipper Phone not specified")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "Please enter valid phone number (xxx)-xxx-xxxx")]
        public string Phone { get; set; }
       
        [Required(ErrorMessage = "Shipper Address not specified")]
        public string Address { get; set; }

        public DateTime Created { get; set; }
        
        // many to many
        [NotMapped]
        // for saving id companies
        public List<int> CompanyShipperList { get; set; } = new List<int>() { };
     
        [NotMapped]
        // To display company names in a table
        public StringBuilder CompanyList { get; set; } = new StringBuilder("");
        
        public List<CompanyShipper> CompanyShippers { get; set; }
    }
}
