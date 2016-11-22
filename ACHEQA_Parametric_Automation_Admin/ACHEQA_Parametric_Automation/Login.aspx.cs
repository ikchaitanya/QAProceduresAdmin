using Jord.ACHEQA.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACHEQA_Parametric_Automation_Admin
{
    public partial class Login : System.Web.UI.Page
    {
        DataTable DBTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string sIPAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(sIPAddress))
            {
                return context.Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                string[] ipArray = sIPAddress.Split(new Char[] { ',' });
                return ipArray[0];
            }
        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            bool pass = false;
            string err1 = string.Empty;
            pass = false;
            lblinvaliduser.Text = "";
            string IPAddress = "";

            IPAddress = GetIPAddress();
            string ValidUser = string.Empty;

            try
            {
                if (hf_autologin.Value == "false")
                {
                    DominoAuthenticationClient.DominoLoginClient objDac = new DominoAuthenticationClient.DominoLoginClient();
                    pass = objDac.ValidateDominoUser("sydney", txtUname.Text, txtpassword.Text, ref err1, 38, IPAddress);
                    if (pass == true)
                    {
                        DBTable = cls_Users_BAL.UserAuthentication_BAL(txtUname.Text.ToString());
                        if (DBTable != null)
                        {
                            if (DBTable.Rows.Count > 0)
                            {
                                Session["UserID"] = DBTable.Rows[0]["UserID"].ToString();
                                Session["UserFullName"] = DBTable.Rows[0]["UserFullName"].ToString();
                                Session["UserName"] = txtUname.Text.ToString();
                            }
                        }
                        Response.Redirect("ProcedureNotes.aspx", false);
                    }
                    else
                    {
                        lblinvaliduser.Text = "Invalid User / Password";
                        return;
                    }
                }

                //txtUname.Text = "vdesai kunchala";
                //Session["UserID"] = "26";
                //Session["UserFullName"] = "Venkat Desai";
                //Session["UserName"] = txtUname.Text.ToString();
                //Response.Redirect("ProcedureNotes.aspx", false);
                //Response.Redirect("ProcedureNotes.aspx");
            }
            catch (Exception ex)
            {

                lblinvaliduser.Text = ex.Message;
            }
        }
    }
}