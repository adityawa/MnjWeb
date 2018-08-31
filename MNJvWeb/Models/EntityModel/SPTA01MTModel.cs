using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNJvWeb.Models.EntityModel
{
    public class SPTA01MTModel : select2BaseModel
    {
        public string GRP_CD { get; set; }
        public string ITEM_CD { get; set; }
        public string ITEM_NM { get; set; }
        public string USED { get; set; }
        public string CD_CLASS { get; set; }

      
    }
}