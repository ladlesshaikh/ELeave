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
    public class LeaveHistoryBUS
    {
        private LeaveHistoryDAO _leaveHistoryDAO;

        /// <constructor>
        /// Constructor LeaveHistoryBUS
        /// </constructor>
        public LeaveHistoryBUS()
        {
            _leaveHistoryDAO = new LeaveHistoryDAO();
        }

        #region getLeaveHistoryList
        public List<LeaveHistoryVO> getLeaveHistoryList(string MemCode)
        {
            try
            {
                return _leaveHistoryDAO.GetLeaveHistoryList(MemCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region getLeaveHistoryBindingList
        public BindingList<LeaveHistoryVO> getLeaveHistoryBindingList(string MemCode)
        {
            try
            {
                return _leaveHistoryDAO.LoadDataGridBindingList(MemCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
