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
    public class CustomerController : Controller
    {

        [Authorize]
        public ActionResult InputVoucherDiscountPromotion()
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
        public ActionResult InputVoucherReimbursement()
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
        public ActionResult InputGiftVoucher()
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
        public ActionResult InputPrepaidPackage()
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
        public ActionResult UpdateStatusPrepaidPackage()
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
        public ActionResult InputTopUpPrepaidPackage()
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
        public ActionResult InputMovePrepaidPackageTreatment()
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
        public ActionResult Transaction()
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


        public JsonResult GetInputVoucherDiscountPromotion(InputVoucherDiscountPromotionParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<InputVoucherDiscountPromotionResult> list = new List<InputVoucherDiscountPromotionResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<InputVoucherDiscountPromotionResult>(dt);
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
        public JsonResult GetInputVoucherReimbursement(InputVoucherReimbursementParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<InputVoucherReimbursementResult> list = new List<InputVoucherReimbursementResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<InputVoucherReimbursementResult>(dt);
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

        public JsonResult GetInputGiftVoucher(InputGiftVoucherParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<InputGiftVoucherResult> list = new List<InputGiftVoucherResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<InputGiftVoucherResult>(dt);
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
        public JsonResult GetInputPrepaidPackage(InputPrepaidPackageParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<InputPrepaidPackageResult> list = new List<InputPrepaidPackageResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<InputPrepaidPackageResult>(dt);
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
        public JsonResult GetUpdateStatusPrepaidPackage(UpdateStatusPrepaidPackageParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<UpdateStatusPrepaidPackageResult> list = new List<UpdateStatusPrepaidPackageResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<UpdateStatusPrepaidPackageResult>(dt);
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
        public JsonResult GetInputTopUpPrepaidPackage(InputTopUpPrepaidPackageParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<InputTopUpPrepaidPackageResult> list = new List<InputTopUpPrepaidPackageResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<InputTopUpPrepaidPackageResult>(dt);
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
        public JsonResult GetInputMovePrepaidPackageTreatment(InputMovePrepaidPackageTreatmentParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<InputMovePrepaidPackageTreatmentResult> list = new List<InputMovePrepaidPackageTreatmentResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<InputMovePrepaidPackageTreatmentResult>(dt);
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
        public JsonResult GetTransaction(TransactionParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<TransactionResult> list = new List<TransactionResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<TransactionResult>(dt);
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