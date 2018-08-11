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
    public class ReportController : Controller
    {


        [Authorize]
        public ActionResult ListRecapDailyTransaction()
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

        //[Authorize]
        public ActionResult ListTransactionByPeriod()
        {
            //if (Session["UserLogOn"] == null)
            //{
            //    return RedirectToAction("Login", "Account");
            //}
            //else
            //{
                return View();
            //}
        }

        //[Authorize]
        public ActionResult ListTransactioniByTreatment()
        {
            return View();
        }

        public ActionResult ListTransactionPerTeraphis()
        {
            return View();
        }

        public ActionResult ListToptenTransaction()
        {
            return View();
        }

        public ActionResult ListToptenCustomer()
        {
            return View();
        }

        public ActionResult ListCashIn()
        {
            return View();
        }

        public ActionResult ListPackageMember()
        {
            return View();
        }

        public ActionResult ListCommisionTeraphis()
        {
            return View();
        }

        public ActionResult ListStatusVoucherPackageMember()
        {
            return View();
        }

        public ActionResult ListTransactionBaseOnTreatmentType()
        {
            return View();
        }

        public ActionResult ListTransactionByCustomerNewOld()
        {
            return View();
        }

        public ActionResult ListHistoryDeleteTransaction()
        {
            return View();
        }

        public ActionResult InquiryTransByItem()
        {
            return View();
        }

        public ActionResult InquiryTransByTherapis()
        {
            return View();
        }

        public ActionResult InquiryTopTenTransaction()
        {
            return View();
        }

        public ActionResult InquiryTransactionByPeriod()
        {
            return View();
        }

        public JsonResult GetInquiryTransByItem(InquiryTransByItemParm prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<InquiryTransByItemResult> list = new List<InquiryTransByItemResult>();
            //DBManager objdbmgr = new DBManager();
            string date_start = Utilities.formatDate(prm.startDate);
            string date_end = Utilities.formatDate(prm.endDate);
            //sSql = "SELECT   MAX(d.sw) sw, "
            //        + " MAX(DECODE(d.sw,1,TRIM(TO_CHAR(TO_DATE(a.indate,'YYYYMMDD'),'DD-MM-YYYY')),'')) tgl,"
            //        + " MAX(DECODE(d.sw,1,c.item_nm, 2, 'TOTAL '||TRIM(TO_CHAR(TO_DATE(a.indate,'YYYYMMDD'),'DD-MM-YYYY')),'GRAND TOTAL')) ItemNm,"
            //        + " SUM(b.qty) qty,"
            //        + " SUM(b.total) amt,"
            //        + " SUM(DECODE(NVL(e.disc_type,'9'),'1',b.voucher_amt,0)) paket,"
            //        + " SUM(DECODE(NVL(e.disc_type,'9'),'2',b.voucher_amt,0)) gift,"
            //        + " SUM(DECODE(NVL(e.disc_type,'9'),'3',b.voucher_amt,0)) reimbsemen,"
            //        + " SUM(DECODE(NVL(e.disc_type,'9'),'4',b.voucher_amt,0)) promo,"
            //        + " SUM(b.total+DECODE(NVL(e.disc_type,'9'),'1',b.voucher_amt,'2',b.voucher_amt,0)) total"
            //        + " FROM   spa12it a, spa13it b, spa02mt c, tot_psu d, spa15it e"
            //        + " WHERE    a.indate BETWEEN '" + date_start + "' AND '" + date_end + "'"
            //        + " AND a.to_no = b.to_no(+)"
            //        + " AND b.item_cd = c.item_cd(+)"
            //        + " AND b.voucher_no= e.voucher_no(+)"
            //        + " AND d.sw <= 3"
            //        + " AND b.item_cd LIKE '" + prm.itemCd + "%'";

            //switch (prm.IsProductOrTreatment)
            //{
            //    case "TREATMENT":
            //        sSql = sSql + " AND c.type_cd = 1";
            //        break;
            //    case "PRODUCT":
            //        sSql = sSql + " AND c.type_cd = 2";
            //        break;
            //}

            //sSql += "GROUP BY DECODE(d.sw,3,'XXXXXXXX', a.indate), DECODE(d.sw,1,b.item_cd, 'XXXXX')";
            //sSql += "ORDER BY DECODE(d.sw,3,'XXXXXXXX', a.indate), DECODE(d.sw,1,b.item_cd, 'XXXXX')";
            //try
            //{
            //    DataTable dt = objdbmgr.GetData(sSql, out errMsg);
            //    list = ObjectConverter.DataTableToList<InquiryTransByItemResult>(dt);

            //}
            //catch (Exception es)
            //{
            //    _status = "Error";
            //    errMsg = es.Message;
            //}

            var JsonResult = Json(new { Data = list, Status = _status, ErrMsg = errMsg }, JsonRequestBehavior.AllowGet);
            JsonResult.MaxJsonLength = Int32.MaxValue;
            return JsonResult;
        }

        public JsonResult GetInquiryTransByTheraphis(InquiryTranByTherapisParm parm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<InquiryTranByTherapisResult> list = new List<InquiryTranByTherapisResult>();
            DBManager objdbmgr = new DBManager();
            string date_start = Utilities.formatDate(parm.startDate);
            string date_end = Utilities.formatDate(parm.endDate);
            sSql = "SELECT   MAX(c.sw) SW,"
                    + " MAX(DECODE(c.sw,1, TRIM(TO_CHAR(TO_DATE(a.indate,'YYYYMMDD'),'DD-MM-YYYY')), '')) TGL,"
                    + " MAX(DECODE(c.sw,1, a.typeTrans, '')) TYPE_NM,"
                    + " MAX(DECODE(c.sw,1, b.emp_nm, 2, 'TOTAL '||b.emp_nm, 'GRAND TOTAL')) EMP_NM,"
                    + " SUM(a.amt) TO_AMT,"
                    + " SUM(a.paket) PAKET,"
                    + " SUM(a.gift) GIFT,"
                    + " SUM(a.total) TOTAL,"
                    + " SUM(a.komisi) KOMISI"
                    + " FROM     (   SELECT  a.indate, 1 grp,'Transaksi' typeTrans,a.to_no,a.emp_no,SUM(b.total) amt,"
                    + " SUM(DECODE(NVL(c.disc_type,'9'),'1',b.voucher_amt,0)) paket,"
                    + " SUM(DECODE(NVL(c.disc_type,'9'),'2',b.voucher_amt,0)) gift,"
                    + " SUM(b.total+DECODE(NVL(c.disc_type,'9'),'1',b.voucher_amt,'2',b.voucher_amt,0)) total,"
                    + " MAX(a.komisi_amt) komisi"
                    + " FROM    spa12it a, spa13it b, spa15it c"
                    + " WHERE   a.indate BETWEEN '" + date_start + "' AND '" + date_end + "' "
                    + " AND a.to_no = b.to_no(+)"
                    + " AND b.voucher_no = c.voucher_no(+)";

            if (parm.therapis != null && !parm.therapis.Equals(string.Empty))
            {
                sSql += " AND a.emp_no = " + parm.therapis;
            }

            sSql += " GROUP BY a.indate, a.to_no, a.emp_no "
            + " UNION ALL"
            + " SELECT  a.indate,2 grp, 'Penjualan Prepaid' typeTrans,a.disc_no to_no, a.emp_no,"
            + " SUM(a.amt) amt,SUM(a.amt) paket, 0 gift,SUM(a.amt) total,MAX(a.komisi_amt) komisi "
            + " FROM    spa14it a "
            + " WHERE   a.indate BETWEEN '" + date_start + "' AND '" + date_end + "'"
            + " AND a.disc_type IN ('1')";

            if (parm.therapis != null && !parm.therapis.Equals(string.Empty))
            {
                sSql += " AND a.emp_no = " + parm.therapis;
            }

            sSql += " GROUP BY a.indate, a.disc_no, a.emp_no"
            + " ) a, spa03mt b, tot_psu c"
            + " WHERE    a.emp_no = b.emp_no(+)"
            + " AND c.sw <= 3"
            + " GROUP BY DECODE(c.sw,3,'XXXXXXXX',a.emp_no), DECODE(c.sw,1,a.indate,'XXXXXXX'), DECODE(c.sw,1,a.grp,99), DECODE(c.sw,1,a.to_no,999999)"
            + " ORDER BY DECODE(c.sw,3,'XXXXXXXX',a.emp_no), DECODE(c.sw,1,a.indate,'XXXXXXX'), DECODE(c.sw,1,a.grp,99), DECODE(c.sw,1,a.to_no,999999)";

            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<InquiryTranByTherapisResult>(dt);

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

        public JsonResult GetInquiryTop10Transaction(InquiryTop10TransParam parm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<InquiryTop10TransResult> list = new List<InquiryTop10TransResult>();
            DBManager objdbmgr = new DBManager();
            string date_start = Utilities.formatDate(parm.startPeriod);
            string date_end = Utilities.formatDate(parm.endPeriod);

            sSql = "SELECT ROWNUM no, a.* FROM ("
                    + " SELECT * FROM ("
                    + " SELECT   MAX(c.item_nm) ItemNm,"
                    + " SUM(b.qty) qty,"
                    + " SUM(b.total+DECODE(NVL(d.disc_type,'9'),'1',b.voucher_amt,'2',b.voucher_amt,0)) amt"
                    + " FROM     spa12it a, spa13it b, spa02mt c, spa15it d"
                    + " WHERE    a.indate BETWEEN '" + date_start + "' AND '" + date_end + "'"
                    + " AND a.to_no = b.to_no(+)"
                    + " AND b.item_cd = c.item_cd(+)"
                    + " AND b.voucher_no = d.voucher_no(+)";

            if (parm.type == "TREATMENT")
            {
                sSql += " AND c.type_cd = 1";
            }
            else if (parm.type == "PRODUCT")
            {
                sSql += " AND c.type_cd = 2";
            }

            sSql += " GROUP BY b.item_cd";

            if (parm.basedOn == "0")
            {
                sSql += " ) ORDER BY qty DESC";
            }
            else
            {
                sSql += " ) ORDER BY amt DESC)a";
            }

            sSql += " ) a";

            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<InquiryTop10TransResult>(dt);

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


        //New BY Wiyono
        public JsonResult GetListRecapDailyTransaction(ListRecapDailyTransactionParam parm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ListRecapDailyTransactionResult> list = new List<ListRecapDailyTransactionResult>();
            DBManager objdbmgr = new DBManager();
            sSql = "";
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ListRecapDailyTransactionResult>(dt);
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

        public JsonResult GetListTransactionByPeriod(ListTransactionByPeriodParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ListTransactionByPeriodResult> list = new List<ListTransactionByPeriodResult>();
            DBManager objdbmgr = new DBManager();

            if (prm.isDetail == "1")
            {
                sSql = "SELECT  MAX(h.sw) sw,"
                       + "      MAX(DECODE(h.sw,4,'',k.gr_nm)) gr_nm,"
                       + "      MAX(DECODE(h.sw,1,a.to_no,2,a.to_no,'')) to_no,"
                       + "      MAX(DECODE(h.sw,4,'',TRIM(TO_CHAR(TO_DATE(a.indate,'YYYYMMDD'),'DD-MM-YYYY')))) tgl,"
                       + "      MAX(DECODE(h.sw,1,a.member_cd,'')) CusCd,"
                       + "      MAX(DECODE(h.sw,1,e.cus_nm,'')) MemberNm,"
                       + "      MAX(DECODE(h.sw,1,c.emp_nm,'')) picNm,"
                       + "      MAX(DECODE(h.sw,1,d.item_nm, 2, 'Total Invoice No '||a.to_no, 3, 'Total Tanggal '||TRIM(TO_CHAR(TO_DATE(a.indate,'YYYYMMDD'),'DD-MM-YYYY')), 4,'TOTAL Gerai '||k.gr_nm,'Grand Total')) ItemNm,"
                       + "      SUM(b.qty) qty,"
                       + "      MAX(DECODE(h.sw,1,b.up,0)) up,"
                       + "      SUM(b.amt) amt,"
                       + "      SUM(b.disc_amt) disc_amt,"
                       + "      SUM(b.total) total,"
                       + "      SUM(b.voucher_amt) voucher,"
                       + "      MAX(DECODE(h.sw,1,NVL(TRIM(TO_CHAR(i.disc_no)),b.voucher_no),'')) voucher_no,"
                       + "      MAX(DECODE(h.sw,1,j.item_nm,'')) voucher_type,"
                       + "      SUM(B.komisi_amt) komisi_amt,"
                       + "      MAX(DECODE(h.sw,2,a.byr_cash,0)) PayCash,"
                       + "      MAX(DECODE(h.sw,2,a.add_amt,0)) add_amt,"
                       + "      MAX(DECODE(h.sw,2,a.add_amt_prosen,0)) add_amt_prosen,"
                       + "      MAX(DECODE(h.sw,2,a.grand_tot_all,0)) grandtotall,"
                       + "      MAX(DECODE(h.sw,1,F_SPA01MTNM(a.pay_cd, 'PAYMENT TYPE'),2,F_SPA01MTNM(a.pay_cd, 'PAYMENT TYPE'),'')) payNm,"
                       + "      MAX(DECODE(h.sw,1,F_SPA01MTNM(a.card_cd, 'CREDIT CARD NAME'),2,F_SPA01MTNM(a.card_cd, 'CREDIT CARD NAME'),'')) cardcd,"
                       + "      MAX(DECODE(h.sw,1,a.card_no,2,a.card_no,'')) cardno"
                       + " FROM     zspa12it a, zspa13it b, zspa03mt c, zspa02mt d, zspa05mt e, ztot_psu h, zspa15it i, zspa01mt j, zgrmst k"
                       + " WHERE    a.to_no = b.to_no(+)"
                       + "          AND a.emp_no = c.emp_no(+)"
                       + "          AND b.item_cd = d.item_cd(+)"
                       + "          AND a.member_cd = e.cus_cd(+)"
                       + "          AND h.sw <= 5"
                       + "          AND b.voucher_no = i.voucher_no(+)"
                       + "          AND i.disc_type = j.item_cd(+)"
                       + "          AND j.grp_cd(+) = 'VOUCHER TYPE'"
                       + "          AND a.gr_cd = k.gr_cd(+)"
                       + "          AND a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + " '"
                       + "          AND a.member_cd LIKE '" + prm.CusCd + "%'"
                       + "          AND a.emp_no LIKE '" + prm.EmpCd + "%'"
                       + "          AND a.pay_cd LIKE '" + prm.PayCd + "%'"
                       + "          AND a.card_cd LIKE '" + prm.CardCd + "%'"
                       + "          AND b.item_cd LIKE '" + prm.ItemCd + "%'"
                       + "          AND a.gr_cd LIKE '" + prm.GeraiCd + "%'"
                       + " GROUP BY DECODE( h.sw,5,'99999',a.gr_cd), DECODE( h.sw,4,'XXXXXXXX',a.indate), DECODE(h.sw,1, a.to_no,2, a.to_no,99999999), DECODE(h.sw,1,b.item_cd,'XXXX')"
                       + " ORDER BY DECODE( h.sw,5,'99999',a.gr_cd), DECODE( h.sw,4,'XXXXXXXX',a.indate), DECODE(h.sw,1, a.to_no,2, a.to_no,99999999), DECODE(h.sw,1,b.item_cd,'XXXX')";
            }
            else
            {
                sSql = "SELECT  MAX(h.sw) sw,"
                       + "      MAX(DECODE(h.sw,2,'',k.gr_nm)) gr_nm,"
                       + "      NULL to_no,"
                       + "      NULL tgl,"
                       + "      NULL CusCd,"
                       + "      NULL MemberNm,"
                       + "      NULL picNm,"
                       + "      MAX(DECODE(h.sw,1,k.gr_nm,'Grand Total')) ItemNm,"
                       + "      SUM(b.qty) qty,"
                       + "      0 up,"
                       + "      SUM(b.amt) amt,"
                       + "      SUM(b.disc_amt) disc_amt,"
                       + "      SUM(b.total) total,"
                       + "      SUM(b.voucher_amt) voucher,"
                       + "      NULL voucher_no,"
                       + "      NULL voucher_type,"
                       + "      SUM(B.komisi_amt) komisi_amt,"
                       + "      0 PayCash,"
                       + "      0 add_amt,"
                       + "      0 add_amt_prosen,"
                       + "      0 grandtotall,"
                       + "      NULL payNm,"
                       + "      NULL cardcd,"
                       + "      NULL cardno"
                       + " FROM     zspa12it a, zspa13it b, zspa03mt c, zspa02mt d, zspa05mt e, ztot_psu h, zspa15it i, zspa01mt j, zgrmst k"
                       + " WHERE    a.to_no = b.to_no(+)"
                       + "          AND a.emp_no = c.emp_no(+)"
                       + "          AND b.item_cd = d.item_cd(+)"
                       + "          AND a.member_cd = e.cus_cd(+)"
                       + "          AND h.sw <= 5"
                       + "          AND b.voucher_no = i.voucher_no(+)"
                       + "          AND i.disc_type = j.item_cd(+)"
                       + "          AND j.grp_cd(+) = 'VOUCHER TYPE'"
                       + "          AND a.gr_cd = k.gr_cd(+)"
                       + "          AND a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + " '"
                       + "          AND a.member_cd LIKE '" + prm.CusCd + "%'"
                       + "          AND a.emp_no LIKE '" + prm.EmpCd + "%'"
                       + "          AND a.pay_cd LIKE '" + prm.PayCd + "%'"
                       + "          AND a.card_cd LIKE '" + prm.CardCd + "%'"
                       + "          AND b.item_cd LIKE '" + prm.ItemCd + "%'"
                       + "          AND a.gr_cd LIKE '" + prm.GeraiCd + "%'"
                       + " GROUP BY DECODE( h.sw,2,'99999',a.gr_cd)"
                       + " ORDER BY DECODE( h.sw,2,'99999',a.gr_cd)";
            }

            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ListTransactionByPeriodResult>(dt);
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

        public JsonResult GetListTransactioniByTreatment(ListTransactioniByTreatmentParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ListTransactioniByTreatmentResult> list = new List<ListTransactioniByTreatmentResult>();
            DBManager objdbmgr = new DBManager();

            if (prm.isDetail == "1")
            {
                sSql = "SELECT   MAX(d.sw) sw,"
                + "         MAX(DECODE(d.sw,4,'', f.gr_nm)) gr_nm,"
                + "         MAX(DECODE(d.sw,1,TRIM(TO_CHAR(TO_DATE(a.indate,'YYYYMMDD'),'DD-MM-YYYY')),'')) tgl,"
                + "         MAX(DECODE(d.sw,1,c.item_nm, 2, 'TOTAL '||TRIM(TO_CHAR(TO_DATE(a.indate,'YYYYMMDD'),'DD-MM-YYYY')),3, 'TOTAL '||f.gr_nm,'GRAND TOTAL')) ItemNm,"
                + "         SUM(b.qty) qty,"
                + "         SUM(b.total) amt,"
                + "         SUM(DECODE(NVL(e.disc_type,'9'),'1',b.voucher_amt,0)) paket,"
                + "         SUM(DECODE(NVL(e.disc_type,'9'),'2',b.voucher_amt,0)) gift,"
                + "         SUM(DECODE(NVL(e.disc_type,'9'),'3',b.voucher_amt,0)) reimbsemen,"
                + "         SUM(DECODE(NVL(e.disc_type,'9'),'4',b.voucher_amt,0)) promo,"
                + "         SUM(b.total+DECODE(NVL(e.disc_type,'9'),'1',b.voucher_amt,'2',b.voucher_amt,0)) total "
                + "FROM     zspa12it a, zspa13it b, zspa02mt c, ztot_psu d, zspa15it e, zgrmst f "
                + "WHERE    a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "         AND a.to_no = b.to_no(+)"
                + "         AND a.gr_cd = f.gr_cd(+)"
                + "         AND b.item_cd = c.item_cd(+)"
                + "         AND b.voucher_no= e.voucher_no(+)"
                + "         AND d.sw <= 4"
                + "         AND a.gr_cd LIKE '" + prm.GeraiCd + "%'"
                + "         AND b.item_cd LIKE '" + prm.ItemCd + "%'";
                if (prm.TypeCd == "1")
                {
                    sSql += "         AND c.type_cd = 1 ";
                }
                if (prm.TypeCd == "2")
                {
                    sSql += "         AND c.type_cd = 2 ";
                }
                sSql += "GROUP BY DECODE(d.sw,4,99999, a.gr_cd), DECODE(d.sw,4,'XXXXXXXX', a.indate), DECODE(d.sw,1,b.item_cd, 'XXXXX') "
                + "ORDER BY DECODE(d.sw,4,99999, a.gr_cd), DECODE(d.sw,4,'XXXXXXXX', a.indate), DECODE(d.sw,1,b.item_cd, 'XXXXX')";
            }
            else
            {
                sSql = "SELECT   MAX(d.sw) sw,"
                + "         MAX(DECODE(d.sw,2,'', f.gr_nm)) gr_nm,"
                + "         NULL tgl,"
                + "         MAX(DECODE(d.sw,1, 'TOTAL '||f.gr_nm,'GRAND TOTAL')) ItemNm,"
                + "         SUM(b.qty) qty,"
                + "         SUM(b.total) amt,"
                + "         SUM(DECODE(NVL(e.disc_type,'9'),'1',b.voucher_amt,0)) paket,"
                + "         SUM(DECODE(NVL(e.disc_type,'9'),'2',b.voucher_amt,0)) gift,"
                + "         SUM(DECODE(NVL(e.disc_type,'9'),'3',b.voucher_amt,0)) reimbsemen,"
                + "         SUM(DECODE(NVL(e.disc_type,'9'),'4',b.voucher_amt,0)) promo,"
                + "         SUM(b.total+DECODE(NVL(e.disc_type,'9'),'1',b.voucher_amt,'2',b.voucher_amt,0)) total "
                + "FROM     zspa12it a, zspa13it b, zspa02mt c, ztot_psu d, zspa15it e, zgrmst f "
                + "WHERE    a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "         AND a.to_no = b.to_no(+)"
                + "         AND a.gr_cd = f.gr_cd(+)"
                + "         AND b.item_cd = c.item_cd(+)"
                + "         AND b.voucher_no= e.voucher_no(+)"
                + "         AND d.sw <= 2"
                + "         AND a.gr_cd LIKE '" + prm.GeraiCd + "%'"
                + "         AND b.item_cd LIKE '" + prm.ItemCd + "%'";
                if (prm.TypeCd == "1")
                {
                    sSql += "         AND c.type_cd = 1 ";
                }
                if (prm.TypeCd == "2")
                {
                    sSql += "         AND c.type_cd = 2 ";
                }
                sSql += "GROUP BY DECODE(d.sw,2,99999, a.gr_cd) "
                + "ORDER BY DECODE(d.sw,2,99999, a.gr_cd)";
            }

            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ListTransactioniByTreatmentResult>(dt);
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
        public JsonResult GetListTransactionPerTeraphis(ListTransactionPerTeraphisParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ListTransactionPerTeraphisResult> list = new List<ListTransactionPerTeraphisResult>();
            DBManager objdbmgr = new DBManager();

            if (prm.isDetail == "1")
            {
                sSql = "SELECT   MAX(c.sw) sw,"
                + "         MAX(DECODE(c.sw,4, '', d.gr_nm)) gr_nm,"
                + "         MAX(DECODE(c.sw,1, TRIM(TO_CHAR(TO_DATE(a.indate,'YYYYMMDD'),'DD-MM-YYYY')), '')) tgl,"
                + "         MAX(DECODE(c.sw,1, a.typeTrans, '')) Type_nm,"
                + "         MAX(DECODE(c.sw,1, b.emp_nm, 2, 'TOTAL '||b.emp_nm, 3, 'TOTAL '||d.gr_nm,'GRAND TOTAL')) rmp_nm,"
                + "         SUM(a.amt) to_amt,"
                + "         SUM(a.paket) paket,"
                + "         SUM(a.gift) gift,"
                + "         SUM(a.total) total,"
                + "         SUM(a.komisi) komisi "
                + "FROM     (   SELECT  a.indate,"
                + "                     1 grp,"
                + "                     'Transaksi' typeTrans,"
                + "                     a.to_no,"
                + "                     a.gr_cd,"
                + "                     a.emp_no,"
                + "                     SUM(b.total) amt,"
                + "                     SUM(DECODE(NVL(c.disc_type,'9'),'1',b.voucher_amt,0)) paket,"
                + "                     SUM(DECODE(NVL(c.disc_type,'9'),'2',b.voucher_amt,0)) gift,"
                + "                     SUM(b.total+DECODE(NVL(c.disc_type,'9'),'1',b.voucher_amt,'2',b.voucher_amt,0)) total,"
                + "                     MAX(a.komisi_amt) komisi"
                + "             FROM    zspa12it a, zspa13it b, zspa15it c"
                + "             WHERE   a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "                     AND a.to_no = b.to_no(+)"
                + "                     AND b.voucher_no = c.voucher_no(+)"
                + "                     AND a.emp_no LIKE '" + prm.EmpNo + "%'"
                + "                     AND a.gr_cd LIKE '" + prm.GeraiCd + "%'"
                + "             GROUP BY a.indate, a.to_no, a.emp_no"
                + "             UNION ALL"
                + "             SELECT  a.indate,"
                + "                     2 grp,"
                + "                     'Penjualan Prepaid' typeTrans,"
                + "                     a.disc_no to_no,"
                + "                     a.gr_cd,"
                + "                     a.emp_no,"
                + "                     SUM(a.amt) amt,"
                + "                     SUM(a.amt) paket,"
                + "                     0 gift,"
                + "                     SUM(a.amt) total,"
                + "                     MAX(a.komisi_amt) komisi"
                + "             FROM    zspa14it a"
                + "             WHERE   a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.sDate) + "'"
                + "                     AND a.disc_type IN ('1')"
                + "                     AND a.emp_no LIKE '" + prm.EmpNo + "%'"
                + "                     AND a.gr_cd LIKE '" + prm.GeraiCd + "%'"
                + "             GROUP BY a.indate, a.disc_no, a.emp_no"
                + "         ) a, zspa03mt b, ztot_psu c, zgrmst d "
                + "WHERE    a.emp_no = b.emp_no(+)"
                + "         AND a.gr_cd = d.gr_cd(+)"
                + "         AND c.sw <= 4"
                + "GROUP BY DECODE(c.sw,4,99999,a.gr_cd), DECODE(c.sw,1,,a.emp_no,2, a.emp_no, 'XXXXXX'), DECODE(c.sw,1,a.indate,'XXXXXXX'), DECODE(c.sw,1,a.grp,99), DECODE(c.sw,1,a.to_no,999999) "
                + "ORDER BY DECODE(c.sw,4,99999,a.gr_cd), DECODE(c.sw,1,,a.emp_no,2, a.emp_no, 'XXXXXX'), DECODE(c.sw,1,a.indate,'XXXXXXX'), DECODE(c.sw,1,a.grp,99), DECODE(c.sw,1,a.to_no,999999)";
            }
            else
            {
                sSql = "SELECT   MAX(c.sw) sw,"
                + "         MAX(DECODE(c.sw,2, '', d.gr_nm)) gr_nm,"
                + "         NULL tgl,"
                + "         NULL Type_nm,"
                + "         MAX(DECODE(c.sw,1, d.gr_nm,'GRAND TOTAL')) rmp_nm,"
                + "         SUM(a.amt) to_amt,"
                + "         SUM(a.paket) paket,"
                + "         SUM(a.gift) gift,"
                + "         SUM(a.total) total,"
                + "         SUM(a.komisi) komisi "
                + "FROM     (   SELECT  a.indate,"
                + "                     1 grp,"
                + "                     'Transaksi' typeTrans,"
                + "                     a.to_no,"
                + "                     a.gr_cd,"
                + "                     a.emp_no,"
                + "                     SUM(b.total) amt,"
                + "                     SUM(DECODE(NVL(c.disc_type,'9'),'1',b.voucher_amt,0)) paket,"
                + "                     SUM(DECODE(NVL(c.disc_type,'9'),'2',b.voucher_amt,0)) gift,"
                + "                     SUM(b.total+DECODE(NVL(c.disc_type,'9'),'1',b.voucher_amt,'2',b.voucher_amt,0)) total,"
                + "                     MAX(a.komisi_amt) komisi"
                + "             FROM    zspa12it a, zspa13it b, zspa15it c"
                + "             WHERE   a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "                     AND a.to_no = b.to_no(+)"
                + "                     AND b.voucher_no = c.voucher_no(+)"
                + "                     AND a.emp_no LIKE '" + prm.EmpNo + "%'"
                + "                     AND a.gr_cd LIKE '" + prm.GeraiCd + "%'"
                + "             GROUP BY a.indate, a.to_no, a.emp_no"
                + "             UNION ALL"
                + "             SELECT  a.indate,"
                + "                     2 grp,"
                + "                     'Penjualan Prepaid' typeTrans,"
                + "                     a.disc_no to_no,"
                + "                     a.gr_cd,"
                + "                     a.emp_no,"
                + "                     SUM(a.amt) amt,"
                + "                     SUM(a.amt) paket,"
                + "                     0 gift,"
                + "                     SUM(a.amt) total,"
                + "                     MAX(a.komisi_amt) komisi"
                + "             FROM    zspa14it a"
                + "             WHERE   a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.sDate) + "'"
                + "                     AND a.disc_type IN ('1')"
                + "                     AND a.emp_no LIKE '" + prm.EmpNo + "%'"
                + "                     AND a.gr_cd LIKE '" + prm.GeraiCd + "%'"
                + "             GROUP BY a.indate, a.disc_no, a.emp_no"
                + "         ) a, zspa03mt b, ztot_psu c, zgrmst d "
                + "WHERE    a.emp_no = b.emp_no(+)"
                + "         AND a.gr_cd = d.gr_cd(+)"
                + "         AND c.sw <= 2"
                + "GROUP BY DECODE(c.sw,2,99999,a.gr_cd) "
                + "ORDER BY DECODE(c.sw,2,99999,a.gr_cd)";
            }

            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ListTransactionPerTeraphisResult>(dt);
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

        public JsonResult GetListToptenTransaction(ListToptenTransactionParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ListToptenTransactionResult> list = new List<ListToptenTransactionResult>();
            DBManager objdbmgr = new DBManager();

            sSql = "SELECT  a.GrNm, a.nomer, a.ItemNm,a.qty, a.amt FROM ("
            + "               a.GrNm,"
            + "               a.gr_cd,"
            + "               a.ItemNm,"
            + "               a.qty,"
            + "               a.amt,";
            if (prm.basedOn == "1")
            {
                sSql += "       ROW_NUMBER() OVER(ORDER BY a.QTY DESC) AS Nomer ";
            }
            else
            {
                sSql += "       ROW_NUMBER() OVER(ORDER BY a.amt DESC) AS Nomer ";
            }
            sSql += "FROM   (   SELECT  MAX(c.item_nm) ItemNm,"
            + "                         MAX(d.gr_nm) GrNm,"
            + "                         a.gr_cd,"
            + "                         b.item_cd,"
            + "                         SUM(b.qty) qty,"
            + "                         SUM(b.total+DECODE(NVL(d.disc_type,'9'),'1',b.voucher_amt,'2',b.voucher_amt,0)) amt"
            + "                 FROM     zspa12it a, zspa13it b, zspa02mt c, zspa15it d,zgrmst e"
            + "                 WHERE    a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "01' AND '" + Utilities.formatDate(prm.eDate) + "31'"
            + "                         AND a.to_no = b.to_no(+)"
            + "                         AND a.gr_cd = e.gr_cd(+)"
            + "                         AND a.gr_cd LIKE '" + prm.GeraiCd + "%'"
            + "                         AND b.item_cd = c.item_cd(+)"
            + "                         AND b.voucher_no = d.voucher_no(+)";
            if (prm.TypeCd == "1")
            {
                sSql += "                   AND c.type_cd = 1'";
            }
            if (prm.TypeCd == "2")
            {
                sSql += "                   AND c.type_cd = 2'";
            }
            sSql += "           GROUP BY a.gr_cd, b.item_cd"
            + "               )"
            + "           ) a"
            + "           ) a "
            + " ORDER BY a.gr_cd, a.nomer DESC";

            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ListToptenTransactionResult>(dt);
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

        public JsonResult GetListToptenCustomer(ListToptenTransactionParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ListToptenTransactionResult> list = new List<ListToptenTransactionResult>();
            DBManager objdbmgr = new DBManager();

            sSql = "SELECT  a.GrNm, a.nomer, a.ItemNm,a.qty, a.amt FROM ("
            + "               a.GrNm,"
            + "               a.gr_cd,"
            + "               a.CusNm,"
            + "               a.qty,"
            + "               a.amt,";
            if (prm.basedOn == "1")
            {
                sSql += "       ROW_NUMBER() OVER(ORDER BY a.QTY DESC) AS Nomer ";
            }
            else
            {
                sSql += "       ROW_NUMBER() OVER(ORDER BY a.amt DESC) AS Nomer ";
            }
            sSql += "FROM   (   SELECT  MAX(c.item_nm) ItemNm,"
            + "                         MAX(d.gr_nm) GrNm,"
            + "                         a.gr_cd,"
            + "                         b.item_cd,"
            + "                         SUM(b.qty) qty,"
            + "                         SUM(b.total+DECODE(NVL(d.disc_type,'9'),'1',b.voucher_amt,'2',b.voucher_amt,0)) amt"
            + "                 FROM     zspa12it a, zspa13it b, zspa05mt c, zspa15it d,zgrmst e"
            + "                 WHERE    a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "01' AND '" + Utilities.formatDate(prm.eDate) + "31'"
            + "                         AND a.to_no = b.to_no(+)"
            + "                         AND a.gr_cd = e.gr_cd(+)"
            + "                         AND a.gr_cd LIKE '" + prm.GeraiCd + "%'"
            + "                         AND a.member_cd = c.cus_cd(+)"
            + "                         AND b.voucher_no = d.voucher_no(+)";
            if (prm.TypeCd == "1")
            {
                sSql += "                   AND c.type_cd = 1'";
            }
            if (prm.TypeCd == "2")
            {
                sSql += "                   AND c.type_cd = 2'";
            }
            sSql += "           GROUP BY a.gr_cd, b.item_cd"
            + "               )"
            + "           ) a"
            + "           ) a "
            + " ORDER BY a.gr_cd, a.nomer DESC";

            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ListToptenTransactionResult>(dt);
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

        public JsonResult GetListCashIn(ListCashInParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ListCashInResult> list = new List<ListCashInResult>();
            DBManager objdbmgr = new DBManager();

            sSql = "SELECT   max(d.sw) sw,"
            + "          MAX(DECODE(d.sw,3,'', e.gr_nm)) GrNm,"
            + "          MAX(DECODE(d.sw,3,'ZZZZZ',a.card_cd)) cardCd,"
            + "          MAX(DECODE(d.sw,1,DECODE(a.card_cd,'00','CASH',b.item_nm),2,'TOTAL '||e.gr_nm. 'GRAND TOTAL')) CardNm,"
            + "          SUM(DECODE(grp,1, a.amt,0)) transaksi,"
            + "          SUM(DECODE(grp,2, a.amt,0)) paket,"
            + "          SUM(a.amt) total"
            + " FROM     (   SELECT  1 grp,"
            + "                      gr_cd,"
            + "                      '00' card_cd,"
            + "                      SUM(byr_cash) amt"
            + "              FROM    spa12it"
            + "              WHERE   indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
            + "                      AND gr_cd LIKE '" + prm.GeraiCd + "%'"
            + "              UNION ALL"
            + "              SELECT 1 grp,"
            + "                      gr_cd,"
            + "                      NVL(card_cd,'XXXX') card_cd,"
            + "                      SUM(byr_kk) amt"
            + "              FROM    zspa12it"
            + "              WHERE   indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.sDate) + "'"
            + "                      AND gr_cd LIKE '" + prm.GeraiCd + "%'"
            + "              GROUP BY gr_cd, NVL(card_cd,'XXXX')"
            + "              UNION ALL"
            + "              SELECT  2 grp,"
            + "                      gr_cd,"
            + "                      '00' card_cd,"
            + "                      SUM(byr_cash) amt"
            + "              FROM    zspa14it"
            + "              WHERE   indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
            + "                      AND NVL(disc_type,0) IN (1,2)"
            + "                      AND gr_cd LIKE '" + prm.GeraiCd + "%'"
            + "              GROUP BY gr_cd, NVL(card_cd,'XXXX')"
            + "              UNION ALL"
            + "              SELECT  2 grp,"
            + "                      gr_cd,"
            + "                      NVL(card_cd,'XXXX') card_cd,"
            + "                      SUM(byr_kk) amt"
            + "              FROM    zspa14it"
            + "              WHERE   indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
            + "                      AND NVL(disc_type,0) IN (1,2)"
            + "                      AND gr_cd LIKE '" + prm.GeraiCd + "%'"
            + "              GROUP BY gr_cd, NVL(card_cd,'XXXX')"
            + "          ) a, zspa01mt b, ztot_psu d, zgrmst e"
            + " WHERE    d.sw <= 3 "
            + "          AND NVL(a.amt,0) <> 0"
            + "          AND a.card_cd = b.item_cd(+)"
            + "          AND a.gr_cd = e.gr_cd(+)"
            + "          AND b.grp_cd(+) = 'CREDIT CARD NAME'"
            + " GROUP BY DECODE(d.sw,3,99999,a.gr_cd), DECODE(d.sw,3,'ZZZZZZ',a.card_cd) "
            + " ORDER BY DECODE(d.sw,3,99999,a.gr_cd), DECODE(d.sw,3,'ZZZZZZ',a.card_cd)";

            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ListCashInResult>(dt);
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

        public JsonResult GetListCashInDetail(ListCashInDetailParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ListCashInDetailResult> list = new List<ListCashInDetailResult>();
            DBManager objdbmgr = new DBManager();

            sSql = "SELECT   * FROM ("
            + "  SELECT   'Transaksi' grpNm,"
            + "          a.to_no,"
            + "          a.indate,"
            + "          b.cus_nm,"
            + "          e.emp_nm,"
            + "          c.item_nm payNm,"
            + "          d.item_nm card_nm,"
            + "          a.card_no,"
            + "          a.tot_qty,"
            + "          a.tot_amt,"
            + "          a.tot_disc,"
            + "          a.voucher_tot,"
            + "          a.byr_cash,"
            + "          a.byr_kk,"
            + "          a.Total"
            + "  FROM     spa12it a, spa05mt b, spa01mt c, spa01mt d, spa03mt e"
            + "  WHERE    a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'";

            if (prm.CardCd != "ZZZZ")
            {
                if (prm.CardCd == "00")
                {
                    sSql += "         AND NVL(a.byr_cash,0) <> 0";
                }
                else
                {
                    sSql += "         AND NVL(a.byr_kk,0) <> 0"
                    + "          AND NVL(a.card_cd,'XXXX') = '" + prm.CardCd + "'";
                }
            }
            sSql += "         AND a.member_cd = b.cus_cd(+)"
            + "          AND a.pay_cd = c.item_cd(+)"
            + "          AND c.grp_cd(+) = 'PAYMENT TYPE'"
            + "          AND a.card_cd = d.item_cd(+)"
            + "          AND d.grp_cd(+) = 'CREDIT CARD NAME'"
            + "          AND a.emp_no = e.emp_no(+)"
            + "  UNION ALL"
            + "  SELECT   DECODE(a.disc_type,'1','Prepaid Paket','Gift Voucher') grpNm,"
            + "          a.disc_no to_no,"
            + "          a.indate,"
            + "          b.cus_nm,"
            + "          e.emp_nm,"
            + "          c.item_nm payNm,"
            + "          d.item_nm card_nm,"
            + "          a.card_no,"
            + "          a.qty,"
            + "          a.amt,"
            + "          0 tot_disc,"
            + "          0 voucher_tot,"
            + "          a.byr_cash,"
            + "          a.byr_kk,"
            + "          a.amt"
            + "  FROM     spa14it a, spa05mt b, spa01mt c, spa01mt d, spa03mt e"
            + "  WHERE    a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
            + "          AND a.cus_cd = b.cus_cd(+)"
            + "          AND a.pay_cd = c.item_cd(+)"
            + "          AND c.grp_cd(+) = 'PAYMENT TYPE'"
            + "          AND a.card_cd = d.item_cd(+)"
            + "          AND d.grp_cd(+) = 'CREDIT CARD NAME'"
            + "          AND a.emp_no = e.emp_no(+)"
            + "          AND a.disc_type IN ('1','2')";
            if (prm.CardCd != "ZZZZ")
            {
                if (prm.CardCd == "00")
                {
                    sSql += "         AND NVL(a.byr_cash,0) <> 0";
                }
                else
                {
                    sSql += "         AND NVL(a.byr_kk,0) <> 0"
                    + "          AND NVL(a.card_cd,'XXXX') = '" + prm.CardCd + "'";
                }
            }
            sSql += "  ) ORDER BY indate, cus_nm";


            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ListCashInDetailResult>(dt);
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

        public JsonResult GetListPackageMember(ListPackageMemberParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ListPackageMemberResult> list = new List<ListPackageMemberResult>();
            DBManager objdbmgr = new DBManager();

            if (prm.isDetail == "1")
            {
                sSql = " SELECT   1 sw,"
                + "          g.gr_nm,"
                + "          a.indate,"
                + "          a.cus_cd,"
                + "          c.cus_nm,"
                + "          DECODE(a.disc_type,5,'Moving Paket',f.item_nm) PaketNm,"
                + "          e.item_nm,"
                + "          NVL(b.qty,0) qty,"
                + "          NVL(b.sisa,0) sisa,"
                + "          b.amt,"
                + "          a.end_dt,"
                + "          d.emp_nm,"
                + "          a.komisi_prosen,"
                + "          a.komisi_amt,"
                + "          a.disc_no,"
                + "          b.item_cd,"
                + "          NVL(a.byr_cash,0) PayCash,"
                + "          NVL(a.byr_kk,0) Paydb,"
                + " FROM     zSPA14IT a, zspa05mt c, zspa03mt d, zspa02mt e, zspa01mt f, zgrmst g,"
                + "          (   SELECT  a.disc_no,"
                + "                      b.item_cd,"
                + "                      a.gr_cd,"
                + "                      COUNT(b.item_cd) qty,"
                + "                      SUM(DECODE(NVL(b.to_no,0),0,1,0)) sisa,"
                + "                      MAX(b.amt) up,"
                + "                      SUM(b.amt) amt"
                + "              FROM    zspa14it a, zspa15it b"
                + "              WHERE   a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "                      AND a.disc_type IN (1,5)"
                + "                      AND a.disc_no = b.disc_no(+)";
                if (prm.PrepaidNo != "")
                {
                    sSql += "                      AND NVL(a.disc_no,'0') = '" + prm.PrepaidNo + "'";
                }
                sSql += "                      AND NVL(a.emp_no,'X') LIKE '" + prm.EmpNo + "'"
                + "                      AND NVL(a.item_cd,'X') LIKE '" + prm.ItemCd + "%'"
                + "              GROUP BY a.gr_cd, a.disc_no, b.item_cd"
                + "          ) b"
                + " WHERE    a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "          AND a.disc_type IN (1,5)"
                + "          AND a.disc_no = b.disc_no(+)"
                + "          AND a.cus_cd = c.cus_cd(+)"
                + "          AND a.emp_no = d.emp_no(+)"
                + "          AND b.item_cd = e.item_cd(+)"
                + "          AND a.paket_nm = f.item_cd(+)"
                + "          AND a.gr_cd = g.gr_cd(+)"
                + "          AND f.grp_cd(+) = 'PREPAID PAKET NAME'"
                + "          AND a.cus_cd LIKE '" + prm.CusCd + "%'"
                + "          AND a.gr_cd LIKE '" + prm.GeraiCd + "%'";
                if (prm.PrepaidNo != "")
                {
                    sSql += "                      AND NVL(a.disc_no,'0') = '" + prm.PrepaidNo + "'";
                }
                sSql += "                      AND NVL(a.emp_no,'X') LIKE '" + prm.EmpNo + "'";
                if (prm.StatusCd == "1")
                {
                    sSql += "          AND NVL(b.sisa,0) > 0";
                }
                if (prm.StatusCd == "2")
                {
                    sSql += "          AND NVL(b.sisa,0) <= 0";
                }
                sSql += " ORDER BY a.gr_cd, a.indate, a.disc_no";
            }
            else
            {
                sSql = " SELECT   MAX(h.sw) sw,"
                + "          MAX(DECODE(h.sw,3,'',g.gr_nm)) grNm,"
                + "          NULL indate,"
                + "          NULL a.cus_cd,"
                + "          MAX(DECODE(h.sw,1,c.cus_nm, 2, 'TOTAL '||g.gr_nm, 'GRAND TOTAL')) cusNm,"
                + "          NULL PaketNm,"
                + "          NULL item_nm,"
                + "          SUM(NVL(b.qty,0)) qty,"
                + "          SUM(NVL(b.sisa,0)) sisa,"
                + "          SUM(b.amt) amt,"
                + "          NULL end_dt,"
                + "          NULL emp_nm,"
                + "          NULL komisi_prosen,"
                + "          SUM(a.komisi_amt) komisi_amt,"
                + "          NULL disc_no,"
                + "          NULL item_cd,"
                + "          SUM(NVL(a.byr_cash,0)) PayCash,"
                + "          SUM(NVL(a.byr_kk,0)) Paydb,"
                + " FROM     zSPA14IT a, zspa05mt c, zspa03mt d, zspa02mt e, zspa01mt f, zgrmst g, ztot_psu h"
                + "          (   SELECT  a.disc_no,"
                + "                      b.item_cd,"
                + "                      a.gr_cd,"
                + "                      COUNT(b.item_cd) qty,"
                + "                      SUM(DECODE(NVL(b.to_no,0),0,1,0)) sisa,"
                + "                      MAX(b.amt) up,"
                + "                      SUM(b.amt) amt"
                + "              FROM    zspa14it a, zspa15it b"
                + "              WHERE   a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "                      AND a.disc_type IN (1,5)"
                + "                      AND a.disc_no = b.disc_no(+)";
                if (prm.PrepaidNo != "")
                {
                    sSql += "                      AND NVL(a.disc_no,'0') = '" + prm.PrepaidNo + "'";
                }
                sSql += "                      AND NVL(a.emp_no,'X') LIKE '" + prm.EmpNo + "'"
                + "                      AND NVL(a.item_cd,'X') LIKE '" + prm.ItemCd + "%'"
                + "              GROUP BY a.gr_cd, a.disc_no, b.item_cd"
                + "          ) b"
                + " WHERE    a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "          AND a.disc_type IN (1,5)"
                + "          AND h.sw <= 3"
                + "          AND a.disc_no = b.disc_no(+)"
                + "          AND a.cus_cd = c.cus_cd(+)"
                + "          AND a.emp_no = d.emp_no(+)"
                + "          AND b.item_cd = e.item_cd(+)"
                + "          AND a.paket_nm = f.item_cd(+)"
                + "          AND a.gr_cd = g.gr_cd(+)"
                + "          AND f.grp_cd(+) = 'PREPAID PAKET NAME'"
                + "          AND a.cus_cd LIKE '" + prm.CusCd + "%'"
                + "          AND a.gr_cd LIKE '" + prm.GeraiCd + "%'";
                if (prm.PrepaidNo != "")
                {
                    sSql += "                      AND NVL(a.disc_no,'0') = '" + prm.PrepaidNo + "'";
                }
                sSql += "                      AND NVL(a.emp_no,'X') LIKE '" + prm.EmpNo + "'";
                if (prm.StatusCd == "1")
                {
                    sSql += "          AND NVL(b.sisa,0) > 0";
                }
                if (prm.StatusCd == "2")
                {
                    sSql += "          AND NVL(b.sisa,0) <= 0";
                }
                sSql += " GROUP BY DECODE(h.sw,3,a.gr_cd,'99999'),DECODE(h.sw,1,a.cus_cd,'9999999')"
                + " GROUP BY DECODE(h.sw,3,a.gr_cd,'99999'),DECODE(h.sw,1,a.cus_cd,'9999999')";
            }

            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ListPackageMemberResult>(dt);
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

        public JsonResult GetListCommisionTeraphis(ListCommisionTeraphisParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ListCommisionTeraphisResult> list = new List<ListCommisionTeraphisResult>();
            DBManager objdbmgr = new DBManager();

            if (prm.isDetail == "1")
            {
                sSql = " SELECT   MAX(h.sw) sw,"
                + "          MAX(DECODE(h.sw,5,'',j.gr_nm)) GrNm,"
                + "          MAX(DECODE(h.sw,1,e.emp_nm,2,'TOTAL Inv No '||a.to_no,3,'TOTAL '||e.emp_nm,4, 'TOTAL '||j.gr_nm,'GRAND TOTAL')) empnm,"
                + "          MAX(DECODE(h.sw,1,a.to_no,2,a.to_no,'')) tono,"
                + "          MAX(DECODE(h.sw,1,TRIM(TO_CHAR(TO_DATE(a.indate,'YYYYMMDD'),'DD-MM-YYYY')),'')) tgl,"
                + "          MAX(DECODE(h.sw,1,f.cus_nm,'')) cust_nm,"
                + "          MAX(DECODE(h.sw,1,a.item_nm,'')) itemNm,"
                + "          SUM(a.amt) amt,"
                + "          SUM(a.voucher_amt) voucher_amt,"
                + "          SUM(a.disc_amt) disc_amt,"
                + "          SUM(a.basic_komisi) basic_komisi,"
                + "          SUM(a.komisi_amt) komisi_amt,"
                + "          SUM(a.komisi_add) komisi_add,"
                + "          SUM(a.komisi_min) komisi_min,"
                + "          SUM(a.komisi_amt + a.komisi_add - a.komisi_min) komisi_tot,"
                + "          MAX(DECODE(h.sw,1,a.voucher_no,'')) voucherNo,"
                + "          MAX(DECODE(h.sw,1,a.emp_to,'')) emp_to,"
                + "          MAX(DECODE(h.sw,1,a.item_to,'')) item_to,"
                + "          MAX(DECODE(h.sw,1,a.komisi_status,'')) komisi_status,"
                + "          MAX(DECODE(h.sw,1,a.komisi_prosen,'')) komisi_prosen"
                + " FROM     (   SELECT  a.to_no,"
                + "                     a.gr_cd,"
                + "                     NVL(c.type_cd,1) type_cd,"
                + "                     a.indate,"
                + "                     c.item_nm,"
                + "                     NVL(b.qty,0) qty,"
                + "                     NVL(b.up,0) up,"
                + "                     NVL(b.amt,0) amt,"
                + "                     NVL(b.voucher_amt,0) voucher_amt,"
                + "                     NVL(b.disc_amt,0) disc_amt,"
                + "                     b.basic_komisi,"
                + "                     DECODE(NVL(b.komisi_status,1),2,0,3,0,4,0,5,0,NVL(b.komisi_amt,0)) komisi_amt,"
                + "                     DECODE(NVL(b.komisi_status,1),2,NVL(b.komisi_amt,0),3,NVL(b.komisi_amt,0),4,NVL(b.komisi_amt,0),5,NVL(b.komisi_amt,0),0) komisi_add,"
                + "                     0 komisi_min,"
                + "                     b.voucher_no,"
                + "                     a.emp_no,"
                + "                     b.item_cd,"
                + "                     b.seq_no,"
                + "                     a.komisi komisi_prosen,"
                + "                     DECODE(NVL(b.komisi_status,1) , 3,'Redeem From '||d.emp_nm,"
                + "                                                     5,'Moving From '||d.emp_nm,"
                + "                                                     NULL"
                + "                     ) Emp_to,"
                + "                     DECODE(NVL(b.komisi_status,1) , 3,'From '||c.item_nm,"
                + "                                                     5,'From '||g.item_nm,"
                + "                                                     NULL"
                + "                     ) Item_to,"
                + "                     a.member_cd cus_cd,"
                + "                     b.komisi_status"
                + "             FROM    zspa12it a, zspa13it b, zspa02mt c, zspa03mt d, zspa15it e, zspa15it f, zspa02mt g"
                + "             WHERE   a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "                     AND a.emp_no <> '1001'"
                + "                     AND a.emp_no LIKE '" + prm.EmpNo + "'"
                + "                     AND a.to_no = b.to_no(+)"
                + "                     AND b.item_cd = c.item_cd(+)"
                + "                     AND b.old_komisi_emp = d.emp_no(+)"
                + "                     AND b.voucher_no = e.voucher_no(+)"
                + "                     AND e.old_voucher = f.voucher_no(+)"
                + "                     AND f.item_cd = g.item_cd(+)"
                + "             UNION ALL"
                + "             SELECT  a.to_no,"
                + "                     a.gr_cd,"
                + "                     NVL(c.type_cd,1) type_cd,"
                + "                     a.indate,"
                + "                     c.item_nm,"
                + "                     0 qty,"
                + "                     0 up,"
                + "                     0 amt,"
                + "                     0 voucher_amt,"
                + "                     0 disc_amt,"
                + "                     0 basic_komisi,"
                + "                     0 komisi_amt,"
                + "                     0 komisi_add,"
                + "                     b.old_komisi_amt komisi_min,"
                + "                     b.voucher_no,"
                + "                     b.old_komisi_emp emp_no,"
                + "                     DECODE(b.komisi_status,3, b.item_cd, f.item_cd) item_cd,"
                + "                     b.seq_no,"
                + "                     d.komisi komisi_prosen,"
                + "                     DECODE(NVL(b.komisi_status,1) , 3,'Redeem To '||d.emp_nm,"
                + "                                                     5,'Moving To '||d.emp_nm,"
                + "                                                     NULL"
                + "                     ) Emp_to,"
                + "                     DECODE(NVL(b.komisi_status,1) , 3,'Redeem To '||c.item_nm,"
                + "                                                     5,'Moving To '||g.item_nm,"
                + "                                                     NULL"
                + "                     ) Item_to,"
                + "                     a.member_cd cus_cd,"
                + "                     b.komisi_status"
                + "             FROM    zspa12it a, zspa13it b, zspa02mt c, zspa03mt d, zspa15it e, zspa15it f, zspa02mt g"
                + "             WHERE   a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "                     AND NVL(b.old_komisi_emp,'X') <> '1001'"
                + "                     AND a.emp_no LIKE '" + prm.EmpNo + "'"
                + "                     AND b.komisi_status IN (3,5)"
                + "                     AND a.to_no = b.to_no(+)"
                + "                     AND b.item_cd = c.item_cd(+)"
                + "                     AND a.emp_no = d.emp_no(+)"
                + "                     AND b.voucher_no = e.voucher_no(+)"
                + "                     AND e.old_voucher = f.voucher_no(+)"
                + "                     AND f.item_cd = g.item_cd(+)"
                + "             UNION ALL"
                + "             SELECT  99999+a.disc_no to_no,"
                + "                     a.gr_cd,"
                + "                     1 type_cd,"
                + "                     a.indate,"
                + "                     b.item_nm paketNm,"
                + "                     NVL(a.qty,0) qty,"
                + "                     NVL(a.up,0) up,"
                + "                     NVL(a.amt,0) amt,"
                + "                     0 voucher_amt,"
                + "                     0 disc_amt,"
                + "                     NVL(a.amt,0) basic_amt,"
                + "                     NVL(a.komisi_amt,0) komisi_amt,"
                + "                     0 komisi_add,"
                + "                     0 komisi_min,"
                + "                     NULL voucher_no,"
                + "                     a.emp_no,"
                + "                     'A999999' item_cd,"
                + "                     0 seq_no,"
                + "                     a.komisi_prosen,"
                + "                     NULL emp_to,"
                + "                     NULL item_to,"
                + "                     a.cus_cd,"
                + "                     0 komisi_status"
                + "             FROM    zspa14it a, zspa01mt b"
                + "             WHERE   a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "                     AND a.emp_no <> '1001'"
                + "                     AND a.emp_no LIKE '" + prm.EmpNo + "'"
                + "                     AND a.paket_nm = b.item_cd(+)"
                + "                     AND a.disc_type IN ('1')"
                + "                     AND b.grp_cd(+) = 'PREPAID PAKET NAME'"
                + "          ) a, zspa03mt e, zspa05mt f, ztot_psu h, zgrmst j"
                + " WHERE    a.emp_no = e.emp_no(+)"
                + "          AND a.cus_cd = f.cus_cd(+)"
                + "          AND a.gr_cd LIKE '" + prm.GeraiCd + "%'"
                + "          AND a.gr_cd = j.gr_cd(+)"
                + "          AND h.sw <= 5"
                + " GROUP BY DECODE(h.sw,5,'9999999',a.gr_cd), DECODE(h.sw,5,'9999999',a.emp_no), DECODE(h.sw,1,a.to_no,2,a.to_no,999999999), DECODE(h.sw,1,a.seq_no,999999999), DECODE(h.sw,1,a.item_cd,'XXXXXXXX')"
                + " ORDER BY DECODE(h.sw,5,'9999999',a.gr_cd), DECODE(h.sw,5,'9999999',a.emp_no), DECODE(h.sw,1,a.to_no,2,a.to_no,999999999), DECODE(h.sw,1,a.seq_no,999999999), DECODE(h.sw,1,a.item_cd,'XXXXXXXX')";

            }
            else
            {
                sSql = " SELECT   MAX(h.sw) sw,"
                + "          MAX(DECODE(h.sw,3,'',j.gr_nm)) GrNm,"
                + "          MAX(DECODE(h.sw,1,e.emp_nm, 2,'TOTAL '||j.gr_nm,'GRAND TOTAL')) empnm,"
                + "          NULL  tono,"
                + "          NULL  tgl,"
                + "          NULL  cust_nm,"
                + "          NULL  itemNm,"
                + "          SUM(a.amt) amt,"
                + "          SUM(a.voucher_amt) voucher_amt,"
                + "          SUM(a.disc_amt) disc_amt,"
                + "          SUM(a.basic_komisi) basic_komisi,"
                + "          SUM(a.komisi_amt) komisi_amt,"
                + "          SUM(a.komisi_add) komisi_add,"
                + "          SUM(a.komisi_min) komisi_min,"
                + "          SUM(a.komisi_amt + a.komisi_add - a.komisi_min) komisi_tot,"
                + "          NULL  voucherNo,"
                + "          NULL  emp_to,"
                + "          NULL  item_to,"
                + "          NULL  komisi_status,"
                + "          NULL  komisi_prosen"
                + " FROM     (   SELECT  a.to_no,"
                + "                     a.gr_cd,"
                + "                     NVL(c.type_cd,1) type_cd,"
                + "                     a.indate,"
                + "                     c.item_nm,"
                + "                     NVL(b.qty,0) qty,"
                + "                     NVL(b.up,0) up,"
                + "                     NVL(b.amt,0) amt,"
                + "                     NVL(b.voucher_amt,0) voucher_amt,"
                + "                     NVL(b.disc_amt,0) disc_amt,"
                + "                     b.basic_komisi,"
                + "                     DECODE(NVL(b.komisi_status,1),2,0,3,0,4,0,5,0,NVL(b.komisi_amt,0)) komisi_amt,"
                + "                     DECODE(NVL(b.komisi_status,1),2,NVL(b.komisi_amt,0),3,NVL(b.komisi_amt,0),4,NVL(b.komisi_amt,0),5,NVL(b.komisi_amt,0),0) komisi_add,"
                + "                     0 komisi_min,"
                + "                     b.voucher_no,"
                + "                     a.emp_no,"
                + "                     b.item_cd,"
                + "                     b.seq_no,"
                + "                     a.komisi komisi_prosen,"
                + "                     DECODE(NVL(b.komisi_status,1) , 3,'Redeem From '||d.emp_nm,"
                + "                                                     5,'Moving From '||d.emp_nm,"
                + "                                                     NULL"
                + "                     ) Emp_to,"
                + "                     DECODE(NVL(b.komisi_status,1) , 3,'From '||c.item_nm,"
                + "                                                     5,'From '||g.item_nm,"
                + "                                                     NULL"
                + "                     ) Item_to,"
                + "                     a.member_cd cus_cd,"
                + "                     b.komisi_status"
                + "             FROM    zspa12it a, zspa13it b, zspa02mt c, zspa03mt d, zspa15it e, zspa15it f, zspa02mt g"
                + "             WHERE   a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "                     AND a.emp_no <> '1001'"
                + "                     AND a.emp_no LIKE '" + prm.EmpNo + "'"
                + "                     AND a.to_no = b.to_no(+)"
                + "                     AND b.item_cd = c.item_cd(+)"
                + "                     AND b.old_komisi_emp = d.emp_no(+)"
                + "                     AND b.voucher_no = e.voucher_no(+)"
                + "                     AND e.old_voucher = f.voucher_no(+)"
                + "                     AND f.item_cd = g.item_cd(+)"
                + "             UNION ALL"
                + "             SELECT  a.to_no,"
                + "                     a.gr_cd,"
                + "                     NVL(c.type_cd,1) type_cd,"
                + "                     a.indate,"
                + "                     c.item_nm,"
                + "                     0 qty,"
                + "                     0 up,"
                + "                     0 amt,"
                + "                     0 voucher_amt,"
                + "                     0 disc_amt,"
                + "                     0 basic_komisi,"
                + "                     0 komisi_amt,"
                + "                     0 komisi_add,"
                + "                     b.old_komisi_amt komisi_min,"
                + "                     b.voucher_no,"
                + "                     b.old_komisi_emp emp_no,"
                + "                     DECODE(b.komisi_status,3, b.item_cd, f.item_cd) item_cd,"
                + "                     b.seq_no,"
                + "                     d.komisi komisi_prosen,"
                + "                     DECODE(NVL(b.komisi_status,1) , 3,'Redeem To '||d.emp_nm,"
                + "                                                     5,'Moving To '||d.emp_nm,"
                + "                                                     NULL"
                + "                     ) Emp_to,"
                + "                     DECODE(NVL(b.komisi_status,1) , 3,'Redeem To '||c.item_nm,"
                + "                                                     5,'Moving To '||g.item_nm,"
                + "                                                     NULL"
                + "                     ) Item_to,"
                + "                     a.member_cd cus_cd,"
                + "                     b.komisi_status"
                + "             FROM    zspa12it a, zspa13it b, zspa02mt c, zspa03mt d, zspa15it e, zspa15it f, zspa02mt g"
                + "             WHERE   a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "                     AND NVL(b.old_komisi_emp,'X') <> '1001'"
                + "                     AND a.emp_no LIKE '" + prm.EmpNo + "'"
                + "                     AND b.komisi_status IN (3,5)"
                + "                     AND a.to_no = b.to_no(+)"
                + "                     AND b.item_cd = c.item_cd(+)"
                + "                     AND a.emp_no = d.emp_no(+)"
                + "                     AND b.voucher_no = e.voucher_no(+)"
                + "                     AND e.old_voucher = f.voucher_no(+)"
                + "                     AND f.item_cd = g.item_cd(+)"
                + "             UNION ALL"
                + "             SELECT  99999+a.disc_no to_no,"
                + "                     a.gr_cd,"
                + "                     1 type_cd,"
                + "                     a.indate,"
                + "                     b.item_nm paketNm,"
                + "                     NVL(a.qty,0) qty,"
                + "                     NVL(a.up,0) up,"
                + "                     NVL(a.amt,0) amt,"
                + "                     0 voucher_amt,"
                + "                     0 disc_amt,"
                + "                     NVL(a.amt,0) basic_amt,"
                + "                     NVL(a.komisi_amt,0) komisi_amt,"
                + "                     0 komisi_add,"
                + "                     0 komisi_min,"
                + "                     NULL voucher_no,"
                + "                     a.emp_no,"
                + "                     'A999999' item_cd,"
                + "                     0 seq_no,"
                + "                     a.komisi_prosen,"
                + "                     NULL emp_to,"
                + "                     NULL item_to,"
                + "                     a.cus_cd,"
                + "                     0 komisi_status"
                + "             FROM    zspa14it a, zspa01mt b"
                + "             WHERE   a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "                     AND a.emp_no <> '1001'"
                + "                     AND a.emp_no LIKE '" + prm.EmpNo + "'"
                + "                     AND a.paket_nm = b.item_cd(+)"
                + "                     AND a.disc_type IN ('1')"
                + "                     AND b.grp_cd(+) = 'PREPAID PAKET NAME'"
                + "          ) a, zspa03mt e, zspa05mt f, ztot_psu h, zgrmst j"
                + " WHERE    a.emp_no = e.emp_no(+)"
                + "          AND a.cus_cd = f.cus_cd(+)"
                + "          AND a.gr_cd LIKE '" + prm.GeraiCd + "%'"
                + "          AND a.gr_cd = j.gr_cd(+)"
                + "          AND h.sw <= 3"
                + " GROUP BY DECODE(h.sw,3,'9999999',a.gr_cd), DECODE(h.sw,1,a.emp_no,'999999999')"
                + " ORDER BY DECODE(h.sw,3,'9999999',a.gr_cd), DECODE(h.sw,1,a.emp_no,'999999999')";
            }

            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ListCommisionTeraphisResult>(dt);
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

        public JsonResult GetListStatusVoucherPackageMember(ListStatusVoucherPackageMemberParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ListStatusVoucherPackageMemberResult> list = new List<ListStatusVoucherPackageMemberResult>();
            DBManager objdbmgr = new DBManager();

            sSql = " SELECT   h.gr_nm,"
            + "          a.indate,"
            + "          e.item_nm typeNm,"
            + "          b.cus_nm,"
            + "          d.item_nm,"
            + "          NVL(f.tot_cnt,0) qty,"
            + "          NVL(f.cnt,0) qty_use,"
            + "          NVL(f.tot_cnt,0) - NVL(f.cnt,0) sisa,"
            + "          a.up,"
            + "          a.amt,"
            + "          a.indate start_dt,"
            + "          a.end_dt,"
            + "          c.emp_nm,"
            + "          a.komisi_prosen,"
            + "          a.komisi_amt,"
            + "          a.disc_no,"
            + "          f.item_cd"
            + " FROM     zSPA14IT a, zspa05mt b, zspa03mt c, ( SELECT * FROM zspa02mt WHERE type_cd = 1) d, zspa01mt e, zgrmst g"
            + "          (   SELECT  a.disc_no,"
            + "                      b.item_cd,"
            + "                      COUNT(*) tot_cnt,"
            + "                      NVL(SUM(DECODE(NVL(b.to_no,0),0,0,1)),0) cnt"
            + "              FROM   z SPA14IT a, zspa15it b"
            + "              WHERE   a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
            + "                      AND a.disc_no = b.disc_no(+)"
            + "                      AND a.disc_type IN (1,5)"
            + "              GROUP BY a.disc_no, b.item_cd"
            + "          ) f"
            + " WHERE    a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
            + "          AND a.disc_type IN (1,5)"
            + "          AND a.gr_cd = h.gr_cd(+)"
            + "          AND a.gr_cd LIKE '" + prm.GeraiCd + "%'"
            + "          AND a.cus_cd = b.cus_cd(+)"
            + "          AND a.emp_no = c.emp_no(+)"
            + "          AND a.disc_no = f.disc_no(+)"
            + "          AND a.disc_type = e.item_cd(+)"
            + "          AND f.item_cd = d.item_cd(+)"
            + "          AND e.grp_cd(+) = 'VOUCHER TYPE'"
            + "          AND a.cus_cd LIKE '" + prm.CusCd + "%'"
            + "          AND NVL(a.item_cd,'X') LIKE '" + prm.ItemCd + "%'";
            if (prm.NotUsed == "1")
            {
                sSql += "          AND NVL(f.tot_cnt,0) - NVL(f.cnt,0) > 0";
            }
            sSql += " ORDER BY a.indate, a.disc_no";

            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ListStatusVoucherPackageMemberResult>(dt);
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

        public JsonResult GetListTransactionBaseOnTreatmentType(ListTransactionBaseOnTreatmentTypeParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ListTransactionBaseOnTreatmentTypeResult> list = new List<ListTransactionBaseOnTreatmentTypeResult>();
            DBManager objdbmgr = new DBManager();

            if (prm.isDetail == "1")
            {
                sSql = " SELECT   MAX(c.sw) sw,"
                + "          MAX(DECODE(c.sw,3,'', d.grNm)) GrNm,"
                + "          MAX(DECODE(c.sw,1,b.item_nm,2,'TOTAL '||d.gr_nm, 'GRAND TOTAL')) itemNm,"
                + "          SUM(DECODE(grp,1,qty,0)) qty1,"
                + "          SUM(DECODE(grp,1,amt,0)) amt1,"
                + "          SUM(DECODE(grp,2,qty,0)) qty2,"
                + "          SUM(DECODE(grp,2,amt,0)) amt2,"
                + "          SUM(DECODE(grp,3,qty,0)) qty3,"
                + "          SUM(DECODE(grp,3,amt,0)) amt3,"
                + "          SUM(qty) qty,"
                + "          SUM(amt) amt"
                + " FROM     (   SELECT  c.visit_grp,"
                + "                      1 grp,"
                + "                      a.gr_cd,"
                + "                      b.item_cd,"
                + "                      b.qty,"
                + "                      b.amt"
                + "              FROM    zspa12it a, zspa13it b, zspa02mt c, zspa15it d"
                + "              WHERE   a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "                      AND a.to_no = b.to_no(+)"
                + "                      AND b.item_cd = c.item_cd(+)"
                + "                      AND NVL(b.voucher_no,'X') = d.voucher_no(+)"
                + "                      AND NVL(d.disc_type,0) NOT IN (1,2)"
                + "              UNION ALL"
                + "              SELECT  b.visit_grp,"
                + "                      DECODE(NVL(a.disc_type,0),1,2,3) grp,"
                + "                      c.gr_cd,"
                + "                      a.item_cd,"
                + "                      1 qty,"
                + "                      a.amt"
                + "              FROM    zspa15it a, zspa02mt b, zspa4it c"
                + "              WHERE   NVL(a.disc_type,0) IN (1,2)"
                + "                      AND a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "                      AND a.item_cd = b.item_cd(+)"
                + "                      AND a.disc_no = c.disc_no(+)"
                + "          ) a, zspa01mt b, ztot_psu c, zgrmst d"
                + " WHERE    a.visit_grp = b.item_cd(+)"
                + "          AND b.grp_cd(+) = 'ITEM GROUP BY CUSTOMER GROUP'"
                + "          AND a.gr_cd = d.gr_cd(+)"
                + "          AND a.gr_cd LIKE '" + prm.GeraiCd + "%'"
                + "          AND c.sw <= 3"
                + " GROUP BY DECODE(c.sw,3,'999999', a.gr_cd), DECODE(c.sw,1,a.visit_grp,'99999')"
                + " ORDER BY DECODE(c.sw,3,'999999', a.gr_cd), DECODE(c.sw,1,a.visit_grp,'99999')";
            }
            else
            {
                sSql = " SELECT   MAX(c.sw) sw,"
                + "          MAX(DECODE(c.sw,2,'GRAND TOTAL', d.grNm)) GrNm,"
                + "          NULL itemNm,"
                + "          SUM(DECODE(grp,1,qty,0)) qty1,"
                + "          SUM(DECODE(grp,1,amt,0)) amt1,"
                + "          SUM(DECODE(grp,2,qty,0)) qty2,"
                + "          SUM(DECODE(grp,2,amt,0)) amt2,"
                + "          SUM(DECODE(grp,3,qty,0)) qty3,"
                + "          SUM(DECODE(grp,3,amt,0)) amt3,"
                + "          SUM(qty) qty,"
                + "          SUM(amt) amt"
                + " FROM     (   SELECT  c.visit_grp,"
                + "                      1 grp,"
                + "                      a.gr_cd,"
                + "                      b.item_cd,"
                + "                      b.qty,"
                + "                      b.amt"
                + "              FROM    zspa12it a, zspa13it b, zspa02mt c, zspa15it d"
                + "              WHERE   a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "                      AND a.to_no = b.to_no(+)"
                + "                      AND b.item_cd = c.item_cd(+)"
                + "                      AND NVL(b.voucher_no,'X') = d.voucher_no(+)"
                + "                      AND NVL(d.disc_type,0) NOT IN (1,2)"
                + "              UNION ALL"
                + "              SELECT  b.visit_grp,"
                + "                      DECODE(NVL(a.disc_type,0),1,2,3) grp,"
                + "                      c.gr_cd,"
                + "                      a.item_cd,"
                + "                      1 qty,"
                + "                      a.amt"
                + "              FROM    zspa15it a, zspa02mt b, zspa4it c"
                + "              WHERE   NVL(a.disc_type,0) IN (1,2)"
                + "                      AND a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "                      AND a.item_cd = b.item_cd(+)"
                + "                      AND a.disc_no = c.disc_no(+)"
                + "          ) a, zspa01mt b, ztot_psu c, zgrmst d"
                + " WHERE    a.visit_grp = b.item_cd(+)"
                + "          AND b.grp_cd(+) = 'ITEM GROUP BY CUSTOMER GROUP'"
                + "          AND a.gr_cd = d.gr_cd(+)"
                + "          AND a.gr_cd LIKE '" + prm.GeraiCd + "%'"
                + "          AND c.sw <= 2"
                + " GROUP BY DECODE(c.sw,2,'999999', a.gr_cd)"
                + " ORDER BY DECODE(c.sw,2,'999999', a.gr_cd)";
            }
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ListTransactionBaseOnTreatmentTypeResult>(dt);
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

        public JsonResult GetListTransactionByCustomerNewOld(ListTransactionByCustomerNewOldParam prm)
        {
            string _status = "success";
            string sSql = string.Empty;
            string errMsg = string.Empty;
            List<ListTransactionByCustomerNewOldResult> list = new List<ListTransactionByCustomerNewOldResult>();
            DBManager objdbmgr = new DBManager();

            if (prm.isDetail == "1")
            {
                sSql = " SELECT   MAX(d.sw) sw,"
                + "          MAX(DECODE(d.sw,3, '', f.gr_nm)) GrNm,"
                + "          MAX(DECODE(d.sw,1, c.item_nm, 2, 'TOTAL '||f.gr_nm, 'GRAND TOTAL')) ItemNm,"
                + "          SUM(b.qty) qty,"
                + "          SUM(b.total) amt,"
                + "          SUM(DECODE(NVL(e.cnt,2),1,b.qty,0)) newQty,"
                + "          SUM(DECODE(NVL(e.cnt,2),1,b.amt,0)) newAmt,"
                + "          SUM(DECODE(NVL(e.cnt,2),2,b.qty,0)) OldQty,"
                + "          SUM(DECODE(NVL(e.cnt,2),2,b.amt,0)) OldAmt"
                + " FROM     zspa12it a, zspa13it b, zspa02mt c, ztot_psu d, zgrmst f,"
                + "          (   SELECT cus_cd, CASE WHEN TO_DATE('20130415','YYYYMMDD') - TO_DATE(NVL(enter_dt,'20130415'),'YYYYMMDD') <= 30 THEN 1 ELSE 2 END cnt FROM spa05mt) e"
                + " WHERE    a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "          AND a.to_no = b.to_no(+)"
                + "          AND a.gr_cd LIKE '" + prm.GeraiCd + "%'"
                + "          AND a.gr_cd = f.gr_cd(+)"
                + "          AND a.to_no = b.to_no(+)"
                + "          AND b.item_cd = c.item_cd(+)"
                + "          AND a.member_cd = e.cus_cd(+)"
                + "          AND d.sw <= 3"
                + "          AND b.item_cd LIKE '" + prm.ItemCd + "%'";
                if (prm.TypeCd == "1")
                {
                    sSql += "          AND c.group_cd = 1";
                }
                if (prm.TypeCd == "2")
                {
                    sSql += "          AND c.group_cd = 2";
                }
                sSql += " GROUP BY DECODE(d.sw,3,'99999', a.gr_cd), DECODE(d.sw,1,b.item_cd, 'XXXXX')"
                + " ORDER BY DECODE(d.sw,3,'99999', a.gr_cd), DECODE(d.sw,1,b.item_cd, 'XXXXX')";
            }
            else
            {
                sSql = " SELECT   MAX(d.sw) sw,"
                + "          MAX(DECODE(d.sw,2, 'GRAND TOTAL', f.gr_nm)) GrNm,"
                + "          NULL ItemNm,"
                + "          SUM(b.qty) qty,"
                + "          SUM(b.total) amt,"
                + "          SUM(DECODE(NVL(e.cnt,2),1,b.qty,0)) newQty,"
                + "          SUM(DECODE(NVL(e.cnt,2),1,b.amt,0)) newAmt,"
                + "          SUM(DECODE(NVL(e.cnt,2),2,b.qty,0)) OldQty,"
                + "          SUM(DECODE(NVL(e.cnt,2),2,b.amt,0)) OldAmt"
                + " FROM     zspa12it a, zspa13it b, zspa02mt c, ztot_psu d, zgrmst f,"
                + "          (   SELECT cus_cd, CASE WHEN TO_DATE('20130415','YYYYMMDD') - TO_DATE(NVL(enter_dt,'20130415'),'YYYYMMDD') <= 30 THEN 1 ELSE 2 END cnt FROM spa05mt) e"
                + " WHERE    a.indate BETWEEN '" + Utilities.formatDate(prm.sDate) + "' AND '" + Utilities.formatDate(prm.eDate) + "'"
                + "          AND a.to_no = b.to_no(+)"
                + "          AND a.gr_cd LIKE '" + prm.GeraiCd + "%'"
                + "          AND a.gr_cd = f.gr_cd(+)"
                + "          AND a.to_no = b.to_no(+)"
                + "          AND b.item_cd = c.item_cd(+)"
                + "          AND a.member_cd = e.cus_cd(+)"
                + "          AND d.sw <= 2"
                + "          AND b.item_cd LIKE '" + prm.ItemCd + "%'";
                if (prm.TypeCd == "1")
                {
                    sSql += "          AND c.group_cd = 1";
                }
                if (prm.TypeCd == "2")
                {
                    sSql += "          AND c.group_cd = 2";
                }
                sSql += " GROUP BY DECODE(d.sw,3,'99999', a.gr_cd)"
                + " ORDER BY DECODE(d.sw,3,'99999', a.gr_cd)";
            }
            try
            {
                DataTable dt = objdbmgr.GetData(sSql, out errMsg);
                if (dt.Rows.Count > 0)
                    list = ObjectConverter.DataTableToList<ListTransactionByCustomerNewOldResult>(dt);
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

        //public JsonResult GetListHistoryDeleteTransaction(ListHistoryDeleteTransactionParam prm)
        //{

        //}
    }
}