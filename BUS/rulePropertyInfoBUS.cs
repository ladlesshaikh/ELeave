using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    
        /// <summary>
        /// Summary description for RulePropertyInfoBUS
        /// </summary>
        public class RulePropertyInfoBUS
        {
            #region variable declaration
            private RulePropertyInfoDAO _rulePropertyInfoDAO;
            #endregion
            #region  Constructor
            /// <constructor>
            /// Constructor RulePropertyInfoBUS
            /// </constructor>
            public RulePropertyInfoBUS()
            {
                _rulePropertyInfoDAO = new RulePropertyInfoDAO();
            }
            #endregion

            #region getRulePropertyInfoDT
            /// <method> 
            /// GetgetRulePropertyInfoDT
            /// </method>
            public DataTable getRulePropertyInfoDT(string strMemCode)
            {
                try
                {
                    return _rulePropertyInfoDAO.getRulePropertyInfoDT(strMemCode.Trim());
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion

            


           

            #region getRulePropertyInfo
            /// <method> 
            /// getRulePropertyInfo
            /// </method>
            public List<RulePropertyInfoVO> getRulePropertyInfo(string strMemCode)
            {
                try
                {
                    return _rulePropertyInfoDAO.getRulePropertyInfo(strMemCode.Trim());
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion
             #region getRulePropertyInfo
            /// <method> 
            /// getRulePropertyInfo
            /// </method>
            public List<RulePropertyInfoVO> getRulePropertyInfo()
            {
                try
                {
                    return _rulePropertyInfoDAO.getRulePropertyInfo();
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
            public List<RulePropertyInfoVO> getRuleInfoTypeBindingList()
            {
                try
                {
                    return _rulePropertyInfoDAO.getRulePropertyInfo();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion

        }
    }

