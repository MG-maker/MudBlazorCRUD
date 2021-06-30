using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MudBlazorCRUD_Dialog_App.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName not specified")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "String length must be from {1} to {2} symbols")]
        public string FirstName { get; set; }
       
        [Required(ErrorMessage = "LastName not specified")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "String length must be from {1} to {2} symbols")]
        public string LastName { get; set; }

        //join models(one-to-one)
        [ValidateComplexType]
        public Information Information { get; set; }
        
        [ValidateComplexType]
        public Work Work { get; set; }
      
        // one-to-many
        [Required]
        public int? CompanyId { get; set; }
        
        [ValidateComplexType]
        public Company Company { get; set; }
    }
}
