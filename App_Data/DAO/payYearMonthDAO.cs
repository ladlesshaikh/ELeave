using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class PayYearMonthDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public PayYearMonthDAO()
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

        #region LoadDataGridDT
        private DataTable LoadDataGridDT()
        {
            try
            {
                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT  MAIN_ID, CONVERT(VARCHAR(12),START_DATE,106) START_DATE,CONVERT(VARCHAR(12),END_DATE,106) END_DATE,FINANCIAL_YEAR,Activate,ISNULL(CurrentYear,0) CurrentYear FROM MASTER_YEAR_MAIN";
                    return SQLHelper.ShowRecord(strSQL);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        /*
        #region LoadDataGridBindingList
        public BindingList<OvertimeVO> LoadDataGridBindingList()
        {
            try
            {


                {
                    strSQL = "SELECT  MAIN_ID, CONVERT(VARCHAR(12),START_DATE,106) START_DATE,CONVERT(VARCHAR(12),END_DATE,106) END_DATE,FINANCIAL_YEAR,Activate,ISNULL(CurrentYear,0) CurrentYear FROM MASTER_YEAR_MAIN";
                    //return SQLHelper.ShowRecord(strSQL).DataTableToList<OvertimeVO>();
                    return new BindingList<OvertimeVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<OvertimeVO>());
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        */


    }
}
