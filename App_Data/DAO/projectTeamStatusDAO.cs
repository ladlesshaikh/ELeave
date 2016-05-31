using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class ProjectTeamStatusDAO
    {
        // private dbConnection conn;
        string strSQL = string.Empty;

        /// <constructor>
        /// Constructor YearDAO
        /// </constructor>
        public ProjectTeamStatusDAO()
        {
            //conn = new dbConnection();
        }

        #region GetStatusList()
        public List<ProjectTeamStatusVO> GetStatusList()
        {
            try
            {
                //  SELECT
                //   distinct
                //    project.PROJECT_ID, 
                //    count(leave.MEM_CODE)over(partition by project.PROJECT_ID) as Leave_Count,
                //    count(*)over(partition by project.PROJECT_ID) as Mem_Count
                //FROM MASTER_PROJECT_TEAM_DTLS  project_teams
                //left join MASTER_PROJECT project on project_teams.PROJECT_ID = project.PROJECT_ID
                //left join TRAN_LEAVE leave on project_teams.MEM_CODE = leave.MEM_CODE
                //WHERE project_teams.Activate = 'A' AND Leave.Is_Sanctioned = 1



                strSQL = " SELECT  distinct \n" +
                " project.PROJECT_ID, project.PROJECT_NAME,project_teams.MEM_CODE,empmaster.Member_Name, project_teams.ACTIVATE,\n" +
                " project.PROJECT_ID, \n" +
                " count(leave.MEM_CODE)over(partition by project.PROJECT_ID) as Leave_Count, \n" +
                " count(*)over(partition by project.PROJECT_ID) as Mem_Count \n" +
                " FROM MASTER_PROJECT_TEAM_DTLS  project_teams \n" +
                " left join MASTER_EMPLOYEE_MAIN empmaster on project_teams.MEM_CODE = empmaster.MEM_CODE \n" +
                " left join MASTER_PROJECT project on project_teams.PROJECT_ID = project.PROJECT_ID \n" +
                " left join TRAN_LEAVE leave on project_teams.MEM_CODE = leave.MEM_CODE \n" +
                " WHERE project_teams.Activate = 'A' AND Leave.Is_Sanctioned = 1";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<ProjectTeamStatusVO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...


        #region GetStatusList()
        public List<ProjectTeamStatusVO> GetStatusList(string mem_code)
        {
            try
            {


                strSQL = " SELECT  distinct \n" +
                " project.PROJECT_ID, project.PROJECT_NAME,project_teams.MEM_CODE ,empmaster.Member_Name  , project_teams.ACTIVATE ,\n" +
                " project.PROJECT_ID, \n" +
                " count(leave.MEM_CODE)over(partition by project.PROJECT_ID) as Leave_Count, \n" +
                " count(*)over(partition by project.PROJECT_ID) as Mem_Count \n" +
                " FROM MASTER_PROJECT_TEAM_DTLS  project_teams \n" +
                " left join MASTER_EMPLOYEE_MAIN empmaster on project_teams.MEM_CODE = empmaster.MEM_CODE \n" +
                " left join MASTER_PROJECT project on project_teams.PROJECT_ID = project.PROJECT_ID \n" +
                " left join TRAN_LEAVE leave on project_teams.MEM_CODE = leave.MEM_CODE \n" +
                " WHERE project_teams.Activate = 'A' AND Leave.Is_Sanctioned = 1 \n" +
                " AND project.PROJECT_ID = (SELECT PROJECT_ID FROM MASTER_PROJECT_TEAM_DTLS MP WHERE MP.MEM_CODE = " + mem_code.Trim() + " AND MP.ACTIVATE = 'A')";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<ProjectTeamStatusVO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...


        #region LoadDataGridBindingList
        public BindingList<ProjectTeamStatusVO> LoadDataGridBindingList()
        {
            try
            {

                strSQL = " SELECT  distinct \n" +
                " project.PROJECT_ID, project.PROJECT_NAME,project_teams.MEM_CODE,empmaster.Member_Name, project_teams.ACTIVATE,\n" +
                " project.PROJECT_ID, \n" +
                " count(leave.MEM_CODE)over(partition by project.PROJECT_ID) as Leave_Count, \n" +
                " count(*)over(partition by project.PROJECT_ID) as Mem_Count \n" +
                " FROM MASTER_PROJECT_TEAM_DTLS  project_teams \n" +
                " left join MASTER_EMPLOYEE_MAIN empmaster on project_teams.MEM_CODE = empmaster.MEM_CODE \n" +
                " left join MASTER_PROJECT project on project_teams.PROJECT_ID = project.PROJECT_ID \n" +
                " left join TRAN_LEAVE leave on project_teams.MEM_CODE = leave.MEM_CODE \n" +
                " WHERE project_teams.Activate = 'A' AND Leave.Is_Sanctioned = 1";
                return new BindingList<ProjectTeamStatusVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<ProjectTeamStatusVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...





    }
}
