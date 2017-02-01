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

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }

        [Display(Name = "Descripción")]
        public string WorksheetDescription { get; set; }

        [Display(Name = "Total")]
        public decimal TotalAmount { get; set; }

        public ICollection<Sheet> Sheets { get; set; }

        [Display(Name = "Comentarios")]
        public string Comments { get; set; }
    }
}