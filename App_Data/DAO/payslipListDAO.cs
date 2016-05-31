using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using EntityMapper;
using System.Linq;


namespace ATTNPAY.Core
{
    public class PayslipListDAO
    {
       // private dbConnection conn;
        string strSQL = string.Empty;

        /// <constructor>
        /// Constructor PayslipListDAO
        /// </constructor>
        public PayslipListDAO()
        {
            //conn = new dbConnection();
        }

       
        #region GetPayslip()
        public PayslipListVO GetPayslip(string sMemCode,int iMonth, int iYear,int iWEEKNO=0, DateTime processDt= default(DateTime))
        {

            DataTable Buffer = new DataTable();
            PayslipListVO tempList = new PayslipListVO();
            try
            {
                strSQL = "SELECT M.MEM_CODE,M.Member_Name+ ' '+ISNULL(M.Member_Surname,'') Member_Name ,M.DESIG_Id,DE.DESIGNATION, \n" +
                            " M.DEPT_Id,D.DEPARTMENT_Name,\n" +
                            " M.Employee_Type_Id,T.Employee_Type, \n" +
                            " TA.PAY_DAY,TA.OT1,TA.OT2,TA.OT3,TA.HOUR_OF_PAYMENT, \n" +
                            " PA.TOTAL_EARNING,PA.TOTAL_DEDUCTION,PA.NET_PAY,ISNULL(T.IS_HourlyPaid,0) IS_HourlyPaid,G.GRADE_Name, \n" +
                            " ISNULL(T.IsOtApplicable,0) IsOtApplicable,TA.PAY_DAY,TA.ABSENT,M.NoOfWorkingDay,M.PaymentId,MP.PaymentMode,MB.Branch_Name, M.DailyPayRate,M.HourlyRate, \n" +
                            " ISNULL(M.BankAccocuntNo,'') BankAccocuntNo ,ISNULL(M.BankBranchId,0) BankBranchId , ISNULL(BNK.ID,0) BANK_ID \n" +
                            " FROM MASTER_EMPLOYEE_MAIN M     \n" +
                            " INNER JOIN MASTER_DEPARTMENT D ON M.DEPT_Id = D.DEPARTMENT_Id \n" +
                            " INNER JOIN MASTER_DESIGNATION DE ON M.DESIG_Id = DE.DESIG_Id \n" +
                            " INNER JOIN MASTER_EMPLOYEE_TYPE T ON M.Employee_Type_Id = T.Employee_Type_Id \n" +
                            " INNER JOIN TRAN_PAY_ATTENDANCE TA ON M.MEM_CODE = TA.MEM_CODE \n" +
                            " INNER JOIN MASTER_GRADE G ON M.GRADE_Id = G.GRADE_Id \n" +
                            " INNER JOIN PAYROLL_YEAR_MAIN PA ON TA.MEM_CODE = PA.MEM_CODE AND TA.MONTH_ID = PA.PsMonth  \n" +
                            " AND TA.YR_ID = PA.PsYear \n" +
                            " INNER JOIN MASTER_BRANCH mb on M.Branch_ID = MB.Branch_ID \n" +
                            " INNER JOIN MASTER_PAYMENT_MODE MP ON M.PaymentId = MP.PaymentId \n" +
                            " LEFT OUTER JOIN MASTER_BANK BNK on  M.BankBranchId=BNK.ID \n" +
                            " WHERE TA.MONTH_ID=" + iMonth.ToString()  + " AND TA.YR_ID=" + iYear.ToString() + " \n" +
                            " AND M.MEM_CODE='" + sMemCode.Trim() + "'";
               

                     if (iWEEKNO!=0)
                         strSQL = strSQL + " AND TA.WEEK_NO=" + iWEEKNO.ToString();

                     if ( processDt!=  default(DateTime))

                        strSQL = strSQL + " AND CONVERT(VARCHAR(12), PA.ProcessingDate,106)='" + processDt + "'";


                        tempList.PayslipHeader = BindClassWithData.BindClass<PayslipHeaderVO>(SQLHelper.ShowRecord(strSQL)).SingleOrDefault();

                // income side ...

                strSQL = "SELECT PD.MEM_CODE,PD.EdCodeId EDCODEID,M.IncomeDeduction INCOMEDEDUCTION, \n" +
                          " M.Description DESCRIPTION,PD.PAY_RATE ACTUAL_EARNING,PD.PAY_AMOUNT AMOUNT FROM PAYROLL_YEAR_DTLS PD \n" +
                          " INNER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER M ON PD.EdCodeId = M.EdCodeId \n" +
                          " WHERE MEM_CODE='" + sMemCode.Trim() + "' AND \n" +
                          " PD.PsMonth = " + iMonth.ToString() + " AND PD.PsYear=" + iYear.ToString() + " \n" +
                          " AND M.IncomeDeduction='I'";

                tempList.LstPayslipEarning = BindClassWithData.BindClass<PayslipEDVO>(SQLHelper.ShowRecord(strSQL)).ToList();
                
                //deduction side ...
                strSQL = "SELECT PD.MEM_CODE,PD.EdCodeId EDCODEID,M.IncomeDeduction INCOMEDEDUCTION, \n" +
                       " M.Description DESCRIPTION,PD.PAY_RATE ACTUAL_EARNING,PD.PAY_AMOUNT AMOUNT FROM PAYROLL_YEAR_DTLS PD \n" +
                       " INNER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER M ON PD.EdCodeId = M.EdCodeId \n" +
                       " WHERE MEM_CODE='" + sMemCode.Trim() + "' AND \n" +
                       " PD.PsMonth = " + iMonth.ToString() + " AND PD.PsYear=" + iYear.ToString() + " \n" +
                       " AND M.IncomeDeduction='D'";
                tempList.LstPayslipDeduction = BindClassWithData.BindClass<PayslipEDVO>(SQLHelper.ShowRecord(strSQL)).ToList();

                // loan details
                strSQL = " SELECT Loan_Id,DTL.MEM_CODE,Description,TL.PrincipalAmount,(TL.PrincipalAmount - PAY_AMOUNT) Balance FROM ( \n" +
                              " SELECT PD.Loan_Id,PD.MEM_CODE,ED.Description,SUM(PD.PAY_AMOUNT) PAY_AMOUNT FROM PAYROLL_YEAR_DTLS PD \n" +
                              " INNER JOIN TRAN_LOAN TL ON PD.Loan_Id = TL.LoanId AND PD.EdCodeId = TL.EdCodeId \n" +
                              " INNER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER ED ON PD.EdCodeId = ED.EdCodeId \n" +
                              " WHERE PD.PsMonth<=" + iMonth.ToString() + " AND \n" +
                              " PD.PsYear<=" + iYear.ToString() + "  AND ISNULL(Loan_Id,0) > 0 AND PD.MEM_CODE='" + sMemCode.Trim() + "' \n" +
                              " GROUP BY PD.Loan_Id,PD.MEM_CODE,ED.Description ) DTL  \n" +
                              " inner join TRAN_LOAN TL ON DTL.Loan_Id = TL.LoanId AND DTL.MEM_CODE = TL.MEM_CODE";
                tempList.LstPayslipLoanDet = BindClassWithData.BindClass<PayslipLoanDetVO>(SQLHelper.ShowRecord(strSQL)).ToList();

                //if (tempList.PayslipHeader!=null)
                //{

                //    strSQL = "EXEC SP_Coinage_report_Detils_Employee_Wise " + iMonth.ToString() + "," + iYear.ToString() + "," + tempList.PayslipHeader.PaymentId.ToString().Trim() + ",'" + sMemCode.Trim() + "'";
                //    Buffer = SQLHelper.ShowRecord(strSQL);
                //    var ret = new List<KeyValuePair<string, string>>();

                //    if (Buffer != null)
                //    {
                //        foreach (DataRow dr in Buffer.Rows)
                //        {

                //            foreach (DataColumn col in Buffer.Columns)
                //            {
                //                ret.Add(new KeyValuePair<string, string>(col.ColumnName , (string)dr[col.ColumnName]));
                //            }
                //        }

                //    }
                //    tempList.LstCoinageList = ret.ToList();
                //}
                return tempList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        
    }
}
