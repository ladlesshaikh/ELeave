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
    public class EmployeeTypeBUS
    {
        private EmployeeTypeDAO _employeeTypeDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public EmployeeTypeBUS()
        {
            _employeeTypeDAO = new EmployeeTypeDAO();
        }
        #region getEmployeeTypeList
        /// <method>
        /// Get getEmployeeTypeList
        /// </method>

        public List<EmployeeTypeVO> getEmployeeTypeList()
        {
            try
            {
                return _employeeTypeDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
        #region getEmployeeTypeBindingList
        /// <method>
        /// Get getEmployeeTypeBindingList
        /// </method>

        public BindingList<EmployeeTypeVO> getEmployeeTypeBindingList()
        {
            try
            {
                return _employeeTypeDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
    }
}
