using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Jord.ACHEQA.DAL;

namespace Jord.ACHEQA.BAL
    {
     public class cls_Procedures_BAL
        {
            public static DataTable Get_Procedures_BAL(int tagID = 0)
            {
                try
                {
                    cls_Procedures_DAL objdal = new cls_Procedures_DAL();

                    return objdal.Get_Procedures_DAL(tagID);

                }
                catch (Exception ex)
                {
                    return null;
                    throw new Exception(ex.Message);
                }
            }
            public static DataTable Get_ProceduresNotes_BAL(string Proc_ID)
            {
                try
                {
                    cls_Procedures_DAL objdal = new cls_Procedures_DAL();

                    return objdal.Get_ProceduresNotes_DAL(Proc_ID);

                }
                catch (Exception ex)
                {
                    return null;
                    throw new Exception(ex.Message);
                }
            }
            public static string Save_Procedures_BAL(DataTable ProcList)
            {
                try
                {
                    cls_Procedures_DAL objdal = new cls_Procedures_DAL();
                    return objdal.Save_Procedures_DAL(ProcList);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            public static string Save_ProcRefClause_BAL(DataTable ProcRefList)
            {
                try
                {
                    cls_Procedures_DAL objdal = new cls_Procedures_DAL();
                    return objdal.Save_ProcRefClause_DAL(ProcRefList);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            public static void Delete_ProcRefClause_BAL(int varID)
            {
                try
                {
                    cls_Procedures_DAL objdal = new cls_Procedures_DAL();
                    objdal.Delete_ProcRefClause_DAL(varID);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            public static DataTable Get_ProcRefClause_DAL(int varID)
            {
                try
                {
                    cls_Procedures_DAL objdal = new cls_Procedures_DAL();
                    return objdal.Get_ProcRefClause_DAL(varID);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
        }
    }
