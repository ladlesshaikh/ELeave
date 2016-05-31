using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using EntityMapper;

namespace ATTNPAY.Core
{
    public class ShiftRosterDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public ShiftRosterDAO()
        {
            //conn = new dbConnection();
        }
       
        #region GetDataGridDT
       public List<ShiftRosterVO> GetDataGridDT(int iAddFlag,string selValue,List<ListVO> _lstListVO,bool bExcludeBckRec)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSelValue = string.Empty;
                if (iAddFlag == 0)
                {
                    strSQL = " SELECT CONVERT(NVARCHAR(50), T.ROW_ID) ROW_ID,MB.Branch_Name,T.SCH_TYPE_ID SHIFT_SHEDULE_CODE, T.SHIFT_GROUP_ID,  \n" +
                    " CASE WHEN T.ROSTER_TYPE='S' THEN MS.SHIFT_ALIAS ELSE TS.SHCH_NAME END SHIFT_SHEDULE_NAME, \n" +
                    " CONVERT(VARCHAR(12),T.START_ON,103) START_ON, \n" +
                    " CONVERT(VARCHAR(12),T.END_ON,103) END_ON ,T.MEM_CODE,EM.Member_Name,  \n" +
                    " CASE WHEN T.ROSTER_TYPE='S' THEN 'SHIFT' ELSE 'SCHEDULE' END SHIFTorSCHU,  \n" +
                    " T.ROSTER_TYPE ROSTER_TYPE_ID,T.Activate FROM TRAN_SHIFT_ROSTER T \n" +
                    " LEFT OUTER JOIN MASTER_SHIFT_MAIN MS ON T.SCH_TYPE_ID = MS.SHIFT_ID \n" +
                    " LEFT OUTER JOIN TRAN_SHIFT_SCHEDULE_MAIN TS ON T.SCH_TYPE_ID = TS.SCH_ID \n" +
                    " INNER JOIN MASTER_EMPLOYEE_MAIN EM ON T.MEM_CODE = EM.MEM_CODE  INNER JOIN MASTER_BRANCH MB ON EM.Branch_ID = MB.Branch_ID\n" +
                    "  \n" +
                    " ORDER BY T.MEM_CODE,T.START_ON,T.END_ON";
                }
                if (iAddFlag == 1) // add flag data ...
                
