using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaRentabilidad.Models
{
    public enum SheetType

    {
        [Display(Name = "Ingreso")]
        Ingreso = 0,

        [Display(Name = "Costo")]
        Costo = 1,
        [Display(Name = "Gasto")]
        Gasto = 2,
        [Display(Name = "Otro Ingreso")]
        OtroIngreso = 3,



    }
}