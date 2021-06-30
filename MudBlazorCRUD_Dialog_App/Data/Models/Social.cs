using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MudBlazorCRUD_Dialog_App.Data.Models
{
    public class Social
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Social Name not specified")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "String length must be from {1} to {2} symbols")]
        public string Name { get; set; }
        
        //one-to-one
        public int InformationId { get; set; }
        public Information Information { get; set; }
    }
}
