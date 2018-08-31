using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNJvWeb.Models.EntityModel
{
    public class SPA02MTModel : select2BaseModel
    {
        public string ITEM_CD { get; set; }
        public string ITEM_NM { get; set; }
        public int HARGA { get; set; }
        public string USED { get; set; }
        public string UNIT_QTY { get; set; }
        public string GROUP_CD { get; set; }
        public string VISIT_GRP { get; set; }
        public int TYPE_CD { get; set; }
        public int STOCK { get; set; }

        
    }
}