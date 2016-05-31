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
    public class ProjectDAO
    {
       // private dbConnection conn;
        string strSQL = string.Empty;

        /// <constructor>
        /// Constructor YearDAO
        /// </constructor>
        public ProjectDAO()
        {
            //conn = new dbConnection();
        }

        #region GetProjectList()
        public List<ProjectVO> GetProjectList()
        {
            try
            {
                strSQL =    "SELECT MD.MONTH_NAME ,MONTH_NO ,MD.MAIN_ID Year_ID  FROM MASTER_YEAR_MAIN YM \n" +
                            " INNER JOIN MASTER_YEAR_DTLS MD ON YM.MAIN_ID = MD.MAIN_ID \n" +
                            " WHERE MD.ACTIVATE='A' AND ISNULL(YM.CurrentYear,0) = 1 ";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<ProjectVO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridList
        public List<ProjectVO> LoadDataGridList()
        {
            try
            {
                strSQL = "SELECT PROJECT_ID,PROJECT_NAME,[PROJECT_DESC],[ISACTIVE],[Start_Date],[Estimated_Date],[Completed_Date],ACTIVATE FROM MASTER_PROJECT";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<ProjectVO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<ProjectVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = "SELECT PROJECT_ID,PROJECT_NAME,[PROJECT_DESC],[ISACTIVE],[Start_Date],[Estimated_Date],ISNULL([Completed_Date],NULL) Completed_Date ,ACTIVATE FROM MASTER_PROJECT";
               // var lst = BindClassWithData.BindClass<ProjectVO>(SQLHelper.ShowRecord(strSQL));
                //return new BindingList<AttnClockAmendmentVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<AttnClockAmendmentVO>());
                return new BindingList<ProjectVO>(BindClassWithData.BindClass<ProjectVO>(SQLHelper.ShowRecord(strSQL)));

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
                    strSQL = "SELECT PROJECT_NAME FROM MASTER_PROJECT WHERE REPLACE(PROJECT_NAME,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT PROJECT_ID,PROJECT_NAME FROM MASTER_PROJECT WHERE REPLACE(PROJECT_ID,' ','') = REPLACE('" + GroupName + "',' ','') AND PLACE_Id='" + strRowId + "' ";
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
