using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for UserBUS
    /// </summary>
    public class DeviceBUS
    {
        private DeviceDAO _deviceDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public DeviceBUS()
        {
            _deviceDAO = new DeviceDAO();
        }

        #region getDevice
        /// <method>
        /// Get getDevice
        /// </method>

        public List<DeviceVO> getDeviceList()
        {
            try
            {
                return _deviceDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
        #region getDeviceBindingList
        /// <method>
        /// Get getDevice
        /// </method>

        public BindingList<DeviceVO> getDeviceBindingList()
        {
            try
            {
                return _deviceDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
        
    }
}
