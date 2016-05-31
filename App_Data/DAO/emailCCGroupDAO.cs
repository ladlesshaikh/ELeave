using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using EntityMapper;

namespace ATTNPAY.Core
{
    public class EmailCCGroupDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// EmailCCGroupDAO
        /// </constructor>
        public EmailCCGroupDAO()
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
                    strSQL = "SELECT EMAILCC_GROUP_ID,EMAILCC_GROUP_NAME,EMAILCC_GROUP_DESC,Activate FROM MASTER_EMAILCC_GROUP";
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
        public List<EmailCCGroupVO> LoadDataGridList()
        {
            try
            {

                strSQL = "SELECT EMAILCC_GROUP_ID,EMAILCC_GROUP_NAME,EMAILCC_GROUP_DESC,Activate FROM MASTER_EMAILCC_GROUP";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<EmailCCGroupVO>();
               

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        




        #region LoadDataGridBindingList
        public BindingList<EmailCCGroupVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = "SELECT EMAILCC_GROUP_ID,EMAILCC_GROUP_NAME,EMAILCC_GROUP_DESC,Activate FROM MASTER_EMAILCC_GROUP";
                return new BindingList<EmailCCGroupVO>(BindClassWithData.BindClass<EmailCCGroupVO>(SQLHelper.ShowRecord(strSQL)));  


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
                    strSQL = "SELECT EMAILCC_GROUP_NAME FROM MASTER_EMAILCC_GROUP WHERE REPLACE(EMAILCC_GROUP_NAME,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT EMAILCC_GROUP_ID, EMAILCC_GROUP_NAME FROM MASTER_EMAILCC_GROUP WHERE REPLACE(Relationship_Name,' ','') = REPLACE('" + GroupName + "',' ','') AND EMAILCC_GROUP_ID='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["EMAILCC_GROUP_ID"].ToString().Trim())
                        {
                            //Duplicate Relation Type
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
