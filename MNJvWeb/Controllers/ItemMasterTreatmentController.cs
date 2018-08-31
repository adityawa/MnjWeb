using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MNJvWeb.Models;
using MNJvWeb.Models.Master;
namespace MNJvWeb.Controllers
{
    public class ItemMasterTreatmentController : Controller
    {
        // GET: ItemMasterTreatment
        [Authorize]
        public ActionResult List()
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

        [HttpGet]
        public JsonResult GetQueryData()
        {
            List<InputMasterItemTreatmentInqModel> ls = new List<InputMasterItemTreatmentInqModel>();
            string _itemGroup = string.Empty;
            string _itemCode = string.Empty;
            string _type = string.Empty; string _custGroup = string.Empty;
            if (Request["itemGrp"] != null)
                _itemGroup = Request["itemGrp"].ToString();
            if (Request["itemCd"] != null)
                _itemCode = Request["itemCd"].ToString();
            if (Request["Type"] != null)
                _type = Request["Type"].ToString();
            if (Request["Customer"] != null)
                _custGroup = Request["Customer"].ToString();
            ls = new InputMasterItemTreatmentBLL().InquiryData(_itemCode, _itemGroup, _type, _custGroup);

            var JsonResult = Json(new { Data = ls }, JsonRequestBehavior.AllowGet);
            JsonResult.MaxJsonLength = Int32.MaxValue;

            return JsonResult;
        }

        [HttpPost]
        public JsonResult Add()
        {
            string _status = "success";
            int resultAffected = 0;
            string _group = string.Empty;
            string _itemCode = string.Empty;
            string _harga = string.Empty;
            string _type = string.Empty; 
            string _custGroup = string.Empty; 
            string _itemNm=string.Empty; 
            string _uom=string.Empty;
            if (Request["itemGrp"] != null)
                _group = Request["itemGrp"].ToString();
           
            if (Request["Type"] != null)
                _type = Request["Type"].ToString();
            if (Request["Customer"] != null)
                _custGroup = Request["Customer"].ToString();
            if (Request["itemNm"] != null)
                _itemNm = Request["itemNm"].ToString();
            if (Request["Harga"] != null)
                _harga = Request["Harga"].ToString();
            if (Request["Uom"] != null)
                _uom = Request["Uom"].ToString();
            try
            {
                resultAffected=new InputMasterItemTreatmentBLL().InsertData(_itemCode, _itemNm, _harga, _uom, _group, _custGroup, _type);
                if (resultAffected <= 0)
                {
                    _status = "transaction failed";
                }
            }
            catch (Exception ex)
            {
                _status = "an error occured. "+ex.Message;
            }
            return Json(new { Status = _status }, JsonRequestBehavior.AllowGet);
        }
    }
}