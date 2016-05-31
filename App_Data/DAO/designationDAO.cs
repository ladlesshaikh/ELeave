using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class DesignationDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public DesignationDAO()
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
                    strSQL = "SELECT DESIG_Id,DESIGNATION,ACTIVATE FROM dbo.MASTER_DESIGNATION";
                    return (SQLHelper.ShowRecord(strSQL));

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLoadDataGridDT
        #region GetDisplayGridDT
        private DataTable GetDisplayGridDT(string strParam)
        {
            try
            {
                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT ID ROW_ID,FROM_AMOUNT,TO_AMOUNT,PERCENTAGE,PLUS_AMOUNT FROM MASTER_TAX_DTILS WHERE ROW_ID=" + strParam.Trim();
                    return (SQLHelper.ShowRecord(strSQL));

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region LoadDataGridList
        public List<DesignationVO> LoadDataGridList()
        {
            try
            {
                strSQL = "SELECT DESIG_Id,DESIGNATION,ACTIVATE FROM dbo.MASTER_DESIGNATION";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<DesignationVO>();
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<DesignationVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = "SELECT DESIG_Id,DESIGNATION,ACTIVATE FROM dbo.MASTER_DESIGNATION";
                return new BindingList<DesignationVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<DesignationVO>());

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
                    strSQL = "SELECT DEPARTMENT_Name FROM MASTER_DEPARTMENT WHERE REPLACE(DEPARTMENT_Name,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT DESIG_Id,DESIGNATION FROM MASTER_DESIGNATION WHERE REPLACE(DESIG_Id,' ','') = REPLACE('" + GroupName + "',' ','') AND DESIG_Id='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);

                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["ID"].ToString().Trim())
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
