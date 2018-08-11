using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNJvWeb.Models.EntityModel
{
    public class ListToptenTransactionResult
    {
        public string GeraiNm { get; set; }
        public decimal Nomer { get; set; }
        public string ItemNm { get; set; }
        public decimal Qty { get; set; }
        public decimal Amt { get; set; }
    }
}