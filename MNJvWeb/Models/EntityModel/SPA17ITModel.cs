using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNJvWeb.Models.EntityModel
{
    public class SPA17ITModel :SPA16ITModel
    {
        public Int32 PREPAID_CD { get; set; }
        public string row_no { get; set; }
        public string ITEM_CD { get; set; }
        public string ITEM_NM { get; set; }
        public int QTY { get; set; }
        public decimal UP_PRC { get; set; }
        public decimal DISC_PROSEN { get; set; }
    }
}