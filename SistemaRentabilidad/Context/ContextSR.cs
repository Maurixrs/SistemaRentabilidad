using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaRentabilidad.Context
{
    public class ContextSR:DbContext
    {
        
            public ContextSR()
                : base("name=ContextSR")
            {
            }


            public System.Data.Entity.DbSet<SistemaRentabilidad.Models.Sheet> Sheet { get; set; }

            public System.Data.Entity.DbSet<SistemaRentabilidad.Models.Worksheet> Worksheet { get; set; }

            public System.Data.Entity.DbSet<SistemaRentabilidad.Models.SheetLine> SheetLines { get; set; }

            public System.Data.Entity.DbSet<SistemaRentabilidad.Models.Transaction> Transactions { get; set; }



    }






}