using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class EmployeeTypeDAO
    {
       // private dbConnection conn;
        string strSQL = string.Empty;

        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public EmployeeTypeDAO()
        {
            //conn = new dbConnection();
        }

        
        #region LoadDataGridDT
        private DataTable LoadDataGridDT()
        {
            try
            {
                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT Employee_Type_Id,Employee_Type,ISNULL(IS_HourlyPaid,0) IS_HourlyPaid,ISNULL(IsOtApplicable,0) IsOtApplicable,ISNULL(BreakDeduction,0) BreakDeduction,Activate FROM MASTER_EMPLOYEE_TYPE";
                    return SQLHelper.ShowRecord(strSQL);
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridList
        public List<EmployeeTypeVO> LoadDataGridList()
        {
            try
            {
                strSQL = "SELECT Employee_Type_Id,Employee_Type,ISNULL(IS_HourlyPaid,0) IS_HourlyPaid,ISNULL(IsOtApplicable,0) IsOtApplicable,ISNULL(BreakDeduction,0) BreakDeduction,Activate FROM MASTER_EMPLOYEE_TYPE";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeTypeVO>();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<EmployeeTypeVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = "SELECT Employee_Type_Id,Employee_Type,ISNULL(IS_HourlyPaid,0) IS_HourlyPaid,ISNULL(IsOtApplicable,0) IsOtApplicable, ISNULL(BreakDeduction,0) BreakDeduction ,   Activate FROM MASTER_EMPLOYEE_TYPE";
                //return SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeTypeVO>();
                return new BindingList<EmployeeTypeVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeTypeVO>());

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
                    strSQL = "SELECT Employee_Type FROM MASTER_EMPLOYEE_TYPE WHERE REPLACE(Employee_Type,' ','') = REPLACE('" + GroupName + "',' ','') ";

                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT Employee_Type_ID,Employee_Type FROM MASTER_EMPLOYEE_TYPE WHERE REPLACE(Employee_Type,' ','') = REPLACE('" + GroupName + "',' ','') AND Employee_Type_ID='" + strRowId + "' ";
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
      
    }
}
