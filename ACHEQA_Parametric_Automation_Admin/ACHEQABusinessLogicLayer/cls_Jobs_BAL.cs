using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jord.ACHEQA.DAL;
using System.Data;

namespace Jord.ACHEQA.BAL
    {
    public static class cls_Jobs_BAL
        {
        public static DataTable Get_Jobs_BAL()
            {
            try
                {
                cls_Jobs_DAL objdal = new cls_Jobs_DAL();
                return objdal.Get_Jobs_DAL();

                }
            catch (Exception ex)
                {
                return null;
                throw new Exception(ex.Message);
                }
            }
        }
    }
