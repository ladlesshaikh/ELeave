using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class SalaryEarningDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor SalaryEarningDAO
        /// </constructor>
        public SalaryEarningDAO()
        {
            //conn = new dbConnection();
        }

        #region LoadDataGridList
        public List<SalaryEarningVO> LoadDataGridList(string strRowId)
        {
            
            try
            {

                strSQL = "SELECT D.EdCodeId,ED.Description HeadName,ISNULL(D.IsPercentage,0) IsPercentage, \n" +
                    " isnull(D.BaseEdCodeId,0) BaseEdCodeId,ISNULL(NED.Description,'') BaseHeadName,Percentage,AMOUNT Amount FROM MASTER_EMPLOYEE_EARNING_DTLS D \n" +
                    " INNER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER ED ON D.EdCodeId = ED.EdCodeId \n" +
                    " LEFT OUTER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER NED ON D.BaseEdCodeId = NED.EdCodeId \n" +
                    " WHERE D.Activate='A' AND D.MEM_CODE='" + strRowId + "'";
              
                    return SQLHelper.ShowRecord(strSQL).DataTableToList<SalaryEarningVO>();
            
            }catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridList
        public List<SalaryEarningVO> LoadSalaryEarningList(string strRowId)
        {

            try
            {

                strSQL = "SELECT D.ID, D.EdCodeId,ED.Description HeadName,ISNULL(D.IsPercentage,0) IsPercentage, \n" +
                    " isnull(D.BaseEdCodeId,0) BaseEdCodeId,ISNULL(NED.Description,'') BaseHeadName,Percentage,AMOUNT Amount FROM MASTER_EMPLOYEE_EARNING_DTLS D \n" +
                    " INNER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER ED ON D.EdCodeId = ED.EdCodeId \n" +
                    " LEFT OUTER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER NED ON D.BaseEdCodeId = NED.EdCodeId \n" +
                    " WHERE D.Activate='A' AND D.MEM_CODE='" + strRowId + "'";

                return SQLHelper.ShowRecord(strSQL).DataTableToList<SalaryEarningVO>();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

       


        #region LoadDataGridBindingList
        public BindingList<SalaryEarningVO> LoadDataGridBindingList(string strRowId)
        {
            
            try
            {
                strSQL = "SELECT D.EdCodeId,ED.Description HeadName,ISNULL(D.IsPercentage,0) IsPercentage, \n" +
                    " isnull(D.BaseEdCodeId,0) BaseEdCodeId,ISNULL(NED.Description,'') BaseHeadName,Percentage,AMOUNT Amount,WEF_Date FROM MASTER_EMPLOYEE_EARNING_DTLS D \n" +
                    " INNER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER ED ON D.EdCodeId = ED.EdCodeId \n" +
                    " LEFT OUTER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER NED ON D.BaseEdCodeId = NED.EdCodeId \n" +
                    " WHERE D.Activate='A' AND D.MEM_CODE='" + strRowId + "'";
                    return new BindingList<SalaryEarningVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<SalaryEarningVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
    }
}