                {


               //     strSqlQuarry = "SELECT 1 SELCH,M.MEM_CODE,M.Member_Name,B.Branch_Name,T.Employee_Type,D.DESIGNATION, \n" +
               //" DE.DEPARTMENT_Name,G.GRADE_Name FROM MASTER_EMPLOYEE_MAIN M  \n" +
               //" INNER JOIN MASTER_BRANCH B ON M.Branch_ID = B.Branch_ID \n" +
               //" INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
               //" INNER JOIN MASTER_DESIGNATION D ON M.DESIG_Id = D.DESIG_Id \n" +
               //" INNER JOIN MASTER_DEPARTMENT DE ON M.DEPT_Id = DE.DEPARTMENT_Id \n" +
               //" INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_ID WHERE M.MEM_CODE='" + MemberCode + "'";
         
                     
                    strSelValue = !string.IsNullOrEmpty(selValue) ? selValue : "0";
                    strSQL = "SELECT " + strSelValue + " SELCH,M.MEM_CODE,M.Member_Name,B.Branch_Name,T.Employee_Type,D.DESIGNATION, \n" +
                   " DE.DEPARTMENT_Name,G.GRADE_Name FROM MASTER_EMPLOYEE_MAIN M  \n" +
                   " INNER JOIN MASTER_BRANCH B ON M.Branch_ID = B.Branch_ID \n" +
                   " INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                   " INNER JOIN MASTER_DESIGNATION D ON M.DESIG_Id = D.DESIG_Id \n" +
                   " INNER JOIN MASTER_DEPARTMENT DE ON M.DEPT_Id = DE.DEPARTMENT_Id \n" +
                   " INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_ID ";

                    if (_lstListVO!=null && _lstListVO.Count>0)
                    {
                       // var res =string.Join(" _lstListVO.GetEnumerator()..
                       
                        //var functions = (_lstListVO)...
                        //    Select(x => new Func<string>(() => { 
                        //  //Do something here...
                        //  Console.WriteLine(x); 
                        //  return x.ToUpper(); 
                      // }));



  
                       //ForEach(x=>x.LOV.ToString().A.Ag..Aggregate((current, next) => current + ", " + next);
                       // Select(i => i.Boo).Aggregate((i, j) => i + delimeter + j)
                       // strSQL = strSQL + "  WHERE M.MEM_CODE IN(" + smemCode + "'";
                    }



                }
                return SQLHelper.ShowRecord(strSQL).DataTableToList<ShiftRosterVO>();
               // dt = SQLHelper.ShowRecord(strSQL);
               // return (dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
       #region GetDataGridDT
       public List<ShiftRosterVO> GetDataGridDT(int iAddFlag,string selValue,string smemCode,bool excludeBackRecord)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSelValue = string.Empty;
                if (iAddFlag == 0)
                {
                    strSQL = " SELECT CONVERT(NVARCHAR(50), T.ROW_ID) ROW_ID,MB.Branch_Name,T.SCH_TYPE_ID SHIFT_SHEDULE_CODE, T.SHIFT_GROUP_ID,  \n" +
                    " CASE WHEN T.ROSTER_TYPE='S' THEN MS.SHIFT_ALIAS ELSE TS.SHCH_NAME END SHIFT_SHEDULE_NAME, \n" +
                    " CONVERT(VARCHAR(12),T.START_ON,103) START_ON, \n" +
                    " CONVERT(VARCHAR(12),T.END_ON,103) END_ON ,T.MEM_CODE,EM.Member_Name,  \n" +
                    " CASE WHEN T.ROSTER_TYPE='S' THEN 'SHIFT' ELSE 'SCHEDULE' END SHIFTorSCHU,  \n" +
                    " T.ROSTER_TYPE ROSTER_TYPE_ID,T.Activate FROM TRAN_SHIFT_ROSTER T \n" +
                    " LEFT OUTER JOIN MASTER_SHIFT_MAIN MS ON T.SCH_TYPE_ID = MS.SHIFT_ID \n" +
                    " LEFT OUTER JOIN TRAN_SHIFT_SCHEDULE_MAIN TS ON T.SCH_TYPE_ID = TS.SCH_ID \n" +
                    " INNER JOIN MASTER_EMPLOYEE_MAIN EM ON T.MEM_CODE = EM.MEM_CODE  INNER JOIN MASTER_BRANCH MB ON EM.Branch_ID = MB.Branch_ID\n" +
                    "  \n" +
                    " ORDER BY T.MEM_CODE,T.START_ON,T.END_ON";
                }

                else if (iAddFlag ==1) // add flag data ...
                {

                    strSelValue = !string.IsNullOrEmpty(selValue) ? selValue : "0";
                    /* comment on 15.4.15
                    strSQL = "SELECT " + strSelValue + " SELCH,M.MEM_CODE,M.Member_Name,B.Branch_Name,T.Employee_Type,D.DESIGNATION, \n" +
                    " DE.DEPARTMENT_Name,G.GRADE_Name FROM MASTER_EMPLOYEE_MAIN M  \n" +
                    " INNER JOIN MASTER_BRANCH B ON M.Branch_ID = B.Branch_ID \n" +
                    " INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                    " INNER JOIN MASTER_DESIGNATION D ON M.DESIG_Id = D.DESIG_Id \n" +
                    " INNER JOIN MASTER_DEPARTMENT DE ON M.DEPT_Id = DE.DEPARTMENT_Id \n" +
                    " INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_ID ";
                    */ 

                    /*
                    strSQL = "SELECT " + strSelValue + " SELCH,M.MEM_CODE,M.Member_Name,B.Branch_Name,T.Employee_Type,D.DESIGNATION, \n" +
                      " DE.DEPARTMENT_Name,G.GRADE_Name,ST.START_ON,ST.END_ON,ST.Activate,CONVERT(NVARCHAR(50), ST.ROW_ID) ROW_ID FROM MASTER_EMPLOYEE_MAIN M  \n" +
                      " INNER JOIN MASTER_BRANCH B ON M.Branch_ID = B.Branch_ID \n" +
                      " INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                      " INNER JOIN MASTER_DESIGNATION D ON M.DESIG_Id = D.DESIG_Id \n" +
                      " INNER JOIN MASTER_DEPARTMENT DE ON M.DEPT_Id = DE.DEPARTMENT_Id \n" +
                      " INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_ID \n" +
                      " INNER JOIN TRAN_SHIFT_ROSTER ST ON ST.MEM_CODE=  M.MEM_CODE \n" +
                      " WHERE ST.Activate='A' \n"+
                      " ORDER BY ST.MEM_CODE,ST.START_ON,ST.END_ON"; 
                    */
                    strSQL = "SELECT " + strSelValue + " SELCH,M.MEM_CODE,M.Member_Name,B.Branch_Name,T.Employee_Type,D.DESIGNATION, \n" +
                     " DE.DEPARTMENT_Name,G.GRADE_Name FROM MASTER_EMPLOYEE_MAIN M  \n" +
                     " INNER JOIN MASTER_BRANCH B ON M.Branch_ID = B.Branch_ID \n" +
                     " INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                     " INNER JOIN MASTER_DESIGNATION D ON M.DESIG_Id = D.DESIG_Id \n" +
                     " INNER JOIN MASTER_DEPARTMENT DE ON M.DEPT_Id = DE.DEPARTMENT_Id \n" +
                     " INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_ID \n" +
                     " ORDER BY ST.MEM_CODE,ST.START_ON,ST.END_ON"; 


                }


