using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class YearMainDAO
    {
       // private dbConnection conn;
        string strSQL = string.Empty;

        /// <constructor>
        /// Constructor YearMainDAO
        /// </constructor>
        public YearMainDAO()
        {
            //conn = new dbConnection();
        }

        #region GetYearList()
        public List<YearMainVO> GetYearList()
        {
            try
            {
                strSQL =   "SELECT MAIN_ID, CONVERT(VARCHAR(12),START_DATE,106) START_DATE,CONVERT(VARCHAR(12),END_DATE,106) END_DATE,FINANCIAL_YEAR,Activate,ISNULL(CurrentYear,0) CurrentYear FROM MASTER_YEAR_MAIN";

                return SQLHelper.ShowRecord(strSQL).DataTableToList<YearMainVO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridList
        public List<YearMainVO> LoadDataGridList()
        {
            try
            {
                strSQL = "SELECT MAIN_ID, CONVERT(VARCHAR(12),START_DATE,106) START_DATE,CONVERT(VARCHAR(12),END_DATE,106) END_DATE,FINANCIAL_YEAR,Activate,ISNULL(CurrentYear,0) CurrentYear FROM MASTER_YEAR_MAIN";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<YearMainVO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<YearMainVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = "SELECT MAIN_ID, CONVERT(VARCHAR(12),START_DATE,106) START_DATE,CONVERT(VARCHAR(12),END_DATE,106) END_DATE,FINANCIAL_YEAR,Activate,ISNULL(CurrentYear,0) CurrentYear FROM MASTER_YEAR_MAIN";
                return new BindingList<YearMainVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<YearMainVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region  CheckData
        private bool CheckData(string FinYrName, string strFlag, string strRowId)
        {
            try
            {
                DataTable dt = new DataTable();
                if (strFlag == "A")
                {
                    strSQL = "SELECT FINANCIAL_YEAR FROM [MASTER_YEAR_MAIN] WHERE REPLACE(FINANCIAL_YEAR,' ','') = REPLACE(" + FinYrName + ",' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT FINANCIAL_YEAR FROM [MASTER_YEAR_MAIN] WHERE REPLACE(PLACE_Id,' ','') = REPLACE(" + FinYrName + ",' ','') AND Main_Id='" + strRowId + "' ";
                    
                 
                    
                    dt = SQLHelper.ShowRecord(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["Main_ID"].ToString().Trim())
                        {
                           // Duplicate PLACE NAME
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
