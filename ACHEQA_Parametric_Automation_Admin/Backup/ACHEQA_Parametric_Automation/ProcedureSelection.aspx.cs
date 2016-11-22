using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jord.ACHEQA.BAL;
using System.Data;

namespace ACHEQA_Parametric_Automation
    {
    public partial class ProcedureSelection : System.Web.UI.Page
        {
        int tid = 0;
        string jobNum = "";
        string tagNum="";
        protected void Page_Load(object sender, EventArgs e)
            {
            string qType = (Request.QueryString["qmode"] != null) ? Request.QueryString["qmode"] : "mq"; ;    
            tid = (Request.QueryString["tid"] != null) ? Convert.ToInt32(Request.QueryString["tid"]) : 0;
            jobNum = (Request.QueryString["jno"] != null) ? Request.QueryString["jno"].ToString() : "";
            tagNum = (Request.QueryString["tagname"] != null) ? Request.QueryString["tagname"].ToString() : "";
            if (!IsPostBack)
                {
                FillProcList();
                GF.UpdateBreadCrum(this.Master, qType, jobNum, tagNum, "Procedure Selection");
                }
            }
        void FillProcList()
            {
            try
                {
                int resumePcount = 0;
                DataTable dt = new DataTable();
                //========GET ALL PROCEDURE LIST FROM MASTER TABLE

                dt = cls_Procedures_BAL.Get_Procedures_BAL();
                if (dt != null && dt.Rows.Count > 0)
                    {

                    chkProcs.DataSource = dt;
                    chkProcs.DataTextField = "ProcName";
                    chkProcs.DataValueField = "ProcID";
                    chkProcs.DataBind();
                    }
                //========GET PROCEDURE LIST OF SELETECTED TAG
                dt = cls_Procedures_BAL.Get_Procedures_BAL(tid);
                if (dt != null && dt.Rows.Count > 0)
                    {
                    for (int rcount = 0; rcount < chkProcs.Items.Count; rcount++)
                        {
                        for (int pcount = resumePcount; pcount < dt.Rows.Count; pcount++)
                            {
                            if (chkProcs.Items[rcount].Text == dt.Rows[pcount]["ProcName"].ToString())
                                {
                                chkProcs.Items[rcount].Selected = true;
                                chkProcs.Items[rcount].Enabled = false;
                                resumePcount = pcount + 1;
                                break;
                                }
                            }
                        }
                    }
                }
            catch (Exception ex)
                {

                lblerr.Text = ex.Message;
                }
            }

        protected void btnSaveProc_Click(object sender, EventArgs e)
            {
            try
                {
                DataTable dtTemp = new DataTable();
                dtTemp.Columns.Add("DesignSetID", typeof(string));
                dtTemp.Columns.Add("ProcID", typeof(string));
                dtTemp.Columns.Add("ProcName", typeof(string));
                dtTemp.Columns.Add("JobNumber", typeof(string));
                dtTemp.Columns.Add("RevisionSlno", typeof(string));
                dtTemp.Columns.Add("CreatedBy", typeof(string));
                // dtTemp.Columns.Add("DesignSetID", typeof(string));


                for (int i = 0; i < chkProcs.Items.Count; i++)
                    {
                    if (chkProcs.Items[i].Selected == true)
                        {
                        DataRow dr = dtTemp.NewRow();
                        dr["DesignSetID"] = tid;
                        dr["ProcID"] = chkProcs.Items[i].Value;
                        dr["ProcName"] = chkProcs.Items[i].Text;
                        dr["JobNumber"] = jobNum;
                        dr["RevisionSlno"] = "Z0";
                        dr["CreatedBy"] = "1";
                        dtTemp.Rows.Add(dr);
                        }
                    }
                cls_Procedures_BAL.Save_Procedures_BAL(dtTemp);
                Response.Redirect("ProcedureInputs.aspx?tid=" + tid + "&jno=" + jobNum + "&tagname=" + tagNum);
                }
            catch (Exception ex)
                {

                lblerr.Text = ex.Message;
                }
            }
        }
    }