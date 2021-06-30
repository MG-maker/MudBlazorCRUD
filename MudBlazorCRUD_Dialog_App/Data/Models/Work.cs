using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MudBlazorCRUD_Dialog_App.Data.Models
{
    public class Work
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Work experience not specified")]
        [Range(1, 70,  ErrorMessage = "Invalid experience value.Value {0} must be from {1} to {2}")]
        public int? Experience { get; set; }
       
        [Required(ErrorMessage = "Work salary not specified")]
        [Range(300, 10000, ErrorMessage = "Invalid salary value. Value {0} must be from {1} to {2}")]
        public int? Salary { get; set; }

        //one-to-one
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
