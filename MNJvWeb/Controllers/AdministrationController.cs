using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MNJvWeb.Models;
using MNJvWeb.Models.EntityModel;
using System.Data;

namespace MNJvWeb.Controllers
{
    public class AdministrationController : Controller
    {

        [Authorize]
        public ActionResult Absenci()
        {
            if (Session["UserLogOn"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult ListAbsenci()
        {
            if (Session["UserLogOn"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult ListUpdateAbsenci()
        {
            if (Session["UserLogOn"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }


        public JsonResult GetAbsenci(AbsenciParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<AbsenciResult> list = new List<AbsenciResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<AbsenciResult>(dt);
            }
            catch (Exception es)
            {
                _status = "Error";
                errMsg = es.Message;
            }
            var JsonResult = Json(new { Data = list, Status = _status, ErrMsg = errMsg }, JsonRequestBehavior.AllowGet);
            JsonResult.MaxJsonLength = Int32.MaxValue;
            return JsonResult;
        }
        public JsonResult GetListAbsenci(ListAbsenciParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ListAbsenciResult> list = new List<ListAbsenciResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ListAbsenciResult>(dt);
            }
            catch (Exception es)
            {
                _status = "Error";
                errMsg = es.Message;
            }
            var JsonResult = Json(new { Data = list, Status = _status, ErrMsg = errMsg }, JsonRequestBehavior.AllowGet);
            JsonResult.MaxJsonLength = Int32.MaxValue;
            return JsonResult;
        }
        public JsonResult GetListUpdateAbsenci(ListUpdateAbsenciParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ListUpdateAbsenciResult> list = new List<ListUpdateAbsenciResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ListUpdateAbsenciResult>(dt);
            }
            catch (Exception es)
            {
                _status = "Error";
                errMsg = es.Message;
            }
            var JsonResult = Json(new { Data = list, Status = _status, ErrMsg = errMsg }, JsonRequestBehavior.AllowGet);
            JsonResult.MaxJsonLength = Int32.MaxValue;
            return JsonResult;
        }
 
    
    }
}