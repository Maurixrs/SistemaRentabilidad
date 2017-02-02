using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SistemaRentabilidad.Models;
using System.Linq;
using System.Web;

namespace SistemaRentabilidad.ViewModels
{
    public class WsVM
    {
        [Key]
        public int IdWorksheet { get; set; }

         public DateTime Date { get; set; }
      
        public string WorksheetDescription { get; set; }

       public decimal TotalAmount { get; set; }

        public List<Sheet> Sheets { get; set; }

     
        public string Comments { get; set; }
    }
}