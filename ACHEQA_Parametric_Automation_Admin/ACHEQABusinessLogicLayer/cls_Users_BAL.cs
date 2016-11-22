using Jord.ACHEQA.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Jord.ACHEQA.BAL
{
    public class cls_Users_BAL
    {
        public static DataTable UserAuthentication_BAL(string dominoUserName)
        {
            try
            {
                cls_Users_DAL objdal = new cls_Users_DAL();
                return objdal.UserAuthentication_DAL(dominoUserName);
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception(ex.Message);
            }
        }

        public string GetFullName(string UserName)
        {
            cls_Users_DAL objdal = new cls_Users_DAL();
            return objdal.GetFullName(UserName);
        }

        public int GetUserID(string UserName)
        {
            cls_Users_DAL objdal = new cls_Users_DAL();
            return objdal.GetUserID(UserName);
        }
    }
}
