using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using EntityMapper;

namespace ATTNPAY.Core
{
    public class MiscEarningDeductionDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public MiscEarningDeductionDAO()
        {
            //conn = new dbConnection();
        }

        
 

        #region GetLoadDataGridDT
        private DataTable GetLoadDataGridDT(bool isChkWithDate, bool isRdMemCode, string strMonthSearch, string strMemberCode)
        {
            try
            {

                using (DataTable dt = new DataTable())
                {
                 
                    strSQL = " select convert(varchar(12),TRD.WefDate,113)WefDate,TRD.Psmonth,TRD.Psyear, cast(EdTranId as varchar(25))EdTranId, \n" +
                    " DTLS.MEM_CODE, \n" +
                    " DTLS.Member_Name Name,TRD.EdCodeId,MRD.Description,cast(AMOUNT as varchar(25))AMOUNT, \n" +
                    " CASE STATUS WHEN 'T' THEN 'Temporary'  WHEN 'P' THEN 'Permanent' When 'C' Then 'Continue' end STATUS ,TRD.Activate,  \n" +
                    " convert(varchar(12),TRD.FromDate,113)FromDate,convert(varchar(12),TRD.ToDate,113)ToDate,IsPercentage,IsApplyToNetSal \n" +
                    " from TRAN_EARN_DED TRD  \n" +
                    " INNER JOIN (select MEM_CODE,Member_Name from MASTER_EMPLOYEE_MAIN  \n" +
                    "  ) DTLS  ON TRD.MEM_CODE = DTLS.MEM_CODE \n" +
                    " INNER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER MRD ON TRD.EdCodeId = MRD.EdCodeId  ";


                    if (isChkWithDate == true)
                    {
                        strSQL = strSQL + " where psmonth='" + strMonthSearch.Trim() + "'";

                        if (isRdMemCode == true)
                        {
                            strSQL = strSQL + " and DTLS.MEM_CODE ='" + strMemberCode.Trim() + "' ";
                        }
                    }
                    else
                    {
                        if (isRdMemCode == true)
                        {
                            strSQL = strSQL + " where DTLS.MEM_CODE ='" + strMemberCode.Trim() + "' ";
                        }
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
       
        #region LoadDataGridList
        public List<MiscEarningDeductionVO> LoadDataGridList(bool isChkWithDate, bool isRdMemCode, string strMonthSearch, string strMemberCode)
        {
            try
            {

                strSQL = " select convert(varchar(12),TRD.WefDate,113)WefDate,TRD.Psmonth,TRD.Psyear, cast(EdTranId as varchar(25))EdTranId, \n" +
                   " DTLS.MEM_CODE, \n" +
                   " DTLS.Member_Name Name,TRD.EdCodeId,MRD.Description,cast(AMOUNT as varchar(25))AMOUNT, \n" +
                   " CASE STATUS WHEN 'T' THEN 'Temporary'  WHEN 'P' THEN 'Permanent' When 'C' Then 'Continue' end STATUS ,TRD.Activate,  \n" +
                   " convert(varchar(12),TRD.FromDate,113)FromDate,convert(varchar(12),TRD.ToDate,113) ToDate ,IsCPF \n" +
                   " from TRAN_EARN_DED TRD  \n" +
                   " INNER JOIN (select MEM_CODE,Member_Name from MASTER_EMPLOYEE_MAIN  \n" +
                   "  ) DTLS  ON TRD.MEM_CODE = DTLS.MEM_CODE \n" +
                   " INNER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER MRD ON TRD.EdCodeId = MRD.EdCodeId  ";


                if (isChkWithDate == true)
                {
                    strSQL = strSQL + " where psmonth='" + strMonthSearch.Trim() + "'";

                    if (isRdMemCode == true)
                    {
                        strSQL = strSQL + " and DTLS.MEM_CODE ='" + strMemberCode.Trim() + "' ";
                    }
                }
                else
                {
                    if (isRdMemCode == true)
                    {
                        strSQL = strSQL + " where DTLS.MEM_CODE ='" + strMemberCode.Trim() + "' ";
                    }
                }
             
                return SQLHelper.ShowRecord(strSQL).DataTableToList<MiscEarningDeductionVO>();
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        //
        #region LoadEarningDeductionLOVList
        public List<MiscEarningDeductionLOV> LoadEarningDeductionLOVList()
        {
            try
            {


                strSQL = "select edcodeid,description,Case IncomeDeduction When 'I' then 'I' Else 'D' End ED ,[Activate] from MASTER_EARNING_DEDUCTION_CODE_MASTER where Activate='A' AND Fixed_Variable='V'";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<MiscEarningDeductionLOV>();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...


        #region LoadDataGridBindingList
        public BindingList<MiscEarningDeductionVO> LoadDataGridBindingList(bool isChkWithDate, bool isRdMemCode, string strMonthSearch, string strMemberCode)
        {
            try
            {

                strSQL = " select convert(varchar(12),TRD.WefDate,113) WefDate,TRD.Psmonth,TRD.Psyear, cast(EdTranId as varchar(25)) EdTranId, \n" +
                   " DTLS.MEM_CODE, \n" +
                   " DTLS.Member_Name Name,TRD.EdCodeId,MRD.Description,cast(AMOUNT as varchar(25))AMOUNT, \n" +
                   " CASE STATUS WHEN 'T' THEN 'Temporary'  WHEN 'P' THEN 'Permanent' When 'C' Then 'Continue' end STATUS ,TRD.Activate,  \n" +
                   " convert(varchar(12),TRD.FromDate,113)FromDate,convert(varchar(12),TRD.ToDate,113)ToDate,IsPercentage,IsApplyToNetSal,IsCPF \n" +
                   " from TRAN_EARN_DED TRD  \n" +
                   " INNER JOIN (select MEM_CODE,Member_Name from MASTER_EMPLOYEE_MAIN  \n" +
                   "  ) DTLS  ON TRD.MEM_CODE = DTLS.MEM_CODE \n" +
                   " INNER JOIN MASTER_EARNING_DEDUCTION_CODE_MASTER MRD ON TRD.EdCodeId = MRD.EdCodeId  ";


                if (isChkWithDate == true)
                {
                    strSQL = strSQL + " where psmonth='" + strMonthSearch.Trim() + "'";

                    if (isRdMemCode == true)
                    {
                        strSQL = strSQL + " and DTLS.MEM_CODE ='" + strMemberCode.Trim() + "' ";
                    }
                }
                else
                {
                    if (isRdMemCode == true)
                    {
                        strSQL = strSQL + " where DTLS.MEM_CODE ='" + strMemberCode.Trim() + "' ";
                    }
                }

               // return SQLHelper.ShowRecord(strSQL).DataTableToList<MiscEarningDeductionVO>();
              // return new BindingList<MiscEarningDeductionVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<MiscEarningDeductionVO>());
                return new BindingList<MiscEarningDeductionVO>(BindClassWithData.BindClass<MiscEarningDeductionVO>(SQLHelper.ShowRecord(strSQL)));  //SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeVO>());
            

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
                    strSQL = "SELECT Description FROM MASTER_EARNING_DEDUCTION_CODE_MASTER WHERE REPLACE(Description,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT EdCodeId,Description FROM MASTER_EARNING_DEDUCTION_CODE_MASTER WHERE REPLACE(Description,' ','') = REPLACE('" + GroupName + "',' ','') AND EdCodeId='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);

                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["EdCodeId"].ToString().Trim())
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
