using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNJvWeb.Models.EntityModel
{
    public class ListRecapDailyTransactionResult
    {
        public string SW { get; set; }
        public string TGL { get; set; }
        public string TYPE_NM { get; set; }
        public string EMP_NM { get; set; }
        public decimal TO_AMT { get; set; }
        public decimal PAKET { get; set; }
        public decimal GIFT { get; set; }
        public decimal TOTAL { get; set; }
        public decimal KOMISI { get; set; }
    }
}