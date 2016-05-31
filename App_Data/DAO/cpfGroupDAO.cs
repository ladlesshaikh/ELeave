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
    public class CpfGroupDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor CpfGroupDAO
        /// </constructor>
        public CpfGroupDAO()
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
                    strSQL = "SELECT [CPF_GRP_CODE] FROM [MASTER_CPF_GROUP] WHERE REPLACE(CPFGroup_Name,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT [CpfGroup_Id],[CPF_GRP_CODE],[CPFGroup_Name],[ACTIVATE] FROM [MASTER_CPF_GROUP]";
             
                    dt = SQLHelper.ShowRecord(strSQL);

                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["CpfGroup_Id"].ToString().Trim())
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
                    strSQL = "SELECT [CpfGroup_Id],[CPF_GRP_CODE],[CPFGroup_Name],[ACTIVATE] FROM [MASTER_CPF_GROUP]";
                    
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
        public List<CpfGroupVO> LoadDataGridList()
        {
            try
            {
                strSQL = "SELECT [CpfGroup_Id],[CPF_GRP_CODE],[CPFGroup_Name],[ACTIVATE] FROM [MASTER_CPF_GROUP]";
                //return SQLHelper.ShowRecord(strSQL).DataTableToList<CpfGroupVO>();
                return BindClassWithData.BindClass<CpfGroupVO>(SQLHelper.ShowRecord(strSQL)).ToList();
                
                     
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<CpfGroupVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = "SELECT [CpfGroup_Id],[CPF_GRP_CODE],[CPFGroup_Name],[ACTIVATE] FROM [MASTER_CPF_GROUP]";
                //return new BindingList<CpfGroupVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<CpfGroupVO>());
                return new BindingList<CpfGroupVO>(BindClassWithData.BindClass<CpfGroupVO>(SQLHelper.ShowRecord(strSQL)));  
            
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

    }
}
