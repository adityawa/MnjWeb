using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNJvWeb.Models.EntityModel
{
    public class ListTransactioniByTreatmentResult
    {
        public int SW { get; set; }
        public string GR_NM { get; set; }
        public string TGL { get; set; }
        public string ITEM_NM { get; set; }
        public decimal QTY { get; set; }
        public decimal AMT { get; set; }
        public decimal PAKET { get; set; }
        public decimal GIFT { get; set; }
        public decimal REIMBURSEMEN { get; set; }
        public decimal PROMO { get; set; }
        public decimal TOTAL { get; set; }
    }
}