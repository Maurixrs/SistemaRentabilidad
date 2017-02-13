using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaRentabilidad.Models
{
    public class Worksheet
    {
        [Key]
        public int IdWorksheet { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Total Ingreso")]
        public decimal Totali { get; set; }
        [Display(Name = "Total costo de ventas")]
        public decimal Totalc { get; set; }
        [Display(Name = "Total gastos")]
        public decimal Totalg { get; set; }
        [Display(Name = "Total otros ingresos")]
        public decimal Totalo { get; set; }
        [Display(Name = "Total")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Comentarios")]
        public string Comments { get; set; }   
        
        public virtual ICollection<Sheet> Sheets { get; set; }     
    }
}