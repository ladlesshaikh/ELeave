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
    public class DesignationBUS
    {
        private DesignationDAO _designationDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public DesignationBUS()
        {
            _designationDAO = new DesignationDAO();
        }

        #region getDesignationList
        /// <method>
        /// Get getDepartmentList
        /// </method>

        public List<DesignationVO> getDesignationList()
        {
            try
            {
                return _designationDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
        #region getDesignationBindingList
        /// <method>
        /// Get getDepartmentList
        /// </method>

        public BindingList<DesignationVO> getDesignationBindingList()
        {
            try
            {
                return _designationDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
    }
}
