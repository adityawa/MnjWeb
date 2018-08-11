using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using MNJvWeb.Models;
using MNJvWeb.Models.EntityModel;
using System.Data;
using Newtonsoft.Json;
namespace MNJvWeb.Controllers
{
    public class AjaxDataController : Controller
    {
        //
        // GET: /AjaxData/
        public JsonResult GetSPA02MT()
        {
            DBHelper objDBHelp = new DBHelper();
            DataTable dtbl = objDBHelp.GetData("SPA02MT",null, new string[]{"USED"}, new string[]{"Y"});
            List<SPA02MTModel> list = new List<SPA02MTModel>();
           // list = ObjectConverter.DataTableToList<SPA02MTModel>(dtbl);
            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                list.Add(new SPA02MTModel { id = dtbl.Rows[i]["ITEM_CD"].ToString(), text = dtbl.Rows[i]["ITEM_NM"].ToString() });
            }
            var JsonResult = Json(new { Data = list }, JsonRequestBehavior.AllowGet);
            JsonResult.MaxJsonLength = Int32.MaxValue;
            return JsonResult;
        }

        public JsonResult GetSPA05MT()
        {
            DBHelper objDBHelp = new DBHelper();
            DataTable dtbl = objDBHelp.GetData("SPA05MT", null, null, null);
            List<SPA05MTModel> list = new List<SPA05MTModel>();
            list = ObjectConverter.DataTableToList<SPA05MTModel>(dtbl);

            var JsonResult = Json(new { Data = list }, JsonRequestBehavior.AllowGet);
            JsonResult.MaxJsonLength = Int32.MaxValue;
            return JsonResult;
        }

        [HttpPost]
        public JsonResult GetSPA02MTWithParam()
        {
            DBHelper objDBHelp = new DBHelper();
            string item_cd=string.Empty;
            if (Request["parameter"] != null)
                item_cd = Request["parameter"].ToString();

            DataTable dtbl = objDBHelp.GetData("SPA02MT", null, new string[]{"ITEM_CD"}, new string[]{item_cd});
            List<SPA02MTModel> list = new List<SPA02MTModel>();
            list = ObjectConverter.DataTableToList<SPA02MTModel>(dtbl);


            return Json(new { Item_Nm = list[0].ITEM_NM }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGerai()
        {
            DBHelper objDBHelp = new DBHelper();
           
            DataTable dtbl = objDBHelp.GetData("SPA01MT", null, new string[]{"GRP_CD"}, new string[]{"GERAI"});
            List<SPTA01MTModel> list = new List<SPTA01MTModel>();
            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                list.Add(new SPTA01MTModel { id = dtbl.Rows[i]["ITEM_CD"].ToString(), text = dtbl.Rows[i]["ITEM_NM"].ToString() });
            }

            //list = ObjectConverter.DataTableToList<SPTA01MTModel>(dtbl);

            var JsonResult = Json(new { Data = list }, JsonRequestBehavior.AllowGet);
            JsonResult.MaxJsonLength = Int32.MaxValue;
            return JsonResult;
        }

        [HttpGet]
        public JsonResult GetItemGroup()
        {
            DBHelper objDBHelp = new DBHelper();

            DataTable dtbl = objDBHelp.GetData("SPA01MT", null, new string[] { "GRP_CD", "USED" }, new string[] { "GROUP ITEM", "Y" });
            List<SPTA01MTModel> list = new List<SPTA01MTModel>();
            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                list.Add(new SPTA01MTModel { id = dtbl.Rows[i]["ITEM_CD"].ToString(), text = dtbl.Rows[i]["ITEM_NM"].ToString() });
            }

            //list = ObjectConverter.DataTableToList<SPTA01MTModel>(dtbl);

            var JsonResult = Json(new { Data = list }, JsonRequestBehavior.AllowGet);
            JsonResult.MaxJsonLength = Int32.MaxValue;
            return JsonResult;
        }

        public JsonResult GetTransType()
        {
            DBHelper objDBHelp = new DBHelper();

            DataTable dtbl = objDBHelp.GetData("SPA01MT", null, new string[] { "GRP_CD" }, new string[] { "TRANSAKSI TYPE" });
            List<SPTA01MTModel> list = new List<SPTA01MTModel>();
            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                list.Add(new SPTA01MTModel { id = dtbl.Rows[i]["ITEM_CD"].ToString(), text = dtbl.Rows[i]["ITEM_NM"].ToString() });
            }

            //list = ObjectConverter.DataTableToList<SPTA01MTModel>(dtbl);

            var JsonResult = Json(new { Data = list }, JsonRequestBehavior.AllowGet);
            JsonResult.MaxJsonLength = Int32.MaxValue;
            return JsonResult;
        }

        public JsonResult GetPaymentType()
        {
            DBHelper objDBHelp = new DBHelper();

            DataTable dtbl = objDBHelp.GetData("SPA01MT", null, new string[] { "GRP_CD" }, new string[] { "PAYMENT TYPE" });
            List<SPTA01MTModel> list = new List<SPTA01MTModel>();
            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                list.Add(new SPTA01MTModel { id = dtbl.Rows[i]["ITEM_CD"].ToString(), text = dtbl.Rows[i]["ITEM_NM"].ToString() });
            }

            //list = ObjectConverter.DataTableToList<SPTA01MTModel>(dtbl);

            var JsonResult = Json(new { Data = list }, JsonRequestBehavior.AllowGet);
            JsonResult.MaxJsonLength = Int32.MaxValue;
            return JsonResult;
        }


        public JsonResult GetSPA03MT()
        {
            string _status = "success";
            DBHelper objDBHelper = new DBHelper();

            DataTable dt = objDBHelper.GetData("SPA03MT", null, null, null);
            List<SPTA03MTModel> list = new List<SPTA03MTModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(new SPTA03MTModel
                {
                    id= dt.Rows[i]["EMP_NO"].ToString(),
                    text = dt.Rows[i]["EMP_NM"].ToString()
                });
            }

            var JsonRes = Json(new { Data = list }, JsonRequestBehavior.AllowGet);
            JsonRes.MaxJsonLength = Int32.MaxValue;
            return JsonRes;
        }

        [HttpGet]
        public JsonResult GetCustomerGroup()
        {
            DBHelper objDBHelp = new DBHelper();

            DataTable dtbl = objDBHelp.GetData("SPA01MT", null, new string[] { "GRP_CD", "USED" }, new string[] { "ITEM GROUP BY CUSTOMER GROUP", "Y" });
            List<SPTA01MTModel> list = new List<SPTA01MTModel>();
            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                list.Add(new SPTA01MTModel { id = dtbl.Rows[i]["ITEM_CD"].ToString(), text = dtbl.Rows[i]["ITEM_NM"].ToString() });
            }

            //list = ObjectConverter.DataTableToList<SPTA01MTModel>(dtbl);

            var JsonResult = Json(new { Data = list }, JsonRequestBehavior.AllowGet);
            JsonResult.MaxJsonLength = Int32.MaxValue;
            return JsonResult;
        }
    }
}