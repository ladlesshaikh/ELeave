using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for UserBUS
    /// </summary>
    public class EmployeeBUS
    {
        private EmployeeDAO _employeeDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public EmployeeBUS()
        {
            _employeeDAO = new EmployeeDAO();
        }

        #region GetEmployeesROs
        public List<KeyValue> getEmployeesROs(string strMemCode)
        {
            try
            {
                return _employeeDAO.GetEmployeesROs(strMemCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetEmployeesROs




        #region getRoMemberInfo
        public List<RoMemberInfoVO> getRoMemberInfo(string strMemCode)
        {
            try
            {
                return _employeeDAO.GetRoMemberInfo(strMemCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetEmployeesROs


        #region getRoMemberInfo
        public List<RoMemberInfoVO> getRoMemberInfo(string strMemCode, bool isAll)
        {
            try
            {
                return _employeeDAO.GetRoMemberInfo(strMemCode, isAll);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<RoMemberInfoVO> getRoName(string strMemCode)
        {
            try
            {
                return _employeeDAO.getRoName(strMemCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetEmployeesROs

        #region GetEmployeesRO
        public string GetEmployeesRO(string strMemCode)
        {
            try
            {

                return _employeeDAO.GetEmployeesRO(strMemCode);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        #endregion GetEmployeesRO

        #region GetAdminUserID
        public LoginUserVO GetAdminUser(string strBranchCode)
        {
            try
            {
                return _employeeDAO.GetAdminUser(strBranchCode.Trim());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region GetRODet
        //GetROAppDetEmail
        public List<string> GetROAppDetEmail(string strMemCode)
        {
            try
            {
                return _employeeDAO.GetROAppDetEmail(strMemCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
       
        public List<string> GetROCCtEmail(string strMemCode,string ApprMemCode)
        {
            try
            {
                return _employeeDAO.GetROCCtEmail(strMemCode, ApprMemCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<string> GetRODetEmail(string strMemCode)
        {
            try
            {
                return _employeeDAO.GetRODetEmail(strMemCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<string> GetRODet(string strMemCode)
        {
            try
            {
                return _employeeDAO.GetRODet(strMemCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetRODet



        #region getEmployee -bool bChecked
        /// <method>
        /// Get getDevice
        /// </method>

        public List<EmployeeVO> getEmployeeList(bool bChecked, string orderBy)
        {
            try
            {
                return _employeeDAO.LoadDataGridList(bChecked, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region getEmployee -bool bChecked
        /// <method>
        /// Get getDevice
        /// </method>

        public List<string> getEmployeesEntrollNos()
        {
            try
            {
                return _employeeDAO.GetEmployeesEntrollNos();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 


        #region getEmployee - Master Dropdown list of values
        public List<ComboBoxFill> getEmployeeDropDownList(bool bChecked, string orderBy)
        {
            try
            {
                return _employeeDAO.GetEmployeeDropdownList(bChecked, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getGrade - Master Dropdown list of values
        public List<ComboBoxFill> getGradeLst(bool bChecked, string orderBy)
        {
            try
            {
                return _employeeDAO.GetGradeDropdownList(bChecked, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region getBranch - Master Dropdown list of values
        public List<ComboBoxFill> getBranch(bool bChecked, string orderBy)
        {
            try
            {
                return _employeeDAO.GetBranchDropdownList(bChecked, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region getDesignation - Master Dropdown list of values
        public List<ComboBoxFill> getDesignation(bool bChecked, string orderBy)
        {
            try
            {
                return _employeeDAO.GetDesignationDropdownList(bChecked, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region getDepartment - Master Dropdown list of values
        public List<ComboBoxFill> getDepartment(bool bChecked, string orderBy)
        {
            try
            {
                return _employeeDAO.GetDepartmentDropdownList(bChecked, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region getShiftType - Master Dropdown list of values
        public List<ComboBoxFill> getShiftType(bool bChecked, string orderBy)
        {
            try
            {
                return _employeeDAO.GetShiftTypeDropdownList(bChecked, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region getEmployeeType - Master Dropdown list of values
        public List<ComboBoxFill> getEmpType(bool bChecked, string orderBy)
        {
            try
            {
                return _employeeDAO.GetEmployeeTypeDropdownList(bChecked, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


















        #region getEmployee -using Employee Group ID
        /// <method>
        /// Get getDevice
        /// </method>

        //public List<string> getEmployeeGroupMemCodes(int iGroupID)
        //{
        //    try
        //    {
        //        return _employeeDAO.LoadDataGroupGridMemList(iGroupID);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        #endregion


        #region getEmployeeBindingList -bool bChecked
        /// <method>
        /// Get getDevice
        /// </method>

        public BindingList<EmployeeVO> getEmployeeBindingList(bool bChecked, string orderBy,string strCondition)
        {
            try
            {
                return _employeeDAO.LoadDataGridBindingList(bChecked, orderBy, strCondition);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region getEmployeeBindingList -bool bChecked
        /// <method>
        /// Get getDevice
        /// </method>

        public BindingList<EmployeeVO> getEmployeeBindingList(bool bChecked, string orderBy)
        {
            try
            {
                return _employeeDAO.LoadDataGridBindingList(bChecked, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region getEmployee -string strRowId
        /// <method>
        /// Get getDevice
        /// </method>

        public List<EmployeeVO> getEmployeeList(string strRowId, string orderBy)
        {
            try
            {
                return _employeeDAO.LoadDataGridList(strRowId, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        
        #region GetEmployeeEarningList(string strRowId)
        /// <method>
        /// Get getEmployeeEarningList...
        /// </method>

        public List<EmployeeVO> getEmployeeEarningList(string strRowId, string orderBy)
        {
            try
            {
                return _employeeDAO.GetEmployeeEarningList(strRowId, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region GetShiftGroupList(string strShiftGrpID)
        /// <method>
        /// Get GetShiftGroupList ....
        /// </method>

        public BindingList<EmployeeVO> GetShiftGroupList(string strShiftGrpID, string orderBy)
        {
            try
            {
                return _employeeDAO.GetEmployeeShiftGroupList(strShiftGrpID, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
        #region GetShiftScheduleList(string MemCode)
        /// <method>
        /// Get getShiftScheduleList...
        /// </method>

        public List<EmployeeVO> getShiftScheduleList(string MemCode, string orderBy)
        {
            try
            {
                return _employeeDAO.GetEmployeeEarningList(MemCode, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region GetRulePropertyInfo(string MemCode)
        /// <method>
        /// Get GetRulePropertyInfo...
        /// </method>

        public RulePropertyInfo getRulePropertyInfo(string MemCode)
        {
            try
            {
                return _employeeDAO.GetRulePropertyInfo(MemCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region GetRulePropertyInfo(List<string> MemCodes)
        /// <method>
        /// Get GetRulePropertyInfo...
        /// </method>

        public List<RulePropertyInfo> getRulePropertyInfo(List<string> MemCodes)
        {
            try
            {
                return _employeeDAO.GetRulePropertyInfo(MemCodes);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
        #region GetRulePropertyInfoList()
        /// <method>
        /// Get GetRulePropertyInfoList...
        /// </method>

        public List<RulePropertyInfo> getRulePropertyInfoList()
        {
            try
            {
                return _employeeDAO.GetRulePropertyInfoList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 




         



    }
}
