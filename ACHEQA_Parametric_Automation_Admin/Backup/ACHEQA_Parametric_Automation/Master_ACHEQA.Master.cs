using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace ACHEQA_Parametric_Automation
    {
    public partial class Master_ACHEQA : System.Web.UI.MasterPage
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            if (!Page.IsPostBack)
                {
                //=======CALL PROCEDURE TO SET LOTUSSELECTED CSS
                FormatList();
                }
            }
        protected void FormatList()
            {
            string qType = (Session["CurrentPage"] != null) ? Session["CurrentPage"].ToString() : "lstQuotes"; // "lstQuotes";
            StringBuilder sb1 = new StringBuilder();            
            pnlHome.Attributes.Add("style", "display:block");

            //=========CHANGE CSS OF ALL LIST ITEM TO BLANK
            sb1.Append("<script language='javascript'>document.getElementById('lstQuotes').className = '';document.getElementById('lstQuotesAll').className = '';document.getElementById('lstLookups').className = '';document.getElementById('lstLookupValues').className = '';</script>");
            if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), "RemoveAll"))
                {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "RemoveAll", sb1.ToString(), false);
                }
            //==========CHANGE SELECTED LIST ITEM CSS TO LOTUSSELECETED
            sb1.Clear();
            sb1.Append("<script language='javascript'>document.getElementById('" + qType + "').className = 'lotusSelected';</script>");
            if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), qType ))
                {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), qType , sb1.ToString(), false);
                }           
            }
        protected void lnk_chgpwd_Click(object sender, EventArgs e)
            {            
            Response.Redirect("ChangePassword.aspx");
            }
        protected void lnk_issuetracker_Click(object sender, EventArgs e)
            {
            Response.Redirect("IssueTracker.aspx");
            }      
        protected void lnkQuotes_Click(object sender, EventArgs e)
            {
            Session["CurrentPage"] = "lstQuotes";
            FormatList();
            Response.Redirect("~/QuoteHome.aspx?qmode=mq");//, false);
            }
        protected void lnkQuotesAll_Click(object sender, EventArgs e)
            {
            Session["CurrentPage"] = "lstQuotesAll";
            FormatList();
            Response.Redirect("~/QuoteHome.aspx?qmode=aq");//, false);
            }
        protected void lnkLookup_Click(object sender, EventArgs e)
            {
            Session["CurrentPage"] = "lstLookups";
            FormatList();
            Response.Redirect("~/lookupcategories.aspx");//, false);
            }
        protected void lnkLookupValues_Click(object sender, EventArgs e)
            {
            Session["CurrentPage"] = "lstLookupValues";
            FormatList();
            Response.Redirect("~/lookups.aspx");//, false);
            }

        protected void lnkInputVariables_Click(object sender, EventArgs e)
            {
            Session["CurrentPage"] = "lnkInputVariables";
            FormatList();
            Response.Redirect("~/InputVariables.aspx");//, false);
            }        
        }
    }