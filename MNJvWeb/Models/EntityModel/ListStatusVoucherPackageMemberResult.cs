using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNJvWeb.Models.EntityModel
{
    public class ListStatusVoucherPackageMemberResult
    {
        public string GRNm { get; set; }
        public string TGL { get; set; }
        public string TYPE_NM { get; set; }
        public string CusNm { get; set; }
        public string ItemNm { get; set; }
        public decimal Qty { get; set; }
        public decimal QtyUse { get; set; }
        public decimal Sisa { get; set; }
        public decimal UnPrc { get; set; }
        public decimal Amt { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string EmpNm { get; set; }
        public decimal KomisiProsen { get; set; }
        public decimal KomisiAmt { get; set; }
        public string DiscNo { get; set; }
        public string ItemCd { get; set; }
    }
}