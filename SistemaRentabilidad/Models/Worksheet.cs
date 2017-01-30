using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRentabilidad.Models
{
    public class Worksheet
    {
        public int IdWorksheet { get; set; }

        public string WorksheetDescription { get; set; }

        public decimal TotalAmount { get; set; }

        public string Comments { get; set; }   
        
        public virtual ICollection<Sheet> Sheets { get; set; }     
    }
}