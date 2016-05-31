using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Globalization;

namespace ATTNPAY.Core
{
    public class DepartmentDAO
    {
        // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public DepartmentDAO()
        {
            //conn = new dbConnection();
        }


        #region GetStatusList()
        public List<DepartmentEmployeeStatusVO> GetStatusList(string mem_code, DateTime fromDt, DateTime toDt)
        {
            try
            {
                #region Comment

                //strSQL = " SELECT  distinct \n" +
                //" project.PROJECT_ID, project.PROJECT_NAME,project_teams.MEM_CODE ,empmaster.Member_Name  , project_teams.ACTIVATE ,\n" +
                //" project.PROJECT_ID, \n" +
                //" count(leave.MEM_CODE)over(partition by project.PROJECT_ID) as Leave_Count, \n" +
                //" count(*)over(partition by project.PROJECT_ID) as Mem_Count \n" +
                //" FROM MASTER_PROJECT_TEAM_DTLS  project_teams \n" +
                //" left join MASTER_EMPLOYEE_MAIN empmaster on project_teams.MEM_CODE = empmaster.MEM_CODE \n" +
                //" left join MASTER_PROJECT project on project_teams.PROJECT_ID = project.PROJECT_ID \n" +
                //" left join TRAN_LEAVE leave on project_teams.MEM_CODE = leave.MEM_CODE \n" +
                //" WHERE project_teams.Activate = 'A' AND Leave.Is_Sanctioned = 1 \n" +
                //" AND project.PROJECT_ID = (SELECT PROJECT_ID FROM MASTER_PROJECT_TEAM_DTLS MP WHERE MP.MEM_CODE = " + mem_code.Trim() + " AND MP.ACTIVATE = 'A')";
                //return SQLHelper.ShowRecord(strSQL).DataTableToList<DepartmentEmployeeStatusVO>();

                //strSQL = " SELECT distinct \n" +
                //" dept.DEPARTMENT_Id,   dept.DEPARTMENT_Name,employees.MEM_CODE ,empmaster.Member_Name  , employees.EMP_STATUS ,\n" +
                //" count(leave.MEM_CODE) over(partition by dept.DEPARTMENT_Id) as Leave_Count, \n" +
                //" count(*) over(partition by dept.DEPARTMENT_Id) as Mem_Count, \n" +
                //" CAST(count(leave.MEM_CODE) over(partition by dept.DEPARTMENT_Id) AS float) / CAST((SELECT COUNT(*)  FROM  MASTER_EMPLOYEE_MAIN DD WHERE DEPT_Id = \n" +
                //" (SELECT DEPT_Id FROM MASTER_EMPLOYEE_MAIN MP1 WHERE MP1.MEM_CODE ='" + mem_code.Trim() + "' AND MP1.EMP_STATUS = 'A')) AS float) *100.00 AS  Percent \n" +
                //" FROM MASTER_EMPLOYEE_MAIN  employees \n" +
                //" left join MASTER_EMPLOYEE_MAIN empmaster on employees.MEM_CODE = empmaster.MEM_CODE \n" +
                //" left join MASTER_DEPARTMENT dept on employees.DEPT_Id = dept.DEPARTMENT_Id \n" +
                //" left join TRAN_LEAVE leave on employees.MEM_CODE = leave.MEM_CODE \n" +
                //" WHERE employees.EMP_STATUS = 'A' AND Leave.Is_Sanctioned = 1 \n" +
                //" AND dept.DEPARTMENT_Id = (SELECT DEPT_Id FROM MASTER_EMPLOYEE_MAIN MP WHERE MP.MEM_CODE = '" + mem_code.Trim() + "' AND MP.EMP_STATUS = 'A') \n" +
                //" AND leave.FROM_DATE >= '" + fromDt.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + "' AND leave.TO_DATE <= '" + toDt.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + "'\n";

                #endregion Comment



                strSQL = " SELECT distinct dept.DEPARTMENT_Id,\n" +
                           " dept.DEPARTMENT_Name,\n" +
                           " employees.MEM_CODE ,\n" +
                           " empmaster.Member_Name  , \n" +
                           " employees.EMP_STATUS ,\n" +
                           " count(leave.MEM_CODE) over(partition by dept.DEPARTMENT_Id) as Leave_Count, \n" +
                            " count(*) over(partition by dept.DEPARTMENT_Id) as Mem_Count, \n" +
                            " (CAST(count(leave.MEM_CODE) over(partition by dept.DEPARTMENT_Id) AS float)) /\n" +
                            " (CAST(\n" +
                            " (SELECT COUNT(*)  FROM  MASTER_EMPLOYEE_MAIN DD WHERE DEPT_Id =\n" +
                            " (SELECT DEPT_Id FROM MASTER_EMPLOYEE_MAIN MP1 WHERE MP1.MEM_CODE = '" + mem_code.Trim() + "' AND MP1.EMP_STATUS = 'A')) AS float)) *100.00 AS TotPercentage\n" +
                            " FROM MASTER_EMPLOYEE_MAIN  employees\n" +
                            " left join MASTER_EMPLOYEE_MAIN empmaster on employees.MEM_CODE = empmaster.MEM_CODE\n" +
                            " left join MASTER_DEPARTMENT dept on employees.DEPT_Id = dept.DEPARTMENT_Id\n" +
                            " left join TRAN_LEAVE leave on employees.MEM_CODE = leave.MEM_CODE\n" +
                            " WHERE employees.EMP_STATUS = 'A' AND Leave.Is_Sanctioned = 1\n" +
                            " AND dept.DEPARTMENT_Id = (SELECT DEPT_Id FROM MASTER_EMPLOYEE_MAIN MP WHERE MP.MEM_CODE = '" + mem_code.Trim() + "'  AND MP.EMP_STATUS = 'A')\n" +
                            " AND leave.FROM_DATE >= '" + fromDt.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture) + "' AND leave.TO_DATE <= '" + toDt.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture) + "'";

                return SQLHelper.ShowRecord(strSQL).DataTableToList<DepartmentEmployeeStatusVO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...






        #region GetLoadDataGridDT
        private DataTable GetLoadDataGridDT()
        {
            try
            {

                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT DEPARTMENT_Id,DEPARTMENT_Name,ACTIVATE FROM dbo.MASTER_DEPARTMENT";

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
        public List<DepartmentVO> LoadDataGridList()
        {
            try
            {

                strSQL = "SELECT DEPARTMENT_Id,DEPARTMENT_Name,ACTIVATE FROM dbo.MASTER_DEPARTMENT";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<DepartmentVO>();
                //return SQLHelper.ShowRecord(strSQL).ToList<DepartmentVO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        // #region LoadDataGridBindingList
        //public BindingList<BankVO> LoadDataGridBindingList()
        #region LoadDataGridList
        public BindingList<DepartmentVO> LoadDataGridBindingList()
        {
            try
            {

                strSQL = "SELECT DEPARTMENT_Id,DEPARTMENT_Name,ACTIVATE FROM dbo.MASTER_DEPARTMENT";
                return new BindingList<DepartmentVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<DepartmentVO>());

                //return SQLHelper.ShowRecord(strSQL).ToList<DepartmentVO>();
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
                    strSQL = "SELECT DEPARTMENT_Name FROM MASTER_DEPARTMENT WHERE REPLACE(DEPARTMENT_Name,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT DEPARTMENT_Id,DEPARTMENT_Name FROM MASTER_DEPARTMENT WHERE REPLACE(DEPARTMENT_Id,' ','') = REPLACE('" + GroupName + "',' ','') AND DEPARTMENT_Id='" + strRowId + "' ";
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
