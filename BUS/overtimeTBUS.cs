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
    public class OvertimeTBUS
    {
        private OvertimeDAO _overtimeDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public OvertimeTBUS()
        {
            _overtimeDAO = new OvertimeDAO();
        }

        #region getOvertimeList
        public List<OvertimeVO> getOvertimeList()
        {
            try
            {
                return _overtimeDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getOvertimeBindingList
        public BindingList<OvertimeVO> getOvertimeBindingList()
        {
            try
            {
                return _overtimeDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
