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
    public class TourApplicationBUS
    {
        private TourApplicationDAO _tourApplicationDAO;

        /// <constructor>
        /// Constructor TourApplicationBUS
        /// </constructor>
        public TourApplicationBUS()
        {
            _tourApplicationDAO = new TourApplicationDAO();
        }

        #region getTourApplicationList
        public List<TourApplicationVO> getTourApplicationList()
        {
            try
            {
                return _tourApplicationDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getTourApplicationBindingList
        public BindingList<TourApplicationVO> getTourApplicationBindingList()
        {
            try
            {
                return _tourApplicationDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
