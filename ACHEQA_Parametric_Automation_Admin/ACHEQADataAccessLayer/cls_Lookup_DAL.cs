using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Jord.ACHEQA.Entities;
using System.Data.SqlClient;

namespace Jord.ACHEQA.DAL
    {
    public class cls_Lookup_DAL
        {
        DBConnect objDB = new DBConnect();
        public string errmsg = string.Empty;
        /// <summary>
        /// GET LLOKUP CATEGORIES
        /// </summary>
        /// <returns></returns>
        public DataTable Get_LookupCategories_DAL()
            {
            try
                {
                return objDB.ExecuteProcForData("[QAACHE].[Get_LookupCategories]", errmsg);
                }
            catch (Exception ex)
                {
                return null;
                throw new Exception(ex.Message);
                }
            }
        /// <summary>
        /// GET LOOKUP VALUES
        /// </summary>
        /// <returns></returns>
        public DataTable Get_LookupValues_DAL(int LcatID)
            {
            try
                {
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@LookupCatID", LcatID);
                return objDB.ExecuteProcForData("[QAACHE].[Get_LookupValues]", errmsg, p);
                }
            catch (Exception ex)
                {
                return null;
                throw new Exception(ex.Message);
                }
            }
        public string Save_LookupCategiries_DAL(LookupCategory_Entity objEntity)
            {
            try
                {
                SqlParameter[] p = new SqlParameter[11];
                p[0] = new SqlParameter("@Lookup_Catg_Name", objEntity.Lookup_Catg_Name);
                p[1] = new SqlParameter("@Catg_Description", objEntity.Catg_Description);
                p[2] = new SqlParameter("@RefClause", objEntity.RefClause);
                p[3] = new SqlParameter("@FlexField1_Name", objEntity.FlexField1_Name);
                p[4] = new SqlParameter("@FlexField2_Name", objEntity.FlexField2_Name);
                p[5] = new SqlParameter("@FlexField3_Name", objEntity.FlexField3_Name);
                p[6] = new SqlParameter("@FlexField4_Name", objEntity.FlexField4_Name);
                p[7] = new SqlParameter("@FlexField5_Name", objEntity.FlexField5_Name);
                p[8] = new SqlParameter("@CREATEDBY", objEntity.CreatedBy);
                p[9] = new SqlParameter("@SORTEXPRESSION", objEntity.SORTEXPRESSION);
                p[10] = new SqlParameter("@Lookup_Catg_ID", objEntity.Lookup_Catg_ID);
                objDB.ExecuteProc("[QAACHE].[Insert_LookupCategory]", p, ref errmsg);
                return (errmsg != "") ? errmsg : "Record Saved";
                }
            catch (Exception ex)
                {


                throw new Exception(ex.Message + "-" + errmsg);
                }

            }
        public string  Save_LookupValues_DAL(LookupValue_Entity objEntity)
            {
            try
                {
                SqlParameter[] p = new SqlParameter[11];
                p[0] = new SqlParameter("@Lookup_Catg_ID", objEntity.Lookup_Catg_ID);
                p[1] = new SqlParameter("@ValueText", objEntity.DisplayText);
                p[2] = new SqlParameter("@DisplayText", objEntity.DisplayText);
                p[3] = new SqlParameter("@FlexField1_Name", objEntity.FlexField1_Name);
                p[4] = new SqlParameter("@FlexField2_Name", objEntity.FlexField2_Name);
                p[5] = new SqlParameter("@FlexField3_Name", objEntity.FlexField3_Name);
                p[6] = new SqlParameter("@FlexField4_Name", objEntity.FlexField4_Name);
                p[7] = new SqlParameter("@FlexField5_Name", objEntity.FlexField5_Name);
                p[8] = new SqlParameter("@CREATEDBY", objEntity.CreatedBy);
                p[9] = new SqlParameter("@isActive", objEntity.IsActive);
                p[10] = new SqlParameter("@Row_ID", objEntity.Row_ID );

                 objDB.ExecuteProc("[QAACHE].[Insert_LookupValues]", p, ref errmsg);
                return (errmsg != "") ? errmsg : "Record Saved";
                }
            catch (Exception ex)
                {

                
                throw new Exception(ex.Message);
                }

            }
        }
    }
