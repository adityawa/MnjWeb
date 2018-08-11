using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNJvWeb.Models.EntityModel
{
    public class ListRecapDailyTransactionParam
    {
        public string startPeriod { get; set; }
        public string endPeriod { get; set; }
        public string gerai { get; set; }
        public string type { get; set; }
        public string action { get; set; }
        public string basedOn { get; set; }
    }
}