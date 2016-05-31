using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class LoanDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public LoanDAO()
        {
            //conn = new dbConnection();
        }

        #region LoadDataGridList
        public List<LoanVO> LoadDataGridList( bool bChkWithDate , bool bRdMemCode ,string strMemberCode, string strSDate, string strEndDate)
        {
            // DateStart  DateEnd
            try
            {
                strSQL = " SELECT Psmonth, Psyear, LoanId, EdCodeId, SanctionNumber, DTLS.MEM_CODE, DTLS.Member_Name MEM_NAME,  \n" +
               " SanctionNumber , CONVERT(VARCHAR(12), SanctonDate, 113)  \n" +
               " AS SANCTION_DATE, CAST(PrincipalAmount AS varchar(25)) AS PrincipalAmount, CAST(No_Installment AS varchar(25)) AS No_Installment,  \n" +
               " CAST(InterestRate AS varchar(25)) AS InterestRate, CAST(Installment_Amount AS varchar(25)) AS Installment_Amount,  \n" +
               " CONVERT(VARCHAR(12), DeductionDate, 113)  \n" +
               " AS DeductionDate, TL.Activate,ISNULL(TL.Stop_Installment,0) Stop_Installment, \n" +
               " CASE WHEN  TL.Activate='A' THEN \n" +
               " CASE WHEN Stop_Installment is not null THEN 'Start' ELSE 'Stop' END \n" +
               " ELSE ' Not Applicable' END Action \n"+ 
               " FROM  TRAN_LOAN AS TL INNER JOIN \n" +
               " (SELECT     MEM_CODE, Member_Name \n" +
               " FROM          MASTER_EMPLOYEE_MAIN) AS DTLS ON TL.MEM_CODE = DTLS.MEM_CODE ";

                //  DateStart.Value.ToString("dd/MMM/yyyy") 
                //  ChkWithDate  RdMemCode  TxtMemberCode TxtMemberCode
                //  DateEnd.Value.ToString("dd/MMM/yyyy")

                if (bChkWithDate == true)
                {
                    strSQL = strSQL + " WHERE SanctonDate BETWEEN '" + strSDate + "' AND '" + strEndDate + "'";
                    if (bRdMemCode == true)
                    {
                        strSQL = strSQL + " and DTLS.Mem_Code ='" + strMemberCode.Trim() + "' ";
                    }
                }
                else
                {
                    if (bRdMemCode == true)
                    {
                        strSQL = strSQL + " WHERE DTLS.Mem_Code ='" + strMemberCode.Trim() + "' ";
                    }
                }
                    
                    return SQLHelper.ShowRecord(strSQL).DataTableToList<LoanVO>();
            
            }catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<LoanVO> LoadDataGridBindingList(bool bChkWithDate, bool bRdMemCode, string strMemberCode, string strSDate, string strEndDate)
        {
            // DateStart  DateEnd
            try
            {
                strSQL = " SELECT Psmonth, Psyear, LoanId, EdCodeId, SanctionNumber, DTLS.MEM_CODE, DTLS.Member_Name NAME,  \n" +
               " SanctionNumber AS Expr1, CONVERT(VARCHAR(12), SanctonDate, 113)  \n" +
               " AS SANCTION_dATE, CAST(PrincipalAmount AS varchar(25)) AS PrincipalAmount, CAST(No_Installment AS varchar(25)) AS No_Installment,  \n" +
               " CAST(InterestRate AS varchar(25)) AS InterestRate, CAST(Installment_Amount AS varchar(25)) AS Installment_Amount,  \n" +
               " CONVERT(VARCHAR(12), DeductionDate, 113)  \n" +
               " AS DeductionDate, TL.Activate,ISNULL(TL.Stop_Installment,0) Stop_Installment \n" +
               " FROM  TRAN_LOAN AS TL INNER JOIN \n" +
               " (SELECT     MEM_CODE, Member_Name \n" +
               " FROM          MASTER_EMPLOYEE_MAIN) AS DTLS ON TL.MEM_CODE = DTLS.MEM_CODE ";

                //  DateStart.Value.ToString("dd/MMM/yyyy") 
                //  ChkWithDate  RdMemCode  TxtMemberCode TxtMemberCode
                //  DateEnd.Value.ToString("dd/MMM/yyyy")

                if (bChkWithDate == true)
                {
                    strSQL = strSQL + " WHERE SanctonDate BETWEEN '" + strSDate + "' AND '" + strEndDate + "'";
                    if (bRdMemCode == true)
                    {
                        strSQL = strSQL + " and DTLS.Mem_Code ='" + strMemberCode.Trim() + "' ";
                    }
                }
                else
                {
                    if (bRdMemCode == true)
                    {
                        strSQL = strSQL + " WHERE DTLS.Mem_Code ='" + strMemberCode.Trim() + "' ";
                    }
                }

               /// return SQLHelper.ShowRecord(strSQL).DataTableToList<LoanVO>();
               /// 
                return new BindingList<LoanVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<LoanVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
    }
}
