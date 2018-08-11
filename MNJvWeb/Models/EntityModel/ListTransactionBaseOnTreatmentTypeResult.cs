using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNJvWeb.Models.EntityModel
{
    public class ListTransactionBaseOnTreatmentTypeResult
    {
        public int SW { get; set; }
        public string GRNm { get; set; }
        public string ItemNm { get; set; }
        public decimal Qty1 { get; set; }
        public decimal Amt1 { get; set; }
        public decimal Qty2 { get; set; }
        public decimal Amt2 { get; set; }
        public decimal Qty3 { get; set; }
        public decimal Amt3 { get; set; }
        public decimal Qty { get; set; }
        public decimal Amt { get; set; }
    }
}