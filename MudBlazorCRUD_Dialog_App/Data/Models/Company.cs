using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MudBlazorCRUD_Dialog_App.Data.Models
{
    public class Company
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Company Name not specified")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "String length must be from {1} to {2} symbols")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Company Address not specified")]
        public string Address { get; set; }
        
        [Required(ErrorMessage = "Company Phone not specified")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "Please enter valid phone number (xxx)-xxx-xxxx")]
        public string Phone { get; set; }
       
        // one-to-many
        public List<Customer> Customers { get; set; } = new List<Customer>();
        
        // many-to-many
        public List<CompanyShipper> CompanyShippers { get; set; }
    }
}
