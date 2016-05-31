using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class TaxSlabDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public TaxSlabDAO()
        {
            //conn = new dbConnection();
        }

        
        #region GetLoadDataGridDT
        private DataTable GetLoadDataGridDT()
        {
            try
            {

                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT ROW_ID,TAX_YEAR FROM MASTER_TAX_MAIN";
                    return (SQLHelper.ShowRecord(strSQL));
                   
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLoadDataGridDT
        #region GetDisplayGridDT
        private DataTable GetDisplayGridDT( string strParam)
        {
            try
            {
                    using (DataTable dt = new DataTable())
                    {
                        strSQL = "SELECT ID ROW_ID,FROM_AMOUNT,TO_AMOUNT,PERCENTAGE,PLUS_AMOUNT FROM MASTER_TAX_DTILS WHERE ROW_ID=" + strParam.Trim();
                        return (SQLHelper.ShowRecord(strSQL));
                        
                    }       
                }
            catch (Exception ex)
            {
                return null;
            }
            
        }
        #endregion
        #region LoadDataGridList
        public List<TaxSlabVO> LoadDataGridList()
        {
            try
            {
                    strSQL = "SELECT ROW_ID,TAX_YEAR FROM MASTER_TAX_MAIN";
                    return SQLHelper.ShowRecord(strSQL).DataTableToList<TaxSlabVO>();
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<TaxSlabVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = "SELECT ROW_ID,TAX_YEAR FROM MASTER_TAX_MAIN";
                return new BindingList<TaxSlabVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<TaxSlabVO>());

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region GetFinancialYearDT
        private DataTable GetFinancialYearDT()
        {
            try
            {
                using (DataTable dt = new DataTable())
                {
                   return  SQLHelper.ShowRecord("SELECT FINANCIAL_YEAR FROM MASTER_YEAR_MAIN WHERE Activate='A' AND ISNULL(CurrentYear,0)=1");
                }
           }catch (Exception ex)
            {
                return null;
            }
        }
       #endregion

    }
}
