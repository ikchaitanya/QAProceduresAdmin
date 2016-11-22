using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACHEQA_Parametric_Automation_Admin
    {
    public static class GF
        {
        public static void UpdateBreadCrum(MasterPage mp, int designID = 0, string QuoteType = "", string jobName = "", string tagName = "", string currPagename = "", string panelShow = "")
            {
            try
                {
                HyperLink hLink = new HyperLink();
                //============SHOW/HIDE PANELS
                if (panelShow == "")//====SHOW MAIN PANEL
                    {
                    if ((Panel)mp.FindControl("pnlMain") != null) ((Panel)mp.FindControl("pnlMain")).Attributes.Add("style", "display:block");// .Visible = true;
                    if ((Panel)mp.FindControl("pnlProcList") != null) ((Panel)mp.FindControl("pnlProcList")).Attributes.Add("style", "display:none"); //.Visible = false;
                    }
                else
                    {
                    if ((Panel)mp.FindControl("pnlProcList") != null) ((Panel)mp.FindControl("pnlProcList")).Attributes.Add("style", "display:block");//.Visible = true;
                    if ((Panel)mp.FindControl("pnlMain") != null) ((Panel)mp.FindControl("pnlMain")).Attributes.Add("style", "display:none");// .Visible = false;
                    }
                //============SETTING VALUES TO BREADCRUM
                hLink = (HyperLink)mp.FindControl("lnkQuoteType");

                //------------QUOTE TYPE
                if (hLink != null)
                    {
                    (hLink).Text = ((QuoteType == "mq") ? "My Quotes" : "All Quotes");
                    (hLink).NavigateUrl = "QuoteHome.aspx?qmode=" + QuoteType;
                    }
                //-------------QUOTE NAME   
                hLink = (HyperLink)mp.FindControl("lnkbtnQuotes");

                if (hLink != null)
                    {
                    (hLink).Text = ((jobName != "") ? " > " : "") + jobName;
                    (hLink).NavigateUrl = "QuoteHome.aspx?qmode=" + QuoteType;
                    }
                //-------------TAG NUMBER
                hLink = (HyperLink)mp.FindControl("lnkbtnTags");

                if (hLink != null)
                    {
                    (hLink).Text = ((tagName != "") ? " > " : "") + tagName;
                    (hLink).NavigateUrl = "QuoteHome.aspx?qmode=" + QuoteType;
                    }

                //if ((HyperLink)mp.FindControl("lnkQuoteType") != null)
                //    {
                //    ((HyperLink)mp.FindControl("lnkQuoteType")).Text = ((QuoteType == "mq") ? "My Quotes" : "All Quotes");
                //    ((HyperLink)mp.FindControl("lnkQuoteType")).NavigateUrl = "QuoteHome.aspx?qmode=" + QuoteType;
                //    }
                //}
                //if ((HyperLink)mp.FindControl("lnkbtnQuotes") != null)
                //    {
                //    ((HyperLink)mp.FindControl("lnkbtnQuotes")).Text = ((jobName != "") ? " > " : "") + jobName;
                //    ((HyperLink)mp.FindControl("lnkbtnQuotes")).NavigateUrl = "QuoteHome.aspx?qmode=" + QuoteType;
                //    }

                //if ((HyperLink)mp.FindControl("lnkbtnTags") != null)
                //    {
                //    ((HyperLink)mp.FindControl("lnkbtnTags")).Text = ((tagName != "") ? " > " : "") + tagName;
                //    ((HyperLink)mp.FindControl("lnkbtnTags")).NavigateUrl = "QuoteHome.aspx?qmode=" + QuoteType;
                //    }


                if ((Label)mp.FindControl("lblCurrPage") != null) ((Label)mp.FindControl("lblCurrPage")).Text = ((currPagename != "") ? " > " : "") + currPagename;
                if ((HiddenField)mp.FindControl("hf_designSetID") != null) ((HiddenField)mp.FindControl("hf_designSetID")).Value = designID.ToString();


                }
            catch (Exception ex)
                {

                throw new Exception(ex.Message);
                }
            }
        }
    }
