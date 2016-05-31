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
        public class ResidenceStatusBUS
        {
            private ResidenceStatusDAO _residenceStatusDAO;
            /// <constructor>
            /// Constructor CanteenDAO
            /// </constructor>
            public ResidenceStatusBUS()
            {
                _residenceStatusDAO = new ResidenceStatusDAO();
            }

            #region getresidenceStatusList
            /// <method>
            /// Get canteen Group list ...
            /// </method>
            public List<ResidenceStatusVO> getResidenceStatusList()
            {
                try
                {
                    return _residenceStatusDAO.LoadDataGridList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion

            #region getResidenceStatusBindingList
            /// <method>
            /// Get getResidenceStatusBindingList list ...
            /// </method>
            public BindingList<ResidenceStatusVO> getResidenceStatusBindingList()
            {
                try
                {
                    return _residenceStatusDAO.LoadDataGridBindingList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion
        }
    }

