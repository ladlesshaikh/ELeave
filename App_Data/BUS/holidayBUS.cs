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
    public class HolidayBUS
    {
        private HolidyDAO _holidayDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public HolidayBUS()
        {
            _holidayDAO = new HolidyDAO();
        }

        #region getHolidyList
        public List<HolidayVO> getHolidyList()
        {
            try
            {
                return _holidayDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getHolidyBindingList
        public BindingList<HolidayVO> getHolidyBindingList()
        {
            try
            {
                return _holidayDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
