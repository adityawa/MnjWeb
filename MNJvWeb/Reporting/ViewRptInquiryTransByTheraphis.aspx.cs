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
    public partial class ViewRptInquiryTransByTheraphis : System.Web.UI.Page
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
                string therapis = arr_prm[2];
                string gerai = arr_prm[3];
                string sSql = "SELECT   MAX(c.sw) SW,"
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

                if (therapis != null && !therapis.Equals(string.Empty))
                {
                    sSql += " AND a.emp_no = " + therapis;
                }

                sSql += " GROUP BY a.indate, a.to_no, a.emp_no "
                + " UNION ALL"
                + " SELECT  a.indate,2 grp, 'Penjualan Prepaid' typeTrans,a.disc_no to_no, a.emp_no,"
                + " SUM(a.amt) amt,SUM(a.amt) paket, 0 gift,SUM(a.amt) total,MAX(a.komisi_amt) komisi "
                + " FROM    spa14it a "
                + " WHERE   a.indate BETWEEN '" + date_start + "' AND '" + date_end + "'"
                + " AND a.disc_type IN ('1')";

                if (therapis != null && !therapis.Equals(string.Empty))
                {
                    sSql += " AND a.emp_no = " + therapis;
                }

                sSql += " GROUP BY a.indate, a.disc_no, a.emp_no"
                + " ) a, spa03mt b, tot_psu c"
                + " WHERE    a.emp_no = b.emp_no(+)"
                + " AND c.sw <= 3"
                + " GROUP BY DECODE(c.sw,3,'XXXXXXXX',a.emp_no), DECODE(c.sw,1,a.indate,'XXXXXXX'), DECODE(c.sw,1,a.grp,99), DECODE(c.sw,1,a.to_no,999999)"
                + " ORDER BY DECODE(c.sw,3,'XXXXXXXX',a.emp_no), DECODE(c.sw,1,a.indate,'XXXXXXX'), DECODE(c.sw,1,a.grp,99), DECODE(c.sw,1,a.to_no,999999)";

                DSReport objdsreport = new DSReport();

                DataTable dtresult = new DataTable();
                DBManager objdbMgr = new DBManager();

                dtresult = objdbMgr.GetData(sSql, out err_msg);

                this.ReportViewer1.Reset();
                ReportDataSource rds = new ReportDataSource("DataSet1", dtresult);

                this.ReportViewer1.LocalReport.ReportEmbeddedResource = "MNJvWeb.Reporting.RptInquiryTransByTheraphis.rdlc";

                this.ReportViewer1.LocalReport.DataSources.Add(rds);


                this.ReportViewer1.LocalReport.Refresh();

                this.ReportViewer1.Visible = true;
            }
        }
    }
}