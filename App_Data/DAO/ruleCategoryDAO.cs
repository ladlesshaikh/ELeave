using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class RuleCategoryDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor RuleCategoryDAO
        /// </constructor>
        public RuleCategoryDAO()
        {
            //conn = new dbConnection();
        }

       
        #region  CheckData
        private bool CheckData(string strRuleCategory, string strFlag, string strRowId)
        {
            try
            {
                DataTable dt = new DataTable();
                if (strFlag == "A")
                {
                    strSQL = " SELECT RuleCategoryId ,RuleCategory,Activate from MASTER_RULE_CATEGORY WHERE REPLACE(RuleCategory,' ','') = REPLACE('" + strRuleCategory + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = " SELECT RuleCategoryId ,RuleCategory,Activate FROM MASTER_RULE_CATEGORY WHERE REPLACE(RuleCategory,' ','') = REPLACE('" + strRuleCategory + "',' ','') AND RuleCategoryId='" + strRowId + "' ";

                    dt = SQLHelper.ShowRecord(strSQL);
                     
                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["RuleCategoryId"].ToString().Trim())
                        {
                            //"Duplicate Department ...
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
        #region GetLoadDataGridDT
        private DataTable GetLoadDataGridDT()
        {
            try
            {
                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT RuleCategoryId ,RuleCategory,Activate FROM MASTER_RULE_CATEGORY ";
                    return (SQLHelper.ShowRecord(strSQL));
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLoadDataGridDT
        #region LoadDataGridList

        public List<RuleCategoryVO> LoadDataGridList()
        {
            try
            {
                strSQL = "SELECT RuleCategoryId ,RuleCategory,Activate FROM MASTER_RULE_CATEGORY ";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<RuleCategoryVO>();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<RuleCategoryVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = "SELECT RuleCategoryId ,RuleCategory,Activate FROM MASTER_RULE_CATEGORY ";
                return new BindingList<RuleCategoryVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<RuleCategoryVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
    }
}
