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
    public class DepartmentBUS
    {
        private DepartmentDAO _deptDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public DepartmentBUS()
        {
            _deptDAO = new DepartmentDAO();
        }

        #region getDepartmentList
        /// <method>
        /// Get getDepartmentList
        /// </method>

        public List<DepartmentVO> getDepartmentList()
        {
            try
            {
                return _deptDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region getDepartmentBindingList
        /// <method>
        /// Get getDepartmenBindingList
        /// </method>

        public BindingList<DepartmentVO> getDepartmentBindingList()
        {
            try
            {
                return _deptDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
    }
}
