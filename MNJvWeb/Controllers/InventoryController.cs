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
    public class InventoryController : Controller
    {

        [Authorize]
        public ActionResult Adjustmentstock()
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
        public ActionResult InputGoodReceived()
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
        public ActionResult ListGoodReceived()
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
        public ActionResult ListGoodIssue()
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
        public ActionResult ListStock()
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
        public ActionResult ListAdjustment()
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

        public JsonResult GetAdjustmentstock(AdjustmentstockParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<AdjustmentstockResult> list = new List<AdjustmentstockResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<AdjustmentstockResult>(dt);
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
        public JsonResult GetInputGoodReceived(InputGoodReceivedParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<InputGoodReceivedResult> list = new List<InputGoodReceivedResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<InputGoodReceivedResult>(dt);
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
        public JsonResult GetListGoodReceived(ListGoodReceivedParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ListGoodReceivedResult> list = new List<ListGoodReceivedResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ListGoodReceivedResult>(dt);
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
        public JsonResult GetListGoodIssue(ListGoodIssueParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ListGoodIssueResult> list = new List<ListGoodIssueResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ListGoodIssueResult>(dt);
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
        public JsonResult GetListStock(ListStockParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ListStockResult> list = new List<ListStockResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ListStockResult>(dt);
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
        public JsonResult GetListAdjustment(ListAdjustmentParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ListAdjustmentResult> list = new List<ListAdjustmentResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ListAdjustmentResult>(dt);
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