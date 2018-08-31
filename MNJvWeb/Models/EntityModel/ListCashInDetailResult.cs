using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNJvWeb.Models.EntityModel
{
    public class ListCashInDetailResult
    {
        public string GrpNm { get; set; }
        public string TONO { get; set; }
        public string TGL { get; set; }
        public string CUSNM { get; set; }
        public string EMPNM { get; set; }
        public string PAYNM { get; set; }
        public string CARDNM { get; set; }
        public string CARDNO { get; set; }
        public decimal QTY { get; set; }
        public decimal AMT { get; set; }
        public decimal DISC { get; set; }
        public decimal VOUCHER { get; set; }
        public decimal BYR_CASH { get; set; }
        public decimal BYR_KK { get; set; }
        public decimal TOTAL { get; set; }
    }
}