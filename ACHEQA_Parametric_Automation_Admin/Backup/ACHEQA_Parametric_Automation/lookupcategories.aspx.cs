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
    public partial class lookupcategories : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            if (!IsPostBack)
                {
                GetLookupCategories();

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
                    dlentry.DataSource = dt;
                    dlentry.DataBind();
                    }

                }
            catch (Exception ex)
                {

                lblerr.Text = "Get Data - " + ex.Message;
                }
            }

        protected void dlentry_ItemCommand(object source, DataListCommandEventArgs e)
            {
            try
                {
                if (e.CommandName == "EDIT")
                    {
                    dlentry.EditItemIndex = e.Item.ItemIndex;
                    GetLookupCategories();
                    }
                if (e.CommandName == "CANCEL")
                    {
                    dlentry.EditItemIndex = -1;
                    GetLookupCategories();
                    }
                if (e.CommandName == "UPDATE")
                    {
                    string sortExp = ((DropDownList)e.Item.FindControl("DDL_SORTEXPRESSION")).SelectedItem.ToString() + " " + ((DropDownList)e.Item.FindControl("ddl_direction")).SelectedItem.ToString();
                    LookupCategory_Entity objEntity = new LookupCategory_Entity();
                    objEntity.Lookup_Catg_ID = Convert.ToInt32( ((HiddenField)e.Item.FindControl("hf_nlookupcatid")).Value);
                    objEntity.Lookup_Catg_Name = ((TextBox)e.Item.FindControl("TXT_LOOKUP_CATG_NAME_1")).Text.ToString();
                    objEntity.Catg_Description = ((TextBox)e.Item.FindControl("TXT_CATG_DESCRIPTION_1")).Text.ToString();
                    objEntity.RefClause = ((TextBox)e.Item.FindControl("TXT_REF_CLAUSE_1")).Text.ToString();
                    objEntity.FlexField1_Name = ((TextBox)e.Item.FindControl("TXT_FLEXFIELD1_NAME_1")).Text.ToString();
                    objEntity.FlexField2_Name = ((TextBox)e.Item.FindControl("TXT_FLEXFIELD2_NAME_1")).Text.ToString();
                    objEntity.FlexField3_Name = ((TextBox)e.Item.FindControl("TXT_FLEXFIELD3_NAME_1")).Text.ToString();
                    objEntity.FlexField4_Name = ((TextBox)e.Item.FindControl("TXT_FLEXFIELD4_NAME_1")).Text.ToString();
                    objEntity.FlexField5_Name = ((TextBox)e.Item.FindControl("TXT_FLEXFIELD5_NAME_1")).Text.ToString();
                    objEntity.CreatedBy = 1;
                    objEntity.SORTEXPRESSION = sortExp;
                    if (cls_Lookup_BAL.Save_LookupCategiries_BAL(objEntity) > 0) lblerr.Text = "Record saved";
                    else lblerr.Text = "Failed to save the record";

                    GetLookupCategories();
                    }
                }
            catch (Exception ex)
                {

                lblerr.Text = "Item command - " + ex.Message;
                }
            }

        protected void btnsave_Click(object sender, EventArgs e)
            {
            SaveLookupCategories();
            ClearAll();
            }
        private void ClearAll()
            {
            try
                {
                TXT_CATG_DESCRIPTION.Text = "";
                TXT_LOOKUP_CATG_NAME.Text = "";
                TXT_REF_CLAUSE.Text = "";                
                TXT_FLEXFIELD1_NAME.Text = "";
                TXT_FLEXFIELD2_NAME.Text = "";
                TXT_FLEXFIELD3_NAME.Text = "";
                TXT_FLEXFIELD4_NAME.Text = "";
                TXT_FLEXFIELD5_NAME.Text = "";
                DDL_SORTEXPRESSION.SelectedValue = "1";
                ddl_direction.SelectedValue = "1";

                }
            catch (Exception ex)
                {

                lblerr.Text = ex.Message;
                }
            }
        private void SaveLookupCategories()
            {
            try
                {
                LookupCategory_Entity objEntity = new LookupCategory_Entity();

                objEntity.Lookup_Catg_Name = TXT_LOOKUP_CATG_NAME.Text;
                objEntity.Catg_Description = TXT_CATG_DESCRIPTION.Text;
                objEntity.RefClause = TXT_REF_CLAUSE.Text;
                objEntity.FlexField1_Name = TXT_FLEXFIELD1_NAME.Text;
                objEntity.FlexField2_Name = TXT_FLEXFIELD2_NAME.Text;
                objEntity.FlexField3_Name = TXT_FLEXFIELD3_NAME.Text;
                objEntity.FlexField4_Name = TXT_FLEXFIELD4_NAME.Text;
                objEntity.FlexField5_Name = TXT_FLEXFIELD5_NAME.Text;
                objEntity.CreatedBy = 1;
                objEntity.SORTEXPRESSION = DDL_SORTEXPRESSION.Text + " " + ddl_direction.Text;
                if (cls_Lookup_BAL.Save_LookupCategiries_BAL(objEntity) > 0) lblerr.Text = "Record saved";
                else lblerr.Text = "Failed to save the record";
                GetLookupCategories();
                }
            catch (Exception ex)
                {

                lblerr.Text = "Save - " + ex.Message;
                }
            }

        protected void dlentry_ItemDataBound(object sender, DataListItemEventArgs e)
            {
            try
                {
                if (e.Item.ItemIndex >= 0)
                    {
                    string SortEXP = DataBinder.Eval(e.Item.DataItem, "SORTEXPRESSION").ToString();
                    if (SortEXP != "")
                        {
                        string[] se = new string[2];
                        se = SortEXP.Split(' ');
                        if ((DropDownList)e.Item.FindControl("DDL_SORTEXPRESSION") != null) ((DropDownList)e.Item.FindControl("DDL_SORTEXPRESSION")).SelectedItem.Text = se[0];
                        if ((DropDownList)e.Item.FindControl("ddl_direction") != null) ((DropDownList)e.Item.FindControl("ddl_direction")).SelectedItem.Text = se[1];
                        }                    
                    }
                }
            catch (Exception ex)
                {

                lblerr.Text = "Data Bound - " + ex.Message;
                }
            }
        }
    }