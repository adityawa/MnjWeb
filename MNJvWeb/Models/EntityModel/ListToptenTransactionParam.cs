﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNJvWeb.Models.EntityModel
{
    public class ListToptenTransactionParam
    {
        public string sDate { get; set; }
        public string eDate { get; set; }
        public string GeraiCd { get; set; }
        public string TypeCd { get; set; }
        public string isDetail { get; set; }
        public string basedOn { get; set; }
    }
}