using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Linq;
using EntityMapper;

namespace ATTNPAY.Core
{
    public class EarningDeductionDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public EarningDeductionDAO()
        {
            //conn = new dbConnection();
        }

        
 

        #region GetLoadDataGridDT
        private DataTable GetLoadDataGridDT()
        {
            try
            {

                using (DataTable dt = new DataTable())
                {
                 
                    strSQL = "SELECT EdCodeId,Description,DescAlias,Printslno, \n" +
                           " CASE WHEN Fixed_Variable='F' THEN 'Fixed' Else 'Variable' End Fixed_Variable,\n" +
                           " CASE WHEN IncomeDeduction='I' THEN 'Income' Else 'Deduction' End IncomeDeduction,\n" +
                           " ISNULL(Taxable,0) Taxable,  \n" +
                           " ISNULL(OTApplicable,0) OTApplicable,Activate,ISNULL(AfectonAttendance,0) AfectonAttendance FROM MASTER_EARNING_DEDUCTION_CODE_MASTER";
        
                    return (SQLHelper.ShowRecord(strSQL));

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLoadDataGridDT
        #region GetDisplayGridDT
        private DataTable GetDisplayGridDT(string strParam)
        {
            try
            {
                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT ID ROW_ID,FROM_AMOUNT,TO_AMOUNT,PERCENTAGE,PLUS_AMOUNT FROM MASTER_TAX_DTILS WHERE ROW_ID=" + strParam.Trim();
                    return (SQLHelper.ShowRecord(strSQL));

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region LoadDataGridList
        public List<EarningDeductionVO> LoadDataGridList()
        {
            try
            {
           
                {
                    strSQL = "SELECT EdCodeId,Description,DescAlias,Printslno, \n" +
                          " CASE WHEN Fixed_Variable='F' THEN 'Fixed' Else 'Variable' End Fixed_Variable,\n" +
                          " CASE WHEN IncomeDeduction='I' THEN 'Income' Else 'Deduction' End IncomeDeduction,\n" +
                          " ISNULL(Taxable,0) Taxable, \n" +
                          " ISNULL(OTApplicable,0) OTApplicable,Activate,ISNULL(AfectonAttendance,0) AfectonAttendance FROM MASTER_EARNING_DEDUCTION_CODE_MASTER";
                            //return SQLHelper.ShowRecord(strSQL).DataTableToList<EarningDeductionVO>();
                            return BindClassWithData.BindClass<EarningDeductionVO>(SQLHelper.ShowRecord(strSQL)).ToList(); 
                 
                
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridList
        public List<EarningDeductionVO> LoadEarningDeductionList()
        {
            try
            {

                {
                    strSQL = "SELECT EdCodeId,Description,DescAlias,Printslno, \n" +
                          " CASE WHEN Fixed_Variable='F' THEN 'Fixed' Else 'Variable' End Fixed_Variable,\n" +
                          " CASE WHEN IncomeDeduction='I' THEN 'Income' Else 'Deduction' End IncomeDeduction,\n" +
                          " ISNULL(Taxable,0) Taxable, \n" +
                          " ISNULL(OTApplicable,0) OTApplicable,Activate,ISNULL(AfectonAttendance,0) AfectonAttendance,0 Amount FROM MASTER_EARNING_DEDUCTION_CODE_MASTER";
                    //return SQLHelper.ShowRecord(strSQL).DataTableToList<EarningDeductionVO>(); -- old line
                    return BindClassWithData.BindClass<EarningDeductionVO>(SQLHelper.ShowRecord(strSQL)).ToList(); 
                   
                   
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...


        // LoadDataGridBasicBindingList
        #region LoadDataGridBasicBindingList
        public BindingList<EarningDeductionVO> LoadDataGridBasicBindingList()
        {
            try
            {

                {
                    strSQL = "SELECT EdCodeId,Description,DescAlias,Printslno, \n" +
                          " CASE WHEN Fixed_Variable='F' THEN 'Fixed' Else 'Variable' End Fixed_Variable,\n" +
                          " CASE WHEN IncomeDeduction='I' THEN 'Income' Else 'Deduction' End IncomeDeduction,\n" +
                          " ISNULL(Taxable,0) Taxable,\n" +
                          " ISNULL(OTApplicable,0) OTApplicable,Activate,ISNULL(AfectonAttendance,0) AfectonAttendance FROM MASTER_EARNING_DEDUCTION_CODE_MASTER";
                    //return SQLHelper.ShowRecord(strSQL).DataTableToList<EarningDeductionVO>();
                   // return new BindingList<EarningDeductionVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<EarningDeductionVO>());
                    return new BindingList<EarningDeductionVO>(BindClassWithData.BindClass<EarningDeductionVO>(SQLHelper.ShowRecord(strSQL))); //.DataTableToList<EarningDeductionVO>());
                 
                
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<EarningDeductionVO> LoadDataGridBindingList()
        {
            try
            {

                {

                    strSQL = "SELECT EdCodeId,Description,DescAlias,Printslno,ISNULL(CalculatedCol,0) CalculatedCol, ISNULL(FormulaText,'') FormulaText, \n" +
                          " CASE WHEN Fixed_Variable='F' THEN 'Fixed' Else 'Variable' End Fixed_Variable,\n" +
                          " CASE WHEN IncomeDeduction='I' THEN 'Income' Else 'Deduction' End IncomeDeduction,\n" +
                          " ISNULL(Taxable,0) Taxable, \n" +
                          " ISNULL(OTApplicable,0) OTApplicable,Activate,ISNULL(AfectonAttendance,0) AfectonAttendance FROM MASTER_EARNING_DEDUCTION_CODE_MASTER";
                    //return SQLHelper.ShowRecord(strSQL).DataTableToList<EarningDeductionVO>();
                    //return new BindingList<EarningDeductionVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<EarningDeductionVO>());
                    return new BindingList<EarningDeductionVO> (BindClassWithData.BindClass<EarningDeductionVO> (SQLHelper.ShowRecord(strSQL))); //.DataTableToList<EarningDeductionVO>());
                    
                
                
                }
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
