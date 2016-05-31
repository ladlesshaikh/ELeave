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
    public class LoginUserBUS
    {
        private LoginUserDAO _loginUserDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public LoginUserBUS()
        {
            _loginUserDAO = new  LoginUserDAO();
        }

        #region getLoginUserList
        public List<LoginUserVO> getLoginUserList(string strBranchCode)
        {
            try
            {
                return _loginUserDAO.LoadDataGridList(strBranchCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getLoginUserBindingList
        public BindingList<LoginUserVO> getLoginUserBindingList(string strBranchCode)
        {
            try
            {
                return _loginUserDAO.LoadDataGridBindingList(strBranchCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
