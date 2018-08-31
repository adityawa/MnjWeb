using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNJvWeb.Models.EntityModel
{
    public class ListCommisionTeraphisResult
    {
        public int SW { get; set; }
        public string GRNm { get; set; }
        public string EmpNm { get; set; }
        public string TONo { get; set; }
        public string Tgl { get; set; }
        public string CusNm { get; set; }
        public string ItemNm { get; set; }
        public decimal Amt { get; set; }
        public decimal VoucherAmt { get; set; }
        public decimal DiscAmt { get; set; }
        public decimal BasicAmt { get; set; }
        public decimal KomisiAmt { get; set; }
        public decimal KomisiAdd { get; set; }
        public decimal KomisiMin { get; set; }
        public decimal KOmisiTot { get; set; }
        public string VoucherNo { get; set; }
        public string EmpTo { get; set; }
        public string ItemTo { get; set; }
        public string KomisiStatus { get; set; }
        public decimal KomisiProsen { get; set; }
    }
}