using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaRentabilidad.Models
{
    public class Transaction
    {
        [Key]
        public int IdTransaction { get; set; }

        public string TransactionDescription { get; set; }

        public SheetType SheetType { get; set; }
    }
}