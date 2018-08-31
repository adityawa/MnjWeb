using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using Dapper;
using MNJvWeb.Models.EntityModel;
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

            if (_itemCd != "0")
                sSql += " AND a.item_cd=" + _itemCd;
            if (_type != "" && _type.ToLower() != "all")
                sSql += " AND a.type_cd=" + _type;
            if (_custGroup != "0" && _custGroup.ToLower() != "all")
                sSql += " AND d.item_cd=" + _custGroup;
            if (_itemGroup != "0" && _itemGroup != "all")
                sSql += " AND c.item_cd=" + _itemGroup;

            DBManager db = new DBManager();
            ls = db.GetDataByDapper<InputMasterItemTreatmentInqModel>(sSql);
            return ls;
        }

        public int InsertData(string _itemCd, string _itemNm, string _harga, string _uom, string _grpCd, string _custCd, string _typeCd)
        {
            int result = 0;
            string sSql = string.Format( "INSERT INTO SPA02MT (ITEM_CD, ITEM_NM, HARGA, USED, UNIT_QTY, GROUP_CD, VISIT_GRP, TYPE_CD) "
                + " VALUES ('{0}', '{1}', {2}, 'Y', '{3}', '{4}', '{5}', '{6}')",new DBHelper().GetAutoNo("spa02mt", "ITEM_CD"), _itemNm,Convert.ToInt32(_harga), "Y", _uom, _grpCd, _custCd, _typeCd);
          
            DBManager db = new DBManager();
            result = db.Add(sSql);
            return result;
        }
    }
}