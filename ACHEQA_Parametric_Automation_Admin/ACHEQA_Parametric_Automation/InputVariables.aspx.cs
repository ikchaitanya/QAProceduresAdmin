using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Jord.ACHEQA.BAL;
using Jord.ACHEQA.Entities;

namespace ACHEQA_Parametric_Automation_Admin
    {
    public partial class InputVariables : System.Web.UI.Page
        {
        int tid = 0;
        string jobNum = "";
        string tagNum = "";
        string qType = "";
        public string errmsg = string.Empty;
        //static List<Double> lstRefList = new List<Double>();
        protected void Page_Load(object sender, EventArgs e)
            {

            qType = (Request.QueryString["qmode"] != null) ? Request.QueryString["qmode"] : "mq"; ;
            tid = (Request.QueryString["tid"] != null) ? Convert.ToInt32(Request.QueryString["tid"]) : 0;
            jobNum = (Request.QueryString["jno"] != null) ? Request.QueryString["jno"].ToString() : "";
            tagNum = (Request.QueryString["tagname"] != null) ? Request.QueryString["tagname"].ToString() : "";
            if (!IsPostBack)
                {
                //lstRefList.Clear();
                hf_vid.Value = "0";
                //=========UPDATE BREAD CRUM ON MASTER PAGE
                GF.UpdateBreadCrum(this.Master, tid, qType, jobNum, tagNum, "Input Variables");
                //=========FILL PROCEDURE DROPDOWN
                FillProcList();
                //=========FILL DATAGRID
                Get_InputVariableData();
                //=========GET LIST OF ALL LOOKUP CATEGORIES
                GetLookupCategories();

                //=========RESET ALL CONTROLS
                ResetAllControls();

                //=========ADD ATTRIBUTES TO CONTROLS
                cmbLookCat.Attributes.Add("onFocus", "cmbfocus();");
                //txtLookupCat.Attributes.Add("style", "color:silver; disabled:true;");
                //lstLookupData.Attributes.Add("style", "display:none;");
                //lstLookupDataHidden.Attributes.Add("style", "display:none");
                chkActive.Attributes.Add("style", "left-margin:0px");
                }
            }
        private void GetLookupCategories()
            {
            try
                {
                DataTable dt = new DataTable();
                dt = cls_Lookup_BAL.Get_LookupCategories_BAL();
                if (dt != null && dt.Rows.Count > 0)
                    {
                    cmbLookCat.DataSource = dt;
                    cmbLookCat.DataTextField = "CatagoryName";
                    cmbLookCat.DataValueField = "Lookup_Catg_ID";
                    
                    cmbLookCat.DataBind();
                    cmbLookCat.Items.Insert(0, new ListItem("Type here to search", "-1"));
                    cmbLookCat.Text = "Type here to search";
                    cmbLookCat.SelectedIndex = 0;
                    Session["SessLookupCat"] = dt;
                    //lstLookupData.DataSource = dt;
                    //lstLookupData.DataTextField = "CatagoryName";
                    //lstLookupData.DataValueField = "Lookup_Catg_ID";
                    //lstLookupData.DataBind();
                    //lstLookupDataHidden.DataSource = dt;
                    //lstLookupDataHidden.DataTextField = "CatagoryName";
                    //lstLookupDataHidden.DataValueField = "Lookup_Catg_ID";
                    //lstLookupDataHidden.DataBind();
                    }

                }
            catch (Exception ex)
                {

                lblerr.Text = "Get Data - " + ex.Message;
                }
            }
        void FillProcList()
            {
            try
                {

                DataTable dt = new DataTable();
                //========GET ALL PROCEDURE LIST FROM MASTER TABLE

                dt = cls_Procedures_BAL.Get_Procedures_BAL();
                if (dt != null && dt.Rows.Count > 0)
                    {
                    ddlProcedures.DataSource = dt;
                    DataRow dr = dt.NewRow();
                    dr["ProcName"] = "-Select-";
                    dr["ProcID"] = -1;
                    dt.Rows.Add(dr);
                    ddlProcedures.DataTextField = "ProcName";
                    ddlProcedures.DataValueField = "ProcInitialProgram";
                    ddlProcedures.DataBind();
                    ddlProcedures.Items.Insert(0, new ListItem("-Select-", "-1"));
                    }
                }
            catch (Exception ex)
                {

                lblerr.Text = "Fill Procedures - " + ex.Message;
                }
            }
        void Get_InputVariableData()
            {
            try
                {
                DataTable dt = new DataTable();
                dt = cls_InputVariable_BAL.Get_InputVariable_BAL(ddlProcedures.SelectedValue);
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
        protected void ddlProcedures_SelectedIndexChanged(object sender, EventArgs e)
            {
            try
                {
                txtVariableName.Text = ddlProcedures.SelectedValue + "_";
                Get_InputVariableData();
                }
            catch (Exception ex)
                {

                lblerr.Text = "Procedure select - " + ex.Message;
                }
            }

        protected void btnSave_Click(object sender, EventArgs e)
            {
            SaveInputVariables();
            if (btnSave.Text == "Update")
                {
                btnSave.Text = "Add";
                btnCancel.Visible = false;
                }
            ResetAllControls();
            }

        private void ResetAllControls()
            {
            try
                {
                txtVariableName.Text = ddlProcedures.SelectedValue;
                cmbLookCat.SelectedIndex = 0;
                //ddlProcedures.SelectedIndex = -1;
                //txtProcInitial.Text = "";
                txtVariableName.Text = "";
                txtDiplayName.Text = "";
                ddlControlType.SelectedIndex = 0;
                txtLookupCat.Text = "";
                txtLookupID.Text = "";
                chkActive.Checked = false;
                chkMandatory.Checked = false;
                ddlProcedures.Focus();
                hf_vid.Value = "0";
                }
            catch (Exception ex)
                {

                lblerr.Text = "Reset - " + ex.Message;
                }
            }
        protected void SaveInputVariables()
            {
            try
                {
                //-----VALIDATION

                InputVariable_Entity objEntity = new InputVariable_Entity();
                objEntity.VarID = Convert.ToInt32(hf_vid.Value);
                objEntity.LookupCatID = (txtLookupID.Text == "") ? 0 : Convert.ToInt32(txtLookupID.Text);
                objEntity.ProcInitial = ddlProcedures.SelectedValue;
                objEntity.VariableName = lblPrefix.Text + txtVariableName.Text.Replace("@XXX_", "");
                objEntity.DisplayName = txtDiplayName.Text;
                objEntity.ControlType = ddlControlType.SelectedItem.Text;
                objEntity.LookupCatName = txtLookupCat.Text;
                objEntity.CreatedBy = 1;
                objEntity.IsRequried = chkMandatory.Checked;
                objEntity.IsActive = chkActive.Checked;

                cls_InputVariable_BAL.Save_InputVariable_BAL(objEntity, ref errmsg);
                if (errmsg != "") lblerr.Text = errmsg;
                else lblerr.Text = "Record saved";
                Get_InputVariableData();
                //if (cls_InputVariable_BAL.Save_InputVariable_BAL(objEntity) == "")
                //    {
                //    lblerr.Text = "Record saved";
                //    Get_InputVariableData();
                //    }
                //else
                //    {
                //    lblerr.Text = 
                //    }
                ResetAllControls();
                }
            catch (Exception ex)
                {

                lblerr.Text = "Save Input variables - " + ex.Message;
                }
            }

        protected void txtLookupCat_TextChanged(object sender, EventArgs e)
            {
            try
                {
                pnLookupCatData.Visible = true;
                DataTable dtSession = new DataTable();
                dtSession = (Session["SessLookupCat"] != null) ? (DataTable)Session["SessLookupCat"] : cls_Lookup_BAL.Get_LookupCategories_BAL();
                if (dtSession != null & dtSession.Rows.Count > 0)
                    {
                    lstLookupData.DataSource = dtSession.Select("", "").CopyToDataTable();
                    lstLookupData.DataBind();
                    }

                }
            catch (Exception ex)
                {

                lblerr.Text = "Lookup cat search - " + ex.Message;
                }
            }

        protected void dgvInputVariables_RowCommand(object sender, GridViewCommandEventArgs e)
            {
            try
                {
                if (e.CommandName == "btnEdit")
                    {
                    ImageButton lb = (ImageButton)(e.CommandSource);
                    GridViewRow selectedrow = (GridViewRow)(lb.NamingContainer);
                    //------UNIQUE ID
                    Label lblVarID = (Label)selectedrow.FindControl("lblVarID");
                    hf_vid.Value = lblVarID.Text;
                    //------VARIABLE NAME
                    string textToReplace = "@XXX_";
                    Label lblvarname = (Label)selectedrow.FindControl("lblVarname");
                    txtVariableName.Text = lblvarname.Text.Replace(textToReplace, "");

                    //------DISPLAY NAME
                    Label lblDispNAme = (Label)selectedrow.FindControl("lblDispNAme");
                    txtDiplayName.Text = lblDispNAme.Text;

                    //------CONTROL TYPE
                    Label lblCtrlType = (Label)selectedrow.FindControl("lblControlType");
                    ddlControlType.Text = lblCtrlType.Text;

                    Label lblLookupCatID = (Label)selectedrow.FindControl("lblLookupCatID");
                    Label lblLookCat = (Label)selectedrow.FindControl("lblLookCat");
                    if (lblCtrlType.Text == "Lookup Value")
                        {
                        //------CATEGORY ID                       
                        txtLookupID.Text = lblLookupCatID.Text;
                        //------CATEGORY NAME                      
                        cmbLookCat.SelectedValue = txtLookupID.Text;
                        cmbLookCat.Enabled = true;
                        }
                    else
                        {
                        txtLookupID.Text = "";
                        //------CATEGORY NAME                      
                        cmbLookCat.SelectedIndex = 0;
                        cmbLookCat.Enabled = false;
                        }
                 
                    //------ACTIVE STATUS
                    Label lblIsRequried = (Label)selectedrow.FindControl("lblIsRequried");
                    chkMandatory.Checked = Convert.ToBoolean(lblIsRequried.Text);

                    //------ACTIVE STATUS
                    Label lblactive = (Label)selectedrow.FindControl("lblisActive");
                    chkActive.Checked = Convert.ToBoolean(lblactive.Text);

                    btnSave.Text = "Update";
                    btnCancel.Visible = true;
                    }


                if (e.CommandName == "btnLink")
                    {
                    ImageButton lb = (ImageButton)(e.CommandSource);
                    GridViewRow selectedrow = (GridViewRow)(lb.NamingContainer);
                    //-----FETCH NOTES DATA OF SELECTED PROCEDURE
                    Label lblVarID = (Label)selectedrow.FindControl("lblVarID");
                    hf_vid.Value = lblVarID.Text;
                    Get_ProcNotes_mst();
                    Get_ProcRefClause();
                    this.modelProcNotes.Show();
                    //hf_vid.Value = "0";
                    }
              
                }
            catch (Exception ex)
                {

                lblerr.Text = "Item command - " + ex.Message;
                }
            }
        protected void Get_ProcNotes_mst()
            {
            try
                {
                DataTable dt = new DataTable();
                dt = cls_Procedures_BAL.Get_ProceduresNotes_BAL(ddlProcedures.SelectedValue);
                if (dt != null & dt.Rows.Count > 0)
                    {
                    dgvRefClause.DataSource = dt;
                    dgvRefClause.DataBind();
                    }
                }
            catch (Exception ex)
                {

                lblerr.Text = "Get Proc Notes - " + ex.Message;

                }

            }
        protected void Get_ProcRefClause()
            {
            try
                {
                int currentgcounter = 0;
                DataTable dt = new DataTable();
                dt = cls_Procedures_BAL.Get_ProcRefClause_DAL(Convert.ToInt32(hf_vid.Value));
                if (dt != null & dt.Rows.Count > 0)
                    {
                    //=========SELECT EXISTING CLAUSES
                    for (int ccounter = 0; ccounter < dt.Rows.Count; ccounter++)
                        {
                        for (int gcounter = currentgcounter; gcounter < dgvRefClause.Rows.Count; gcounter++)
                            {
                            Label lblProcNotes_ID = (Label)dgvRefClause.Rows[gcounter].FindControl("lblProcNoteID");
                            if (lblProcNotes_ID.Text == dt.Rows[ccounter][2].ToString())
                            //if (dgvRefClause.Rows[gcounter].Cells[0].Text == dt.Rows[ccounter][2].ToString())
                                {
                                CheckBox chkLink = (CheckBox)dgvRefClause.Rows[gcounter].FindControl("chkLink");
                                chkLink.Checked = true;
                                currentgcounter = gcounter + 1;
                                break;
                                }

                            } //grid rows counter

                        }//dt rows counter
                    }
                }
            catch (Exception ex)
                {

                lblerr.Text = "Get Proc Notes - " + ex.Message;

                }

            }
        protected void btnCancel_Click(object sender, EventArgs e)
            {
            btnSave.Text = "Save";
            btnCancel.Visible = false;
            ResetAllControls();
            }

        protected void lstLookupData_SelectedIndexChanged(object sender, EventArgs e)
            {
            try
                {
                txtLookupCat.Text = lstLookupData.Items[lstLookupData.SelectedIndex].Text;
                txtLookupID.Text = lstLookupData.Items[lstLookupData.SelectedIndex].Value;
                txtLookupCat.Attributes.Add("style", "color:black;");
                txtLookupCat.Enabled = true;
                }
            catch (Exception ex)
                {

                lblerr.Text = "lookup cat selected - " + ex.Message;
                }
            }

        protected void lstLookupData_TextChanged(object sender, EventArgs e)
            {
            try
                {
                txtLookupCat.Text = lstLookupData.Items[lstLookupData.SelectedIndex].Text;
                txtLookupID.Text = lstLookupData.Items[lstLookupData.SelectedIndex].Value;
                txtLookupCat.Attributes.Add("style", "color:black;");
                }
            catch (Exception ex)
                {

                lblerr.Text = "lookup cat selected - " + ex.Message;
                }
            }

        protected void dgvRefClause_RowDataBound(object sender, GridViewRowEventArgs e)
            {
            try
                {
                if (e.Row.RowIndex >= 0)
                    {
                    Label lblSequenceNumber = (Label)e.Row.FindControl("lblSequenceNumber");
                    CheckBox chkLink = (CheckBox)e.Row.FindControl("chkLink");
                    if (lblSequenceNumber.Text == "1")
                        {
                        chkLink.Visible = false;
                        }

                    }
                }
            catch (Exception ex)
                {
                lblerr.Text = "Ref Clause - " + ex.Message;
                }
            }

        protected void btnSaveRef_Click(object sender, EventArgs e)
            {
            //-------DELETE EXISTING RECORDS
            cls_Procedures_BAL.Delete_ProcRefClause_BAL(Convert.ToInt32(hf_vid.Value));
            //-------SAVE NEW RECORDS
            SaveRefCaluse();
            }

        private void SaveRefCaluse()
            {
            try
                {
                //=========DELETE EXISTING ENTRIES
                cls_Procedures_BAL.Delete_ProcRefClause_BAL(Convert.ToInt32(hf_vid.Value));
                //=========INSERT NEW ENTRIES
                DataTable dtTemp = new DataTable();
                dtTemp.Columns.Add("ProcNotes_ID", typeof(string));
                dtTemp.Columns.Add("VarID", typeof(string));
                dtTemp.Columns.Add("CreatedBy", typeof(string));

                for (int i = 1; i < dgvRefClause.Rows.Count; i++)
                    {
                    CheckBox chkLink = (CheckBox)dgvRefClause.Rows[i].FindControl("chkLink");
                    //----------CHECK IF CLAUSE IS SELECTED
                    if (chkLink.Checked == true)
                        {
                        Label lblProcNotes_ID = (Label)dgvRefClause.Rows[i].FindControl("lblProcNoteID");

                        DataRow dr = dtTemp.NewRow();
                        dr["ProcNotes_ID"] = lblProcNotes_ID.Text;
                        dr["VarID"] = hf_vid.Value;
                        dr["CreatedBy"] = "1";
                        dtTemp.Rows.Add(dr);
                        }
                    }
                lblerr.Text =  cls_Procedures_BAL.Save_ProcRefClause_BAL(dtTemp);
                Get_InputVariableData();
                hf_vid.Value = "0";
                }
            catch (Exception ex)
                {
                lblerr.Text = "Ref Clause Save - " + ex.Message;
                }
            }

        protected void cmbLookCat_TextChanged(object sender, EventArgs e)
            {

            }

        protected void cmbLookCat_SelectedIndexChanged(object sender, EventArgs e)
            {
            txtLookupID.Text = cmbLookCat.SelectedValue;
            }

        protected void ddlControlType_SelectedIndexChanged(object sender, EventArgs e)
            {
            if (ddlControlType.Text == "Lookup Value") cmbLookCat.Enabled = true;
            else cmbLookCat.Enabled = false;

            }
        //protected void chkLink_CheckedChanged(object sender, EventArgs e)
        //    {
            
        //    GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
        //    int index = row.RowIndex;
        //    CheckBox cb1 = (CheckBox)dgvRefClause.Rows[index].FindControl("chkLink");
        //    //Label lblRefSelected = (Label)dgvRefClause.Rows[index].FindControl("lblRefSelected");
        //    Label lblSerialNumber = (Label)dgvRefClause.Rows[index].FindControl("lblSerialNumber");
        //    if (cb1.Checked == true) lstRefList.Add (Convert.ToDouble ( lblSerialNumber.Text)); // lblRefSelected.Text = lblRefSelected.Text + lblSerialNumber.Text + ",";
        //    else
        //        {
        //        lstRefList.Remove(Convert.ToDouble(lblSerialNumber.Text));
        //        //lblRefSelected.Text = lblRefSelected.Text.Replace(lblSerialNumber.Text, "");
        //        //lblRefSelected.Text = lblRefSelected.Text.Replace(",,", "");
        //        }
        //    //lblRefSelected.Text=   lblRefSelected.Text.TrimEnd(',');
        //    //----------MAKE STRING OF ALL LIST ITEMS
        //    lblRefSelected.Text = "Selected Reference Clauses are: ";
        //    lstRefList.Sort();
        //    foreach (var item in lstRefList)
        //        {
        //        lblRefSelected.Text = lblRefSelected.Text + item.ToString() + ",";
        //        }
        //   lblRefSelected.Text = lblRefSelected.Text.TrimEnd(',');
        //    this.modelProcNotes.Show();
        //    //here you can find your control and get value(Id).

        //    }

       
        }
    }