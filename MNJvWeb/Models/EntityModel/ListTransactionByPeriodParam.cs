using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNJvWeb.Models.EntityModel
{
    public class ListTransactionByPeriodParam
    {
        public string sDate { get; set; }
        public string eDate { get; set; }
        public string GeraiCd { get; set; }
        public string ItemCd { get; set; }
        public string CusCd { get; set; }
        public string EmpCd { get; set; }
        public string PayCd { get; set; }
        public string CardCd { get; set; }
        public string isDetail { get; set; }
    }
}