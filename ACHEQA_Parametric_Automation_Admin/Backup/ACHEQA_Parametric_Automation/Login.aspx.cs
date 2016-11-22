using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACHEQA_Parametric_Automation
    {
    public partial class Login : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {

            }

        protected void lnkLogin_Click(object sender, EventArgs e)
            {
            try
                {
                Response.Redirect("QuoteHome.aspx");
                }
            catch (Exception ex)
                {

                lblinvaliduser.Text = ex.Message;
                }
            }
        }
    }