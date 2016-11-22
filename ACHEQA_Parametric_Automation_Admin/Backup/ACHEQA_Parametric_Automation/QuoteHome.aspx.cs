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
    public partial class QA_QuoteHome : System.Web.UI.Page
        {  
        string quoteType = string.Empty;
           
        protected void Page_Load(object sender, EventArgs e)
            {
            quoteType = (Request.QueryString["qmode"] != null) ? Request.QueryString["qmode"].ToString() : "mq";
            GF.UpdateBreadCrum(this.Master, quoteType);
            if (!IsPostBack)
                {
               
              
                GetJobList();
               
                }
            }
        void GetJobList()
            {
            try
                {
                DataTable dt = new DataTable();
                dt = cls_Jobs_BAL.Get_Jobs_BAL();
                if (dt != null)
                    {
                    if (dt.Rows.Count  > 0)
                        {
                        dgvJobs.DataSource = dt;
                        dgvJobs.DataBind();
                        }
                    }
                }
            catch (Exception ex)
                {
                
                lblerr.Text = ex.Message;
                }
            }
        protected void btn_newquote_Click(object sender, EventArgs e)
            {
            try
                {
                Response.Redirect("Quote_Create.aspx");//?qtype=user");
                }
            catch (Exception ex)
                {
                lblerr.Text = ex.Message;
                }
            }
        protected void dgvJobs_OnRowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
            {
            try
                {

                string qurl = string.Empty;
                if (e.CommandName == "lnkTagReference")
                    {
                    LinkButton lb = (LinkButton)(e.CommandSource);
                    GridViewRow selectedrow = (GridViewRow)(lb.NamingContainer);
                    Label QID = (Label)selectedrow.FindControl("lblqid");
                    Label jobNumber = (Label)selectedrow.FindControl("lblJobNumber");
                    LinkButton tagNumber = (LinkButton)selectedrow.FindControl("lnkTagReference");
                    //Session["CurrentPage"] = quoteType;
                    qurl = "ProcedureInputs.aspx?tid=" + QID.Text + "&jno=" + jobNumber.Text + "&tagname=" + tagNumber.Text + "&qmode=" + quoteType;
                    Response.Redirect(qurl);
                    }
                if (e.CommandName == "btndel")
                    {
                    ImageButton lb = (ImageButton)(e.CommandSource);
                    GridViewRow selectedrow = (GridViewRow)(lb.NamingContainer);
                    Label QID = (Label)selectedrow.FindControl("lblqid");
                    //lblerr.Text = clsQuote.DeleteQuote(QID.Text, "", ref exmsg);
                    //FillQuotes();
                    }
                if (e.CommandName == "btnLink")
                    {
                    ImageButton lb = (ImageButton)(e.CommandSource);
                    GridViewRow selectedrow = (GridViewRow)(lb.NamingContainer);
                    Label QID = (Label)selectedrow.FindControl("lblqid");
                    Label jobNumber = (Label)selectedrow.FindControl("lblJobNumber");
                    LinkButton tagNumber = (LinkButton)selectedrow.FindControl("lnkTagReference");
                    qurl = "ProcedureSelection.aspx?tid=" + QID.Text + "&jno=" + jobNumber.Text + "&tagname=" + tagNumber.Text + "&qmode=" + quoteType;
                    Response.Redirect(qurl);
                    //lblerr.Text = clsQuote.DeleteQuote(QID.Text, "", ref exmsg);
                    //FillQuotes();
                    }
                }
            catch (Exception ex)
                {
                lblerr.Text = ex.Message;
                }
            }
        }
    }