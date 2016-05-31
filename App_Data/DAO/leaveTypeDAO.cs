using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class LeaveTypeDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public LeaveTypeDAO()
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
                       strSQL = "SELECT LeaveCode,LeaveName,ShortName,MaxBalance,MaxTransferabble, \n" +
                             " ISNULL(IsTransferable,0) IsTransferable,ISNULL(IsEncashable,0)IsEncashable,Activate,\n" +
                             " ISNULL(Acc_Month_Bal,0) Acc_Month_Bal FROM MASTER_LEAVE_TYPE";
         
                    
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
        public List<LeaveTypeVO> LoadDataGridList()
        {
            try
            {
              

                {
                    strSQL = "SELECT LeaveCode,LeaveName,ShortName,MaxBalance,MaxTransferabble, \n" +
                            " ISNULL(IsTransferable,0) IsTransferable,ISNULL(IsEncashable,0)IsEncashable,Activate,\n" +
                            " ISNULL(Acc_Month_Bal,0) Acc_Month_Bal FROM MASTER_LEAVE_TYPE";
                    return SQLHelper.ShowRecord(strSQL).DataTableToList<LeaveTypeVO>();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<LeaveTypeVO> LoadDataGridBindingList()
        {
            try
            {


                {
                    strSQL = "SELECT LeaveCode,LeaveName,ShortName,MaxBalance,MaxTransferabble, \n" +
                            " ISNULL(IsTransferable,0) IsTransferable,ISNULL(IsEncashable,0)IsEncashable,Activate,\n" +
                            " ISNULL(Acc_Month_Bal,0) Acc_Month_Bal FROM MASTER_LEAVE_TYPE";

                    //strSQL = "  SELECT LeaveCode,LeaveName,ShortName,MaxBalance,MaxTransferabble,   \n" +
                    //        " ISNULL(IsTransferable,0) IsTransferable, CASE WHEN ISNULL(IsEncashable,0)=0 THEN 'N' \n" +
                    //        " ELSE 'Y' END  IsEncashable,Activate, \n" +
                    //        " ISNULL(Acc_Month_Bal,0) Acc_Month_Bal FROM MASTER_LEAVE_TYPE ";

                    
                    //return SQLHelper.ShowRecord(strSQL).DataTableToList<LeaveTypeVO>();
                    return new BindingList<LeaveTypeVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<LeaveTypeVO>());
                }
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
                    strSQL = "SELECT LeaveName FROM MASTER_LEAVE_TYPE WHERE REPLACE(LeaveName,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT LeaveCode,LeaveName FROM MASTER_LEAVE_TYPE WHERE REPLACE(LeaveName,' ','') = REPLACE('" + GroupName + "',' ','') AND LeaveCode='" + strRowId + "' ";
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
