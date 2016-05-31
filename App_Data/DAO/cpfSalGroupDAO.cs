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
    public class CpfSalGroupDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor CpfSalGroupDAO
        /// </constructor>
        public CpfSalGroupDAO()
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
                    strSQL = " SELECT   [CPFSALGROUPID]  FROM [MASTER_CPF_SALARY_GROUP] WHERE REPLACE(CPFSALGROUPID,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = " SELECT   [CPFSALGROUPID]  FROM  [MASTER_CPF_SALARY_GROUP] WHERE REPLACE(CPFSALGROUPID,' ','') = REPLACE('" + GroupName + "',' ','') AND CPFSALGROUPID='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);

                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["CPFSALGROUPID"].ToString().Trim())
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
                    strSQL = " SELECT   [CPFSALGROUPID],[SALFROM],[SALTO],[ACTIVATE] FROM [MASTER_CPF_SALARY_GROUP]";
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
        public List<CpfSalGroupVO> LoadDataGridList()
        {
            try
            {
                strSQL = " SELECT [CPFSALGROUPID],[SALFROM],[SALTO],[ACTIVATE] FROM [MASTER_CPF_SALARY_GROUP]";
                //return SQLHelper.ShowRecord(strSQL).DataTableToList<CpfSalGroupVO>();
                return BindClassWithData.BindClass<CpfSalGroupVO>(SQLHelper.ShowRecord(strSQL)).ToList();  
       
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<CpfSalGroupVO> LoadDataGridBindingList()
        {
            try
            {
                 strSQL = " SELECT   [CPFSALGROUPID],[SALFROM],[SALTO],[ACTIVATE] FROM [MASTER_CPF_SALARY_GROUP]";
                 
                
                //return new BindingList<CpfSalGroupVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<CpfSalGroupVO>());
                 return new BindingList<CpfSalGroupVO>(BindClassWithData.BindClass<CpfSalGroupVO>(SQLHelper.ShowRecord(strSQL)));  
       
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<CpfSalGroupVO> LoadDataGridKeyValueBindingList()
        {
            try
            {

                strSQL = " SELECT   [CPFSALGROUPID]  ,SALFROM, SALTO, CONCAT( [SALFROM],'-',[SALTO])  FormattedSal  FROM [MASTER_CPF_SALARY_GROUP] where Activate='A' order by CPFSALGROUPID ";
                //return new BindingList<CpfSalGroupVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<CpfSalGroupVO>());
                return new BindingList<CpfSalGroupVO>(BindClassWithData.BindClass<CpfSalGroupVO>(SQLHelper.ShowRecord(strSQL)));

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
    }
}
