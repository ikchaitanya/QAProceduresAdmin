using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Jord.ACHEQA.Entities;

namespace Jord.ACHEQA.DAL
    {
  public   class cls_InputVariable_DAL
        {
        public string errmsg = string.Empty;
        public DataTable Get_InputVariable_DAL(string procInit)
            {
            try
                {
                DBConnect objDB = new DBConnect();
                SqlParameter[] p = new SqlParameter[1];

                p[0] = new SqlParameter("@ProcInit", procInit);
                
                return objDB.ExecuteProcForData("[QAACHE].[Get_ProcInputVariables]", errmsg, p);
                }
            catch (Exception ex)
                {
                return null;
                throw new Exception(ex.Message);
                }
            }

        public string  Save_InputVariable_DAL(InputVariable_Entity objEntity,ref string errmsg)
            {
            try
                {
                DBConnect objDB = new DBConnect();
                SqlParameter[] p = new SqlParameter[9];
                p[0] = new SqlParameter("@ProcInitial", objEntity.ProcInitial );
                p[1] = new SqlParameter("@LookupCatID", objEntity.LookupCatID );
                p[2] = new SqlParameter("@VariableName", objEntity.VariableName);
                p[3] = new SqlParameter("@DisplayName", objEntity.DisplayName);
                p[4] = new SqlParameter("@ControlType", objEntity.ControlType);
                //p[5] = new SqlParameter("@SeqNo", objEntity.SeqNo);
                p[5] = new SqlParameter("@CREATEDBY", objEntity.CreatedBy);
                p[6] = new SqlParameter("@isActive", objEntity.IsActive) ;
                p[7] = new SqlParameter("@IsRequried", objEntity.IsRequried );
                p[8] = new SqlParameter("@VarID", objEntity.VarID );
               
                 objDB.ExecuteProc("[QAACHE].[Insert_ProcInputVariables]", p, ref errmsg);
                 return (errmsg != "") ? errmsg : "Record Saved";
                }
            catch (Exception ex)
                {

                throw new Exception(ex.Message);
                }
            }
        }
    }
