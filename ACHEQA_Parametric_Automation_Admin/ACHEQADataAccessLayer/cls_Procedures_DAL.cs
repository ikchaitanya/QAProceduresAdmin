using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Jord.ACHEQA.Entities;

namespace Jord.ACHEQA.DAL
    {
  public   class cls_Procedures_DAL
        {
            public string errmsg = string.Empty;
            public DataTable Get_Procedures_DAL(int tagID = 0)
            {
                try
                {
                    DBConnect objDB = new DBConnect();
                    SqlParameter[] p = new SqlParameter[1];
                    p[0] = new SqlParameter("@DesignSetID", tagID);
                    return objDB.ExecuteProcForData("[QAACHE].[Get_ProcedureList]", errmsg, p);
                }
                catch (Exception ex)
                {
                    return null;
                    throw new Exception(ex.Message);
                }
            }
            public DataTable Get_ProceduresNotes_DAL(string Proc_ID)
            {
                try
                {
                    DBConnect objDB = new DBConnect();
                    SqlParameter[] p = new SqlParameter[1];

                    p[0] = new SqlParameter("@Proc_ID", Proc_ID);
                    return objDB.ExecuteProcForData("[QAACHE].[Get_ProcNotes]", errmsg, p);
                }
                catch (Exception ex)
                {
                    return null;
                    throw new Exception(ex.Message);
                }
            }
            public string Save_Procedures_DAL(DataTable ProcList)
            {
                try
                {
                    DBConnect objDB = new DBConnect();
                    objDB.ExecuteProc("[QAACHE].Insert_ProcList", ProcList, ref errmsg);
                    return (errmsg != "") ? errmsg : "Record Saved";
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            public string Save_ProcRefClause_DAL(DataTable ProcRefList)
            {
                try
                {
                    DBConnect objDB = new DBConnect();
                    objDB.ExecuteProc("[QAACHE].[Insert_ProcRefClause]", ProcRefList, ref errmsg);
                    return (errmsg != "") ? errmsg : "Record Saved";
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            public void Delete_ProcRefClause_DAL(int varID)
            {
                try
                {
                    DBConnect objDB = new DBConnect();
                    SqlParameter[] p = new SqlParameter[1];

                    p[0] = new SqlParameter("@VarID", varID);
                    objDB.ExecuteProc("[QAACHE].[Delete_ProcRefClause]", p, ref errmsg);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            public DataTable Get_ProcRefClause_DAL(int varID)
            {
                try
                {
                    DBConnect objDB = new DBConnect();
                    SqlParameter[] p = new SqlParameter[1];

                    p[0] = new SqlParameter("@Var_ID", varID);
                    return objDB.ExecuteProcForData("[QAACHE].[Get_ProcRefClause]", errmsg, p);
                }
                catch (Exception ex)
                {
                    return null;
                    throw new Exception(ex.Message);
                }
            }
        }
    }
