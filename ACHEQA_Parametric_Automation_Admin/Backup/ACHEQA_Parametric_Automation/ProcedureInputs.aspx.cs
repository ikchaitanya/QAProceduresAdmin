using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Jord.ACHEQA.BAL;
using System.Web.UI.HtmlControls;

namespace ACHEQA_Parametric_Automation
    {
    public partial class ProcedureInputs : System.Web.UI.Page
        {
        int tid = 0;
        string jobNum = "";
        string tagNum = "";
        string qType = "";
        string procNameGrid = ""; //---CONCATINATE ALL IDs OF PROCEDURES TO FETCH DATA
        protected void Page_Load(object sender, EventArgs e)
            {
            qType = (Request.QueryString["qmode"] != null) ? Request.QueryString["qmode"] : "mq"; ;
            tid = (Request.QueryString["tid"] != null) ? Convert.ToInt32(Request.QueryString["tid"]) : 0;
            jobNum = (Request.QueryString["jno"] != null) ? Request.QueryString["jno"].ToString() : "";
            tagNum = (Request.QueryString["tagname"] != null) ? Request.QueryString["tagname"].ToString() : "";
            if (!IsPostBack)
                {
                Get_Procedure_List();

                Get_ProcInput();
                GF.UpdateBreadCrum(this.Master, qType, jobNum, tagNum, "Procedure Input");
                }
            }

        private void Get_Procedure_List()
            {
            try
                {
                //DataTable dt = new DataTable();
                ////========GET ALL PROCEDURE LIST FROM MASTER TABLE

                //dt = cls_Procedures_BAL.Get_Procedures_BAL(tid);
                //if (dt != null && dt.Rows.Count > 0)
                //    {
                //    for (int pcounter = 0; pcounter < dt.Rows.Count; pcounter++)
                //        {
                //        procNameGrid = procNameGrid + dt.Rows[pcounter]["ProcSetID"] + ",";
                //        }
                //    procNameGrid = procNameGrid.TrimEnd(',');

                //    //ddlProcedures.DataSource = dt;
                //    //ddlProcedures.DataTextField = "ProcName";
                //    //ddlProcedures.DataValueField = "ProcSetID";
                //    //ddlProcedures.DataBind();
                //    //ddlProcedures.Items.Insert(0, new ListItem("-Select-", "-1"));
                //    }
                //else
                //    {
                //    //=========REDIRECT TO PROC SECTION PAGE
                //    Response.Redirect("ProcedureSelection.aspx?tid=" + tid + "&jno=" + jobNum + "&tagname=" + tagNum + "&qmode=" + qType);
                //    }
                }
            catch (Exception ex)
                {

                lblerr.Text = "Procedure List - " + ex.Message;
                }
            }

        protected void lstProcList_SelectedIndexChanged(object sender, EventArgs e)
            {
            Get_ProcInput();
            }

        private void Get_ProcInput()
            {
            try
                {
                DataTable dt = new DataTable();
                dt = cls_InputVariable_BAL.Get_InputVariable_BAL("", tid);// Convert.ToInt32(ddlProcedures.SelectedValue));
                if (dt != null & dt.Rows.Count > 0)
                    {
                    dgvInputVariables.DataSource = dt;
                    dgvInputVariables.DataBind();
                    }
                else
                    {
                    dgvInputVariables.DataSource = null;
                    dgvInputVariables.DataBind();
                    }
                }
            catch (Exception ex)
                {
                lblerr.Text = "Get Input variable list - " + ex.Message;
                }
            }

        protected void dgvInputVariables_RowDataBound(object sender, GridViewRowEventArgs e)
            {
            try
                {
                if (e.Row.RowIndex >= 0)
                    {
                    //============ADD HEADING AS PER PROCEDURE NAME
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    if (procNameGrid != drv["ProcName"].ToString())
                        {
                        procNameGrid = drv["ProcName"].ToString();
                        // Get a reference to the current row's Parent, which is the Gridview (which happens to be a table)
                        Table tbl = e.Row.Parent as Table;
                        if (tbl != null)
                            {
                            GridViewRow row = new GridViewRow(-1, -1, DataControlRowType.DataRow, DataControlRowState.Normal);
                            TableCell cell = new TableCell();

                            // Span the row across all of the columns in the Gridview
                            cell.ColumnSpan = this.dgvInputVariables.Columns.Count;

                            cell.Width = Unit.Percentage(100);
                            cell.Style.Add("font-weight", "bold");
                            cell.Style.Add("background-color", "#345c70");
                            cell.Style.Add("color", "white");

                            HtmlGenericControl span = new HtmlGenericControl("span");
                            span.InnerHtml = procNameGrid;

                            cell.Controls.Add(span);
                            row.Cells.Add(cell);

                            tbl.Rows.AddAt(tbl.Rows.Count - 1, row);
                            }
                        }
                    //-------------SHOW/ HIDE TEXTBOX/DROPDOWN AS PER CONTROL TYPE
                    Label CtrlType = (Label)e.Row.FindControl("lblControlType");
                    TextBox txtInput = (TextBox)e.Row.FindControl("txtInput");
                    DropDownList ddlInput = (DropDownList)e.Row.FindControl("ddlInput");
                    if (CtrlType.Text == "Lookup Value")
                        {
                        ddlInput.Visible = true;
                        txtInput.Visible = false;
                        //----------------GET LOOKUP VALUES AS PER CAT ID
                        Label lblLookCat = (Label)e.Row.FindControl("lblLookCatID");
                        if (cls_Lookup_BAL.Get_LookupValues_BAL(Convert.ToInt32(lblLookCat.Text)) != null && cls_Lookup_BAL.Get_LookupValues_BAL(Convert.ToInt32(lblLookCat.Text)).Rows.Count > 0)
                            {
                            ddlInput.DataSource = cls_Lookup_BAL.Get_LookupValues_BAL(Convert.ToInt32(lblLookCat.Text));
                            ddlInput.DataTextField = "DisplayText";
                            ddlInput.DataBind();
                            }

                        }
                    else
                        {
                        ddlInput.Visible = false;
                        txtInput.Visible = true;
                        }
                    //-------------SHOW * FOR MANDATORY FIELDS
                    Label lblIsRequried = (Label)e.Row.FindControl("lblIsRequried");
                    Label lblShowRequried = (Label)e.Row.FindControl("lblShowRequried");
                    if (lblIsRequried.Text == "True") lblShowRequried.Text = "*";
                    else lblShowRequried.Text = "";

                    }

                }
            catch (Exception ex)
                {
                lblerr.Text = "Row Bound - " + ex.Message;
                }
            }
        }
    }