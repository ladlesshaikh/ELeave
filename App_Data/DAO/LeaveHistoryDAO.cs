using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using EntityMapper;
using System.Linq;

namespace ATTNPAY.Core
{
    public class LeaveHistoryDAO
    {
        // private dbConnection conn;
        string strSQL = string.Empty;

        /// <constructor>
        /// Constructor LeaveHistoryDAO
        /// </constructor>
        public LeaveHistoryDAO()
        {

        }

        #region GetLeaveHistoryList
        public List<LeaveHistoryVO> GetLeaveHistoryList(string MemCode)
        {
            try
            {

                string SqlQuarry = "SELECT   L.LeaveName, X.LeaveCode,X.OB,ISNULL(LA.LEAVE_ACC_BAL,0) LEAVE_ACC_BAL,X.LEAVE_AVAILED,  ISNULL(L_ENCASH.EN_BAL, 0) AS EN_BAL,ISNULL(ADJ.ADJ_BAL,0) ADJ_BAL, \n" +
                   " (X.OB + ISNULL(LA.LEAVE_ACC_BAL,0)) - ( ISNULL(X.LEAVE_AVAILED,0) + ISNULL(L_ENCASH.EN_BAL, 0)) + ISNULL(ADJ.ADJ_BAL,0) CB \n" +
                   " FROM         (SELECT     MEM_CODE, LeaveCode, SUM(OB) AS OB, SUM(TotalLeave) AS LEAVE_AVAILED  \n" +
                   " FROM          (SELECT     MEM_CODE, LeaveCode, SUM(TOT_DAY) AS TotalLeave, 0 AS OB \n" +
                   " FROM          TRAN_LEAVE \n" +
                   " WHERE      (Activate = 'A') AND (FinYear = '" + GlobalVariable.FinanCialYear + "') AND (MEM_CODE = '" + MemCode + "') \n" +
                   " GROUP BY MEM_CODE, LeaveCode \n" +
                   " UNION \n" +
                   " SELECT     MEM_CODE, LEAVE_CODE, 0 AS TotalLeave, OB \n" +
                   " FROM         TRAN_LEAVE_OB \n" +
                   " WHERE     (MEM_CODE = '" + MemCode + "') AND (FinYear = '" + GlobalVariable.FinanCialYear + "')) AS MAIN \n" +
                   " GROUP BY MEM_CODE, LeaveCode) AS X LEFT OUTER JOIN \n" +
                   " (SELECT     LeaveCode, MEM_CODE, SUM(ACCRUED_BAL) AS LEAVE_ACC_BAL \n" +
                   " FROM          TRAN_LEAVE_ACCRUAL \n" +
                   " WHERE      (FIN_YEAR = '" + GlobalVariable.FinanCialYear + "') \n" +
                   " GROUP BY MEM_CODE, LeaveCode) AS LA ON X.MEM_CODE = LA.MEM_CODE AND X.LeaveCode = LA.LeaveCode LEFT OUTER JOIN \n" +
                   " (SELECT     LeaveCode, MEM_CODE, ISNULL(SUM(APPLIED), 0) AS EN_BAL \n" +
                   " FROM          TRAN_LEAVE_ENCASHMENT \n" +
                   " WHERE      (FINYEAR = '" + GlobalVariable.FinanCialYear + "') \n" +
                   " GROUP BY MEM_CODE, LeaveCode) AS L_ENCASH ON X.MEM_CODE = L_ENCASH.MEM_CODE AND X.LeaveCode = L_ENCASH.LeaveCode  \n" +
                   " LEFT OUTER JOIN  \n" +
                   " (SELECT     LeaveCode, MEM_CODE, ISNULL(SUM(ADJUST), 0) AS ADJ_BAL  \n" +
                   " FROM          TRAN_LEAVE_ADJUSTMENT WHERE (FIN_YEAR = '" + GlobalVariable.FinanCialYear + "') GROUP BY LeaveCode, MEM_CODE ) ADJ ON X.MEM_CODE = ADJ.MEM_CODE  \n" +
                   " AND X.LeaveCode = ADJ.LeaveCode \n" +
                   " INNER JOIN MASTER_LEAVE_TYPE L ON X.LeaveCode = L.LeaveCode ";
                return BindClassWithData.BindClass<LeaveHistoryVO>(SQLHelper.ShowRecord(SqlQuarry)).ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<LeaveHistoryVO> LoadDataGridBindingList(string MemCode)
        {
            try
            {
                string SqlQuarry = "SELECT   L.LeaveName, X.LeaveCode,X.OB,ISNULL(LA.LEAVE_ACC_BAL,0) LEAVE_ACC_BAL,X.LEAVE_AVAILED,  ISNULL(L_ENCASH.EN_BAL, 0) AS EN_BAL,ISNULL(ADJ.ADJ_BAL,0) ADJ_BAL, \n" +
                  " (X.OB + ISNULL(LA.LEAVE_ACC_BAL,0)) - ( ISNULL(X.LEAVE_AVAILED,0) + ISNULL(L_ENCASH.EN_BAL, 0)) + ISNULL(ADJ.ADJ_BAL,0) CB \n" +
                  " FROM         (SELECT     MEM_CODE, LeaveCode, SUM(OB) AS OB, SUM(TotalLeave) AS LEAVE_AVAILED  \n" +
                  " FROM          (SELECT     MEM_CODE, LeaveCode, SUM(TOT_DAY) AS TotalLeave, 0 AS OB \n" +
                  " FROM          TRAN_LEAVE \n" +
                  " WHERE      (Activate = 'A') AND (FinYear = '" + GlobalVariable.FinanCialYear + "') AND (MEM_CODE = '" + MemCode + "') \n" +
                  " GROUP BY MEM_CODE, LeaveCode \n" +
                  " UNION \n" +
                  " SELECT     MEM_CODE, LEAVE_CODE, 0 AS TotalLeave, OB \n" +
                  " FROM         TRAN_LEAVE_OB \n" +
                  " WHERE     (MEM_CODE = '" + MemCode + "') AND (FinYear = '" + GlobalVariable.FinanCialYear + "')) AS MAIN \n" +
                  " GROUP BY MEM_CODE, LeaveCode) AS X LEFT OUTER JOIN \n" +
                  " (SELECT     LeaveCode, MEM_CODE, SUM(ACCRUED_BAL) AS LEAVE_ACC_BAL \n" +
                  " FROM          TRAN_LEAVE_ACCRUAL \n" +
                  " WHERE      (FIN_YEAR = '" + GlobalVariable.FinanCialYear + "') \n" +
                  " GROUP BY MEM_CODE, LeaveCode) AS LA ON X.MEM_CODE = LA.MEM_CODE AND X.LeaveCode = LA.LeaveCode LEFT OUTER JOIN \n" +
                  " (SELECT     LeaveCode, MEM_CODE, ISNULL(SUM(APPLIED), 0) AS EN_BAL \n" +
                  " FROM          TRAN_LEAVE_ENCASHMENT \n" +
                  " WHERE      (FINYEAR = '" + GlobalVariable.FinanCialYear + "') \n" +
                  " GROUP BY MEM_CODE, LeaveCode) AS L_ENCASH ON X.MEM_CODE = L_ENCASH.MEM_CODE AND X.LeaveCode = L_ENCASH.LeaveCode  \n" +
                  " LEFT OUTER JOIN  \n" +
                  " (SELECT     LeaveCode, MEM_CODE, ISNULL(SUM(ADJUST), 0) AS ADJ_BAL  \n" +
                  " FROM          TRAN_LEAVE_ADJUSTMENT WHERE (FIN_YEAR = '" + GlobalVariable.FinanCialYear + "') GROUP BY LeaveCode, MEM_CODE ) ADJ ON X.MEM_CODE = ADJ.MEM_CODE  \n" +
                  " AND X.LeaveCode = ADJ.LeaveCode \n" +
                  " INNER JOIN MASTER_LEAVE_TYPE L ON X.LeaveCode = L.LeaveCode ";
                return new BindingList<LeaveHistoryVO>(SQLHelper.ShowRecord(SqlQuarry).DataTableToList<LeaveHistoryVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...





    }
}
