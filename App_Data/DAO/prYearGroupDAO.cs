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
    public class PrYearGroupDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor PrYearGroupDAO
        /// </constructor>
        public PrYearGroupDAO()
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
                    strSQL = " SELECT  [PRYearGroup_Name] FROM [MASTER_PRYEAR_GROUP] REPLACE(PRYearGroup_Name,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT  [PRYearGroup_Name] FROM [MASTER_PRYEAR_GROUP] WHERE REPLACE(PRYearGroup_Name,' ','') = REPLACE('" + GroupName + "',' ','') AND PRYearGroup_id='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);

                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["PRYearGroup_id"].ToString().Trim())
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
                    strSQL = " SELECT  [PRYearGroup_id],[PRYearGroup_Name],[ACTIVATE] FROM [MASTER_PRYEAR_GROUP]";
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
        public List<PRYearGroupVO> LoadDataGridList()
        {
            try
            {
                strSQL = " SELECT  [PRYearGroup_id],[PRYearGroup_Name],[ACTIVATE] FROM [MASTER_PRYEAR_GROUP]";
                //return SQLHelper.ShowRecord(strSQL).DataTableToList<PRYearGroupVO>();
                return   BindClassWithData.BindClass<PRYearGroupVO>(SQLHelper.ShowRecord(strSQL)).ToList();  

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<PRYearGroupVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = " SELECT  [PRYearGroup_id],[PRYearGroup_Name],[ACTIVATE] FROM [MASTER_PRYEAR_GROUP]";
                //return new  BindingList<PRYearGroupVO>(  SQLHelper.ShowRecord(strSQL).DataTableToList<PRYearGroupVO>());
                return new BindingList<PRYearGroupVO>(BindClassWithData.BindClass<PRYearGroupVO>(SQLHelper.ShowRecord(strSQL)));  
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
    }
}
