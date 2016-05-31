using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for YearMainBUS
    /// </summary>
    public class YearMainBUS
    {
        private YearMainDAO _yearMainDAO;

        /// <constructor>
        /// Constructor YearMainBUS
        /// </constructor>
        public YearMainBUS()
        {
            _yearMainDAO = new YearMainDAO();
        }

        #region getYearList
        public List<YearMainVO> getYearList()
        {
            try
            {
                return _yearMainDAO.GetYearList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region getYearMainBindingList
        public BindingList<YearMainVO> getYearMainBindingList()
        {
            try
            {
                return _yearMainDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
