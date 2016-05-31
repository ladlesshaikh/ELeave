using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using ATTNPAY.Class;
using System.Linq;
using EntityMapper;
namespace ATTNPAY.Core
{
    public class EmployeeDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public EmployeeDAO()
        {
            //conn = new dbConnection();
        }



        #region GetRoMemberInfo
        public List<RoMemberInfoVO> GetRoMemberInfo(string strMemCode)
        {
            try
            {

                strSQL = " SELECT ISNULL(A.RO_MEM_CODE, '') MEM_CODE , b.Member_Name, ISNULL(A.SEQ_NO,0) SeqNo,ISNULL(B.EmailAddress, '') EMAIL ,0 ISADMIN \n" +
                        "  FROM[dbo].[MASTER_RO_DTLS] A INNER JOIN MASTER_EMPLOYEE_MAIN B \n" +
                        "  ON A.RO_MEM_CODE=B.MEM_CODE WHERE A.MEM_CODE ='" + strMemCode.Trim() + "' AND A.Activate='A'  \n" +
                        "  UNION \n" +
                        "  SELECT  U.MEM_CODE, E.Member_Name,0 SeqNo, ISNULL(E.EmailAddress, '') EMAIL,1 ISADMIN  \n" +
                        "  FROM MASTER_USER U \n" +
                        "  INNER JOIN MASTER_USER_GROUP R ON U.ROLE_ID = R.ROW_ID \n" +
                        "  INNER JOIN MASTER_EMPLOYEE_MAIN E ON U.MEM_CODE = E.MEM_CODE WHERE U.Branch_Id= 1 \n" +
                       // "  AND UPPER(R.ROLE_NAME)='ADMIN' AND E.EMP_STATUS='A'";
                       "  AND E.EMP_STATUS='A'";
                return BindClassWithData.BindClass<RoMemberInfoVO>(SQLHelper.ShowRecord(strSQL)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetRoMemberInfo


        #region GetRoMemberInfo
        public List<RoMemberInfoVO> GetRoMemberInfo(string strMemCode, bool isAll)
        {
            try
            {
                if (isAll == true)
                {
                    strSQL = " SELECT ISNULL(A.RO_MEM_CODE, '') MEM_CODE , b.Member_Name, ISNULL(A.SEQ_NO,0) SeqNo,ISNULL(B.EmailAddress, '') EMAIL ,0 ISADMIN \n" +
                            "  FROM[dbo].[MASTER_RO_DTLS] A INNER JOIN MASTER_EMPLOYEE_MAIN B \n" +
                            "  ON A.RO_MEM_CODE=B.MEM_CODE WHERE A.MEM_CODE ='" + strMemCode.Trim() + "' AND A.Activate='A'  \n" +
                            "  UNION \n" +
                            "  SELECT  U.MEM_CODE, E.Member_Name,0 SeqNo, ISNULL(E.EmailAddress, '') EMAIL,1 ISADMIN  \n" +
                            "  FROM MASTER_USER U \n" +
                            "  INNER JOIN MASTER_USER_GROUP R ON U.ROLE_ID = R.ROW_ID \n" +
                            "  INNER JOIN MASTER_EMPLOYEE_MAIN E ON U.MEM_CODE = E.MEM_CODE WHERE U.Branch_Id= 1 \n" +
                            "  AND UPPER(R.ROLE_NAME)='ADMIN' AND E.EMP_STATUS='A' ORDER by SEQNO";
                }
                else
                {

                    strSQL = " SELECT ISNULL(A.RO_MEM_CODE, '') MEM_CODE , b.Member_Name, ISNULL(A.SEQ_NO,0) SeqNo,ISNULL(B.EmailAddress, '') EMAIL ,0 ISADMIN \n" +
                          "  FROM[dbo].[MASTER_RO_DTLS] A INNER JOIN MASTER_EMPLOYEE_MAIN B \n" +
                          "  ON A.RO_MEM_CODE=B.MEM_CODE WHERE A.MEM_CODE ='" + strMemCode.Trim() + "' AND A.Activate='A'  order by A.SEQ_NO";

                }


                return BindClassWithData.BindClass<RoMemberInfoVO>(SQLHelper.ShowRecord(strSQL)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<RoMemberInfoVO> getRoName(string strMemCode)
        {
            try
            {
                
                    strSQL = " SELECT ISNULL(A.MEM_CODE, '') MEM_CODE , a.Member_Name, ISNULL(a.EmailAddress, '') EMAIL  \n" +
                          "  FROM  MASTER_EMPLOYEE_MAIN a \n" +
                          " WHERE a.MEM_CODE ='" + strMemCode.Trim() + "'";

                

                return BindClassWithData.BindClass<RoMemberInfoVO>(SQLHelper.ShowRecord(strSQL)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetRoMemberInfo


        #region GetEmployeesRO
        public List<KeyValue> GetEmployeesROs(string strMemCode)
        {
            try
            {
                // strSQL = "SELECT ISNULL(RO_MEM_CODE, '') RO_MEM_CODE FROM MASTER_EMPLOYEE_MAIN WHERE MEM_CODE = '" + strMemCode.Trim() + "'";

                strSQL = " SELECT ISNULL(A.RO_MEM_CODE, '') RO_MEM_CODE , ISNULL(B.EmailAddress, '') RO_EMAIL \n" +
                         " FROM[dbo].[MASTER_RO_DTLS] A INNER JOIN MASTER_EMPLOYEE_MAIN B \n" +
                        "  ON A.MEM_CODE=B.MEM_CODE WHERE A.MEM_CODE ='" + strMemCode.Trim() + "' AND A.Activate='A'";
                return BindClassWithData.BindClass<KeyValue>(SQLHelper.ShowRecord(strSQL)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
#endregion GetEmployeesRO


        #region GetEmployeesRO
        public string GetEmployeesRO(string strMemCode)
        {
            try
            {
                strSQL = "SELECT ISNULL(RO_MEM_CODE, '') RO_MEM_CODE FROM MASTER_EMPLOYEE_MAIN WHERE MEM_CODE = '" + strMemCode.Trim() + "'";
                return SQLHelper.GetSingleValue(strSQL);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        #endregion GetEmployeesRO

        #region GetEmployeesRO
        public List<string> GetRODetEmail(string strMemCode)
        {
            try
            {

                //strSQL = " SELECT ISNULL(RO_MEM_CODE, '') RO_MEM_CODE ,(SELECT  ISNULL(EmailAddress, '') RO_EMAIL \n" +
                //           " FROM MASTER_EMPLOYEE_MAIN WHERE  MEM_CODE = \n" +
                //           " (SELECT ISNULL(RO_MEM_CODE, '') MEM_CODE FROM MASTER_EMPLOYEE_MAIN WHERE MEM_CODE = '" + strMemCode.Trim() + "' )) RO_EMAIL \n" +
                //           " FROM MASTER_EMPLOYEE_MAIN WHERE MEM_CODE = '" + strMemCode.Trim() + "'";
                strSQL = " SELECT (SELECT  ISNULL(EmailAddress, '') RO_EMAIL \n" +
                   " FROM MASTER_EMPLOYEE_MAIN WHERE  MEM_CODE = \n" +
                   " (SELECT ISNULL(RO_MEM_CODE, '') MEM_CODE FROM [MASTER_RO_DTLS] WHERE MEM_CODE = '" + strMemCode.Trim() + "' AND SEQ_NO = 1) ) RO_EMAIL \n" +
                   " FROM MASTER_EMPLOYEE_MAIN WHERE MEM_CODE = '" + strMemCode.Trim() + "'";

                return (SQLHelper.ShowRecord(strSQL).Rows[0].ItemArray.Select(x => x.ToString()).ToArray().ToList<string>());

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<string> GetROAppDetEmail(string strMemCode)
        {
            try
            {

                //strSQL = " SELECT ISNULL(RO_MEM_CODE, '') RO_MEM_CODE ,(SELECT  ISNULL(EmailAddress, '') RO_EMAIL \n" +
                //           " FROM MASTER_EMPLOYEE_MAIN WHERE  MEM_CODE = \n" +
                //           " (SELECT ISNULL(RO_MEM_CODE, '') MEM_CODE FROM MASTER_EMPLOYEE_MAIN WHERE MEM_CODE = '" + strMemCode.Trim() + "' )) RO_EMAIL \n" +
                //           " FROM MASTER_EMPLOYEE_MAIN WHERE MEM_CODE = '" + strMemCode.Trim() + "'";
                strSQL = " SELECT  ISNULL(EmailAddress, '') RO_EMAIL \n" +
                   " FROM MASTER_EMPLOYEE_MAIN WHERE   \n" +
                   " MEM_CODE = '" + strMemCode.Trim() + "' ";
                  

                return (SQLHelper.ShowRecord(strSQL).Rows[0].ItemArray.Select(x => x.ToString()).ToArray().ToList<string>());

            }
            catch (Exception ex)
            {
                return null;
            }
        }
      
        public List<string> GetROCCtEmail(string strMemCode, string ApprMemCode)
        {
            try
            {

                //strSQL = " SELECT ISNULL(RO_MEM_CODE, '') RO_MEM_CODE ,(SELECT  ISNULL(EmailAddress, '') RO_EMAIL \n" +
                //           " FROM MASTER_EMPLOYEE_MAIN WHERE  MEM_CODE = \n" +
                //           " (SELECT ISNULL(RO_MEM_CODE, '') MEM_CODE FROM MASTER_EMPLOYEE_MAIN WHERE MEM_CODE = '" + strMemCode.Trim() + "' )) RO_EMAIL \n" +
                //           " FROM MASTER_EMPLOYEE_MAIN WHERE MEM_CODE = '" + strMemCode.Trim() + "'";
                if (ApprMemCode.ToString() !="")

                {
                    strSQL = " SELECT ISNULL(EmailAddress, '') EmailAddress \n" +
                             " FROM MASTER_EMPLOYEE_MAIN WHERE  MEM_CODE = (SELECT top 1 ISNULL(RO_MEM_CODE, '') \n" +
                             "  MEM_CODE FROM dbo.MASTER_RO_DTLS WHERE MEM_CODE = '" + strMemCode.Trim() + "' and ro_mem_code not in ('" + ApprMemCode.Trim() + "') )";
                }
                else
                {
                    strSQL = " SELECT ISNULL(EmailAddress, '') EmailAddress \n" +
                                              " FROM MASTER_EMPLOYEE_MAIN WHERE  MEM_CODE = (SELECT top 1 ISNULL(RO_MEM_CODE, '') \n" +
                                              "  MEM_CODE FROM dbo.MASTER_RO_DTLS WHERE MEM_CODE = '" + strMemCode.Trim() + "')";

                }



                return (SQLHelper.ShowRecord(strSQL).Rows[0].ItemArray.Select(x => x.ToString()).ToArray().ToList<string>());

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<string> GetRODet(string strMemCode)
        {
            try
            {

                strSQL = " SELECT ISNULL(RO_MEM_CODE, '') RO_MEM_CODE ,(SELECT  ISNULL(EmailAddress, '') RO_EMAIL \n" +
                           " FROM MASTER_EMPLOYEE_MAIN WHERE  MEM_CODE = \n" +
                           " (SELECT ISNULL(RO_MEM_CODE, '') MEM_CODE FROM MASTER_EMPLOYEE_MAIN WHERE MEM_CODE = '" + strMemCode.Trim() + "' )) RO_EMAIL \n" +
                           " FROM MASTER_EMPLOYEE_MAIN WHERE MEM_CODE = '" + strMemCode.Trim() + "'";
                return (SQLHelper.ShowRecord(strSQL).Rows[0].ItemArray.Select(x => x.ToString()).ToArray().ToList<string>());

            }
            catch (Exception ex)
            {
                return null;
            }
        }
       
        #endregion GetEmployeesRO



        #region GetAdminUserID
        public LoginUserVO GetAdminUser(string strBranchCode)
        {
            try
            {

                strSQL = "SELECT U.ROW_ID,U.USER_NAME,U.MEM_CODE,E.Member_Name, U.Password, \n" +
                " U.PasswordHint,U.ROLE_ID,R.ROLE_NAME,U.Activate FROM MASTER_USER U  \n" +
                " INNER JOIN MASTER_USER_GROUP R ON U.ROLE_ID = R.ROW_ID  \n" +
                " INNER JOIN MASTER_EMPLOYEE_MAIN E ON U.MEM_CODE = E.MEM_CODE WHERE U.Branch_Id=" + strBranchCode + "\n" +
                " AND UPPER(R.ROLE_NAME)='ADMIN'";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<LoginUserVO>().FirstOrDefault();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region GetEmployeeDropdownList
        public List<ComboBoxFill> GetEmployeeDropdownList(bool bChecked, string orderBy)
        {
            try
            {

                strSQL = "SELECT MEM_CODE ValueMember ,Member_Name DisplayMember FROM MASTER_EMPLOYEE_MAIN";

                if (bChecked == true)
                {
                    strSQL = strSQL + " WHERE EMP_STATUS='A'";
                }
                else
                {
                    strSQL = strSQL + " WHERE EMP_STATUS <> 'A'";
                }

                if (!string.IsNullOrEmpty(orderBy))
                    strSQL = strSQL + " order by " + orderBy.Trim();
                return BindClassWithData.BindClass<ComboBoxFill>(SQLHelper.ShowRecord(strSQL)).ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetEmployeeDropdownList

        //                 dtData = SQLHelper.ShowRecord("SELECT Branch_ID,Branch_Name FROM MASTER_BRANCH WHERE Company_Id='1'");

        //Written By Manu
        //on 21/02/2016 @ 5:43 AM

        #region LoadGrade
        public List<ComboBoxFill> GetGradeDropdownList(bool bChecked, string orderBy)
        {
            try
            {
                strSQL = "SELECT GRADE_Id ValueMember, GRADE_Name DisplayMember FROM MASTER_GRADE";

                if (bChecked == true)
                {
                    strSQL = strSQL + " WHERE Activate = 'A'";
                }
                else
                {
                    strSQL = strSQL + " WHERE Activate = 'A'";
                }

                if (!string.IsNullOrEmpty(orderBy))
                    strSQL = strSQL + " order by " + orderBy.Trim();
                return BindClassWithData.BindClass<ComboBoxFill>(SQLHelper.ShowRecord(strSQL)).ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region LoadBranch
        public List<ComboBoxFill> GetBranchDropdownList(bool bChecked, string orderBy)
        {
            try
            {
                strSQL = "SELECT Branch_ID ValueMember,Branch_Name DisplayMember FROM MASTER_BRANCH";

                if (bChecked == true)
                {
                    strSQL = strSQL + " WHERE Company_Id = '1'";
                }
                else
                {
                    strSQL = strSQL + " WHERE Company_Id = '1'";
                }

                if (!string.IsNullOrEmpty(orderBy))
                    strSQL = strSQL + " order by " + orderBy.Trim();
                return BindClassWithData.BindClass<ComboBoxFill>(SQLHelper.ShowRecord(strSQL)).ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region LoadDesignation
        public List<ComboBoxFill> GetDesignationDropdownList(bool bChecked, string orderBy)
        {
            try
            { 
                strSQL = "SELECT DESIG_Id ValueMember,DESIGNATION DisplayMember FROM MASTER_DESIGNATION";

                if (bChecked == true)
                {
                    strSQL = strSQL + " WHERE Activate='A'";
                }
                else
                {
                    strSQL = strSQL + " WHERE Activate='A'";
                }

                if (!string.IsNullOrEmpty(orderBy))
                    strSQL = strSQL + " order by " + orderBy.Trim();
                return BindClassWithData.BindClass<ComboBoxFill>(SQLHelper.ShowRecord(strSQL)).ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region LoadDepartment
        public List<ComboBoxFill> GetDepartmentDropdownList(bool bChecked, string orderBy)
        {
            try
            {          
                strSQL = "SELECT DEPARTMENT_Id ValueMember, DEPARTMENT_Name DisplayMember FROM MASTER_DEPARTMENT";

                if (bChecked == true)
                {
                    strSQL = strSQL + " WHERE Activate='A'";
                }
                else
                {
                    strSQL = strSQL + " WHERE Activate='A'";
                }

                if (!string.IsNullOrEmpty(orderBy))
                    strSQL = strSQL + " order by " + orderBy.Trim();
                return BindClassWithData.BindClass<ComboBoxFill>(SQLHelper.ShowRecord(strSQL)).ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region LoadShiftType
        public List<ComboBoxFill> GetShiftTypeDropdownList(bool bChecked, string orderBy)
        {
            try
            {
                strSQL = "SELECT SHIFT_ID ValueMember,SHIFT_NAME DisplayMember FROM MASTER_SHIFT_MAIN";

                if (bChecked == true)
                {
                    strSQL = strSQL + " WHERE Activate='A'";
                }
                else
                {
                    strSQL = strSQL + " WHERE Activate='A'";
                }

                if (!string.IsNullOrEmpty(orderBy))
                    strSQL = strSQL + " order by " + orderBy.Trim();
                return BindClassWithData.BindClass<ComboBoxFill>(SQLHelper.ShowRecord(strSQL)).ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region LoadEmployeeTye
        public List<ComboBoxFill> GetEmployeeTypeDropdownList(bool bChecked, string orderBy)
        {
            try
            {
                strSQL = "SELECT Employee_Type DisplayMember,Employee_Type_Id ValueMember FROM MASTER_EMPLOYEE_TYPE";

                if (bChecked == true)
                {
                    strSQL = strSQL + " WHERE Activate='A'";
                }
                else
                {
                    strSQL = strSQL + " WHERE Activate='A'";
                }

                if (!string.IsNullOrEmpty(orderBy))
                    strSQL = strSQL + " order by " + orderBy.Trim();
                return BindClassWithData.BindClass<ComboBoxFill>(SQLHelper.ShowRecord(strSQL)).ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        //End

        #region LoadDropdown
        private DataTable GetDropdownDT()
        {
            try
            {

                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT DV_ID,DEVICE_NAME,DEVICE_LOCATION,DV_IP,PORT,ACTIVATE FROM MASTER_DEVICE";
                    return (SQLHelper.ShowRecord(strSQL));

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion LoadDropdown

        #region GetLoadDataGridDT
        private DataTable GetLoadDataGridDT(bool bChecked)
        {
            try
            {
                using (DataTable dt = new DataTable())
                {
                    //  []
                     //[BankAccocuntNo]
                     //[BankBranchId]

                    strSQL = "SELECT M.MEM_CODE,M.Member_Name,M.Member_Surname,M.BankAccocuntNo,M.BankBranchId, M.ENROLL_NO,M.SEX,M.Employee_Type_Id,T.Employee_Type, \n" +
                    " M.DEPT_Id,D.DEPARTMENT_Name, M.CAT_ID,CA.CAT_NAME,\n" +
                    " M.DESIG_Id,DE.DESIGNATION,M.GRADE_Id,G.GRADE_Name,M.PAY_Id,P.PAY_Name,M.EMP_STATUS,M.CPF_STATUS,M.CPF_ID,BR.Branch_Name FROM MASTER_EMPLOYEE_MAIN M \n" +
                    " INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                    " INNER JOIN MASTER_DEPARTMENT D ON M.DEPT_Id = D.DEPARTMENT_Id \n" +
                    " INNER JOIN MASTER_CATEGORY CA ON M.CAT_ID = CA.CAT_ID \n" +
                    " INNER JOIN MASTER_DESIGNATION DE ON M.DESIG_Id = DE.DESIG_Id \n" +
                    " INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_Id \n" +
                    " INNER JOIN MASTER_PAYBASIS P ON M.PAY_Id = P.PAY_Id INNER JOIN MASTER_BRANCH BR ON M.Branch_ID = BR.Branch_ID ";
                    if (bChecked == true)
                    {
                        strSQL = strSQL + " WHERE EMP_STATUS='A'";
                    }
                    else
                    {
                        strSQL = strSQL + " WHERE EMP_STATUS <> 'A'";
                    }
                  
                    return (SQLHelper.ShowRecord(strSQL));

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLoadDataGridDT

        //LoadDataGroupGridList(iGroupID, orderBy);



        

        #region LoadDataGroupGridList
        public List<EmployeeVO> LoadDataGroupGridList(int iGrId, string orderBy)
        {
            try
            {
                //using (DataTable dt = new DataTable())
                //{
                strSQL = "SELECT M.MEM_CODE,M.Member_Name,M.Member_Surname,M.BankAccocuntNo,M.BankBranchId,M.ENROLL_NO,M.SEX,M.Employee_Type_Id,T.Employee_Type, \n" +
                    " M.DEPT_Id,D.DEPARTMENT_Name, M.CAT_ID,CA.CAT_NAME,\n" +
                    " M.DESIG_Id,DE.DESIGNATION,M.GRADE_Id,G.GRADE_Name,M.PAY_Id,M.PaymentId,M.PRStatusID,M.CPF_STATUS,M.CPF_ID, M.PR_DATE ,P.PAY_Name,M.EMP_STATUS,BR.Branch_Name FROM MASTER_EMPLOYEE_MAIN M \n" +
                    " INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                    " INNER JOIN MASTER_DEPARTMENT D ON M.DEPT_Id = D.DEPARTMENT_Id \n" +
                    " INNER JOIN MASTER_CATEGORY CA ON M.CAT_ID = CA.CAT_ID \n" +
                    " INNER JOIN MASTER_DESIGNATION DE ON M.DESIG_Id = DE.DESIG_Id \n" +
                    " INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_Id \n" +
                    " INNER JOIN MASTER_PAYBASIS P ON M.PAY_Id = P.PAY_Id INNER JOIN MASTER_BRANCH BR ON M.Branch_ID = BR.Branch_ID " +
                    " WHERE M.MEM_CODE IN( SELECT MEM_CODE FROM MASTER_SHIFT_GROUP_DTLS WHERE SHIFT_GROUP_ID=" + iGrId.ToString() + "AND ACTIVATE='A')";
                     
                
                if (!string.IsNullOrEmpty(orderBy))
                    strSQL = strSQL + " order by " + orderBy;
               // return (SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeVO>());
                return BindClassWithData.BindClass<EmployeeVO>(SQLHelper.ShowRecord(strSQL)).ToList();
                // return (SQLHelper.ShowRecord(strSQL).ToList<EmployeeVO>());
                //}
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion LoadDataGroupGridList




        #region LoadDataGridList
        public List<EmployeeVO> LoadDataGridList(bool bChecked , string orderBy)
        {
            try
            {
                //using (DataTable dt = new DataTable())
                //{
                strSQL = "SELECT M.MEM_CODE,M.Member_Name,M.Member_Surname,M.BankAccocuntNo,M.BankBranchId,M.ENROLL_NO,M.SEX,M.Employee_Type_Id,T.Employee_Type, \n" +
                    " M.DEPT_Id,D.DEPARTMENT_Name, M.CAT_ID,CA.CAT_NAME,\n" +
                    " M.DESIG_Id,DE.DESIGNATION,M.GRADE_Id,G.GRADE_Name,M.PAY_Id,M.PaymentId ,P.PAY_Name,M.EMP_STATUS,BR.Branch_Name, M.PR_DATE,M.PRStatusID,M.CPF_STATUS,M.CPF_ID FROM MASTER_EMPLOYEE_MAIN M \n" +
                    " INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                    " INNER JOIN MASTER_DEPARTMENT D ON M.DEPT_Id = D.DEPARTMENT_Id \n" +
                    " INNER JOIN MASTER_CATEGORY CA ON M.CAT_ID = CA.CAT_ID \n" +
                    " INNER JOIN MASTER_DESIGNATION DE ON M.DESIG_Id = DE.DESIG_Id \n" +
                    " INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_Id \n" +
                    " INNER JOIN MASTER_PAYBASIS P ON M.PAY_Id = P.PAY_Id INNER JOIN MASTER_BRANCH BR ON M.Branch_ID = BR.Branch_ID ";
                    if (bChecked == true)
                    {
                        strSQL = strSQL + " WHERE EMP_STATUS='A'";
                    }
                    else
                    {
                        strSQL = strSQL + " WHERE EMP_STATUS <> 'A'";
                    }
                    if (!string.IsNullOrEmpty(orderBy))
                        strSQL = strSQL + " order by " + orderBy;
                   
                   // return (SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeVO>()); old line
                   return BindClassWithData.BindClass<EmployeeVO>(SQLHelper.ShowRecord(strSQL)).ToList();  //SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeVO>());
          
                   // return (SQLHelper.ShowRecord(strSQL).ToList<EmployeeVO>());
                //}
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLoadDataGridDT

        #region LoadDataGridBindingList
        public BindingList<EmployeeVO> LoadDataGridBindingList(bool bChecked, string orderBy,string strCond)
        {
            try
            {
                //using (DataTable dt = new DataTable())
                //{// CONVERT(VARCHAR,M.DOJ,101)
                //strSQL = "SELECT M.MEM_CODE,M.Member_Name,M.ENROLL_NO, M.DOJ, M.SEX,M.Employee_Type_Id,T.Employee_Type, \n" +
                //    " M.DEPT_Id,D.DEPARTMENT_Name, M.CAT_ID,CA.CAT_NAME,\n" +
                //    " M.DESIG_Id,DE.DESIGNATION,M.GRADE_Id,G.GRADE_Name,M.PAY_Id,M.PaymentId ,    P.PAY_Name,M.EMP_STATUS,BR.Branch_Name FROM MASTER_EMPLOYEE_MAIN M \n" +
                //    " INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                //    " INNER JOIN MASTER_DEPARTMENT D ON M.DEPT_Id = D.DEPARTMENT_Id \n" +
                //    " INNER JOIN MASTER_CATEGORY CA ON M.CAT_ID = CA.CAT_ID \n" +
                //    " INNER JOIN MASTER_DESIGNATION DE ON M.DESIG_Id = DE.DESIG_Id \n" +
                //    " INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_Id \n" +
                //    " INNER JOIN MASTER_PAYBASIS P ON M.PAY_Id = P.PAY_Id INNER JOIN MASTER_BRANCH BR ON M.Branch_ID = BR.Branch_ID ";
                
                
                //

                strSQL = "SELECT convert(nvarchar(36), ROW_ID) ROW_ID, M.MEM_CODE,M.Member_Name,M.Member_Surname,M.BankAccocuntNo,M.BankBranchId,M.ENROLL_NO, M.DOJ, M.PR_DATE,M.PRStatusID,M.CPF_STATUS,M.CPF_ID, M.SEX,M.Employee_Type_Id,T.Employee_Type, \n" +
                   " M.DEPT_Id,D.DEPARTMENT_Name, M.CAT_ID,CA.CAT_NAME,\n" +
                   " M.DESIG_Id,DE.DESIGNATION,M.GRADE_Id,G.GRADE_Name,M.PAY_Id,M.PaymentId ,    P.PAY_Name,M.EMP_STATUS,BR.Branch_Name FROM MASTER_EMPLOYEE_MAIN M \n" +
                   " LEFT OUTER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                   " LEFT OUTER JOIN MASTER_DEPARTMENT D ON M.DEPT_Id = D.DEPARTMENT_Id \n" +
                   " LEFT OUTER JOIN MASTER_CATEGORY CA ON M.CAT_ID = CA.CAT_ID \n" +
                   " LEFT OUTER JOIN MASTER_DESIGNATION DE ON M.DESIG_Id = DE.DESIG_Id \n" +
                   " LEFT OUTER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_Id \n" +
                   " LEFT OUTER JOIN MASTER_PAYBASIS P ON M.PAY_Id = P.PAY_Id \n " +
                   " LEFT OUTER JOIN MASTER_BRANCH BR ON M.Branch_ID = BR.Branch_ID ";
           

                
                if (bChecked == true)
                {
                    strSQL = strSQL + " WHERE EMP_STATUS='A'";
                }
                else
                {
                    strSQL = strSQL + " WHERE EMP_STATUS <> 'A'";
                }

                if (strCond != string.Empty)
                {
                    if (strCond.IndexOf("AND") != -1)
                           strSQL = strSQL + strCond;
                    else
                        strSQL = strSQL + " AND " + strCond;
                     
                }

                if (!string.IsNullOrEmpty(orderBy))
                    strSQL = strSQL + " order by " + orderBy;
               //return new BindingList<EmployeeVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeVO>());
                //return new BindingList<EmployeeVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeVO>());
               //return new BindingList<EmployeeVO>(SQLHelper.ShowRecord(strSQL).DataTableToListExt2<EmployeeVO>().ToList());
               
               return new BindingList<EmployeeVO>(  BindClassWithData.BindClass<EmployeeVO>(SQLHelper.ShowRecord(strSQL)));  //SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeVO>());
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion LoadDataGridBindingList

        #region LoadDataGridBindingList
        public BindingList<EmployeeVO> LoadDataGridBindingList(bool bChecked, string orderBy)
        {
            try
            {
                //using (DataTable dt = new DataTable())
                //{// CONVERT(VARCHAR,M.DOJ,101)
                //strSQL = "SELECT M.MEM_CODE,M.Member_Name,M.ENROLL_NO, M.DOJ, M.SEX,M.Employee_Type_Id,T.Employee_Type, \n" +
                //    " M.DEPT_Id,D.DEPARTMENT_Name, M.CAT_ID,CA.CAT_NAME,\n" +
                //    " M.DESIG_Id,DE.DESIGNATION,M.GRADE_Id,G.GRADE_Name,M.PAY_Id,M.PaymentId ,    P.PAY_Name,M.EMP_STATUS,BR.Branch_Name FROM MASTER_EMPLOYEE_MAIN M \n" +
                //    " INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                //    " INNER JOIN MASTER_DEPARTMENT D ON M.DEPT_Id = D.DEPARTMENT_Id \n" +
                //    " INNER JOIN MASTER_CATEGORY CA ON M.CAT_ID = CA.CAT_ID \n" +
                //    " INNER JOIN MASTER_DESIGNATION DE ON M.DESIG_Id = DE.DESIG_Id \n" +
                //    " INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_Id \n" +
                //    " INNER JOIN MASTER_PAYBASIS P ON M.PAY_Id = P.PAY_Id INNER JOIN MASTER_BRANCH BR ON M.Branch_ID = BR.Branch_ID ";


                //

                strSQL = "SELECT M.MEM_CODE,M.Member_Name,M.Member_Surname,M.BankAccocuntNo,M.BankBranchId,M.ENROLL_NO, M.DOJ,M.PR_DATE,M.PRStatusID,M.CPF_STATUS,M.CPF_ID, M.SEX,M.Employee_Type_Id,T.Employee_Type, \n" +
                   " M.DEPT_Id,D.DEPARTMENT_Name, M.CAT_ID,CA.CAT_NAME,\n" +
                   " M.DESIG_Id,DE.DESIGNATION,M.GRADE_Id,G.GRADE_Name,M.PAY_Id,M.PaymentId ,    P.PAY_Name,M.EMP_STATUS,BR.Branch_Name FROM MASTER_EMPLOYEE_MAIN M \n" +
                   " LEFT OUTER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                   " LEFT OUTER JOIN MASTER_DEPARTMENT D ON M.DEPT_Id = D.DEPARTMENT_Id \n" +
                   " LEFT OUTER JOIN MASTER_CATEGORY CA ON M.CAT_ID = CA.CAT_ID \n" +
                   " LEFT OUTER JOIN MASTER_DESIGNATION DE ON M.DESIG_Id = DE.DESIG_Id \n" +
                   " LEFT OUTER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_Id \n" +
                   " LEFT OUTER JOIN MASTER_PAYBASIS P ON M.PAY_Id = P.PAY_Id \n " +
                   " LEFT OUTER JOIN MASTER_BRANCH BR ON M.Branch_ID = BR.Branch_ID ";



                if (bChecked == true)
                {
                    strSQL = strSQL + " WHERE EMP_STATUS='A'";
                }
                else
                {
                    strSQL = strSQL + " WHERE EMP_STATUS <> 'A'";
                }

                //if (strCond != string.Empty)
                //    strSQL = strSQL + " AND " + strCond;
                if (!string.IsNullOrEmpty(orderBy))
                    strSQL = strSQL + " order by " + orderBy;
                //return new BindingList<EmployeeVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeVO>());
                return new BindingList<EmployeeVO>(BindClassWithData.BindClass<EmployeeVO>(SQLHelper.ShowRecord(strSQL)));  //SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeVO>());
         

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion LoadDataGridBindingList
        #region GetEmployeesDT
        private DataTable GetEmployeesDT(string strRowId)
        {
            try
            {
                using (DataTable dt = new DataTable())
                {

                    strSQL = "SELECT * FROM MASTER_EMPLOYEE_MAIN WHERE MEM_CODE='" + strRowId + "'";
                    return (SQLHelper.ShowRecord(strSQL));

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetEmployeesDT
        #region GetEmployeesEntrollNos
        public List<string> GetEmployeesEntrollNos()
        {
            try
            {
               strSQL = "SELECT ISNULL(ENROLL_NO,0) ENROLL_NO FROM MASTER_EMPLOYEE_MAIN WHERE EMP_STATUS='A'";
               return  SQLHelper.ShowRecord(strSQL).AsEnumerable()
                           .Select(r => r.Field<string>("ENROLL_NO"))
                           .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetEmployeesDT

        #region GetEmployeesList-strRowId
        public List<EmployeeVO> GetEmployeesList(string strRowId)
        {
            try
            {
                //using (DataTable dt = new DataTable())
                //{

                    strSQL = "SELECT * FROM MASTER_EMPLOYEE_MAIN WHERE MEM_CODE='" + strRowId + "'";
                    //return (SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeVO>());
                    return BindClassWithData.BindClass<EmployeeVO>(SQLHelper.ShowRecord(strSQL)).ToList();

                //}
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetEmployeesList

        #region LoadDataGridList
        public List<EmployeeVO> LoadDataGridList(string strRowId, string orderBy)
        {
            try
            {
                strSQL = "SELECT * FROM MASTER_EMPLOYEE_MAIN WHERE MEM_CODE='" + strRowId + "'";

                if (!string.IsNullOrEmpty(orderBy))
                    strSQL = strSQL + " order by " + orderBy;
                
                //return SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeVO>();
                return BindClassWithData.BindClass<EmployeeVO>(SQLHelper.ShowRecord(strSQL)).ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region GetEmployeeEarningDT
        private DataTable GetEmployeeEarningDT(string strRowId)
        {
            try
            {
                using (DataTable dt = new DataTable())
                {
                        strSQL = "SELECT D.EdCodeId,ED.Description HeadName,ISNULL(D.IsPercentage,0) IsPercentage, \n" +
                        " isnull(D.BaseEdCodeId,0) BaseEdCodeId,ISNULL(NED.Description,'') BaseHeadName,Percentage,AMOUNT Amount FROM MASTER_EMPLOYEE_EARNING_DTLS D \n" +
                        " INNER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER ED ON D.EdCodeId = ED.EdCodeId \n" +
                        " LEFT OUTER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER NED ON D.BaseEdCodeId = NED.EdCodeId \n" +
                        " WHERE D.Activate='A' AND D.MEM_CODE='" + strRowId + "'";
                        return (SQLHelper.ShowRecord(strSQL));

                }
            }catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetEmployeeEarningDT
        #region GetEmployeeEarningList
        public List<EmployeeVO> GetEmployeeEarningList(string strRowId,string orderBy)
        {
            try
            {
                
                    strSQL = "SELECT D.EdCodeId,ED.Description HeadName,ISNULL(D.IsPercentage,0) IsPercentage, \n" +
                    " isnull(D.BaseEdCodeId,0) BaseEdCodeId,ISNULL(NED.Description,'') BaseHeadName,Percentage,AMOUNT Amount FROM MASTER_EMPLOYEE_EARNING_DTLS D \n" +
                    " INNER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER ED ON D.EdCodeId = ED.EdCodeId \n" +
                    " LEFT OUTER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER NED ON D.BaseEdCodeId = NED.EdCodeId \n" +
                    " WHERE D.Activate='A' AND D.MEM_CODE='" + strRowId + "'";

                    if (!string.IsNullOrEmpty(orderBy))
                        strSQL = strSQL + " order by " + orderBy;
                    
                    //return SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeVO>();
                    return BindClassWithData.BindClass<EmployeeVO>(SQLHelper.ShowRecord(strSQL)).ToList();
  
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetEmployeeEarningList

        #region GetShiftSchedulegDT
        private DataTable GetShiftScheduleDT(string MemCode)
        {
            try
            {
                using (DataTable dt = new DataTable())
                {

                    strSQL = "SELECT TS.ROW_ID,TS.SCH_TYPE_ID,MS.SHIFT_NAME,CONVERT(VARCHAR(12),START_ON,106) START_ON, \n" +
                          " CONVERT(VARCHAR(12),END_ON,106) END_ON,CASE WHEN TS.Activate='A' THEN 'Activate' ELSE 'Last' END Activate FROM TRAN_SHIFT_ROSTER TS \n" +
                          " INNER JOIN MASTER_SHIFT_MAIN MS ON TS.SCH_TYPE_ID = MS.SHIFT_ID \n" +
                          " WHERE MEM_CODE='" + MemCode + "' ORDER BY TS.Activate,TS.ROW_ID";
                            return (SQLHelper.ShowRecord(strSQL));

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetEmployeeEarningDT

        //GetEmployeeShiftGroupList(strShiftGrpID, orderBy);
        #region GetShiftSchedulegList
        public BindingList<EmployeeVO> GetEmployeeShiftGroupList(string strShiftGrpID, string orderBy)
        {
            try
            {


                strSQL = "SELECT M.MEM_CODE,M.Member_Name,M.Employee_Type_Id,T.Employee_Type, \n" +
                   " M.DEPT_Id,D.DEPARTMENT_Name,SG.ShiftGroup,SG.Active \n" +
                   " M.DESIG_Id,DE.DESIGNATION,M.GRADE_Id,G.GRADE_Name,BR.Branch_Name FROM MASTER_EMPLOYEE_MAIN M \n" +
                   " INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                   " INNER JOIN MASTER_DEPARTMENT D ON M.DEPT_Id = D.DEPARTMENT_Id \n" +
                   " INNER JOIN MASTER_DESIGNATION DE ON M.DESIG_Id = DE.DESIG_Id \n" +
                   " INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_Id \n" +
                   " INNER JOIN MASTER_BRANCH BR ON M.Branch_ID = BR.Branch_ID \n" +
                   " INNER JOIN MASTER_SHIFT_GROUP_DTLS SG ON SG.SHIFT_GROUP_ID = " + strShiftGrpID.Trim() + " \n" +
                   "WHERE M.MEM_CODE IN (SELECT MEM_CODE FROM MASTER_SHIFT_GROUP_DTLS WHERE SHIFT_GROUP_ID=" + strShiftGrpID.Trim() + ")";

                
                if (!string.IsNullOrEmpty(orderBy))
                    strSQL = strSQL + " order by " + orderBy;

               // return (SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeVO>());
               // return new BindingList<EmployeeVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeVO>());
                return new BindingList<EmployeeVO>( BindClassWithData.BindClass<EmployeeVO>(SQLHelper.ShowRecord(strSQL)));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetEmployeeShiftGroupList


        #region GetShiftSchedulegList
        private List<EmployeeVO> GetShiftScheduleList(string MemCode)
        {
            try
            {
               

                    strSQL = "SELECT TS.ROW_ID,TS.SCH_TYPE_ID,MS.SHIFT_NAME,CONVERT(VARCHAR(12),START_ON,106) START_ON, \n" +
                          " CONVERT(VARCHAR(12),END_ON,106) END_ON,CASE WHEN TS.Activate='A' THEN 'Activate' ELSE 'Last' END Activate FROM TRAN_SHIFT_ROSTER TS \n" +
                          " INNER JOIN MASTER_SHIFT_MAIN MS ON TS.SCH_TYPE_ID = MS.SHIFT_ID \n" +
                          " WHERE MEM_CODE='" + MemCode + "' ORDER BY TS.Activate,TS.ROW_ID";

                       // return (SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeVO>());
                        return BindClassWithData.BindClass<EmployeeVO>(SQLHelper.ShowRecord(strSQL)).ToList();
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetEmployeeEarningList


        // get  RulePropertyInfo  funtion populate the employee list for apply rules

        #region GetRulePropertyInfo
        public  RulePropertyInfo  GetRulePropertyInfo(string MemCode)
        {
            try
            {
                string strSql = string.Empty;      
                //declare the object .....
                RulePropertyInfo _rulePropertyInfo = new RulePropertyInfo();

                strSQL = "  SELECT M.MEM_CODE, BR.Branch_Name Branch,CASE M.SEX WHEN 'M' THEN 'MALE' ELSE 'FEMALE' END SEX, \n "+
                  "  T.Employee_Type EmployeeType, \n"+ 
                  "  D.DEPARTMENT_Name Department,CA.CAT_NAME Category ,  \n"+ 
                  "  M.DOB BirthDate , Q.STATUS_Type MaritalStatus ,\n"+ 
                  "  M.DOJ JoiningDate,M.WEEK_ENGAGED WeekEngaged,M.State,M.City,M.Country, M.OVERTIME_RATE OvertimeRate,\n"+ 
                  "  M.HourlyRate,M.NoOfWorkingDay,M.DailyPayRate,  \n"+ 
                  "  DE.DESIGNATION,G.GRADE_Name Grade,S.PaymentMode, \n"+
                  "  P.PAY_Name PayName,ISNULL(PG.RULE_GROUP_ID,0) PolicyGroupID,M.EMP_STATUS Activate FROM MASTER_EMPLOYEE_MAIN M  \n" + 
                  "  INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id   \n"+ 
                  "  INNER JOIN MASTER_DEPARTMENT D ON M.DEPT_Id = D.DEPARTMENT_Id    \n"+ 
                  "  INNER JOIN MASTER_CATEGORY CA ON M.CAT_ID = CA.CAT_ID   \n"+ 
                  "  INNER JOIN MASTER_DESIGNATION DE ON M.DESIG_Id = DE.DESIG_Id    \n"+ 
                  "  INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_Id  \n"+ 
                  "  INNER JOIN MASTER_PAYMENT_MODE S ON M.PaymentId = S.PaymentId \n"+ 
                  "  INNER JOIN MASTER_MARITAL_STATUS Q ON M.MARITAL_STATUS_Id = Q.STATUS_Id    \n"+ 
                  "  INNER JOIN MASTER_PAYBASIS P ON M.PAY_Id = P.PAY_Id \n"+
                  "  INNER JOIN MASTER_BRANCH BR ON M.Branch_ID = BR.Branch_ID   \n"+
                  "  LEFT OUTER JOIN MASTER_EMPLOYEE_RULE_DTLS PG ON M.MEM_CODE = PG.MEM_CODE  \n" + 
                  "  WHERE EMP_STATUS='A' AND M.MEM_CODE='" + MemCode.Trim() +"'" ;
                   


                strSql = " SELECT D.ID,D.MEM_CODE, D.EdCodeId,ED.Description HeadName,ISNULL(D.IsPercentage,0) IsPercentage, \n" +
                        " isnull(D.BaseEdCodeId,0) BaseEdCodeId,ISNULL(NED.Description,'') BaseHeadName,Percentage,AMOUNT Amount,WEF_Date, \n" +
                        " D.Activate FROM MASTER_EMPLOYEE_EARNING_DTLS D \n"+ 
                        " INNER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER ED ON D.EdCodeId = ED.EdCodeId  \n"+
                        " LEFT OUTER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER NED ON D.BaseEdCodeId = NED.EdCodeId \n"+ 
                        " WHERE D.Activate='A' \n"+
                        " AND D.MEM_CODE='" + MemCode.Trim() +"'";

                    try
                    {
                             //get the employee info type 
                            // _rulePropertyInfo = SQLHelper.ShowRecord(strSQL).DataTableToList<RulePropertyInfo>()[0]; //get first item
                             _rulePropertyInfo = BindClassWithData.BindClass<RulePropertyInfo>(SQLHelper.ShowRecord(strSQL))[0];
                        
                               // _rulePropertyInfo.PaymentPropertyInfoList = SQLHelper.ShowRecord(strSql).DataTableToList<PaymentPropertyInfo>(); //get first item
                                _rulePropertyInfo.PaymentPropertyInfoList = BindClassWithData.BindClass<PaymentPropertyInfo>(SQLHelper.ShowRecord(strSql)).ToList();  
                             return (_rulePropertyInfo);

                    }
                catch (Exception exp)
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetRulePropertyInfo
        #region GetRulePropertyInfo overloaded to use list of mem_code

        public List<RulePropertyInfo> GetRulePropertyInfo(List<string> MemCodes)
        {
            try
            {
                string memcodes = string.Empty;


                string strSql = string.Empty;
                //declare the object .....
                
                List<RulePropertyInfo> _rulePropertyInfoList = new List<RulePropertyInfo>();
                List<PaymentPropertyInfo> _paymentPropertyInfoList = new List<PaymentPropertyInfo>();

                foreach (string item in MemCodes)
                    memcodes += "'" + item + "',";
                memcodes=memcodes.Substring(0,memcodes.Length-1);


                strSQL = "  SELECT M.MEM_CODE, BR.Branch_Name Branch,CASE M.SEX WHEN 'M' THEN 'MALE' ELSE 'FEMALE' END SEX, \n " +
                  "  T.Employee_Type EmployeeType, \n" +
                  "  D.DEPARTMENT_Name Department,CA.CAT_NAME Category ,  \n" +
                  "  M.DOB BirthDate , Q.STATUS_Type MaritalStatus ,\n" +
                  "  M.DOJ JoiningDate,M.WEEK_ENGAGED WeekEngaged,M.State,M.City,M.Country, M.OVERTIME_RATE OvertimeRate,\n" +
                  "  M.HourlyRate,M.NoOfWorkingDay,M.DailyPayRate,  \n" +
                  "  DE.DESIGNATION,G.GRADE_Name Grade,S.PaymentMode, \n" +
                  "  P.PAY_Name PayName,ISNULL(PG.RULE_GROUP_ID,0) PolicyGroupID,M.EMP_STATUS Activate FROM MASTER_EMPLOYEE_MAIN M  \n" +
                  "  INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id   \n" +
                  "  INNER JOIN MASTER_DEPARTMENT D ON M.DEPT_Id = D.DEPARTMENT_Id    \n" +
                  "  INNER JOIN MASTER_CATEGORY CA ON M.CAT_ID = CA.CAT_ID   \n" +
                  "  INNER JOIN MASTER_DESIGNATION DE ON M.DESIG_Id = DE.DESIG_Id    \n" +
                  "  INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_Id  \n" +
                  "  INNER JOIN MASTER_PAYMENT_MODE S ON M.PaymentId = S.PaymentId \n" +
                  "  INNER JOIN MASTER_MARITAL_STATUS Q ON M.MARITAL_STATUS_Id = Q.STATUS_Id    \n" +
                  "  INNER JOIN MASTER_PAYBASIS P ON M.PAY_Id = P.PAY_Id \n" +
                  "  INNER JOIN MASTER_BRANCH BR ON M.Branch_ID = BR.Branch_ID   \n" +
                  "  LEFT OUTER JOIN MASTER_EMPLOYEE_RULE_DTLS PG ON M.MEM_CODE = PG.MEM_CODE  \n" +
                  "  WHERE EMP_STATUS='A' AND M.MEM_CODE IN(" + memcodes.Trim() + ")";



                strSql = " SELECT D.ID,D.MEM_CODE, D.EdCodeId,ED.Description HeadName,ISNULL(D.IsPercentage,0) IsPercentage, \n" +
                        " isnull(D.BaseEdCodeId,0) BaseEdCodeId,ISNULL(NED.Description,'') BaseHeadName,Percentage,AMOUNT Amount,WEF_Date, \n" +
                        " D.Activate FROM MASTER_EMPLOYEE_EARNING_DTLS D \n" +
                        " INNER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER ED ON D.EdCodeId = ED.EdCodeId  \n" +
                        " LEFT OUTER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER NED ON D.BaseEdCodeId = NED.EdCodeId \n" +
                        " WHERE D.Activate='A' \n" +
                        " AND D.MEM_CODE IN(" + memcodes.Trim() + ")";

                try
                {
                    //get the employee inof type 
                    
                    
                    
                   // _rulePropertyInfoList = SQLHelper.ShowRecord(strSQL).DataTableToList<RulePropertyInfo>(); //get items ...
                   // _paymentPropertyInfoList = SQLHelper.ShowRecord(strSql).DataTableToList<PaymentPropertyInfo>(); //get items ...



                    _rulePropertyInfoList = BindClassWithData.BindClass<RulePropertyInfo>(SQLHelper.ShowRecord(strSQL)).ToList();
                    _paymentPropertyInfoList = BindClassWithData.BindClass<PaymentPropertyInfo>(SQLHelper.ShowRecord(strSql)).ToList();  
                         




                    // add PaymentProperty to the list ...

                    foreach (RulePropertyInfo _ruleProperty in _rulePropertyInfoList)
                    {
                        // _ruleProperty.PaymentProperty= from x in _paymentPropertyInfoList 
                        _ruleProperty.PaymentPropertyInfoList.AddRange(_paymentPropertyInfoList.FindAll(x => x.Mem_Code == _ruleProperty.Mem_Code));

                    }


                    return (_rulePropertyInfoList);

                }
                catch (Exception exp)
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetRulePropertyInfo

        #region  GetEmployeeEarningList
        
       
        public List<RulePropertyInfo> GetRulePropertyInfoList()
        {
            try
            {
                try
                {
                    string strSql = string.Empty;
                    //declare the object .....
                    List<RulePropertyInfo> _rulePropertyInfoList = new List<RulePropertyInfo>();
                    List<PaymentPropertyInfo> _paymentPropertyInfoList = new List<PaymentPropertyInfo>();

                    strSQL = "  SELECT M.MEM_CODE, BR.Branch_Name Branch,CASE M.SEX WHEN 'M' THEN 'MALE' ELSE 'FEMALE' END SEX, \n " +
                      "  T.Employee_Type EmployeeType, \n" +
                      "  D.DEPARTMENT_Name Department,CA.CAT_NAME Category ,  \n" +
                      "  M.DOB BirthDate , Q.STATUS_Type MaritalStatus ,\n" +
                      "  M.DOJ JoiningDate,M.WEEK_ENGAGED WeekEngaged,M.State,M.City,M.Country, M.OVERTIME_RATE OvertimeRate,\n" +
                      "  M.HourlyRate,M.NoOfWorkingDay,M.DailyPayRate,  \n" +
                      "  DE.DESIGNATION,G.GRADE_Name Grade,S.PaymentMode, \n" +
                      "  P.PAY_Name PayName, ISNULL(PG.RULE_GROUP_ID,0) PolicyGroupID,  M.EMP_STATUS Activate FROM MASTER_EMPLOYEE_MAIN M  \n" +
                      "  INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id   \n" +
                      "  INNER JOIN MASTER_DEPARTMENT D ON M.DEPT_Id = D.DEPARTMENT_Id    \n" +
                      "  INNER JOIN MASTER_CATEGORY CA ON M.CAT_ID = CA.CAT_ID   \n" +
                      "  INNER JOIN MASTER_DESIGNATION DE ON M.DESIG_Id = DE.DESIG_Id    \n" +
                      "  INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_Id  \n" +
                      "  INNER JOIN MASTER_PAYMENT_MODE S ON M.PaymentId = S.PaymentId \n" +
                      "  INNER JOIN MASTER_MARITAL_STATUS Q ON M.MARITAL_STATUS_Id = Q.STATUS_Id    \n" +
                      "  INNER JOIN MASTER_PAYBASIS P ON M.PAY_Id = P.PAY_Id  \n" +
                      "  LEFT OUTER JOIN MASTER_EMPLOYEE_RULE_DTLS PG ON M.MEM_CODE = PG.MEM_CODE  \n" +  
                      "  INNER JOIN MASTER_BRANCH BR ON M.Branch_ID = BR.Branch_ID   \n" +
                      "  WHERE EMP_STATUS='A' ORDER BY MEM_CODE ";


                    strSql = " SELECT D.ID,D.MEM_CODE, D.EdCodeId,ED.Description HeadName,ISNULL(D.IsPercentage,0) IsPercentage, \n" +
                            " isnull(D.BaseEdCodeId,0) BaseEdCodeId,ISNULL(NED.Description,'') BaseHeadName,Percentage,AMOUNT Amount,WEF_Date, \n" +
                            " D.Activate FROM MASTER_EMPLOYEE_EARNING_DTLS D \n" +
                            " INNER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER ED ON D.EdCodeId = ED.EdCodeId  \n" +
                            " LEFT OUTER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER NED ON D.BaseEdCodeId = NED.EdCodeId \n" +
                            " WHERE D.Activate='A'";
                           // " AND D.MEM_CODE='" + MemCode.Trim() + "'";

                    try
                    {

                        //get the employee inof type 
                       // _rulePropertyInfoList = SQLHelper.ShowRecord(strSQL).DataTableToList<RulePropertyInfo>(); //get items ...
                       // _paymentPropertyInfoList=SQLHelper.ShowRecord(strSql).DataTableToList<PaymentPropertyInfo>(); //get items ...

                        _rulePropertyInfoList = BindClassWithData.BindClass<RulePropertyInfo>(SQLHelper.ShowRecord(strSql)).ToList();
                        _paymentPropertyInfoList = BindClassWithData.BindClass<PaymentPropertyInfo>(SQLHelper.ShowRecord(strSql)).ToList();  
                   

                        // add PaymentProperty to the list ...
                        
                        foreach (RulePropertyInfo _ruleProperty in _rulePropertyInfoList)
                        {
                           // _ruleProperty.PaymentProperty= from x in _paymentPropertyInfoList 
                           _ruleProperty.PaymentPropertyInfoList.AddRange(_paymentPropertyInfoList.FindAll(x=>x.Mem_Code==_ruleProperty.Mem_Code));
                                                           
                        }


                        return (_rulePropertyInfoList);

                    }
                    catch (Exception exp)
                    {
                        return null;
                    }


                }
                catch (Exception ex)
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetEmployeeEarningList





        //#region GetShiftScheduleList
        //private List<EmployeeVO> GetShiftScheduleList(string MemCode)
        //{
        //    try
        //    {
               

        //            strSQL = "SELECT TS.ROW_ID,TS.SCH_TYPE_ID,MS.SHIFT_NAME,CONVERT(VARCHAR(12),START_ON,106) START_ON, \n" +
        //                  " CONVERT(VARCHAR(12),END_ON,106) END_ON,CASE WHEN TS.Activate='A' THEN 'Activate' ELSE 'Last' END Activate FROM TRAN_SHIFT_ROSTER TS \n" +
        //                  " INNER JOIN MASTER_SHIFT_MAIN MS ON TS.SCH_TYPE_ID = MS.SHIFT_ID \n" +
        //                  " WHERE MEM_CODE='" + MemCode + "' ORDER BY TS.Activate,TS.ROW_ID";
        //            return SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeVO>();
        //    }catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        //#endregion GetShiftScheduleList
        #region  CheckData
        private bool CheckData(string GroupName, string strFlag, string strRowId)
        {
            try
            {
                DataTable dt = new DataTable();
                if (strFlag == "A")
                {

                    strSQL = "SELECT ENROLL_NO FROM MASTER_EMPLOYEE_MAIN WHERE REPLACE(ENROLL_NO,' ','') = REPLACE('" + GroupName + "',' ','') ";
                     if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                   
                    strSQL = "SELECT MEM_CODE,ENROLL_NO FROM MASTER_EMPLOYEE_MAIN WHERE REPLACE(ENROLL_NO,' ','') = REPLACE('" + GroupName + "',' ','') AND MEM_CODE <> '" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["MEM_CODE"].ToString().Trim())
                        {
                            //Duplicate Employee Enrollment No
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


        //ShiftSchedule
    }
}
