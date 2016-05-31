using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class HolidyDAO
    {
       // private dbConnection conn;
        string strSQL = string.Empty;

        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public HolidyDAO()
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
                    strSQL = "SELECT HOLIDAY_ID,CONVERT(VARCHAR(12),Holiday_Date,103) Holiday_Date,Description,FinYear,Activate,ISNULL(IsOTApplicable,0) IsOTApplicable,OT_ID FROM MASTER_HOLIDAY";
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
        public List<HolidayVO> LoadDataGridList()
        {
            try
            {
                    strSQL = "SELECT HOLIDAY_ID,CONVERT(VARCHAR(12),Holiday_Date,103) Holiday_Date,Description,FinYear,Activate,ISNULL(IsOTApplicable,0) IsOTApplicable,OT_ID FROM MASTER_HOLIDAY";
                    return SQLHelper.ShowRecord(strSQL).DataTableToList<HolidayVO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<HolidayVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = "SELECT HOLIDAY_ID,CONVERT(VARCHAR(12),Holiday_Date,103) Holiday_Date,Description,FinYear,Activate,ISNULL(IsOTApplicable,0) IsOTApplicable,OT_ID FROM MASTER_HOLIDAY";
                return new BindingList<HolidayVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<HolidayVO>());
            
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
                    strSQL = "SELECT Holiday_Date FROM MASTER_HOLIDAY WHERE CONVERT(VARCHAR(12),Holiday_Date,112) = CONVERT(VARCHAR(12),CONVERT(DATE,'" + GroupName + "'),112) ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT HOLIDAY_ID,Holiday_Date FROM MASTER_HOLIDAY WHERE  CONVERT(VARCHAR(12),Holiday_Date,112)= CONVERT(VARCHAR(12),CONVERT(DATE,'" + GroupName + "'),112) AND HOLIDAY_ID='" + strRowId + "' ";
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
