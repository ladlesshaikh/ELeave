using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ATTNPAY.Core
{
    public class ProcessOTDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public ProcessOTDAO()
        {
            //conn = new dbConnection();
        }

        /// <method>
        /// Get User Email By Firstname or Lastname and return DalaTable
        /// </method>
        public DataTable searchByName(string _username)
        {
            string query = string.Format("select * from [t01_user] where t01_firstname like @t01_firstname or t01_lastname like @t01_lastname ");
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@t01_firstname", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_username);
            sqlParameters[1] = new SqlParameter("@t01_lastname", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(_username);
            //return conn.executeSelectQuery(query, sqlParameters);
            return null;
        }

        /// <method>
        /// Get User Email By Id and return DalaTable
        /// </method>
        public DataTable searchById(string _id)
        {
            string query = "select * from [t01_id] where t01_id = @t01_id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@t01_id", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_id);
            //return conn.executeSelectQuery(query, sqlParameters);
            return null;
        }
        #region GetEmployeeList
        private DataTable GetEmployeeList()
        {
            try
            {
                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT Relationship_Id,Relationship_Name,Activate FROM MASTER_RELATIONSHIP";
                    return SQLHelper.ShowRecord(strSQL);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridDT
        private DataTable LoadDataGridDT()
        {
            try
            {
                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT Branch_ID,Branch_Name FROM MASTER_BRANCH WHERE Company_Id='1'";
                    return SQLHelper.ShowRecord(strSQL);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region  CheckData
        private bool CheckData(string GroupName, string strFlag, string strRowId)
        {
            try
            {
                DataTable dt = new DataTable();
                if (strFlag == "A")
                {
                    strSQL = "SELECT Relationship_Name FROM MASTER_RELATIONSHIP WHERE REPLACE(Relationship_Name,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT Relationship_Id,Relationship_Name FROM MASTER_RELATIONSHIP WHERE REPLACE(Relationship_Name,' ','') = REPLACE('" + GroupName + "',' ','') AND Relationship_Id='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["MEM_CODE"].ToString().Trim())
                        {
                            //Duplicate Employee Enrollment No
                            return false;
                        }
                        else
                            return true;
                    }
                    else
                        return true;
                }//else
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion 

    }
}
