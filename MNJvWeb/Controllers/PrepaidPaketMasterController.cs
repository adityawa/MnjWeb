using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MNJvWeb.Models;
using MNJvWeb.Models.EntityModel;
using Newtonsoft.Json;
namespace MNJvWeb.Controllers
{
    public class PrepaidPaketMasterController : BaseController
    {
        //
        // GET: /PrepaidPaketMaster/
        [Authorize]

        public ActionResult Index()
        {
            return CheckSession();

        }

        [HttpGet]
        public JsonResult GetPrepaidPaket(string param)
        {
            string _status = "success";
            List<SPA17ITModel> ls = new List<SPA17ITModel>();
            string sSql = "SELECT a.prepaid_cd,"
                            + " a.prepaid_nm,"
                            + " a.amt,"
                            + " b.item_cd,"
                            + " c.item_nm,"
                            + " b.qty,"
                            + " a.input_dt,"
                            + " a.input_id"
                            + " FROM spa16it a, spa17it b, spa02mt c"
                            + " WHERE a.prepaid_cd = b.prepaid_cd(+)"
                            + " AND b.item_cd = c.item_cd(+)";
            if (param.ToLower() != "0" && param != string.Empty)
            {
                sSql += " AND a.prepaid_cd= " + param;
            }
            sSql += " ORDER BY a.prepaid_cd, c.item_nm";
            try
            {
                ls = new DBManager().GetDataByDapper<SPA17ITModel>(sSql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            var JsonResult = Json(new { Data = ls, Status = _status }, JsonRequestBehavior.AllowGet);
            JsonResult.MaxJsonLength = Int32.MaxValue;
            return JsonResult;
        }

        [HttpPost]
        public JsonResult AddPrepaidPaket()
        {
            string _status = "success";
            int _PrepaidNo = 0;
            if (Session["UserLogOn"] != null)
            {

                SPA16ITModel spa16it = new SPA16ITModel();
                spa16it.PREPAID_NM = Request.Form["PrepaidName"];
                spa16it.AMT = Decimal.Parse(Request.Form["Price"]);
                List<SPA17ITModel> ls_detail = JsonConvert.DeserializeObject<List<SPA17ITModel>>(Request.Form["Detail"]);
                if (Request.Form["PrepaidCD"] == "")
                {
                    try
                    {
                        string _err = string.Empty;
                        _PrepaidNo = Convert.ToInt32(new DBManager().GetData("SELECT NVL(MAX(PREPAID_CD),0) + 1 DISC_NO FROM SPA16IT", out _err).Rows[0][0].ToString());
                        spa16it.PREPAID_CD = _PrepaidNo;
                        List<string> ls_qry = new List<string>();
                          ls_qry.Add( string.Format("INSERT into SPA16IT (INPUT_DT, PREPAID_CD, PREPAID_NM, AMT, INPUT_ID) "
                            + " VALUES ('{0}', {1}, '{2}', {3}, {4})", DateTime.Now.ToString("yyyyMMdd"), spa16it.PREPAID_CD, spa16it.PREPAID_NM, spa16it.AMT, DateTime.Now.ToString("yyyyMMddhhmmss")));

                            for (int i = 0; i < ls_detail.Count; i++)
                            {
                                ls_qry.Add( string.Format("INSERT INTO SPA17IT (PREPAID_CD, ITEM_CD, QTY, UP_PRC, DISC_PROSEN) "
                                    + " VALUES ({0}, '{1}', {2}, {3}, {4})", _PrepaidNo, ls_detail[i].ITEM_CD, ls_detail[i].QTY, ls_detail[i].UP_PRC, 0));
                                
                            }
                            int header_result = new DBManager().AddOrUpdateWithTRansaction(ls_qry, out _status);

                    }
                    catch (Exception ex)
                    {
                        _status = ex.Message;
                     
                    }
                }
                else
                {
                    //update here
                    List<string> lsqry=new List<string>();
                    lsqry.Add( string.Format("UPDATE SPA16IT SET AMT={0} where PREPAID_CD={1} ", spa16it.AMT, Request.Form["PrepaidCD"].ToString()));
                    lsqry.Add( "Delete from SPA17IT where PREPAID_CD= " + Request.Form["PrepaidCD"].ToString());
                    
                    try
                    {   
                            for (int i = 0; i < ls_detail.Count; i++)
                            {
                                lsqry.Add( string.Format(" INSERT INTO SPA17IT (PREPAID_CD, ITEM_CD, QTY, UP_PRC, DISC_PROSEN) "
                                    + " VALUES ({0}, '{1}', {2}, {3}, {4})", Request.Form["PrepaidCD"].ToString(), ls_detail[i].ITEM_CD, ls_detail[i].QTY, ls_detail[i].UP_PRC, 0));
                            }
                            int result_updated = new DBManager().AddOrUpdateWithTRansaction(lsqry, out _status);
                    }
                    catch (Exception ex)
                    {
                        _status = ex.Message;
                       
                    }
                   
                }
            }
            else
            {
                _status = "Session Expired";
            }

            return Json(new { Status = _status }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeletePrepaid(string id)
        {
            string _status = "success";
            string[] arr_Parm = id.Split(';').ToArray();
            string sSqlCekTran = string.Format("SELECT PAKET_NM FROM spa14it WHERE disc_type=1 AND paket_nm={0}", arr_Parm[0]);
            string _msgErr = string.Empty;
            System.Data.DataTable dt_cek = new DBManager().GetData(sSqlCekTran, out _msgErr);
            if (dt_cek.Rows.Count > 0)
            {
                _status = "Prepaid Packet cannot deleted because already used in Transaction";
            }
            else
            {
                string sSqlDel = string.Format("DELETE from SPA17IT where PREPAID_CD={0} AND ITEM_CD={1}", arr_Parm[0], arr_Parm[1]);
                int afftected_detail = new DBManager().Delete(sSqlDel);
                if (afftected_detail > 0)
                {
                    //cek if item in detail still exist, if No
                    string sSqlCekCurrDetail = string.Format("SELECT * FROM SPA17IT WHERE PREPAID_CD={0}", arr_Parm[0]);
                    int currDetail = new DBManager().GetData(sSqlCekCurrDetail, out _msgErr).Rows.Count;
                    if (currDetail <= 0)
                    {
                        string sSqlDelHdr = string.Format("DELETE FROM SPA16IT where PREPAID_CD={0}", arr_Parm[0]);
                        try
                        {
                            int affected_hdr = new DBManager().Delete(sSqlDelHdr);
                        }
                        catch (Exception ex)
                        {
                            _status = ex.Message;
                        }
                    }

                }
            }

            return Json(new { Status = _status }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDetailPrepaidPacket(string parm)
        {
            string _status = "success";
            bool _isUseInTran = false;
            List<SPA17ITModel> lsDetail = new List<SPA17ITModel>();
            string sSql_header = "SELECT * from SPA16IT where PREPAID_CD= " + parm;
            string sSql_detail = "SELECT a.PREPAID_CD, a.ITEM_CD, a.QTY, a.UP_PRC, b.ITEM_NM from SPA17IT a INNER JOIN SPA02MT b on a.ITEM_CD=b.ITEM_CD where a.PREPAID_CD= " + parm;
            string sSqlCekTran = string.Format("SELECT PAKET_NM FROM spa14it WHERE disc_type=1 AND paket_nm={0}", parm);
            try
            {
                System.Data.DataTable dt_cek = new DBManager().GetData(sSqlCekTran, out _status);
                if (dt_cek.Rows.Count > 0)
                {
                    _isUseInTran = true;
                }
                var headr = new DBManager().GetDataByDapper<SPA16ITModel>(sSql_header).FirstOrDefault();
                var detil = new DBManager().GetDataByDapper<SPA17ITModel>(sSql_detail);
                int _row_no = 1;
                foreach (var item in detil)
                {

                    lsDetail.Add(new SPA17ITModel
                    {
                        row_no = _row_no.ToString(),
                        ITEM_CD = item.ITEM_CD,
                        ITEM_NM = item.ITEM_NM,
                        QTY = item.QTY
                    });
                    _row_no++;
                }

                return Json(new { Status = _status, Data = lsDetail, Prpepaid_NO = headr.PREPAID_CD, Prepaid_NM = headr.PREPAID_NM, AMT = headr.AMT, IsUseInTran = _isUseInTran }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _status = ex.Message;
                return Json(new { Data = lsDetail, Status = _status }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}