using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Jord.ACHEQA.Entities;
using System.Data;

namespace Jord.ACHEQA.DAL
    {
    public class cls_Jobs_DAL
        {
        DBConnect objDB = new DBConnect();
        public string errmsg = string.Empty;
        /// <summary>
        /// Inser details of new job
        /// </summary>
        /// <param name="objEntity"></param>
        /// <returns></returns>
        public int InsertJobsDAL(Job_Entity objEntity)
            {
            try
                {
                int recordID = 0;
                SqlParameter[] p = new SqlParameter[3];

                //p[0] = new SqlParameter("@CurdAction",objEntity.);
                p[0] = new SqlParameter("@JobNo", objEntity.JobNumber);
                p[1] = new SqlParameter("@ProjectName", objEntity.Project);
                p[2] = new SqlParameter("@Customer", objEntity.Customer);
                p[3] = new SqlParameter("@CreatedBy", objEntity.CreatedBy);
                p[4] = new SqlParameter("@id", 0);
                p[4].Direction = ParameterDirection.Output;

                objDB.ExecuteProc("QAACHE.[QA_InsertUpdate_JobDetails]", p, ref errmsg);
                recordID = Convert.ToInt32(p[4].Value);
                return recordID;
                }
            catch (Exception ex)
                {
                throw new Exception(ex.Message);
                }
            }
        public DataTable Get_Jobs_DAL()
            {
            try
                {
                return objDB.ExecuteProcForData("[QAACHE].[Get_JobDetails]", errmsg);
                }
            catch (Exception ex)
                {
                return null;
                throw new Exception(ex.Message);
                }
            }
        }
    }
