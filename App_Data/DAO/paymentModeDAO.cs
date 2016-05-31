using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class PaymentModeDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public PaymentModeDAO()
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
                    strSQL = "SELECT PaymentId,PaymentMode,Activate FROM MASTER_PAYMENT_MODE";
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
        public List<PaymentModeVO> LoadDataGridList()
        {
            try
            {
                
                    strSQL = "SELECT PaymentId,PaymentMode,Activate FROM MASTER_PAYMENT_MODE";
                    return SQLHelper.ShowRecord(strSQL).DataTableToList <PaymentModeVO>();
                

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<PaymentModeVO> LoadDataGridBindingList()
        {
            try
            {

                strSQL = "SELECT PaymentId,PaymentMode,Activate FROM MASTER_PAYMENT_MODE";
               // return SQLHelper.ShowRecord(strSQL).DataTableToList<PaymentModeVO>();
                return new BindingList<PaymentModeVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<PaymentModeVO>());
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
                    strSQL = "SELECT PaymentMode FROM MASTER_PAYMENT_MODE WHERE REPLACE(PaymentMode,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT PaymentId,PaymentMode FROM MASTER_PAYMENT_MODE WHERE REPLACE(PaymentMode,' ','') = REPLACE('" + GroupName + "',' ','') AND PaymentId='" + strRowId + "' ";
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
