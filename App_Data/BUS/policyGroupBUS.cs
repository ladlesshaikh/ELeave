using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    
        /// <summary>
        /// Summary description for BankBUS
        /// </summary>
        public class PolicyGroupBUS
        {
            #region variable declaration
            private PolicyGroupDAO _policyGroupDAO;
            #endregion
            #region  Constructor
            /// <constructor>
            /// Constructor PolicyGroupBUS
            /// </constructor>
            public PolicyGroupBUS()
            {
                _policyGroupDAO = new  PolicyGroupDAO();
            }
            #endregion
            #region getPolicyGroupList
            /// <method> 
            /// Get getBankList
            /// </method>
            public List<PolicyGroupVO> getPolicyGroupList()
            {
                try
                {
                    return _policyGroupDAO.LoadDataGridList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion



            #region getPolicyGroupBindingList
            /// <method> 
            /// Get getPolicyGroupBindingList
            /// </method>
            public BindingList<PolicyGroupVO> getPolicyGroupBindingList()
            {
                try
                {

                    return _policyGroupDAO.LoadDataGridBindingList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion

        }
    }

