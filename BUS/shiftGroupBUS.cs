using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for ShiftGroupBUS
    /// </summary>
    public class ShiftGroupBUS
    {
        private ShiftGroupDAO _shiftGroupDAO;

        /// <constructor>
        ///  ShiftGroupBUS
        /// </constructor>
        public ShiftGroupBUS()
        {
            _shiftGroupDAO = new ShiftGroupDAO();
        }

        #region getShiftGroupList
        /// <method>
        /// Get getShiftGroupList
        /// </method>

        public List<ShiftGroupVO> getShiftGroupList()
        {
            try
            {
                return _shiftGroupDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region getShiftGrouptBindingList
        /// <method>
        /// Get getShiftGrouptBindingList
        /// </method>

        public BindingList<ShiftGroupVO> getShiftGroupBindingList()
        {
            try
            {
                return _shiftGroupDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
    }
}
