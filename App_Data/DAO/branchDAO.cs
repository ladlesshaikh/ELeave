using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class BranchDAO
    {
       // private dbConnection conn;
        string strSQL = string.Empty;

        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public BranchDAO()
        {
            //conn = new dbConnection();
        }

       /// <summary>
        /// Get data to load in the DataGrid ...
       /// </summary>
       /// <returns></returns>
      

        #region GetLoadDataGridDT
        private DataTable GetLoadDataGridDT()
        {
            try
            {

                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT Branch_ID,Branch_Name,Address,State,Zip,Activate FROM MASTER_BRANCH";
                    return (SQLHelper.ShowRecord(strSQL));

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLoadDataGridDT

        #region LoadDataGridDT
        private DataTable LoadDataGridDT()
        {
            try
            {
                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT Branch_ID,Branch_Name,Address,State,Zip,Activate FROM MASTER_BRANCH";
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
                    strSQL = "SELECT Branch_ID,Branch_Name,Address,State,Zip,Activate FROM MASTER_BRANCH";
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
        public List<BranchesVO> LoadDataGridList()
        {
            try
            {
                //if (HdrProfileDet[p]["PROF_COD_1"] 

                //using (DataTable dt = new DataTable())
                //{
                    strSQL = "SELECT Branch_ID ,Branch_Name,Address,State,Zip,Activate FROM MASTER_BRANCH";
                    return SQLHelper.ShowRecord(strSQL).DataTableToList<BranchesVO>();

                    /*
                    var list = SQLHelper.ShowRecord(strSQL).AsEnumerable()
                        .Select(dr =>
                        new BankVO
                        {
                            ID = Convert.ToInt32(dr.Field<int>("ID")),
                            BankName = dr.Field<string>("Bank_Name"),
                            IFSC = dr.Field<string>("IFSC"),
                            MICR = dr.Field<string>("MICR"),
                            Branch = dr.Field<string>("Branch"),
                            Address = dr.Field<string>("Address"),
                            Activate = dr.Field<string>("Activate")
                        }

                ).ToList();

                    List<BankVO> Lst = (from dr in SQLHelper.ShowRecord(strSQL).AsEnumerable()
                                        select new BankVO()
                                          {

                                              ID = Convert.ToInt32(dr.Field<int>("ID")),
                                              BankName = dr.Field<string>("Bank_Name"),
                                              IFSC = dr.Field<string>("IFSC"),
                                              MICR = dr.Field<string>("MICR"),
                                              Branch = dr.Field<string>("Branch"),
                                              Address = dr.Field<string>("Address"),
                                              Activate = dr.Field<string>("Activate")
                                          
                                          
                                          }).ToList();


                   
                  


                    List<BankVO> list = SQLHelper.ShowRecord(strSQL).AsEnumerable()

                        .Select(x => new BankVO
                         {
                            
                                             ID = Convert.ToInt32(x["ID"]),
                                             BankName = (string)(x["Bank_Name"]),
                                             IFSC = (string)(x["IFSC"]),
                                             MICR = (string)(x["MICR"]),
                                             Branch = (string)(x["Branch"]),
                                             Address = (string)(x["Address"])
                                                        
                         }).ToList();
                     */



                //}
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<BranchesVO> LoadDataGridBindingList()
        {
            try
            {
                
                strSQL = "SELECT Branch_ID ,Branch_Name,Address,State,Zip,Activate FROM MASTER_BRANCH";
                return new BindingList<BranchesVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<BranchesVO>());

               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...






    }
}
