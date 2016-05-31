using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class EmployeeGradeDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public EmployeeGradeDAO()
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
                    strSQL = "SELECT GRADE_Name FROM MASTER_GRADE WHERE REPLACE(GRADE_Name,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT GRADE_Id,GRADE_Name FROM MASTER_GRADE WHERE REPLACE(GRADE_Name,' ','') = REPLACE('" + GroupName + "',' ','') AND GRADE_Id='" + strRowId + "' ";

                    dt = SQLHelper.ShowRecord(strSQL);

                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["GRADE_Id"].ToString().Trim())
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
        public List<EmployeeGradeVO> LoadDataGridList()
        {
            try
            {
                strSQL = "SELECT GRADE_Id,GRADE_Name,ACTIVATE,ISNULL(NoTaxDeduction,0) NoTaxDeduction,ISNULL(NoAbsentDeduction,0) NoAbsentDeduction FROM MASTER_GRADE";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeGradeVO>();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<EmployeeGradeVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = "SELECT GRADE_Id,GRADE_Name,ACTIVATE,ISNULL(NoTaxDeduction,0) NoTaxDeduction,ISNULL(NoAbsentDeduction,0) NoAbsentDeduction FROM MASTER_GRADE";
               // return SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeGradeVO>();
                return new BindingList<EmployeeGradeVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeGradeVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
    }
}
