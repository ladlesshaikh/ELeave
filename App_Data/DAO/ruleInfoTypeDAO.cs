using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class RuleInfoTypeDAO
    {
       // private dbConnection conn;
        string strSQL = string.Empty;

        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public RuleInfoTypeDAO()
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
                    //strSQL = "SELECT ID,Bank_Name,IFSC,MICR,Branch,Address,Activate FROM MASTER_BANK";
                    return SQLHelper.ShowRecord(strSQL);
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridDR
        private List<DataRow> LoadDataGridDR()
        {
            try
            {
                //if (HdrProfileDet[p]["PROF_COD_1"] 
                //INFOTYPE_ID	INFO_TYPE	Property

                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT ID,INFO_TYPE,Property,Activate FROM MASTER_RULE_INFO WHERE Activate='A'";
                    return (new List<DataRow>(SQLHelper.ShowRecord(strSQL).Select()));
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridList
        public List<RuleInfoTypeVO> LoadDataGridList()
        {
            try
            {
                    strSQL = "SELECT ID,INFO_TYPE,Property,Activate FROM MASTER_RULE_INFO WHERE Activate='A'";
                    return SQLHelper.ShowRecord(strSQL).DataTableToList<RuleInfoTypeVO>();
                 
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<RuleInfoTypeVO> LoadDataGridBindingList()
        {
            try
            {
                    strSQL = "SELECT ID,INFO_TYPE,Property,Activate FROM MASTER_RULE_INFO WHERE Activate='A'";
                    return new BindingList<RuleInfoTypeVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<RuleInfoTypeVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...




    }
}
