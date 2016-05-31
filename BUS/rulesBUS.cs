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
        public class RulesBUS
        {
            #region variable declaration
            private RulesDAO _rulesDAO;
            #endregion
            #region  Constructor
            /// <constructor>
            /// Constructor RulesBUS
            /// </constructor>
            public RulesBUS()
            {
                _rulesDAO = new RulesDAO();
            }
            #endregion
            #region getPolicyGroupList
            /// <method> 
            /// Get getRulesList
            /// </method>
            public List<RulesVO> getRulesList()
            {
                try
                {
                    return _rulesDAO.LoadDataGridList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion



            #region getRulesBindingList
            /// <method> 
            /// Get getRulesBindingList
            /// </method>
            public BindingList<RulesVO> getRulesBindingList()
            {
                try
                {

                    return _rulesDAO.LoadDataGridBindingList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion


            #region getRulesBindingList overloaded version
            /// <method> 
            /// Get getRulesBindingList this list include the details of the policy group rules id and group id
            /// this list is used in the rules mapping window ...
            /// </method>
            public BindingList<RulesGroupVO> getRulesBindingList(int iPolicyGroupID)
            {
                try
                {
                    return _rulesDAO.LoadDataGridBindingList(iPolicyGroupID);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion
            #region getRulesGroupList overloaded version
            /// <method> 
            /// Get getRulesBindingList this list include the details of the policy group rules id and group id
            /// this list is used in the rules mapping window ...
            /// </method>
            public List<RulesGroupVO> getRulesGroupList(int iPolicyGroupID)
            {
                try
                {
                    return _rulesDAO.LoadDataGroupRulesList(iPolicyGroupID);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion

                         
            #region getRulesInfoList
            /// <method> 
            /// Get getRulesInfoList list contains neccessary items to show in the info list
            /// Rule_Name,Priority,Condition,Then_Action,Else_Action
            /// this list is used in the rules mapping window ...
            /// </method>
            /*
            public DataTable getRulesInfoList(int iPolicyGroupID)
            {
                try
                {
                   return _rulesDAO.LoadInfoRulesList(iPolicyGroupID);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            */
            #endregion
        }

    
    }

