using Jord.ACHEQA.DAL;
using Jord.ACHEQA.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Jord.ACHEQA.BAL
{
    public class clsProcedureNotes_BAL
    {
        private string _ConnectionString = string.Empty;

        public clsProcedureNotes_BAL()
        {
           //this is a test line....
        }

        public int InsertUpdateProcedureNotes(ProcedureNotes_Entity objPN)
        {
            clsProcedureNotes_DAL objALDAL = new clsProcedureNotes_DAL();
            return objALDAL.InsertUpdateProcedureNotes(objPN);
        }

        public int InsertUpdateProcedureNotesLines(ProcNotes_Lines_Entity objPNL)
        {
            clsProcedureNotes_DAL objALDAL = new clsProcedureNotes_DAL();
            return objALDAL.InsertUpdateProcedureNotesLines(objPNL);
        }

        public int UpdateProcedureNotesLineNumber(int ProcNotes_Line_ID, int LineNumber, int LastUpdatedBy)
        {
            clsProcedureNotes_DAL objALDAL = new clsProcedureNotes_DAL();
            return objALDAL.UpdateProcedureNotesLineNumber(ProcNotes_Line_ID, LineNumber, LastUpdatedBy);
        }

        public DataTable GetAllProcNotes()
        {
            clsProcedureNotes_DAL objALDAL = new clsProcedureNotes_DAL();
            return objALDAL.GetAllProcNotes();
        }

        public DataTable GetProcNotesByProcID(int Proc_ID)
        {
            clsProcedureNotes_DAL objALDAL = new clsProcedureNotes_DAL();
            return objALDAL.GetProcNotesByProcID(Proc_ID);
        }

        public int GetCountOfProc_ID(int Proc_ID)
        {
            clsProcedureNotes_DAL objALDAL = new clsProcedureNotes_DAL();
            return objALDAL.GetCountOfProc_ID(Proc_ID);
        }

        public int GetCountOfChildNodes(int ProcNotes_ID)
        {
            clsProcedureNotes_DAL objALDAL = new clsProcedureNotes_DAL();
            return objALDAL.GetCountOfChildNodes(ProcNotes_ID);
        }

        public int GetCountOfProcNotes_IDInParentID(int ProcNotes_ID)
        {
            clsProcedureNotes_DAL objALDAL = new clsProcedureNotes_DAL();
            return objALDAL.GetCountOfProcNotes_IDInParentID(ProcNotes_ID);
        }

        public int GetMaxSequenceNumber(int ProcNotes_ID)
        {
            clsProcedureNotes_DAL objALDAL = new clsProcedureNotes_DAL();
            return objALDAL.GetMaxSequenceNumber(ProcNotes_ID);
        }

        public int GetSNO(int ProcNotes_ID)
        {
            clsProcedureNotes_DAL objALDAL = new clsProcedureNotes_DAL();
            return objALDAL.GetSNO(ProcNotes_ID);
        }

        public int GetMaxSeqNum(int ProcNotes_ID)
        {
            clsProcedureNotes_DAL objALDAL = new clsProcedureNotes_DAL();
            return objALDAL.GetMaxSeqNum(ProcNotes_ID);
        }

        public int GetMaxLineNumber(int ProcNotes_ID)
        {
            clsProcedureNotes_DAL objALDAL = new clsProcedureNotes_DAL();
            return objALDAL.GetMaxLineNumber(ProcNotes_ID);
        }

        public DataTable GetProcNoteLinesByProcNoteID(int ProcNotes_ID)
        {
            clsProcedureNotes_DAL objALDAL = new clsProcedureNotes_DAL();
            return objALDAL.GetProcNoteLinesByProcNoteID(ProcNotes_ID);
        }

        public DataTable GetProcReportData(int Proc_ID)
        {
            clsProcedureNotes_DAL objALDAL = new clsProcedureNotes_DAL();
            return objALDAL.GetProcReportData(Proc_ID);
        }
    }
}
