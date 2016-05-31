using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.ComponentModel;
using EntityMapper;

namespace ATTNPAY.Core
{
    public class CpfConfigDAO
    {
       
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor CpfConfigDAO
        /// </constructor>
        public CpfConfigDAO()
        {
            //conn = new dbConnection();
        }

       
        #region  CheckData
        private bool CheckData(string GroupName, string strFlag, string strRowId)
        {
            try
            {
                DataTable dt = new DataTable();
                if (strFlag == "A")
                {
                    strSQL = "SELECT [CPF_CONFIG_NAME] FROM [MASTER_CPF_CONFIG] WHERE REPLACE(CPF_CONFIG_NAME,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT [CPF_CONFIG_ID],[CPF_CONFIG_NAME],CPF_CONFIG_DESCRIPTION,[ACTIVATE] FROM  [MASTER_CPF_CONFIG]";
             
                    dt = SQLHelper.ShowRecord(strSQL);

                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["CPF_CONFIG_ID"].ToString().Trim())
                        {
                           
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
                    strSQL = "SELECT [CPF_CONFIG_ID],[CPF_CONFIG_NAME],CPF_CONFIG_DESCRIPTION,[ACTIVATE] FROM [MASTER_CPF_CONFIG]";
                    
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
        public List<CpfConfigVO> LoadDataGridList()
        {
            try
            {
                strSQL = "SELECT [CPF_CONFIG_ID],[CPF_CONFIG_NAME],CPF_CONFIG_DESCRIPTION,[ACTIVATE] FROM [MASTER_CPF_CONFIG]";
                return BindClassWithData.BindClass<CpfConfigVO>(SQLHelper.ShowRecord(strSQL)).ToList();
                
                     
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<CpfConfigVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = "SELECT [CPF_CONFIG_ID] ,[CPF_CONFIG_NAME],CPF_CONFIG_DESCRIPTION,[ACTIVATE] FROM [MASTER_CPF_CONFIG]";
                return new BindingList<CpfConfigVO>(BindClassWithData.BindClass<CpfConfigVO>(SQLHelper.ShowRecord(strSQL)));  
            
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

    }
}
