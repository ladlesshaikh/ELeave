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
        public class BranchBUS
        {
            private BranchDAO  _branchDAO;
            /// <constructor>
            /// Constructor BranchBUS
            /// </constructor>
            public BranchBUS()
            {
                _branchDAO = new BranchDAO();
            }

            #region getBranchList
            /// <method>
            /// Get getBranchList
            /// </method>
            public List<BranchesVO> getBranchList()
            {
                try
                {
                    return _branchDAO.LoadDataGridList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion
            #region getBranchList
            /// <method>
            /// Get getBranchBindingList
            /// </method>
            public BindingList<BranchesVO> getBranchBindingList()
            {
                try
                {
                    return _branchDAO.LoadDataGridBindingList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion
        }
    }

