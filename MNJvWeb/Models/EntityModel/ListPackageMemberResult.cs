using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNJvWeb.Models.EntityModel
{
    public class ListPackageMemberResult
    {
        public int SW { get; set; }
        public string GRNM { get; set; }
        public string TGL { get; set; }
        public string CUSCD { get; set; }
        public string CUSNM { get; set; }
        public string PAKETNM { get; set; }
        public string ITEMNM { get; set; }
        public decimal QTY { get; set; }
        public decimal SISA { get; set; }
        public decimal AMT { get; set; }
        public string ENDDT { get; set; }
        public string EMPNM { get; set; }
        public decimal KOMISIS_PROSEN { get; set; }
        public decimal KOMISI_AMT { get; set; }
        public string DISCNo { get; set; }
        public string ITEMCD { get; set; }
        public decimal BYR_CASH { get; set; }
        public decimal BYR_KK { get; set; }
    }
}