using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Jord.ACHEQA.DAL
{
    public class DBConnect : IDisposable
    {
        SqlConnection con = new SqlConnection();
        string constr = string.Empty;
        private String globalErrormsg;

        public DBConnect()
        {
            constr = ConfigurationManager.ConnectionStrings["QAConnection"].ConnectionString;
        }

        public int ExecuteProc(string procname, SqlParameter[] p, ref string exmsg)
        {

            int functionReturnValue = 0;
            try
            {


                SqlCommand sqlcom = new SqlCommand(procname, con);
                sqlcom.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i <= p.Length - 1; i++)
                {
                    sqlcom.Parameters.Add(p[i]);
                }
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = constr;
                    con.Open();
                }
                functionReturnValue = sqlcom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                con.Close();
                exmsg = ex.Message;
                throw new Exception(ex.Message);
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return functionReturnValue;
        }

        public DataTable ExecuteProcForData(String procname, String exmsg, SqlParameter[] p = null)
        {
            DataTable functionReturnValue = null;
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = constr;
                    con.Open();
                }
                SqlCommand sqlcom = new SqlCommand(procname, con);
                sqlcom.CommandType = CommandType.StoredProcedure;

                if (p != null)
                {
                    for (int i = 0; i <= p.Length - 1; i++)
                    {
                        sqlcom.Parameters.Add(p[i]);
                    }
                }

                SqlDataAdapter sqladap = new SqlDataAdapter(sqlcom);
                DataSet objDataset = new DataSet();
                sqladap.Fill(objDataset, "tbl");
                con.Close();
                functionReturnValue = objDataset.Tables[0];
                objDataset = null;
            }
            catch (Exception ex)
            {
                con.Close();
                exmsg = ex.Message;
                throw new Exception(ex.Message);

            }
            //con.Close();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return functionReturnValue;
        }

        //public SqlDataReader Read(string str)
        //{
        //    SqlDataReader dr = null;

        //    try
        //    {
        //        con.ConnectionString = constr;
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand(str, con);
        //        dr = cmd.ExecuteReader();

        //        //if (con.State == ConnectionState.Closed)
        //        //{
        //        //    con.Open();
        //        //    dr = cmd.ExecuteReader();
        //        //}
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return dr;
        //}

        public string ExecNonQryStr(string qry)
        {
            string functionReturnValue = null;
            SqlCommand com = new SqlCommand();
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = constr;
                    con.Open();
                }
                com.Connection = con;
                com.CommandText = qry;
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                functionReturnValue = null;
                throw new Exception(ex.Message);
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return functionReturnValue;
        }

        public DataTable ExecQryStr(string qry, string err_msg = "")
        {
            DataTable functionReturnValue = null;
            DataSet objDataset = new DataSet();

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = constr;
                    con.Open();
                }

            }
            catch (Exception ex)
            {
                con.Close();
                globalErrormsg = ex.Message;
                functionReturnValue = null;
                throw new Exception(ex.Message);
                //return functionReturnValue;
            }


            SqlDataAdapter objAdap = new SqlDataAdapter(qry, con);

            try
            {
                objAdap.Fill(objDataset, "tbl");

                functionReturnValue = objDataset.Tables[0];
            }
            catch (Exception ex)
            {
                con.Close();
                functionReturnValue = null;
                throw new Exception(ex.Message);
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return functionReturnValue;
        }

        public string ExecScalarStr(string qry)
        {
            string functionReturnValue = null;

            SqlConnection conn = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.CommandType = CommandType.Text;
            try
            {
                conn.Open();
                functionReturnValue = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return functionReturnValue;
        }

        public string ExecuteProcForScalar(string procname, SqlParameter[] p, ref string exmsg)
        {
            int functionReturnValue = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = constr;
                    con.Open();
                }
                SqlCommand sqlcom = new SqlCommand(procname, con);
                sqlcom.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i <= p.Length - 1; i++)
                {
                    sqlcom.Parameters.Add(p[i]);
                }

                functionReturnValue = Convert.ToInt32(sqlcom.ExecuteScalar());
            }
            catch (Exception ex)
            {
                con.Close();
                exmsg = ex.Message;
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return functionReturnValue.ToString();
        }

        public int ExecuteProcForScalarInt(string procname, SqlParameter[] p, ref string exmsg)
        {
            int functionReturnValue = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = constr;
                    con.Open();
                }
                SqlCommand sqlcom = new SqlCommand(procname, con);
                sqlcom.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i <= p.Length - 1; i++)
                {
                    sqlcom.Parameters.Add(p[i]);
                }

                functionReturnValue = Convert.ToInt32(sqlcom.ExecuteScalar());
            }
            catch (Exception ex)
            {
                exmsg = ex.Message;
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return functionReturnValue;
        }

        public int ExecuteProc(string procname, DataTable dtable, ref string exmsg)
        {
            int functionReturnValue = 0;
            try
            {

                con.ConnectionString = constr;
                SqlParameter[] p;
                p = new SqlParameter[Convert.ToInt32(dtable.Columns.Count)];
                string paraName, paraValue, qstring;

                con.Open();
                using (TransactionScope scope = new TransactionScope())
                {
                    for (byte dtrows = 0; dtrows < dtable.Rows.Count; dtrows++)
                    {
                        SqlCommand sqlcom = new SqlCommand(procname, con);
                        sqlcom.CommandType = CommandType.StoredProcedure;
                        for (byte dtcol = 0; dtcol < dtable.Columns.Count; dtcol++)
                        {

                            //p = new SqlParameter[Convert.ToInt32(dtable.Columns.Count)];
                            paraName = "@" + dtable.Columns[dtcol].Caption.ToString();
                            paraValue = dtable.Rows[dtrows][dtcol].ToString();
                            p[dtcol] = new SqlParameter(paraName, paraValue);
                            sqlcom.Parameters.Add(p[dtcol]);
                        }
                        functionReturnValue = sqlcom.ExecuteNonQuery();
                    }
                    //SAVE GRAND TOTAL TO TABLE

                    scope.Complete();
                }


            }

            catch (Exception ex)
            {
                con.Close();
                exmsg = ex.Message;
                throw new Exception(ex.Message);
            }
            con.Close();
            return functionReturnValue;
        }

        public string ExecuteProcForScalarString(string procname, SqlParameter[] p, ref string exmsg)
        {
            string functionReturnValue = string.Empty;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = constr;
                    con.Open();
                }
                SqlCommand sqlcom = new SqlCommand(procname, con);
                sqlcom.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i <= p.Length - 1; i++)
                {
                    sqlcom.Parameters.Add(p[i]);
                }

                functionReturnValue = sqlcom.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                exmsg = ex.Message;
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return functionReturnValue.ToString();
        }
        public double ExecuteProcForScalarDouble(string procname, SqlParameter[] p, ref string exmsg)
        {
            double functionReturnValue = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = constr;
                    con.Open();
                }
                SqlCommand sqlcom = new SqlCommand(procname, con);
                sqlcom.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i <= p.Length - 1; i++)
                {
                    sqlcom.Parameters.Add(p[i]);
                }

                functionReturnValue = Convert.ToDouble(sqlcom.ExecuteScalar());
            }
            catch (Exception ex)
            {
                exmsg = ex.Message;
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return functionReturnValue;
        }

        ~DBConnect()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
