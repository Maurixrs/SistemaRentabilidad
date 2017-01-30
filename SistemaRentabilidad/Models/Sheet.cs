using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRentabilidad.Models
{
    public class Sheet
    {
        public int IdSheet { get; set; }

        public string SheetDescription { get; set; }

        public DateTime Date { get; set; }

        public decimal Rode { get; set; }

        public bool Type { get; set; }

        public string Comments { get; set; }

        public int idWorkSheet { get; set; } //Clave Foránea

        public virtual Worksheet WorkSheet { get; set; }
    }
}