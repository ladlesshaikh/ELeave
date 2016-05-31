using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class ProjectTeamsDtlsDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor ProjectTeamsDtlsDAO
        /// </constructor>
        public ProjectTeamsDtlsDAO()
        {
            //conn = new dbConnection();
        }

              
        #region GetMemCodes
        public List<ListVO> GetMemCodes(int id)
        {
            try
            {
                if(id==0) // all list
                    strSQL = "SELECT MEM_CODE LOV FROM MASTER_PROJECT_TEAM_DTLS where ACTIVATE='A'";
                else
                    strSQL = "SELECT MEM_CODE LOV FROM MASTER_PROJECT_TEAM_DTLS where PROJECT_ID=" + id.ToString() + " AND ACTIVATE='A'";
                return new List<ListVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<ListVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetMemCodes

        #region LoadDataGridList
        public BindingList<ProjectTeamsDetlsVO> LoadDataGridBindingList(string strProjectTeamsID,string orderBy)
        {
            try
            {

                strSQL = "SELECT SG.ID,M.MEM_CODE,M.Member_Name,T.Employee_Type, \n" +
                   " M.DEPT_Id,D.DEPARTMENT_Name,SG.PROJECT_ID,SG.Activate, \n" +
                   " DE.DESIGNATION,G.GRADE_Name,BR.Branch_Name FROM MASTER_EMPLOYEE_MAIN M \n" +
                   " INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                   " INNER JOIN MASTER_DEPARTMENT D ON M.DEPT_Id = D.DEPARTMENT_Id \n" +
                   " INNER JOIN MASTER_DESIGNATION DE ON M.DESIG_Id = DE.DESIG_Id \n" +
                   " INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_Id \n" +
                   " INNER JOIN MASTER_BRANCH BR ON M.Branch_ID = BR.Branch_ID \n" +
                   " INNER JOIN MASTER_PROJECT_TEAM_DTLS SG ON SG.MEM_CODE=M.MEM_CODE \n" +
                   " WHERE SG.PROJECT_ID="+ strProjectTeamsID +
                   " AND M.MEM_CODE IN (SELECT MEM_CODE FROM MASTER_PROJECT_TEAM_DTLS WHERE PROJECT_ID=" + strProjectTeamsID.Trim() + ")";
                    
                    if(!string.IsNullOrEmpty(orderBy))
                         strSQL +=" Order by " + orderBy;
                   return new BindingList<ProjectTeamsDetlsVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<ProjectTeamsDetlsVO>());
               
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


                    strSQL = "SELECT SHIFT_GROUP_NAME FROM MASTER_SHIFT_GROUP WHERE REPLACE(SHIFT_GROUP_NAME,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT [SHIFT_GROUP_ID],SHIFT_GROUP_NAME FROM MASTER_SHIFT_GROUP WHERE REPLACE(SHIFT_GROUP_NAME,' ','') = REPLACE('" + GroupName + "',' ','') AND SHIFT_GROUP_ID='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);
                    
                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["ID"].ToString().Trim())
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

    }
}
