using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNJvWeb.Models.EntityModel
{
    public class ListTransactionByCustomerNewOldResult
    {
        public int SW { get; set; }
        public string GeraiNm { get; set; }
        public string ItemNm { get; set; }
        public decimal Qty { get; set; }
        public decimal Amt { get; set; }
        public decimal NewQty { get; set; }
        public decimal NewAmt { get; set; }
        public decimal OldQty { get; set; }
        public decimal OldAmt { get; set; }
    }
}