                else if (iAddFlag == 2) // add flag data ...
                
                {


               //     strSqlQuarry = "SELECT 1 SELCH,M.MEM_CODE,M.Member_Name,B.Branch_Name,T.Employee_Type,D.DESIGNATION, \n" +
               //" DE.DEPARTMENT_Name,G.GRADE_Name FROM MASTER_EMPLOYEE_MAIN M  \n" +
               //" INNER JOIN MASTER_BRANCH B ON M.Branch_ID = B.Branch_ID \n" +
               //" INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
               //" INNER JOIN MASTER_DESIGNATION D ON M.DESIG_Id = D.DESIG_Id \n" +
               //" INNER JOIN MASTER_DEPARTMENT DE ON M.DEPT_Id = DE.DEPARTMENT_Id \n" +
               //" INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_ID WHERE M.MEM_CODE='" + MemberCode + "'";


                    if (excludeBackRecord == true)
                    {

                        strSelValue = !string.IsNullOrEmpty(selValue) ? selValue : "0";
                        strSQL = "SELECT " + strSelValue + " SELCH,M.MEM_CODE,M.Member_Name,B.Branch_Name,T.Employee_Type,D.DESIGNATION, \n" +
                       " DE.DEPARTMENT_Name,G.GRADE_Name,ST.START_ON,ST.END_ON,ST.Activate,CONVERT(NVARCHAR(50), ST.ROW_ID) ROW_ID FROM MASTER_EMPLOYEE_MAIN M  \n" +
                       " INNER JOIN MASTER_BRANCH B ON M.Branch_ID = B.Branch_ID \n" +
                       " INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                       " INNER JOIN MASTER_DESIGNATION D ON M.DESIG_Id = D.DESIG_Id \n" +
                       " INNER JOIN MASTER_DEPARTMENT DE ON M.DEPT_Id = DE.DEPARTMENT_Id \n" +
                       " INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_ID \n" +
                       " INNER JOIN TRAN_SHIFT_ROSTER ST ON ST.MEM_CODE=  M.MEM_CODE ";

                        strSQL = strSQL + "WHERE ST.Activate='A'";

                        if (!string.IsNullOrEmpty(smemCode))
                        {

                            if (smemCode.Contains(","))
                                strSQL = strSQL + "  AND M.MEM_CODE IN(" + smemCode + ")";
                            else
                                strSQL = strSQL + "  AND M.MEM_CODE=" + smemCode;
                        }



                    }// if (excludeBackRecord == true)

                    else
                    {



                        strSelValue = !string.IsNullOrEmpty(selValue) ? selValue : "0";
                        strSQL = "SELECT " + strSelValue + " SELCH,M.MEM_CODE,M.Member_Name,B.Branch_Name,T.Employee_Type,D.DESIGNATION, \n" +
                       " DE.DEPARTMENT_Name,G.GRADE_Name ,ST.START_ON,ST.END_ON,ST.Activate,CONVERT(NVARCHAR(50), ST.ROW_ID) ROW_ID FROM MASTER_EMPLOYEE_MAIN M  \n" +
                       " INNER JOIN MASTER_BRANCH B ON M.Branch_ID = B.Branch_ID \n" +
                       " INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                       " INNER JOIN MASTER_DESIGNATION D ON M.DESIG_Id = D.DESIG_Id \n" +
                       " INNER JOIN MASTER_DEPARTMENT DE ON M.DEPT_Id = DE.DEPARTMENT_Id \n" +
                       " INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_ID \n"+
                       " INNER JOIN TRAN_SHIFT_ROSTER ST ON ST.MEM_CODE=  M.MEM_CODE ";

                        if (!string.IsNullOrEmpty(smemCode))
                        {

                            if (smemCode.Contains(","))
                                strSQL = strSQL + "  WHERE M.MEM_CODE IN(" + smemCode + ")";
                            else
                                strSQL = strSQL + "  WHERE M.MEM_CODE='" + smemCode + "'";
                        }
                    }// if (excludeBackRecord == true)
                    

                }


                
                


