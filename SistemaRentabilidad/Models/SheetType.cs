using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaRentabilidad.Models
{
    public enum SheetType

    {
        [Display(Name = "Egreso")]
        Egreso = 0,

        [Display(Name = "Ingreso")]
        Ingreso = 1,


    }
}