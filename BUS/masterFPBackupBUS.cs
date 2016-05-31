using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{

    /// <summary>
    /// Summary description for FpdeviceBUS
    /// </summary>
    public class MasterFPBackupBUS
    {
        #region variable declaration
        private MasterFpBackupDAO _masterFpBackupDAO;
        private MasterFpBackupDetDAO _masterFpBackupDetDAO;
        #endregion
        #region  Constructor
        /// <constructor>
        /// Constructor MasterFPBackupBUS
        /// </constructor>
        public MasterFPBackupBUS()
        {
            _masterFpBackupDAO = new MasterFpBackupDAO();
            _masterFpBackupDetDAO = new MasterFpBackupDetDAO();
        }
        #endregion

        #region getLastBackupNo
        /// <method> 
        /// Get getFPDeviceList
        /// </method>
        public string getLastBackupNo(string bkmode)
        {
            try
            {
                return _masterFpBackupDAO.GetLastBackupNo(bkmode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion






        #region  getFpBackupBindingList
        /// <method> 
        /// Get getFpBackupBindingList
        /// </method>
        public BindingList<MasterFpBackupVO> getFpBackupBindingList()
        {
            try
            {

                return _masterFpBackupDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion getFpBackupBindingList

        #region  getFpBackupObject
        /// <method> 
        /// Get getFpBackupObject
        /// </method>
        public MasterFpBackupVO getFpBackupBindingList(string strBackUpNo)
        {
            try
            {

                return _masterFpBackupDAO.GetBackUpItem(strBackUpNo);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion getFpBackupBindingList



        #region  getFpBackupDetList
        /// <method> 
        /// Get getFpBackupDetList
        /// </method>
        public List<MasterFpBackupDetVO> getFPBackupDetList()
        {
            try
            {

                return _masterFpBackupDetDAO.LoadFPBackUpDetList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

       

        #region  getFpBackupDetList
        /// <method> 
        /// Get getFpBackupDetList
        /// </method>
        public List<MasterFpBackupDetVO> getFPBackupDetList(string strBckNo)
        {
            try
            {
                return _masterFpBackupDetDAO.LoadFPBackUpDetList(strBckNo);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region  getFPDeviceFunctionsBindingList
        /// <method> 
        /// Get getFPDeviceFunctionsBindingList
        /// </method>
        //public  List<DeviceFunctionVO> getFPDeviceFunctionsList()
        //{
        //    try
        //    {

        //        return _fPDeviceDAO.LoadFPDeviceFunctionsList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        #endregion


        // getFPDeviceFunctionsParameterList






        //DeviceFunctionValueLists
        #region  getDeviceFunctionValueBindingList 
        /// <method> 
        /// Get getDeviceFunctionValueBindingList
        /// </method>
        //public BindingList<FPDeviceFunctionValueVO> getDeviceFunctionValueBindingList()
        //{
        //    try
        //    {
        //        return _fPDeviceDAO.LoadDeviceFunctionValueBindingList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        #endregion

       
        #region getFPDeviceLists
        /// <method> 
        /// Get getFPDeviceLists
        /// </method>
        //public BindingList<FPDeviceVO> getFPDeviceLists()
        //{
        //    try
        //    {
        //        return _fPDeviceDAO.LoadFPDeviceBindingList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        #endregion

        #region GetDeviceStatus
        /// <method> 
        /// Get getFPDeviceLists
        /// </method>
        //public BindingList<FPDeviceStatusVO> getDeviceStatus()
        //{
        //    try
        //    {
        //        return _fPDeviceDAO.LoadFPDeviceStatusBindingList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        #endregion



        // 

        #region getFPDeviceFunctionsParameterList
        /// <method> 
        /// Get getFPDeviceFunctionsParameterList
        /// </method>
        //public BindingList<DeviceFunctionParameterVO > getFPDeviceFunctionsParameterList()
        //{
        //    try
        //    {
        //        return _fPDeviceDAO.LoadFPDeviceFunctionsParameterBindingList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        #endregion


        // 

        // getFPDeviceLists

       

    }
}