                return SQLHelper.ShowRecord(strSQL).DataTableToList<ShiftRosterVO>();
               // dt = SQLHelper.ShowRecord(strSQL);
               // return (dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

       #region GetDataGridDT
       public List<ShiftRosterMemberVO> GetDataGridMemDT(int iAddFlag, string selValue, string smemCode, bool excludeBackRecord)
       {
           try
           {
               DataTable dt = new DataTable();
               string strSelValue = string.Empty;
               if (iAddFlag == 1) // add flag data ...
               {

                   strSelValue = !string.IsNullOrEmpty(selValue) ? selValue : "0";
                   /* comment on 15.4.15
                   strSQL = "SELECT " + strSelValue + " SELCH,M.MEM_CODE,M.Member_Name,B.Branch_Name,T.Employee_Type,D.DESIGNATION, \n" +
                   " DE.DEPARTMENT_Name,G.GRADE_Name FROM MASTER_EMPLOYEE_MAIN M  \n" +
                   " INNER JOIN MASTER_BRANCH B ON M.Branch_ID = B.Branch_ID \n" +
                   " INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                   " INNER JOIN MASTER_DESIGNATION D ON M.DESIG_Id = D.DESIG_Id \n" +
                   " INNER JOIN MASTER_DEPARTMENT DE ON M.DEPT_Id = DE.DEPARTMENT_Id \n" +
                   " INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_ID ";
                   */

                   /*
                   strSQL = "SELECT " + strSelValue + " SELCH,M.MEM_CODE,M.Member_Name,B.Branch_Name,T.Employee_Type,D.DESIGNATION, \n" +
                     " DE.DEPARTMENT_Name,G.GRADE_Name,ST.START_ON,ST.END_ON,ST.Activate,CONVERT(NVARCHAR(50), ST.ROW_ID) ROW_ID FROM MASTER_EMPLOYEE_MAIN M  \n" +
                     " INNER JOIN MASTER_BRANCH B ON M.Branch_ID = B.Branch_ID \n" +
                     " INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                     " INNER JOIN MASTER_DESIGNATION D ON M.DESIG_Id = D.DESIG_Id \n" +
                     " INNER JOIN MASTER_DEPARTMENT DE ON M.DEPT_Id = DE.DEPARTMENT_Id \n" +
                     " INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_ID \n" +
                     " INNER JOIN TRAN_SHIFT_ROSTER ST ON ST.MEM_CODE=  M.MEM_CODE \n" +
                     " WHERE ST.Activate='A' \n"+
                     " ORDER BY ST.MEM_CODE,ST.START_ON,ST.END_ON"; 
                    
                   */
                   strSQL = "SELECT " + strSelValue + " SELCH,M.MEM_CODE,M.Member_Name,B.Branch_Name,T.Employee_Type,D.DESIGNATION, \n" +
                    " DE.DEPARTMENT_Name,G.GRADE_Name, M.EMP_STATUS Activate FROM MASTER_EMPLOYEE_MAIN M  \n" +
                    " INNER JOIN MASTER_BRANCH B ON M.Branch_ID = B.Branch_ID \n" +
                    " INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                    " INNER JOIN MASTER_DESIGNATION D ON M.DESIG_Id = D.DESIG_Id \n" +
                    " INNER JOIN MASTER_DEPARTMENT DE ON M.DEPT_Id = DE.DEPARTMENT_Id \n" +
                    " INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_ID \n" +
                    " ORDER BY M.MEM_CODE";


               }


               else if (iAddFlag == 2) // add flag data ...
               {


                   //     strSqlQuarry = "SELECT 1 SELCH,M.MEM_CODE,M.Member_Name,B.Branch_Name,T.Employee_Type,D.DESIGNATION, \n" +
                   //" DE.DEPARTMENT_Name,G.GRADE_Name FROM MASTER_EMPLOYEE_MAIN M  \n" +
                   //" INNER JOIN MASTER_BRANCH B ON M.Branch_ID = B.Branch_ID \n" +
                   //" INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                   //" INNER JOIN MASTER_DESIGNATION D ON M.DESIG_Id = D.DESIG_Id \n" +
                   //" INNER JOIN MASTER_DEPARTMENT DE ON M.DEPT_Id = DE.DEPARTMENT_Id \n" +
                   //" INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_ID WHERE M.MEM_CODE='" + MemberCode + "'";


                   if (excludeBackRecord == true)
                   {

                       strSelValue = !string.IsNullOrEmpty(selValue) ? selValue : "0";
                       strSQL = "SELECT " + strSelValue + " SELCH,M.MEM_CODE,M.Member_Name,B.Branch_Name,T.Employee_Type,D.DESIGNATION, \n" +
                      " DE.DEPARTMENT_Name,G.GRADE_Name,ST.START_ON,ST.END_ON,ST.Activate,CONVERT(NVARCHAR(50), ST.ROW_ID) ROW_ID FROM MASTER_EMPLOYEE_MAIN M  \n" +
                      " INNER JOIN MASTER_BRANCH B ON M.Branch_ID = B.Branch_ID \n" +
                      " INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                      " INNER JOIN MASTER_DESIGNATION D ON M.DESIG_Id = D.DESIG_Id \n" +
                      " INNER JOIN MASTER_DEPARTMENT DE ON M.DEPT_Id = DE.DEPARTMENT_Id \n" +
                      " INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_ID \n" +
                      " INNER JOIN TRAN_SHIFT_ROSTER ST ON ST.MEM_CODE=  M.MEM_CODE ";

                       strSQL = strSQL + "WHERE ST.Activate='A'";

                       if (!string.IsNullOrEmpty(smemCode))
                       {

                           if (smemCode.Contains(","))
                               strSQL = strSQL + "  AND M.MEM_CODE IN(" + smemCode + ")";
                           else
                               strSQL = strSQL + "  AND M.MEM_CODE=" + smemCode;
                       }



                   }// if (excludeBackRecord == true)

                   else
                   {



                       strSelValue = !string.IsNullOrEmpty(selValue) ? selValue : "0";
                       strSQL = "SELECT " + strSelValue + " SELCH,M.MEM_CODE,M.Member_Name,B.Branch_Name,T.Employee_Type,D.DESIGNATION, \n" +
                      " DE.DEPARTMENT_Name,G.GRADE_Name ,ST.START_ON,ST.END_ON,ST.Activate,CONVERT(NVARCHAR(50), ST.ROW_ID) ROW_ID FROM MASTER_EMPLOYEE_MAIN M  \n" +
                      " INNER JOIN MASTER_BRANCH B ON M.Branch_ID = B.Branch_ID \n" +
                      " INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                      " INNER JOIN MASTER_DESIGNATION D ON M.DESIG_Id = D.DESIG_Id \n" +
                      " INNER JOIN MASTER_DEPARTMENT DE ON M.DEPT_Id = DE.DEPARTMENT_Id \n" +
                      " INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_ID \n" +
                      " INNER JOIN TRAN_SHIFT_ROSTER ST ON ST.MEM_CODE=  M.MEM_CODE ";

                       if (!string.IsNullOrEmpty(smemCode))
                       {

                           if (smemCode.Contains(","))
                               strSQL = strSQL + "  WHERE M.MEM_CODE IN(" + smemCode + ")";
                           else
                               strSQL = strSQL + "  WHERE M.MEM_CODE='" + smemCode + "'";
                       }
                   }// if (excludeBackRecord == true)


               }

               return SQLHelper.ShowRecord(strSQL).DataTableToList<ShiftRosterMemberVO>();
               
           }
           catch (Exception ex)
           {
               return null;
           }
       }
       #endregion

