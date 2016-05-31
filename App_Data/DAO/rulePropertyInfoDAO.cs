using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class RulePropertyInfoDAO 
    {
       // private dbConnection conn;
        string strSQL = string.Empty;

        /// <constructor>
        /// Constructor RulePropertyInfoDAO
        /// </constructor>
        public RulePropertyInfoDAO()
        {
            //conn = new dbConnection();
        }




        #region getRulePropertyInfoDT
        public DataTable getRulePropertyInfoDT(string strMemCode)
        {
            try
            {
                using (DataTable dt = new DataTable())
                {

                    strSQL = "  A.[MEM_CODE] ,A.[Branch_ID] Branch ,A.[DOB] BirthDate ,A.[SEX] Sex  , MS.STATUS_Type  MaritalStatus ,RS.ResidenceStatusName  PRstatus ,A.[PR_DATE] PRDate ,A.[DOJ] JoiningDate,A.[WEEK_ENGAGED] WeekEngaged";
                    strSQL += "  , B.Employee_Type  EmployeeType ,C.DEPARTMENT_Name Department ,D.CAT_NAME  Category ,E.DESIGNATION  Designation,F.GRADE_Name Grade ,G.PAY_Name PayName , A.[City],A.[State],A.[Country] ";
                    strSQL += "  ,A.[OVERTIME_RATE] OvertimeRate ,A.[HourlyRate]  HourlyRate ,A.[NoOfWorkingDay] NoOfWorkingDay,A.[DailyPayRate] DailyRate";
                    strSQL += "  WHERE A.Activate='A'" ;
                    strSQL += " INNER JOIN  MASTER_MARITAL_STATUS MMS  ON  MMS.STATUS_Type= A.STATUS_Type";
                    
                    
                    //  A.[CAT_ID],A.[DESIG_Id],A.[DESIG_Id], [GRADE_Id],A.[PaymentId],A.[PRStatusID],A.[MARITAL_STATUS_Id]
                    return SQLHelper.ShowRecord(strSQL);
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region GetRulePropertyInfo(string strMemCode)
        public List<RulePropertyInfoVO> getRulePropertyInfo(string strMemCode)
        {
            try
            {

                strSQL = "  A.[MEM_CODE] ,A.[Branch_ID] Branch ,A.[DOB] BirthDate ,A.[SEX] Sex ,A.[MARITAL_STATUS_Id] MaritalStatus ,A.[PRStatusID] PRstatus ,A.[PR_DATE] PRDate ,A.[DOJ] JoiningDate,A.[WEEK_ENGAGED] WeekEngaged";
                strSQL += "  ,A.[Employee_Type_Id] EmployeeType ,A.[DEPT_Id] Department ,A.[CAT_ID] Category ,A.[DESIG_Id] Designation,A.[GRADE_Id] Grade ,A.[PaymentId] PaymentMode ,A.[PAY_Id] PayName ,A.[City],A.[State],A.[Country] ";
                strSQL += "  ,A.[OVERTIME_RATE] OvertimeRate ,A.[HourlyRate]  HourlyRate ,A.[NoOfWorkingDay] NoOfWorkingDay,A.[DailyPayRate] DailyRate";
                strSQL += "  WHERE A.Activate='A'";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<RulePropertyInfoVO>();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region GetRulePropertyInfo()
        public List<RulePropertyInfoVO> getRulePropertyInfo()
        {
            try
            {

                strSQL = "  A.[MEM_CODE] ,A.[Branch_ID] Branch ,A.[DOB] BirthDate ,A.[SEX] Sex ,A.[MARITAL_STATUS_Id] MaritalStatus ,A.[PRStatusID] PRstatus ,A.[PR_DATE] PRDate ,A.[DOJ] JoiningDate,A.[WEEK_ENGAGED] WeekEngaged";
                strSQL += "  ,A.[Employee_Type_Id] EmployeeType ,A.[DEPT_Id] Department ,A.[CAT_ID] Category ,A.[DESIG_Id] Designation,A.[GRADE_Id] Grade ,A.[PaymentId] PaymentMode ,A.[PAY_Id] PayName ,A.[City],A.[State],A.[Country] ";
                strSQL += "  ,A.[OVERTIME_RATE] OvertimeRate ,A.[HourlyRate]  HourlyRate ,A.[NoOfWorkingDay] NoOfWorkingDay,A.[DailyPayRate] DailyRate";
                strSQL += "  WHERE A.Activate='A'";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<RulePropertyInfoVO>(); 
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        //public BindingList<RuleInfoTypeVO> LoadDataGridBindingList()
        //{
        //    try
        //    {
        //            strSQL = "SELECT ID,INFO_TYPE,Property,Activate FROM MASTER_RULE_INFO WHERE Activate='A'";
        //            return new BindingList<RuleInfoTypeVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<RuleInfoTypeVO>());
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
       #endregion ...




    }
}
