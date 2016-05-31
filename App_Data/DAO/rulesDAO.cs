using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class RulesDAO
    {
       // private dbConnection conn;
        string strSQL = string.Empty;

        /// <constructor>
        /// Constructor RulesDAO
        /// </constructor>
        public RulesDAO()
        {
            //conn = new dbConnection();
        }
              

        
        #region LoadDataGridDT
        private DataTable LoadDataGridDT()
        {
            try
            {
                using (DataTable dt = new DataTable())
                {


                    strSQL = "SELECT RULE_ID,RULE_NAME,RULE_DESCRIPTION,Priority,Condition,Then_Action,Else_Action,OverRuled,Activate FROM MASTER_RULE";
                    return SQLHelper.ShowRecord(strSQL);
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridDR
        private List<DataRow> LoadDataGridDR()
        {
            try
            {
                //if (HdrProfileDet[p]["PROF_COD_1"] 

                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT RULE_ID,RULE_NAME,RULE_DESCRIPTION,Priority,Condition,Then_Action,Else_Action,OverRuled,Activate FROM MASTER_RULE";
                    return (new List<DataRow>(SQLHelper.ShowRecord(strSQL).Select()));
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridList
        public List<RulesVO> LoadDataGridList()
        {
            try
            {
                

                {
                    strSQL = "SELECT RULE_ID,RULE_NAME,RULE_DESCRIPTION,Priority,Condition,Then_Action,Else_Action,OverRuled,Activate FROM MASTER_RULE";
                    return SQLHelper.ShowRecord(strSQL).DataTableToList<RulesVO>();
                   
                    

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<RulesVO> LoadDataGridBindingList()
        {
            try
            {


                {
                     
                  strSQL = " SELECT A.RULE_ID,A.RULE_NAME,A.RULE_DESCRIPTION,A.Priority,A.RULE_CAT_ID Rule_CategoryId , B.RuleCategory as Rule_Category, ";
                  strSQL +=  " A.Condition,A.Then_Action,A.Else_Action,A.OverRuled,A.Activate FROM MASTER_RULE A  ";
                  strSQL += " JOIN MASTER_RULE_CATEGORY B  ON  A.RULE_CAT_ID = B.RuleCategoryId  ";
                    
                    
                   return new BindingList<RulesVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<RulesVO>());
                    

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<RulesGroupVO> LoadDataGridBindingList(int iPolicyGroupID)
        {
            try
            {


                
                  // [ID]
                  // [GROUP_ID]
                  // [RULE_ID]
                  // [Activate]
                    //


                strSQL = " SELECT  GM.ID ID ,GM.GROUP_ID GROUP_ID, R.RULE_ID,R.RULE_NAME,R.RULE_DESCRIPTION,R.Priority,R.Condition,R.Then_Action,R.Else_Action,R.OverRuled,R.Activate   \n";
                         strSQL +=  " FROM MASTER_POLICY_RULE_DTLS GM ";
                         strSQL +=   " INNER JOIN MASTER_RULE R ON R.RULE_ID= GM.RULE_ID  ";
                         strSQL +=  "  WHERE R.ACTIVATE='A'  AND   GM.ACTIVATE='A'  ";
                        

                        // strSQL = "SELECT  GM.ID ID,GM.GROUP_ID GROUP_ID, R.RULE_ID,R.RULE_NAME,R.RULE_DESCRIPTION,R.Priority,R.Condition,R.Then_Action,R.Else_Action,R.Activate FROM MASTER_RULE";
                    
                        return new BindingList<RulesGroupVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<RulesGroupVO>());


                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGroupRulesList
        public  List<RulesGroupVO> LoadDataGroupRulesList(int iPolicyGroupID)
        {
            try
            {

                // [ID]
                // [GROUP_ID]
                // [RULE_ID]
                // [Activate]
                //




                strSQL = " SELECT  GM.ID ID ,GM.GROUP_ID GROUP_ID, R.RULE_ID,R.RULE_NAME,R.RULE_DESCRIPTION,R.Priority,R.Condition,R.Then_Action,R.Else_Action,R.OverRuled,R.Activate   \n";
                strSQL += " FROM MASTER_POLICY_RULE_DTLS GM ";
                strSQL += " INNER JOIN MASTER_RULE R ON R.RULE_ID= GM.RULE_ID  ";
                strSQL += "  WHERE R.ACTIVATE='A'  AND   GM.ACTIVATE='A'  ";


                // strSQL = "SELECT  GM.ID ID,GM.GROUP_ID GROUP_ID, R.RULE_ID,R.RULE_NAME,R.RULE_DESCRIPTION,R.Priority,R.Condition,R.Then_Action,R.Else_Action,R.Activate FROM MASTER_RULE";

                return new  List<RulesGroupVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<RulesGroupVO>());



            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...


        #region LoadRules using rule group id
        public List<RulesGroupVO> LoadRules(int iPolicyGroupID)
        {
            try
            {
                strSQL = " SELECT GM.ID ID ,GM.GROUP_ID GROUP_ID, R.RULE_ID , P.WEF_DATE,P.Re_Evaluate ReEvaluate,P.IsDefault, R.RULE_NAME,R.RULE_DESCRIPTION,R.Priority,R.Condition,R.Then_Action,R.Else_Action,R.Valid, ISNULL(R.OverRuled,'false') OverRuled,ISNULL(R.IsPercentage,'false')IsPercentage, R.Activate   \n";
                strSQL += " FROM MASTER_POLICY_RULE_DTLS GM ";
                strSQL += " INNER JOIN MASTER_RULE R ON R.RULE_ID= GM.RULE_ID  ";
                strSQL += " INNER JOIN MASTER_POLICY_GROUP P ON GM.GROUP_ID= P.GROUP_ID ";
                strSQL += " WHERE R.ACTIVATE='A'  AND  GM.ACTIVATE='A' AND R.Valid=1 AND  GM.GROUP_ID=" + iPolicyGroupID;
                return new List<RulesGroupVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<RulesGroupVO>());
                                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadRules all rules ...
        public List<RulesGroupVO> LoadRules()
        {
            try
            {
                /* old sql
                strSQL = " SELECT GM.ID ID ,GM.GROUP_ID GROUP_ID, R.RULE_ID ,R.RULE_NAME,R.RULE_DESCRIPTION,R.Priority,R.Condition,R.Then_Action,R.Else_Action,R.Valid,R.IsPercentage,R.Activate   \n";
                strSQL += " FROM MASTER_POLICY_RULE_DTLS GM ";
                strSQL += " INNER JOIN MASTER_RULE R ON R.RULE_ID= GM.RULE_ID  ";
                strSQL += " WHERE R.ACTIVATE='A'  AND  GM.ACTIVATE='A' AND R.Valid=1 ";
                */

                strSQL = " SELECT GM.ID ID ,GM.GROUP_ID GROUP_ID, R.RULE_ID , P.WEF_DATE,P.Re_Evaluate ReEvaluate,P.IsDefault, R.RULE_NAME,R.RULE_DESCRIPTION,R.Priority,R.Condition,R.Then_Action,R.Else_Action,R.Valid, ISNULL(R.OverRuled,'false') OverRuled ,ISNULL(R.IsPercentage,'false')IsPercentage, R.Activate   \n";
                strSQL += " FROM MASTER_POLICY_RULE_DTLS GM ";
                strSQL += " INNER JOIN MASTER_RULE R ON R.RULE_ID= GM.RULE_ID  ";
                strSQL += " INNER JOIN MASTER_POLICY_GROUP P ON GM.GROUP_ID= P.GROUP_ID ";
                strSQL += " WHERE R.ACTIVATE='A'  AND  GM.ACTIVATE='A' AND R.Valid=1 ";
                return new List<RulesGroupVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<RulesGroupVO>());

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region  RuleValidator

        public bool ValidateRules(string strRule)
            {
             //foreach (var rule in rules)
             //   {
             //    if (!rule(value))
             //       return false;
             //   }
             return true;
            }
        #endregion ...


    }
}
