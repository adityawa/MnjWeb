using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNJvWeb.Models.EntityModel
{
    public class ListPackageMemberParam
    {
        public string sDate { get; set; }
        public string eDate { get; set; }
        public string GeraiCd { get; set; }
        public string ItemCd { get; set; }
        public string EmpNo { get; set; }
        public string CusCd { get; set; }
        public string StatusCd { get; set; }
        public string PrepaidNo { get; set; }
        public string isDetail { get; set; }
    }
}