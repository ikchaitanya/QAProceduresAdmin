using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Jord.ACHEQA.BAL;
using Jord.ACHEQA.Entities;

namespace ACHEQA_Parametric_Automation
    {
    public partial class lookups : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            if (!IsPostBack)
                {
                GetLookupCategories();
                GetLookupValues();

                }
            }
        private void GetLookupCategories(DataListItemEventArgs e = null)
            {
            try
                {
                DataTable dt = new DataTable();
                dt = cls_Lookup_BAL.Get_LookupCategories_BAL();
                if (dt != null && dt.Rows.Count > 0)
                    {
                    //==============DROPDOWN IN DATA LIST
                    if (e != null)
                        {
                        DropDownList ddl = (DropDownList)e.Item.FindControl("DDL_LOOKUP_CATG_ID_1");
                        if (ddl != null)
                            {
                            ddl.DataSource = dt;
                            ddl.DataTextField = "Catg_Description";
                            ddl.DataValueField = "Lookup_Catg_ID";
                            ddl.DataBind();
                            string catID = DataBinder.Eval(e.Item.DataItem, "LOOKUP_CATG_ID").ToString();
                            ddl.SelectedValue = catID;
                            }
                        }
                    //=============DROPDOWN OUTSIDE DATALIST
                    else
                        {
                        DDL_LOOKUP_CATG_ID.DataSource = dt;
                        DDL_LOOKUP_CATG_ID.DataTextField = "Catg_Description";
                        DDL_LOOKUP_CATG_ID.DataValueField = "Lookup_Catg_ID";
                        DDL_LOOKUP_CATG_ID.DataBind();
                        }
                    }

                }
            catch (Exception ex)
                {

                lblerr.Text = "Get Data - " + ex.Message;
                }
            }
        private void GetLookupValues()
            {
            try
                {
                DataTable dt = new DataTable();
                dt = cls_Lookup_BAL.Get_LookupValues_BAL(Convert.ToInt32(DDL_LOOKUP_CATG_ID.SelectedValue));
                if (dt != null && dt.Rows.Count > 0)
                    {
                    dlentry.DataSource = dt;
                    dlentry.DataBind();
                    }
                else
                    {
                    dlentry.DataSource = null;
                    dlentry.DataBind();
                    }

                }
            catch (Exception ex)
                {

                lblerr.Text = "Get lookup values" + ex.Message;
                }
            }

        protected void DDL_LOOKUP_CATG_ID_SelectedIndexChanged(object sender, EventArgs e)
            {
            try
                {
                GetLookupValues();
                }
            catch (Exception ex)
                {

                lblerr.Text = ex.Message;
                }
            }
        protected void SaveLookupValues()
            {
            try
                {
                LookupValue_Entity objEntity = new LookupValue_Entity();
                objEntity.Lookup_Catg_ID = Convert.ToInt32(DDL_LOOKUP_CATG_ID.SelectedValue);
                objEntity.ValueText = TXT_VALUETEXT.Text;
                objEntity.DisplayText = TXT_DISPLAYTEXT.Text;
                objEntity.FlexField1_Name = TXT_FLEXFIELD1.Text;
                objEntity.FlexField2_Name = TXT_FLEXFIELD2.Text;
                objEntity.FlexField3_Name = TXT_FLEXFIELD3.Text;
                objEntity.FlexField4_Name = TXT_FLEXFIELD4.Text;
                objEntity.FlexField5_Name = TXT_FLEXFIELD5.Text;
                objEntity.IsActive = CHK_ROWACTIVE.Checked;
                objEntity.CreatedBy = 1;
                if (cls_Lookup_BAL.Save_LookupValues_BAL(objEntity) > 0) lblerr.Text = "Record saved";
                else lblerr.Text = "Failed to save the record";
                GetLookupValues();
                }
            catch (Exception ex)
                {
                lblerr.Text = "Save lookup values" + ex.Message;
                }
            }

        protected void btnsave_Click(object sender, EventArgs e)
            {
            SaveLookupValues();
            ClearAll();

            }

        private void ClearAll()
            {
            try
                {
                DDL_LOOKUP_CATG_ID.SelectedValue = "1";
                TXT_DISPLAYTEXT.Text = "";
                TXT_VALUETEXT.Text = "";
                TXT_FLEXFIELD1.Text = "";
                TXT_FLEXFIELD2.Text = "";
                TXT_FLEXFIELD3.Text = "";
                TXT_FLEXFIELD4.Text = "";
                TXT_FLEXFIELD5.Text = "";
                CHK_ROWACTIVE.Checked = false;
                }
            catch (Exception ex)
                {

                lblerr.Text = ex.Message;
                }
            }

        protected void dlentry_ItemCommand(object source, DataListCommandEventArgs e)
            {
            try
                {
                if (e.CommandName == "EDIT")
                    {
                    dlentry.EditItemIndex = e.Item.ItemIndex;
                    GetLookupValues();
                    }
                if (e.CommandName == "CANCEL")
                    {
                    dlentry.EditItemIndex = -1;
                    GetLookupValues();
                    }
                if (e.CommandName == "UPDATE")
                    {

                    LookupValue_Entity objEntity = new LookupValue_Entity();
                    objEntity.Row_ID = Convert.ToInt32(((HiddenField)e.Item.FindControl("hf_rowID")).Value);
                    objEntity.Lookup_Catg_ID = Convert.ToInt32(((DropDownList)e.Item.FindControl("DDL_LOOKUP_CATG_ID_1")).Text);
                    objEntity.ValueText = ((TextBox)e.Item.FindControl("TXT_DISPLAYTEXT_1")).Text.ToString();
                    objEntity.DisplayText = ((TextBox)e.Item.FindControl("TXT_DISPLAYTEXT_1")).Text.ToString();
                    objEntity.FlexField1_Name = ((TextBox)e.Item.FindControl("TXT_FLEXFIELD1_1")).Text.ToString();
                    objEntity.FlexField2_Name = ((TextBox)e.Item.FindControl("TXT_FLEXFIELD2_1")).Text.ToString();
                    objEntity.FlexField3_Name = ((TextBox)e.Item.FindControl("TXT_FLEXFIELD3_1")).Text.ToString();
                    objEntity.FlexField4_Name = ((TextBox)e.Item.FindControl("TXT_FLEXFIELD4_1")).Text.ToString();
                    objEntity.FlexField5_Name = ((TextBox)e.Item.FindControl("TXT_FLEXFIELD5_1")).Text.ToString();
                    objEntity.CreatedBy = 1;
                    objEntity.IsActive = Convert.ToBoolean(((CheckBox)e.Item.FindControl("CHK_ROWACTIVE_1")).Checked);

                    if (cls_Lookup_BAL.Save_LookupValues_BAL(objEntity) > 0) lblerr.Text = "Record saved";
                    else lblerr.Text = "Failed to save the record";

                    GetLookupValues();
                    }

                }
            catch (Exception ex)
                {

                lblerr.Text = "Item command - " + ex.Message;
                }
            }

        protected void dlentry_ItemDataBound(object sender, DataListItemEventArgs e)
            {
            try
                {
                //==========FILL DROPDOWN OF DATALIST
                GetLookupCategories(e);
                //==========FILL CHECK BOX
                if (e.Item.ItemIndex >= 0)
                    {
                    CheckBox chkActive = (CheckBox)e.Item.FindControl("CHK_ROWACTIVE_1");
                    string isActive = DataBinder.Eval(e.Item.DataItem, "ROWACTIVE").ToString();
                    if (chkActive != null) chkActive.Checked = Convert.ToBoolean(isActive);
                    }
                }
            catch (Exception ex)
                {

                lblerr.Text = "Row bound - " + ex.Message;
                }
            }
        }
    }