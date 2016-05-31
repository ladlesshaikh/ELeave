using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using EntityMapper;

namespace ATTNPAY.Core
{
    public class CpfAgeGroupDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor CpfAgeGroupDAO
        /// </constructor>
        public CpfAgeGroupDAO()
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
                    //SELECT  [CPFAgeGroupID],[AgeFrom] ,[AgeTo] ,[Activate] FROM [SELECTASALAD].[dbo].[MASTER_CPF_AGE_GROUP]
                    strSQL = "SELECT  [CPFAgeGroupID],[AgeFrom] ,[AgeTo] ,[Activate] FROM [MASTER_CPF_AGE_GROUP] WHERE REPLACE(CPFAgeGroupID,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = " SELECT  [CPFAgeGroupID],[AgeFrom] ,[AgeTo] ,[Activate] FROM [MASTER_CPF_AGE_GROUP] WHERE WHERE REPLACE(CPFAgeGroupID,' ','') = REPLACE('" + GroupName + "',' ','') AND CPFAgeGroupID='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);

                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["CPFAgeGroupID"].ToString().Trim())
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
                    strSQL = "SELECT  [CPFAgeGroupID],[AgeFrom] ,[AgeTo] ,[Activate] FROM [MASTER_CPF_AGE_GROUP] ";
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
        public List<CpfAgeGroupVO> LoadDataGridList()
        {
            try
            {
                strSQL = "SELECT  [CPFAgeGroupID],[AgeFrom] ,[AgeTo] ,[Activate] FROM [MASTER_CPF_AGE_GROUP] ";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<CpfAgeGroupVO>();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<CpfAgeGroupVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = "SELECT  [CPFAgeGroupID],[AgeFrom] ,[AgeTo] ,[Activate] FROM [MASTER_CPF_AGE_GROUP] ";
                //return new BindingList<CpfAgeGroupVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<CpfAgeGroupVO>());
                return new BindingList<CpfAgeGroupVO>(BindClassWithData.BindClass<CpfAgeGroupVO>(SQLHelper.ShowRecord(strSQL)));  
       
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<CpfAgeGroupVO > LoadDataGridKeyValueBindingList()
        {
            try
            {

                strSQL = " SELECT  [CPFAgeGroupID] , AgeFrom,AgeTo, CONCAT([AgeFrom],'-',[AgeTo]) FormatedAge  FROM [MASTER_CPF_AGE_GROUP] where Activate='A' order by [CPFAgeGroupID] ";
                //return new BindingList<CpfAgeGroupVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<CpfAgeGroupVO>());
                return new BindingList<CpfAgeGroupVO>(BindClassWithData.BindClass<CpfAgeGroupVO>(SQLHelper.ShowRecord(strSQL)));

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
    }
}
