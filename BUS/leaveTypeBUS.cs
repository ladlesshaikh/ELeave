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
    public class LeaveTypeBUS
    {
        private LeaveTypeDAO _leaveTypeDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public LeaveTypeBUS()
        {
            _leaveTypeDAO = new LeaveTypeDAO();
        }

        #region getLeaveTypeList
        public List<LeaveTypeVO> getLeaveTypeList()
        {
            try
            {
                return _leaveTypeDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getLeaveTypeBindingList
        public BindingList<LeaveTypeVO> getLeaveTypeBindingList()
        {
            try
            {
                return _leaveTypeDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
