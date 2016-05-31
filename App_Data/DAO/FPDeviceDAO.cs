using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class FPDeviceDAO
    {
        // private dbConnection conn;
        string strSQL = string.Empty;

        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public FPDeviceDAO()
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
        public List<FPDeviceDAO> LoadDataGridList()
        {
            try
            {
                    strSQL = "SELECT ID,Bank_Name ,IFSC,MICR,Branch,Address,Activate FROM MASTER_BANK";
                    return SQLHelper.ShowRecord(strSQL).DataTableToList<FPDeviceDAO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        // LoadFPDeviceFunctionsBindingList();
        #region LoadFPDeviceFunctionsBindingList
        public BindingList<DeviceFunctionVO> LoadFPDeviceFunctionsBindingList()
        {
            try
            {
                    strSQL = "SELECT ID,Bank_Name ,IFSC,MICR,Branch,Address,Activate FROM MASTER_BANK";
                    return new BindingList<DeviceFunctionVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<DeviceFunctionVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        // LoadDeviceFunctionValueBindingList
        #region LoadFPDeviceFunctionsBindingList
        public BindingList<FPDeviceFunctionValueVO> LoadDeviceFunctionValueBindingList()
        {
            try
            {
                strSQL = "SELECT ID,Bank_Name ,IFSC,MICR,Branch,Address,Activate FROM MASTER_BANK";
                return new BindingList<FPDeviceFunctionValueVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<FPDeviceFunctionValueVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        //
        #region LoadFPDeviceFunctionsList
        public List<DeviceFunctionVO> LoadFPDeviceFunctionsList()
        {
            try
            {
               strSQL = "SELECT ID,Bank_Name ,IFSC,MICR,Branch,Address,Activate FROM MASTER_BANK";
               return SQLHelper.ShowRecord(strSQL).DataTableToList<DeviceFunctionVO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadFPDeviceBindingList
        public BindingList<FPDeviceVO> LoadFPDeviceBindingList()
        {
            try
            {
                strSQL = "SELECT ID,Bank_Name ,IFSC,MICR,Branch,Address,Activate FROM MASTER_BANK";
                return new BindingList<FPDeviceVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<FPDeviceVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        //
        #region LoadFPDeviceStatusBindingList
        public BindingList<FPDeviceStatusVO > LoadFPDeviceStatusBindingList()
        {
            try
            {
                strSQL = "SELECT ID,Bank_Name ,IFSC,MICR,Branch,Address,Activate FROM MASTER_BANK";
                return new BindingList<FPDeviceStatusVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<FPDeviceStatusVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...   


        // 


        #region LoadFPDeviceFunctionsParameterBindingList
        public BindingList<DeviceFunctionParameterVO> LoadFPDeviceFunctionsParameterBindingList()
        {
            try
            {
                strSQL = "SELECT ID,Bank_Name ,IFSC,MICR,Branch,Address,Activate FROM MASTER_BANK";
                return new BindingList<DeviceFunctionParameterVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<DeviceFunctionParameterVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...   



        #region LoadDataGridBindingList
        public BindingList<FPDeviceDAO> LoadDataGridBindingList()
        {
            try
            {


                {
                    strSQL = "SELECT ID,Bank_Name ,IFSC,MICR,Branch,Address,Activate FROM MASTER_BANK";
                    return new BindingList<FPDeviceDAO>(SQLHelper.ShowRecord(strSQL).DataTableToList<FPDeviceDAO>());
               
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