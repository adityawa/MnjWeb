using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.Common;
using Microsoft.Reporting.WebForms;

using MNJvWeb.Models.Master;
namespace MNJvWeb.Reporting
{
    public partial class ItemMasterProductPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string[] arr_param = { };
                if (Request.QueryString["param"] != null)
                {
                    arr_param = Request.QueryString["param"].ToString().Split('|');
                    List<InputMasterItemTreatmentInqModel> ls = new List<InputMasterItemTreatmentInqModel>();
                    ls = new InputMasterItemTreatmentBLL().InquiryData(arr_param[0], arr_param[1], arr_param[2], arr_param[3]);
                    DataTable dt = MNJvWeb.Models.ObjectConverter.ToDataTable<InputMasterItemTreatmentInqModel>(ls);
                    this.ReportViewer1.Reset();
                    ReportDataSource rds = new ReportDataSource("DSItemMstPrd", dt);

                    this.ReportViewer1.LocalReport.ReportEmbeddedResource = "MNJvWeb.Reporting.ItemMstProductTreatment.rdlc";

                    this.ReportViewer1.LocalReport.DataSources.Add(rds);


                    this.ReportViewer1.LocalReport.Refresh();

                    this.ReportViewer1.Visible = true;
                }
            }

        }
    }
}
