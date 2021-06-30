using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MudBlazorCRUD_Dialog_App.Data.Models
{
    public class Information 
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Age not specified")]
        [Range(1, 110, ErrorMessage = "Invalid age.Value {0} must be from {1} to {2}")]
        public int? Age { get; set; }
       
        [Required(ErrorMessage = "PhoneNumber not specified")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "Please enter valid phone number (xxx)-xxx-xxxx")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Email not specified")]
        [EmailAddress(ErrorMessage = "Invalid adress. Please enter 'your email name'@mail.com")]
        public string Email { get; set; }

        public int CustomerId { get; set; }
        
        public Customer Customer { get; set; }
        
        // one to one
        [ValidateComplexType]
        public Social Social { get; set; }
    }
}
