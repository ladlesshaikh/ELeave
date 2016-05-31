using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for LobBUS
    /// </summary>
    public class LobBUS
    {
        #region Initialization
        private LobDAO _lobDAO;
        /// <constructor>
        /// Constructor LobBUS
        /// </constructor>
        public LobBUS()
        {
            _lobDAO = new  LobDAO();
        }
        #endregion
        #region getLeaveOpeningBalanceList
        public List<LobVO> getLeaveOpeningBalanceList()
        {
            try
            {
                return _lobDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getLeaveOpeningBalanceBindingList
        public BindingList<LobVO> getLeaveOpeningBalanceBindingList()
        {
            try
            {
                return _lobDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
