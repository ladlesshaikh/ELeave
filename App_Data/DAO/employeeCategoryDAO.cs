using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class EmployeeCategoryDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public EmployeeCategoryDAO()
        {
            //conn = new dbConnection();
        }

        #region GetLoadDataGridDT
        private DataTable GetLoadDataGridDT()
        {
            try
            {

                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT CAT_ID,CAT_NAME,ACTIVATE FROM MASTER_CATEGORY";
                    return (SQLHelper.ShowRecord(strSQL));

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLoadDataGridDT

        #region LoadDataGridList
        public List<EmployeeCategoryVO> LoadDataGridList()
        {
            try
            {
                    strSQL = "SELECT CAT_ID,CAT_NAME,ACTIVATE FROM MASTER_CATEGORY";
                    return SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeCategoryVO>();
             
            }catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<EmployeeCategoryVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = "SELECT CAT_ID,CAT_NAME,ACTIVATE FROM MASTER_CATEGORY";
                //return SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeCategoryVO>();
                return new BindingList<EmployeeCategoryVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeCategoryVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        
        //         strSqlQuarry = "SELECT CAT_ID,CAT_NAME,ACTIVATE FROM MASTER_CATEGORY";
        #region  CheckData
        private bool CheckData(string GroupName, string strFlag, string strRowId)
        {
            try
            {
                DataTable dt = new DataTable();
                if (strFlag == "A")
                {
                    
                    strSQL = "SELECT CAT_NAME FROM MASTER_CATEGORY WHERE REPLACE(CAT_NAME,' ','') = REPLACE('" + GroupName + "',' ','') ";

                    
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT CAT_ID,CAT_NAME FROM MASTER_CATEGORY WHERE REPLACE(CAT_NAME,' ','') = REPLACE('" + GroupName + "',' ','') AND CAT_ID='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["CAT_ID"].ToString().Trim())
                        {
                            //"Duplicate Department ...
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
