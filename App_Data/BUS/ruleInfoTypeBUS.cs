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
        public class RuleInfoTypeBUS
        {
            #region variable declaration
            private RuleInfoTypeDAO _ruleInfoTypeDAO;
            #endregion
            #region  Constructor
            /// <constructor>
            /// Constructor UserBUS
            /// </constructor>
            public RuleInfoTypeBUS()
            {
                _ruleInfoTypeDAO = new RuleInfoTypeDAO();
            }
            #endregion
            #region getRuleInfoTypeList
            /// <method> 
            /// Get getBankList
            /// </method>
            public List<RuleInfoTypeVO> getRuleInfoTypeList()
            {
                try
                {
                    return _ruleInfoTypeDAO.LoadDataGridList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion



            #region   getRuleInfoTypeBindingList
            /// <method> 
            /// Get getRuleInfoTypeBindingList
            /// </method>
            public BindingList<RuleInfoTypeVO> getRuleInfoTypeBindingList()
            {
                try
                {
                    return _ruleInfoTypeDAO.LoadDataGridBindingList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion

        }
    }

