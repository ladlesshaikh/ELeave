using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class LobDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor LobDAO
        /// </constructor>
        public LobDAO()
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
        public List<LobVO> LoadDataGridList()
        {
            try
            {
                   
                    strSQL = " SELECT T.ROW_ID,T.MEM_CODE,ME.Member_Name,L.LeaveName,T.LEAVE_CODE,OB,FinYear,T.Activate FROM TRAN_LEAVE_OB T \n" +
                              " INNER JOIN MASTER_EMPLOYEE_MAIN ME ON T.MEM_CODE = ME.MEM_CODE \n" +
                              " INNER JOIN MASTER_LEAVE_TYPE L ON T.LEAVE_CODE = L.LeaveCode \n" +
                              " WHERE L.Activate='A'  ";
                         return SQLHelper.ShowRecord(strSQL).DataTableToList<LobVO>();
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<LobVO> LoadDataGridBindingList()
        {
            try
            {

                strSQL = " SELECT T.ROW_ID,T.MEM_CODE,ME.Member_Name,L.LeaveName,T.LEAVE_CODE,OB,FinYear,T.Activate FROM TRAN_LEAVE_OB T \n" +
                          " INNER JOIN MASTER_EMPLOYEE_MAIN ME ON T.MEM_CODE = ME.MEM_CODE \n" +
                          " INNER JOIN MASTER_LEAVE_TYPE L ON T.LEAVE_CODE = L.LeaveCode \n" +
                          " WHERE L.Activate='A'  ";
               // return SQLHelper.ShowRecord(strSQL).DataTableToList<LobVO>();
                return new BindingList<LobVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<LobVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        
    }
}
