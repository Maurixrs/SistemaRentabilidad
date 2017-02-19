using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaRentabilidad.Models
{
    public class SheetLine
    {
        [Key]
        public int IdSheetLine { get; set; }

        public string LineDescription { get; set; }

        public virtual SheetType SheetType { get; set; }


    }
}