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
        public class CanteenBUS
        {
            private CanteenDAO  _canteenDAO;
            /// <constructor>
            /// Constructor CanteenDAO
            /// </constructor>
            public CanteenBUS()
            {
                _canteenDAO = new CanteenDAO();
            }

            #region getCanteenList
            /// <method>
            /// Get canteen list ...
            /// </method>
            public List<CanteenVO> getCanteenList()
            {
                try
                {
                    return _canteenDAO.LoadDataGridList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion

            #region getCanteenBindingList
            /// <method>
            /// Get canteen list ...
            /// </method>
            public BindingList<CanteenVO> getCanteenBindingList()
            {
                try
                {
                    return _canteenDAO.LoadDataGridBindingList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion
        }
    }

