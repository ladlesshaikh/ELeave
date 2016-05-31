using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for LeaveApplicationBUS
    /// </summary>
    public class LeaveApplicationBUS
    {
        private LeaveApplicationDAO _leaveApplicationDAO;

        /// <constructor>
        /// Constructor LeaveApplication
        /// </constructor>
        public LeaveApplicationBUS()
        {
            _leaveApplicationDAO = new LeaveApplicationDAO();
        }

       // LoadDataGridBindingList
        #region getLeaveApplicationList
        public List<LeaveApplicationVO> getLeaveApplicationList()
        {
            try
            {
                return _leaveApplicationDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region getLeaveApplicationBindingList
        public BindingList<LeaveApplicationVO> getLeaveApplicationBindingList()
        {
            try
            {
                return _leaveApplicationDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
