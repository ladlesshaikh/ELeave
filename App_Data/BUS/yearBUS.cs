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
    public class YearBUS
    {
        private YearDAO _yearDAO;

        /// <constructor>
        /// Constructor YearBUS
        /// </constructor>
        public YearBUS()
        {
            _yearDAO = new YearDAO();
        }

        #region getTourPlaceList
        public List<YearVO> getYearList()
        {
            try
            {
                return _yearDAO.GetYearList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region getTourPlaceBindingList
        public BindingList<TourVO> getTourPlaceBindingList()
        {
            try
            {
                return _yearDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
