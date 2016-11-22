using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Jord.ACHEQA.DAL
{
    public class cls_Users_DAL
    {
        DBConnect objDB = new DBConnect();
        public string errmsg = string.Empty;
        public DataTable UserAuthentication_DAL(string dominoUserName)
        {
            try
            {
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@dominoUserName", dominoUserName);
                return objDB.ExecuteProcForData("[QAACHE].[GetQAUsersByUserName]", errmsg, p);

            }
            catch (Exception ex)
            {
                return null;
                throw new Exception(ex.Message);
            }
        }

        public string GetFullName(string UserName)
        {
            string functionReturnValue;
            string sql = null;
            sql = "SELECT UserFullName FROM dbo.Users WHERE dominousername='" + UserName + "'";
            functionReturnValue = objDB.ExecScalarStr(sql);
            return functionReturnValue;
        }

        public int GetUserID(string UserName)
        {
            int functionReturnValue;
            string sql = null;
            sql = "SELECT userid FROM dbo.Users WHERE dominousername='" + UserName + "'";
            functionReturnValue = Convert.ToInt32(objDB.ExecScalarStr(sql));
            return functionReturnValue;
        }
    }
}
