using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI ;
using System.Web.UI.WebControls;

namespace ACHEQA_Parametric_Automation
    {
    public static class GF
        {
        public static void UpdateBreadCrum(MasterPage mp, string QuoteType = "", string jobName = "", string tagName = "", string currPagename = "")
         {
         try
             {
             //if (QuoteType != "")
             //    {
                 if ((HyperLink)mp.FindControl("lnkQuoteType") != null)
                     {
                     ((HyperLink)mp.FindControl("lnkQuoteType")).Text = ((QuoteType == "mq") ? "My Quotes" : "All Quotes");
                     ((HyperLink)mp.FindControl("lnkQuoteType")).NavigateUrl = "QuoteHome.aspx?qmode=" + QuoteType;
                     }
                 //}
             if ((HyperLink)mp.FindControl("lnkbtnQuotes") != null)
                 {
                 ((HyperLink)mp.FindControl("lnkbtnQuotes")).Text = ((jobName != "") ? " > " : "") + jobName;
                 ((HyperLink)mp.FindControl("lnkbtnQuotes")).NavigateUrl = "QuoteHome.aspx?qmode=" + QuoteType;
                 }

             if ((HyperLink)mp.FindControl("lnkbtnTags") != null)
                 {
                 ((HyperLink)mp.FindControl("lnkbtnTags")).Text = ((tagName != "") ? " > " : "") + tagName;
                 ((HyperLink)mp.FindControl("lnkbtnTags")).NavigateUrl = "QuoteHome.aspx?qmode=" + QuoteType;
                 }


             if ((Label)mp.FindControl("lblCurrPage") != null) ((Label)mp.FindControl("lblCurrPage")).Text = ((currPagename != "") ? " > " : "") + currPagename;

             }
         catch (Exception ex)
             {
             
             throw new Exception (ex.Message);
             }
         }
        }
    }
