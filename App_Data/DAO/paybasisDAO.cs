using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class PaybasisDAO
    {
        // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public PaybasisDAO()
        {
            //conn = new dbConnection();
        }



        #region LoadDataGridDT
        private DataTable LoadDataGridDT()
        {
            try
            {
               
                    strSQL = "SELECT PAY_Id,PAY_Name,ISNULL(IsWeeklyPay,0) IsWeeklyPay,ISNULL(WeekStart,-1) WeekStart,ACTIVATE FROM dbo.MASTER_PAYBASIS";
                    return SQLHelper.ShowRecord(strSQL);
              

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridList
        public List<PaybasisVO> LoadDataGridList()
        {
            try
            {
                strSQL = "SELECT PAY_Id,PAY_Name, ISNULL(IsWeeklyPay,0) IsWeeklyPay ,ISNULL(WeekStart,-1) WeekStart," +
                    " CASE ISNULL(WeekStart,-1)  " +
                      "   WHEN -1 THEN '' " +
	                  "   WHEN 0 THEN 'SUNDAY'  "+
                      "   WHEN 1 THEN 'MONDAY'  "+
                      "   WHEN 2 THEN 'TUESDAY'  "+
                      "   WHEN 3 THEN 'WEDNESDAY'  " +  
                      "   WHEN 4 THEN 'THURSDAY'  "+
                      "   WHEN 5 THEN 'FRIDAY'  "+ 
                      "   WHEN 6 THEN 'SATURDAY'  "+
                      "   END  WeekStartName, " +
                      "   ACTIVATE FROM dbo.MASTER_PAYBASIS";

                return SQLHelper.ShowRecord(strSQL).DataTableToList<PaybasisVO>();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<PaybasisVO> LoadDataGridBindingList()
        {
            try
            {
                //strSQL = "SELECT PAY_Id,PAY_Name,ISNULL(IsWeeklyPay,0) IsWeeklyPay,ISNULL(WeekStart,-1) WeekStart, ACTIVATE FROM dbo.MASTER_PAYBASIS";

                strSQL = "SELECT PAY_Id,PAY_Name, ISNULL(IsWeeklyPay,0) IsWeeklyPay ,ISNULL(WeekStart,-1) WeekStart," +
                    " CASE ISNULL(WeekStart,-1)  " +
                      "   WHEN -1 THEN '' " +
                      "   WHEN 0 THEN 'SUNDAY'  " +
                      "   WHEN 1 THEN 'MONDAY'  " +
                      "   WHEN 2 THEN 'TUESDAY'  " +
                      "   WHEN 3 THEN 'WEDNESDAY'  " +
                      "   WHEN 4 THEN 'THURSDAY'  " +
                      "   WHEN 5 THEN 'FRIDAY'  " +
                      "   WHEN 6 THEN 'SATURDAY'  " +
                      "   END  WeekStartName, " +
                      "   ACTIVATE FROM dbo.MASTER_PAYBASIS";
                
                
                return new BindingList<PaybasisVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<PaybasisVO>());

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
                    strSQL = "SELECT PAY_Name FROM MASTER_PAYBASIS WHERE REPLACE(PAY_Name,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT PAY_Id,PAY_Name FROM MASTER_PAYBASIS WHERE REPLACE(PAY_Id,' ','') = REPLACE('" + GroupName + "',' ','') AND PAY_Id='" + strRowId + "' ";
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
