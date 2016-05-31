using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class TourDAO
    {
       // private dbConnection conn;
        string strSQL = string.Empty;

        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public TourDAO()
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
                    strSQL = "SELECT PLACE_Id,PLACE_Name,ACTIVATE FROM MASTER_TOUR_PLACE";
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
        public List<TourVO> LoadDataGridList()
        {
            try
            {
                strSQL = "SELECT PLACE_Id,PLACE_Name,ACTIVATE FROM MASTER_TOUR_PLACE";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<TourVO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<TourVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = "SELECT PLACE_Id,PLACE_Name,ACTIVATE FROM MASTER_TOUR_PLACE";
                return new BindingList<TourVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<TourVO>());
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
                    strSQL = "SELECT PLACE_Name FROM MASTER_TOUR_PLACE WHERE REPLACE(PLACE_Name,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT PLACE_Id,PLACE_Name FROM MASTER_TOUR_PLACE WHERE REPLACE(PLACE_Id,' ','') = REPLACE('" + GroupName + "',' ','') AND PLACE_Id='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["ID"].ToString().Trim())
                        {
                           // Duplicate PLACE NAME
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
