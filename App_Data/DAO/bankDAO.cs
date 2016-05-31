using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class BankDAO
    {
       // private dbConnection conn;
        string strSQL = string.Empty;

        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public BankDAO()
        {
            //conn = new dbConnection();
        }

        

        
        #region LoadDataGridDT
        private DataTable LoadDataGridDT()
        {
            try
            {
                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT ID,Bank_Name,IFSC,MICR,Branch,Address,Activate FROM MASTER_BANK";
                    return SQLHelper.ShowRecord(strSQL);
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridDR
        private List<DataRow> LoadDataGridDR()
        {
            try
            {
                //if (HdrProfileDet[p]["PROF_COD_1"] 

                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT ID,Bank_Name,IFSC,MICR,Branch,Address,Activate FROM MASTER_BANK";
                    return (new List<DataRow>(SQLHelper.ShowRecord(strSQL).Select()));
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridList
        public List<BankVO> LoadDataGridList()
        {
            try
            {
                

                {
                    strSQL = "SELECT ID,Bank_Name ,IFSC,MICR,Branch,Address,Activate FROM MASTER_BANK";
                    return SQLHelper.ShowRecord(strSQL).DataTableToList<BankVO>();
                   
                    //List<Student> newStudents = studentTbl.ToList<Student>(); 
                    
                    
                    //  return  SQLHelper.ShowRecord(strSQL).Select().t.CopyTo(.Select().t..AsEnumerable().Select().GetEnumerator().DataTableToList<BankVO>();//. datatable.AsEnumerable().ToList()
                   // SQLHelper.ShowRecord(strSQL).Rows.OfType<DataRow>()
                   // .Select().ToList<BankVO>();

                 //   var list = from x in SQLHelper.ShowRecord(strSQL).AsEnumerable().Select().<BankVO>());
                    
                 //var lst
                  //var lst = from x in SQLHelper.ShowRecord(strSQL).AsEnumerable()
                  //            select x;

                  //IEnumerable<BankVO> query =
                  // from x in SQLHelper.ShowRecord(strSQL).AsEnumerable()
                  //  select new BankVO(){ x}; 

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<BankVO> LoadDataGridBindingList()
        {
            try
            {


                {
                    strSQL = "SELECT ID,Bank_Name ,IFSC,MICR,Branch,Address,Activate FROM MASTER_BANK";

                    return new BindingList<BankVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<BankVO>());
                    //return  SQLHelper.ShowRecord(strSQL).DataTableToList<BankVO>();

                    //List<Student> newStudents = studentTbl.ToList<Student>(); 


                    //  return  SQLHelper.ShowRecord(strSQL).Select().t.CopyTo(.Select().t..AsEnumerable().Select().GetEnumerator().DataTableToList<BankVO>();//. datatable.AsEnumerable().ToList()
                    // SQLHelper.ShowRecord(strSQL).Rows.OfType<DataRow>()
                    // .Select().ToList<BankVO>();

                    //   var list = from x in SQLHelper.ShowRecord(strSQL).AsEnumerable().Select().<BankVO>());

                    //var lst
                    //var lst = from x in SQLHelper.ShowRecord(strSQL).AsEnumerable()
                    //            select x;

                    //IEnumerable<BankVO> query =
                    // from x in SQLHelper.ShowRecord(strSQL).AsEnumerable()
                    //  select new BankVO(){ x}; 

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...




    }
}
