using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class MaritalStatusDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor MaritalStatusDAO
        /// </constructor>
        public MaritalStatusDAO()
        {
            //conn = new dbConnection();
        }

       
        #region  CheckData
        private bool CheckData(string GroupName, string strFlag, string strRowId)
        {
            try
            {
                DataTable dt = new DataTable();
                if (strFlag == "A")
                {
                    strSQL = "SELECT STATUS_TYPE FROM MASTER_MARITAL_STATUS WHERE REPLACE(STATUS_TYPE,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT STATUS_Id,STATUS_TYPE FROM MASTER_MARITAL_STATUS WHERE REPLACE(STATUS_Id,' ','') = REPLACE('" + GroupName + "',' ','') AND STATUS_Id='" + strRowId + "' ";

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
        #region GetLoadDataGridDT
        private DataTable GetLoadDataGridDT()
        {
            try
            {
                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT GRADE_Id,GRADE_Name,ACTIVATE,ISNULL(NoTaxDeduction,0) NoTaxDeduction,ISNULL(NoAbsentDeduction,0) NoAbsentDeduction FROM MASTER_GRADE";
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
        public List<MaritalStatusVO> LoadDataGridList()
        {
            try
            {
                strSQL = "SELECT STATUS_Id,STATUS_TYPE,ACTIVATE FROM dbo.MASTER_MARITAL_STATUS";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<MaritalStatusVO>();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<MaritalStatusVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = "SELECT STATUS_Id,STATUS_TYPE,ACTIVATE FROM dbo.MASTER_MARITAL_STATUS";
                //return SQLHelper.ShowRecord(strSQL).DataTableToList<MaritalStatusVO>();
                return new BindingList<MaritalStatusVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<MaritalStatusVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
    }
}
