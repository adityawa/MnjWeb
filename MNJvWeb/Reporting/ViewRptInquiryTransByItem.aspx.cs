using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MNJvWeb.Models;
using System.Data;
using Microsoft.Reporting.Common;
using Microsoft.Reporting.WebForms;
namespace MNJvWeb.Reporting
{
    public partial class ViewRptInquiryTransByItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string err_msg = string.Empty;
                string[] arr_prm = { };
                string _param = string.Empty;
                if (Request.QueryString["param"] != null)
                    _param = Request.QueryString["param"].ToString();
                if (_param != string.Empty)
                    arr_prm = _param.Split('|');
                string date_start = Utilities.formatDate(arr_prm[0]);
                string date_end = Utilities.formatDate(arr_prm[1]);
                string sSql = "SELECT   MAX(TRIM(TO_CHAR(TO_DATE(a.indate,'YYYYMMDD'),'DD-MM-YYYY'))) tgl,"
                            + " MAX(c.item_nm) ItemNm,"
                            + "SUM(b.qty) qty,"
                            + "SUM(b.total )amt,"
                            + "SUM(DECODE(NVL(e.disc_type,'9'),'1',b.voucher_amt,0)) paket,"
                            + "SUM(DECODE(NVL(e.disc_type,'9'),'2',b.voucher_amt,0)) gift,"
                            + "SUM(DECODE(NVL(e.disc_type,'9'),'3',b.voucher_amt,0)) reimbsemen,"
                            + "SUM(DECODE(NVL(e.disc_type,'9'),'4',b.voucher_amt,0)) promo,"
                            + "SUM(b.total+DECODE(NVL(e.disc_type,'9'),'1',b.voucher_amt,'2',b.voucher_amt,0)) total,"
                            + "'INQURY TRANSACTION BY TREATMENT / PRODUCT' total1,"
                            + "'" + arr_prm[0] + " - " + arr_prm[1] + "' period,"
                            + " '" + arr_prm[3] + "' ttype "
                            + " FROM spa12it a, spa13it b, spa02mt c, spa15it e "
                            + "WHERE a.indate BETWEEN '" + date_start + "' AND '" + date_end + "' "
                            + "AND a.to_no = b.to_no(+) "
                            + "AND b.item_cd = c.item_cd(+) "
                            + "AND b.voucher_no= e.voucher_no(+) "
                            + "AND b.item_cd LIKE '" + arr_prm[2] + "%'";

                switch (arr_prm[3])
                {
                    case "TREATMENT":
                        sSql = sSql + " AND c.type_cd = 1";
                        break;
                    case "PRODUCT":
                        sSql = sSql + " AND c.type_cd = 2";
                        break;
                }

                sSql = sSql + " GROUP BY a.indate, b.item_cd";
                sSql = sSql + " ORDER BY a.indate, b.item_cd";
                DSReport objdsreport = new DSReport();

                DataTable dtresult = new DataTable();
                DBManager objdbMgr = new DBManager();

                dtresult = objdbMgr.GetData(sSql, out err_msg);

                this.ReportViewer1.Reset();
                ReportDataSource rds = new ReportDataSource("DataSet1", dtresult);

                this.ReportViewer1.LocalReport.ReportEmbeddedResource = "MNJvWeb.Reporting.RptInquiryTransByItem.rdlc";

                this.ReportViewer1.LocalReport.DataSources.Add(rds);


                this.ReportViewer1.LocalReport.Refresh();

                this.ReportViewer1.Visible = true;
            }
        }
    }
}