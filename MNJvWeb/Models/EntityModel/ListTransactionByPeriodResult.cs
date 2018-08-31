using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNJvWeb.Models.EntityModel
{
    public class ListTransactionByPeriodResult
    {
        public int SW { get; set; }
        public string GR_NM { get; set; }
        public string TO_NO { get; set; }
        public string TGL { get; set; }
        public string CUSCD { get; set; }
        public string MEMBERNM { get; set; }
        public string PICNM { get; set; }
        public string ITEMNM { get; set; }
        public double QTY { get; set; }
        public double UP { get; set; }
        public double AMT { get; set; }
        public double DISC_AMT { get; set; }
        public double TOTAL { get; set; }
        public double VOUCHER { get; set; }
        public string VOUCHER_NO { get; set; }
        public string VOUCHER_TYPE { get; set; }
        public double KOMISI_AMT { get; set; }
        public double PAYCASH { get; set; }
        public double ADD_AMT { get; set; }
        public double ADD_AMT_PROSEN { get; set; }
        public double GRANDTOTALL { get; set; }
        public string PAYNM { get; set; }
        public string CARDCD { get; set; }
        public string CARDNO { get; set; }
    }
}