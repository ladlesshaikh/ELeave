using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    
        /// <summary>
    /// Summary description for RoleManagerBUS
        /// </summary>
        public class RoleManagerBUS
        {
            #region variable declaration
                private RoleManagerDAO _roleManagerDAO;
            #endregion

            #region  Constructor
            /// <constructor>
            /// Constructor RoleManagerBUS
            /// </constructor>
            public RoleManagerBUS()
            {
                _roleManagerDAO = new RoleManagerDAO();
            }
            #endregion
            #region getRoleBindingLis
            /// <method> 
            /// Get getRoleBindingLis
            /// </method>
            public BindingList<RoleManagerVO> getRoleBindingList()
            {
                try
                {
                    return _roleManagerDAO.LoadBindingList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion
            #region getRoleList
            /// <method> 
            /// Get getRoleList
            /// </method>
            public List<RoleManagerVO> getRoleList()
            {
                try
                {
                    return _roleManagerDAO.LoadList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion
        }
    }

