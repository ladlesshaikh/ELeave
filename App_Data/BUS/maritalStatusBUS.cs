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
    public class MaritalStatusBUS
    {
        #region initialization
        private MaritalStatusDAO _maritalStatusDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public MaritalStatusBUS()
        {
            _maritalStatusDAO = new MaritalStatusDAO();
        }
        #endregion
        #region getMaritalStatusList
        public List<MaritalStatusVO> getMaritalStatusList()
        {
            try
            {
                return _maritalStatusDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getMaritalStatusBindingList
        public BindingList<MaritalStatusVO> getMaritalStatusBindingList()
        {
            try
            {
                return _maritalStatusDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
