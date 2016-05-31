using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    
        /// <summary>
    /// Summary description for canteenGroupBUS
        /// </summary>
        public class CanteenGroupBUS
        {
            private CanteenGroupDAO  _canteenGroupDAO;
            /// <constructor>
            /// Constructor CanteenDAO
            /// </constructor>
            public CanteenGroupBUS()
            {
                _canteenGroupDAO = new CanteenGroupDAO();
            }

            #region getCanteenGroupList
            /// <method>
            /// Get canteen Group list ...
            /// </method>
            public List<CanteenGroupVO> getCanteenGroupList()
            {
                try
                {
                    return _canteenGroupDAO.LoadDataGridList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion

            #region getCanteenGroupBindingList
            /// <method>
            /// Get canteen list ...
            /// </method>
            public BindingList<CanteenGroupVO> getCanteenGroupBindingList()
            {
                try
                {
                    return _canteenGroupDAO.LoadDataGridBindingList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion
        }
    }

