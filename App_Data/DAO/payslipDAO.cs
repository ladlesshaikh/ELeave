using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class PayslipDAO
    {
        // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor PayslipDAO
        /// </constructor>
        public PayslipDAO()
        {
            //conn = new dbConnection();
        }



        #region LoadDataGridDT
       public List<PayslipProcessVO>  GetPayslipProcessingDates(int imonthno,int iyrid)
        {
            try
            {


                strSQL = "  SELECT distinct PsMonth,PsYear,CONVERT(VARCHAR(12),ProcessingDate,106) ProcessingDate,ISNULL(psWEEKNO,0) psWEEKNO  FROM dbo.PAYROLL_YEAR_MAIN";
                strSQL += " WHERE PsMonth=" + imonthno + " AND PsYear=" + iyrid + " and psWEEKNO<>0";
                return SQLHelper.ShowRecord(strSQL).DataTableToList <PayslipProcessVO>();
                 

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
       #region LoadDataGridDT
       public List<PayslipProcessVO> GetPayslipProcessingDates(int iweekno,int imonthno, int iyrid)
       {
           try
           {


               strSQL = "  SELECT distinct  PsMonth,PsYear,CONVERT(VARCHAR(12),ProcessingDate,106) ProcessingDate,ISNULL(psWEEKNO,0) psWEEKNO  FROM dbo.PAYROLL_YEAR_MAIN";
               strSQL += " WHERE PsMonth=" + imonthno + " AND PsYear=" + iyrid + " and psWEEKNO=" + iweekno;
               return SQLHelper.ShowRecord(strSQL).DataTableToList<PayslipProcessVO>();


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
                strSQL = "SELECT PAY_Id,PAY_Name, ISNULL(IsWeeklyPay,0) IsWeeklyPay ,ACTIVATE FROM dbo.MASTER_PAYBASIS";
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
                strSQL = "SELECT PAY_Id,PAY_Name,ISNULL(IsWeeklyPay,0) IsWeeklyPay,ACTIVATE FROM dbo.MASTER_PAYBASIS";
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
