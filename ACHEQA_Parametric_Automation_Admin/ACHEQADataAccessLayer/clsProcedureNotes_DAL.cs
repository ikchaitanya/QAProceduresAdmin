using Jord.ACHEQA.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Jord.ACHEQA.DAL
{
    public class clsProcedureNotes_DAL
    {
        public String errmsg = string.Empty;
        private string _ConnectionString = string.Empty;
        DBConnect objDB;

        public clsProcedureNotes_DAL()
        {
            objDB = new DBConnect();
        }

        public int InsertUpdateProcedureNotes(ProcedureNotes_Entity objPN)
        {
            try
            {
                int ReturnID;
                int OutputProcNotes_ID = 0;
                errmsg = string.Empty;
                System.Data.SqlClient.SqlParameter[] p = new SqlParameter[11];

                p[0] = new SqlParameter("@ProcNotes_ID", objPN.ProcNotes_ID);
                p[1] = new SqlParameter("@Proc_ID", objPN.Proc_ID);
                p[2] = new SqlParameter("@ParentID", objPN.ParentID);
                p[3] = new SqlParameter("@SerialNumber", objPN.SerialNumber);
                p[4] = new SqlParameter("@Notes", objPN.Notes);
                p[5] = new SqlParameter("@CreatedBy", objPN.CreatedBy);
                p[6] = new SqlParameter("@LastUpdatedBy", objPN.LastUpdatedBy);
                p[7] = new SqlParameter("@SequenceNumber", objPN.SequenceNumber);
                p[8] = new SqlParameter("@SNO", objPN.SNO);
                p[9] = new SqlParameter("@SeqNum", objPN.SeqNum);
                p[10] = new SqlParameter("@OutputProcNotes_ID", OutputProcNotes_ID);
                p[10].Direction = ParameterDirection.Output;
                ReturnID = objDB.ExecuteProc("QAACHE.INS_UPD_ProcNotes", p, ref errmsg);
                OutputProcNotes_ID = Convert.ToInt32(p[10].Value);
                return OutputProcNotes_ID;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Creating / Updating Procedure Notes _ DAL " + ex.Message);
            }
        }

        public int InsertUpdateProcedureNotesLines(ProcNotes_Lines_Entity objPNL)
        {
            try
            {
                int ReturnID;
                int OutputProcNotes_Line_ID = 0;
                errmsg = string.Empty;
                System.Data.SqlClient.SqlParameter[] p = new SqlParameter[10];

                p[0] = new SqlParameter("@ProcNotes_Line_ID", objPNL.ProcNotes_Line_ID);
                p[1] = new SqlParameter("@ProcNotes_ID", objPNL.ProcNotes_ID);
                p[2] = new SqlParameter("@LineNumber", objPNL.LineNumber);
                p[3] = new SqlParameter("@Notes_Type", objPNL.Notes_Type);
                p[4] = new SqlParameter("@Notes", objPNL.Notes);
                p[5] = new SqlParameter("@Notes_Binary", objPNL.Notes_Binary);
                p[6] = new SqlParameter("@IsActive", objPNL.IsActive);
                p[7] = new SqlParameter("@CreatedBy", objPNL.CreatedBy);
                p[8] = new SqlParameter("@LastUpdatedBy", objPNL.LastUpdatedBy);
                p[9] = new SqlParameter("@OutputProcNotes_Line_ID", OutputProcNotes_Line_ID);
                p[9].Direction = ParameterDirection.Output;
                ReturnID = objDB.ExecuteProc("QAACHE.INS_UPD_ProcNotes_Lines", p, ref errmsg);
                OutputProcNotes_Line_ID = Convert.ToInt32(p[9].Value);
                return OutputProcNotes_Line_ID;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Creating / Updating Procedure Notes Lines _ DAL " + ex.Message);
            }
        }

        public int UpdateProcedureNotesLineNumber(int ProcNotes_Line_ID, int LineNumber, int LastUpdatedBy)
        {
            try
            {
                int ReturnID;
                int OutputProcNotes_Line_ID = 0;
                errmsg = string.Empty;
                System.Data.SqlClient.SqlParameter[] p = new SqlParameter[4];

                p[0] = new SqlParameter("@ProcNotes_Line_ID", ProcNotes_Line_ID);
                p[1] = new SqlParameter("@LineNumber", LineNumber);
                p[2] = new SqlParameter("@LastUpdatedBy", LastUpdatedBy);
                p[3] = new SqlParameter("@OutputProcNotes_Line_ID", OutputProcNotes_Line_ID);
                p[3].Direction = ParameterDirection.Output;
                ReturnID = objDB.ExecuteProc("QAACHE.UPD_ProcNotes_LineNumber", p, ref errmsg);
                OutputProcNotes_Line_ID = Convert.ToInt32(p[3].Value);
                return OutputProcNotes_Line_ID;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Updating Procedure Notes Line Number _ DAL " + ex.Message);
            }
        }

        public DataTable GetAllProcNotes()
        {
            string errmsg = string.Empty;
            DataTable dt;
            try
            {
                System.Data.SqlClient.SqlParameter[] p = new SqlParameter[0];

                dt = objDB.ExecuteProcForData("QAACHE.GetAllProcNotes", errmsg, p);

                objDB = null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting All Proc Notes - DAL " + ex.Message);
            }

            return dt;
        }

        public DataTable GetProcNotesByProcID(int Proc_ID)
        {
            string errmsg = string.Empty;
            DataTable dt;
            try
            {
                System.Data.SqlClient.SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Proc_ID", Proc_ID);

                dt = objDB.ExecuteProcForData("QAACHE.GetProcNotesByProcID", errmsg, p);

                objDB = null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting GetProcNotesByProcID - DAL " + ex.Message);
            }

            return dt;
        }

        public DataTable GetProcNoteLinesByProcNoteID(int ProcNotes_ID)
        {
            string errmsg = string.Empty;
            DataTable dt;
            try
            {
                System.Data.SqlClient.SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@ProcNotes_ID", ProcNotes_ID);

                dt = objDB.ExecuteProcForData("QAACHE.GetProcNoteLinesByProcNoteID", errmsg, p);

                objDB = null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting GetProcNoteLinesByProcNoteID - DAL " + ex.Message);
            }

            return dt;
        }

        public int GetCountOfProc_ID(int Proc_ID)
        {
            int functionReturnValue = 0;
            string sql = null;
            sql = "Select Count(Proc_ID) From QAACHE.mst_ProcNotes Where Proc_ID=" + Proc_ID + "";
            functionReturnValue = Convert.ToInt32(objDB.ExecScalarStr(sql));
            return functionReturnValue;
        }

        public int GetCountOfChildNodes(int ProcNotes_ID)
        {
            int functionReturnValue = 0;
            string sql = null;
            sql = "Select COUNT(*) From QAACHE.mst_ProcNotes Where ParentID=" + ProcNotes_ID + "";
            functionReturnValue = Convert.ToInt32(objDB.ExecScalarStr(sql));
            return functionReturnValue;
        }

        public int GetCountOfProcNotes_IDInParentID(int ProcNotes_ID)
        {
            int functionReturnValue = 0;
            string sql = null;
            sql = "Select Count(ProcNotes_ID) From QAACHE.mst_ProcNotes Where ParentID=" + ProcNotes_ID + "";
            functionReturnValue = Convert.ToInt32(objDB.ExecScalarStr(sql));
            return functionReturnValue;
        }

        public int GetMaxSequenceNumber(int ProcNotes_ID)
        {
            int functionReturnValue = 0;
            string sql = null;
            sql = "Select MAX(SequenceNumber) FROM QAACHE.mst_ProcNotes Where ProcNotes_ID=(Select ISNULL(Max(ProcNotes_ID)," + ProcNotes_ID + ") FROM QAACHE.mst_ProcNotes Where ParentID=" + ProcNotes_ID + ")";
            functionReturnValue = Convert.ToInt32(objDB.ExecScalarStr(sql));
            return functionReturnValue;
        }

        public int GetSNO(int ProcNotes_ID)
        {
            int functionReturnValue = 0;
            string sql = null;
            sql = "Select SNO FROM QAACHE.mst_ProcNotes Where ProcNotes_ID=" + ProcNotes_ID + "";
            functionReturnValue = Convert.ToInt32(objDB.ExecScalarStr(sql));
            return functionReturnValue;
        }

        /*---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

        public int GetMaxSeqNum(int ProcNotes_ID)
        {
            int functionReturnValue = 0;
            string sql = null;
            sql = "Select MAX(SeqNum) FROM QAACHE.mst_ProcNotes Where ProcNotes_ID=(Select ISNULL(Max(ProcNotes_ID)," + ProcNotes_ID + ") FROM QAACHE.mst_ProcNotes Where ParentID=" + ProcNotes_ID + ")";
            functionReturnValue = Convert.ToInt32(objDB.ExecScalarStr(sql));
            return functionReturnValue;
        }

        /*---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

        public int GetMaxLineNumber(int ProcNotes_ID)
        {
            int functionReturnValue = 0;
            string sql = null;
            sql = "Select ISNULL(Max(LineNumber),0) FROM QAACHE.mst_ProcNotes_Lines Where ProcNotes_ID=" + ProcNotes_ID + "";
            functionReturnValue = Convert.ToInt32(objDB.ExecScalarStr(sql));
            return functionReturnValue;
        }

        public DataTable GetProcReportData(int Proc_ID)
        {
            string errmsg = string.Empty;
            DataTable dt;
            try
            {
                System.Data.SqlClient.SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Proc_ID", Proc_ID);
                dt = objDB.ExecuteProcForData("QAACHE.GetProcReportData", errmsg, p);

                objDB = null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting ProcReportData - DAL " + ex.Message);
            }

            return dt;
        }
    }
}
