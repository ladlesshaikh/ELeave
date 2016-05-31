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
    public class TourBUS
    {
        private TourDAO _tourDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public TourBUS()
        {
            _tourDAO = new TourDAO();
        }

        #region getTourPlaceList
        public List<TourVO> getTourPlaceList()
        {
            try
            {
                return _tourDAO.LoadDataGridList();
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
                return _tourDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
