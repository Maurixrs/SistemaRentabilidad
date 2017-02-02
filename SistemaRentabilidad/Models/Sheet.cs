using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaRentabilidad.Models
{
    public class Sheet
    {
        [Key]
        public int IdSheet { get; set; }

        public string SheetDescription { get; set; }

        //[Display(Name = "Fecha")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        //public DateTime Date { get; set; }

        [Display(Name = "Monto")]
        public decimal Amount { get; set; }

        //[Display(Name = "IVA")]
        //public Boolean Iva { get; set; }

        [Display(Name = "Comentarios")]
        public string Comments { get; set; }

        public int IdWorkSheet { get; set; } //Clave Foránea

        public virtual Worksheet WorkSheet { get; set; }

        public virtual SheetType SheetType { get; set; }

    }
}