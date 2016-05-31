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
    public class FpdeviceManagementBUS
    {
        #region variable declaration
        private FPDeviceDAO _fPDeviceDAO;
        #endregion
        #region  Constructor
        /// <constructor>
        /// Constructor FpdeviceBUS
        /// </constructor>
        public FpdeviceManagementBUS()
        {
            _fPDeviceDAO = new FPDeviceDAO();
        }
        #endregion
        #region getFPDeviceList
        /// <method> 
        /// Get getFPDeviceList
        /// </method>
        public List<FPDeviceDAO> getFPDeviceList()
        {
            try
            {
                return _fPDeviceDAO.LoadDataGridList();
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
        public BindingList<DeviceFunctionVO> getFPDeviceFunctionsBindingList()
        {
            try
            {

                return _fPDeviceDAO.LoadFPDeviceFunctionsBindingList();
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
        public  List<DeviceFunctionVO> getFPDeviceFunctionsList()
        {
            try
            {

                return _fPDeviceDAO.LoadFPDeviceFunctionsList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        // getFPDeviceFunctionsParameterList






        //DeviceFunctionValueLists
        #region  getDeviceFunctionValueBindingList 
        /// <method> 
        /// Get getDeviceFunctionValueBindingList
        /// </method>
        public BindingList<FPDeviceFunctionValueVO> getDeviceFunctionValueBindingList()
        {
            try
            {
                return _fPDeviceDAO.LoadDeviceFunctionValueBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

       
        #region getFPDeviceLists
        /// <method> 
        /// Get getFPDeviceLists
        /// </method>
        public BindingList<FPDeviceVO> getFPDeviceLists()
        {
            try
            {
                return _fPDeviceDAO.LoadFPDeviceBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region GetDeviceStatus
        /// <method> 
        /// Get getFPDeviceLists
        /// </method>
        public BindingList<FPDeviceStatusVO> getDeviceStatus()
        {
            try
            {
                return _fPDeviceDAO.LoadFPDeviceStatusBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion



        // 

        #region getFPDeviceFunctionsParameterList
        /// <method> 
        /// Get getFPDeviceFunctionsParameterList
        /// </method>
        public BindingList<DeviceFunctionParameterVO > getFPDeviceFunctionsParameterList()
        {
            try
            {
                return _fPDeviceDAO.LoadFPDeviceFunctionsParameterBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        // 

        // getFPDeviceLists

        #region  getFPDeviceBindingList
        /// <method> 
        /// Get getFPDeviceBindingList
        /// </method>
        public BindingList<FPDeviceDAO> getFPDeviceBindingList()
        {
            try
            {

                return _fPDeviceDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}

