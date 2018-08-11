using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNJvWeb.Models.EntityModel
{
    public class InquiryTransByItemParm
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string itemCd { get; set; }
        public string IsProductOrTreatment { get; set; }
    }
}