       #region GetShiftPeriod
       public List<ShiftPeriodVO> GetShiftPeriod(string strMemCode)
       {
           try
           {
                
              strSQL =  "  SELECT CONVERT(VARCHAR(12),T.START_ON,103) START_ON , CONVERT(VARCHAR(12),T.END_ON,103) END_ON " +
                        "  FROM TRAN_SHIFT_ROSTER T WHERE T.MEM_CODE= '" + strMemCode.Trim() +"' AND T.ACTIVATE='A'";
               
              return SQLHelper.ShowRecord(strSQL).DataTableToList<ShiftPeriodVO>(); 
           }
           catch (Exception exp)
           {
               return null;
           }
       }

       #endregion GetShiftPeriod


       //
        #region LoadDataGridList
        public List<ShiftRosterVO> LoadDataGridList()
        {
            try
            {
                strSQL = " SELECT CONVERT(NVARCHAR(50), T.ROW_ID) ROW_ID,MB.Branch_Name,T.SCH_TYPE_ID SHIFT_SHEDULE_CODE,CONVERT(VARCHAR, T.SHIFT_GROUP_ID) SHIFT_GROUP_ID, \n" +
                  " CASE WHEN T.ROSTER_TYPE='S' THEN MS.SHIFT_ALIAS ELSE TS.SHCH_NAME END SHIFT_SHEDULE_NAME, \n" +
                  " CONVERT(VARCHAR(12),T.START_ON,103) START_ON, \n" +
                  " CONVERT(VARCHAR(12),T.END_ON,103) END_ON ,T.MEM_CODE,EM.Member_Name,  \n" +
                  " CASE WHEN T.ROSTER_TYPE='S' THEN 'SHIFT' ELSE 'SCHEDULE' END SHIFTorSCHU,  \n" +
                  " T.ROSTER_TYPE ROSTER_TYPE_ID,T.Activate FROM TRAN_SHIFT_ROSTER T \n" +
                  " LEFT OUTER JOIN MASTER_SHIFT_MAIN MS ON T.SCH_TYPE_ID = MS.SHIFT_ID \n" +
                  " LEFT OUTER JOIN TRAN_SHIFT_SCHEDULE_MAIN TS ON T.SCH_TYPE_ID = TS.SCH_ID \n" +
                  " INNER JOIN MASTER_EMPLOYEE_MAIN EM ON T.MEM_CODE = EM.MEM_CODE  INNER JOIN MASTER_BRANCH MB ON EM.Branch_ID = MB.Branch_ID\n" +
                  "  \n" +
                  " ORDER BY T.MEM_CODE,T.START_ON,T.END_ON";
                    return SQLHelper.ShowRecord(strSQL).DataTableToList<ShiftRosterVO>();
                   // return SQLHelper.ShowRecord(strSQL).ToList<ShiftRosterVO>();
                    //List<ShiftRosterVO> list2 = SQLHelper.ShowRecord(strSQL).Rows...Cast<ShiftRosterVO>().ToList();
                    //List<ShiftRosterVO> list4 = new List<ShiftRosterVO>(SQLHelper.ShowRecord(strSQL).Select().CopyToDataTable(());
            
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<ShiftRosterVO> LoadDataGridBindingList()
        {
            try
            {
                //CONVERT(NVARCHAR(50), T.ROW_ID) ROW_ID

                strSQL = " SELECT CONVERT(NVARCHAR(50), T.ROW_ID) ROW_ID,MB.Branch_Name,T.SCH_TYPE_ID SHIFT_SHEDULE_CODE,CONVERT(VARCHAR, T.SHIFT_GROUP_ID) SHIFT_GROUP_ID, \n" +
                  " CASE WHEN T.ROSTER_TYPE='S' THEN MS.SHIFT_ALIAS ELSE TS.SHCH_NAME END SHIFT_SHEDULE_NAME, \n" +
                  " CONVERT(VARCHAR(12),T.START_ON,106) START_ON, \n" +
                  " CONVERT(VARCHAR(12),T.END_ON,106) END_ON ,T.MEM_CODE,EM.Member_Name,  \n" +
                  " CASE WHEN T.ROSTER_TYPE='S' THEN 'SHIFT' ELSE 'SCHEDULE' END SHIFTorSCHU,  \n" +
                  " T.ROSTER_TYPE ROSTER_TYPE_ID,T.Activate FROM TRAN_SHIFT_ROSTER T \n" +
                  " LEFT OUTER JOIN MASTER_SHIFT_MAIN MS ON T.SCH_TYPE_ID = MS.SHIFT_ID \n" +
                  " LEFT OUTER JOIN TRAN_SHIFT_SCHEDULE_MAIN TS ON T.SCH_TYPE_ID = TS.SCH_ID \n" +
                  " INNER JOIN MASTER_EMPLOYEE_MAIN EM ON T.MEM_CODE = EM.MEM_CODE  INNER JOIN MASTER_BRANCH MB ON EM.Branch_ID = MB.Branch_ID\n" +
                  "  \n" +
                  " ORDER BY T.MEM_CODE,T.START_ON,T.END_ON";
               
                 return new BindingList<ShiftRosterVO>(BindClassWithData.BindClass<ShiftRosterVO>(SQLHelper.ShowRecord(strSQL)));  //SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeVO>());
          
                //return new BindingList<ShiftRosterVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<ShiftRosterVO>());
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        
    }
}
