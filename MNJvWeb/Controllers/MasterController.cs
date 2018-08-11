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
    public class MasterController : Controller
    {

        [Authorize]
        public ActionResult ItemMaster()
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
        public ActionResult PrepaidPackageMaster()
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
        public ActionResult EmployeeMaster()
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
        public ActionResult CustomerMaster()
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
        public ActionResult CodeMaster()
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


        public JsonResult GetItemMaster(ItemMasterParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ItemMasterResult> list = new List<ItemMasterResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ItemMasterResult>(dt);
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
        public JsonResult GetPrepaidPackageMaster(PrepaidPackageMasterParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<PrepaidPackageMasterResult> list = new List<PrepaidPackageMasterResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<PrepaidPackageMasterResult>(dt);
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
        public JsonResult GetEmployeeMaster(EmployeeMasterParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<EmployeeMasterResult> list = new List<EmployeeMasterResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<EmployeeMasterResult>(dt);
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
        public JsonResult GetCustomerMaster(CustomerMasterParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<CustomerMasterResult> list = new List<CustomerMasterResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<CustomerMasterResult>(dt);
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
        public JsonResult GetCodeMaster(CodeMasterParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<CodeMasterResult> list = new List<CodeMasterResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<CodeMasterResult>(dt);
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