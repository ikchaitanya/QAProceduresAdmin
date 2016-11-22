using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Jord.ACHEQA.DAL;
using Jord.ACHEQA.Entities;

namespace Jord.ACHEQA.BAL
    {
  public static   class cls_InputVariable_BAL
        {
      public static DataTable Get_InputVariable_BAL(string procInit)
            {
            try
                {
                cls_InputVariable_DAL objdal = new cls_InputVariable_DAL();
                return objdal.Get_InputVariable_DAL(procInit);
                }
            catch (Exception ex)
                {
                return null;
                throw new Exception(ex.Message);
                }
            }
      public static string Save_InputVariable_BAL(InputVariable_Entity objEntity, ref string errmsg)
            {
            try
                {
                cls_InputVariable_DAL objdal = new cls_InputVariable_DAL();
                 return objdal.Save_InputVariable_DAL(objEntity, ref errmsg );
                }
            catch (Exception ex)
                {

                return "Error in saving";
                throw new Exception(ex.Message);
                }
            }
        }
    }
