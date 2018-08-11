using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using Dapper;
namespace MNJvWeb.Models.Master
{
    public class InputMasterItemTreatmentModel
    {
        public string ITEM_CD { get; set; }
        public string CUSTOMER { get; set; }
        public string Type { get; set; }
        public string GRP_CD { get; set; }
        public string ITEM_NM { get; set; }
        public decimal HARGA { get; set; }
        public string UNIT_NM { get; set; }
    }

    public class InputMasterItemTreatmentInqModel : InputMasterItemTreatmentModel
    {
        public string GROUP_NM { get; set; }
        public string TYPE_NM { get; set; }
        public decimal STOCK { get; set; }
    }

    public class InputMasterItemTreatmentBLL
    {
        public List<InputMasterItemTreatmentInqModel> InquiryData(string _itemCd, string _itemGroup, string _type, string _custGroup)
        {
            List<InputMasterItemTreatmentInqModel> ls = new List<InputMasterItemTreatmentInqModel>();
            string sSql = "SELECT   a.item_cd,"
        + " DECODE(a.type_cd,1,'Treatment','Product') type_Nm,"
        + " c.item_nm group_Nm,"
        + " d.item_nm  as Customer,"
        + " a.item_nm,"
        + " NVL(a.harga,0) harga,"
        + " b.item_nm unit_nm,"
        + " a.stock"
+ " FROM     SPA02MT a, SPA01MT b, SPA01MT C, SPA01MT D"
+ " WHERE    a.unit_qty = b.item_cd(+)"
         + " AND b.grp_cd(+) = 'UNIT QUANTITY'"
         + "  AND a.group_cd = c.item_cd(+)"
         + " AND c.grp_cd(+) = 'GROUP ITEM'"
         + " AND a.VISIT_GRP = d.item_cd(+)"
         + " AND d.grp_cd(+) = 'ITEM GROUP BY CUSTOMER GROUP'";


            DBManager db = new DBManager();
            ls = db.GetDataByDapper<InputMasterItemTreatmentInqModel>(sSql);
            return ls;
        }
    }
}