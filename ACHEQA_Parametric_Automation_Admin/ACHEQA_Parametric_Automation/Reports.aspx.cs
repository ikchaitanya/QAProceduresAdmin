using Jord.ACHEQA.BAL;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACHEQA_Parametric_Automation_Admin
{
    public partial class Reports : System.Web.UI.Page
    {
        clsProcedureNotes_BAL objProcedureNotes_Bal;
        DataTable dt_ProcReportData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDowns();
            }
            Image1.Visible = false;
        }

        public void BindDropDowns()
        {
            DataTable dt_ProcedureList = new DataTable();
            dt_ProcedureList = cls_Procedures_BAL.Get_Procedures_BAL();
            ddlProcedureList.DataSource = dt_ProcedureList;
            ddlProcedureList.DataTextField = "ProcName";
            ddlProcedureList.DataValueField = "ProcID";
            ddlProcedureList.DataBind();
            ddlProcedureList.Items.Insert(0, (new ListItem("--Select--", "-1")));
        }

        public void BindAllNotesForReport()
        {
            try
            {
                dt_ProcReportData = new DataTable();
                objProcedureNotes_Bal = new clsProcedureNotes_BAL();
                dt_ProcReportData = objProcedureNotes_Bal.GetProcReportData(Convert.ToInt32(ddlProcedureList.SelectedItem.Value.ToString()));

                if (dt_ProcReportData != null)
                {
                    if (dt_ProcReportData.Rows.Count > 0)
                    {
                        var strPath = "ACHEQA_Parametric_Automation_Admin.Reports.ProcReportData.rdlc";
                        ReportViewer1.LocalReport.ReportEmbeddedResource = strPath;
                        
                        ReportDataSource _rsource = new ReportDataSource("dsProcReportData", dt_ProcReportData);
                        ReportViewer1.LocalReport.DataSources.Add(_rsource);
                        ReportViewer1.LocalReport.Refresh();
                        ReportViewer1.Visible = true;
                        Image1.Visible = false;
                    }
                    else
                    {
                        ReportViewer1.Visible = false;
                        Image1.Visible = true;
                    }
                }
                else
                {
                    ReportViewer1.Visible = false;
                    Image1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.ToString());
            }
        }

        protected void ddlProcedureList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindAllNotesForReport();
        }
    }
}