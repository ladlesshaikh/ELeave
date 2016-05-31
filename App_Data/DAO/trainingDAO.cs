using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class TrainingDAO
    {
       // private dbConnection conn;
        string strSQL = string.Empty;

        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public TrainingDAO()
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
                    strSQL = "SELECT TRA_Id,TRANING_Name,ACTIVATE FROM  MASTER_TRANING";
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
        public List<TrainingVO> LoadDataGridList()
        {
            try
            {
                strSQL = "SELECT TRA_Id,TRANING_Name,ACTIVATE FROM  MASTER_TRANING";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<TrainingVO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<TrainingVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = "SELECT TRA_Id,TRANING_Name,ACTIVATE FROM  MASTER_TRANING";
                return new BindingList<TrainingVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<TrainingVO>());
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
                    strSQL = "SELECT TRANING_Name FROM MASTER_TRANING WHERE REPLACE(TRANING_Name,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT TRA_Id,TRANING_Name FROM MASTER_TRANING WHERE REPLACE(TRA_Id,' ','') = REPLACE('" + GroupName + "',' ','') AND TRA_Id='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["ID"].ToString().Trim())
                        {
                            // Duplicate TRANING NAME
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
