using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;
using ATTNPAY.Class;
using SimpleExpressionEvaluator;
using System.Reflection;
using System.Linq;
using System.Text.RegularExpressions;
namespace ATTNPAY.Core
{
    
        /// <summary>
        /// Summary description for BankBUS
        /// </summary>
        public class RuleManagerBUS
        {
            #region variable declaration

            string strInsertSQL = string.Empty;
            string strUpdateSQL = string.Empty;


            //used to get the rules list associated with the group policy of an employee.
            private RulesDAO _rulesDAO;
            private List<SalaryEarningVO> _lstSalaryEarningVO=null;
            
            // base class of employee master 
            private EmployeeBUS _employeeBUS;

            RulePropertyInfo _objRulePropertyInfo; // storing ruleproperty info type using member code/employee code
            List<RulesGroupVO> _lstRules; //used for storing the rules associated with an employee
            
            // ED code master ...
            private EarningDeductionBUS _earningDeductionBUS;
            // ....
            // this class is used to get the existing ED list of employees..
            // this list is used to check whether any ed info types exists in the ed details before add/update new
            // ed info types thru rules
            
             private SalaryEarningBUS _salaryEarningBUS;
           
            // rule evaluator
            //private Evaluator evaluator = null;

            // QueryBuilder ....
            QueryBuilderHelper _qbuilder = null;
            //declare dictionary to include the payment stuff rquired to evaluate expression

            // declare the dictionary
		     public Dictionary<string, double> payStuffDictionary = new Dictionary<string, double>();
             public Dictionary<string, double> payStuffRunTimeDictionary = new Dictionary<string, double>();

            #endregion
            #region  Constructor
            /// <constructor>
            /// Constructor RulesBUS
            /// </constructor>
            public RuleManagerBUS()
            {
                _rulesDAO = new RulesDAO();
               //  evaluator = new Evaluator();
                 _earningDeductionBUS = new EarningDeductionBUS();
                 _employeeBUS=new EmployeeBUS();
                _salaryEarningBUS=new SalaryEarningBUS();
                _qbuilder = new QueryBuilderHelper();
                _objRulePropertyInfo = new RulePropertyInfo();
               

            }
            #endregion
            #region getRulesList
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

            #region applyRules(MemCode)
            /// <method> 
            /// applyRules
            
            /// </method>
            public ResultStatus applyRules(string strMemCode)//, List<RulesGroupVO> _lstRules SalaryEarningBUS objSalaryEarningBUS)
            {
                try
                {
                    #region initialization
                    int _rtn = 0;
                    double result = 0.0;
                    bool insertOnlyFlag = false;
                    bool isPercentage = false;
                    string sBaseCodeId = string.Empty;
                    int iPercentage = 0;
                    string clearString=string.Empty;

                    Regex rgx = new Regex(@"[[]]");
                    /*
                    var result = ruleValidator.ValidateRulesSum(
                    new Person[] { person1, person2 },
                    new Rule[] { rule1, rule2 });            
                    */
                    //RulePropertyInfo _objRulePropertyInfo

                    
                    //check strMemCode is null
                    if (string.IsNullOrEmpty(strMemCode))
                        return ResultStatus.EmptyString;

                   
                    _objRulePropertyInfo = new RulePropertyInfo();
                    _lstRules = new List<RulesGroupVO>();

                   // if (_objRulePropertyInfo.PolicyGroupID == null)
                    //    return ResultStatus.EmptyString;
                    
                    //populate RulePropertyInfo using the 'strMemCode' -employeecode value ...
                    _objRulePropertyInfo = _employeeBUS.getRulePropertyInfo(strMemCode);

                    //populate rules using PolicyGroupID ...
                    _lstRules = _rulesDAO.LoadRules(_objRulePropertyInfo.PolicyGroupID);
                    _lstRules.OrderBy(s => s.Priority);

                    payStuffRunTimeDictionary.Clear();
                    List<EarningDeductionVO> _edCodes=new  List<EarningDeductionVO>();
                    _edCodes=_earningDeductionBUS.getEarningDeductionList();
                    #endregion initialization

                    #region comment

                    //foreach (RulesGroupVO rule in _lstRules)
                    //{
                        
                    //    // validate the rule ...
                    //    var evaluatorResult = evaluator.Evaluate<RulePropertyInfo>(rule.Condition, _objRulePropertyInfo);

                    //    if (evaluatorResult == true)
                    //    {

                    //        //Evaluate the Then_Action expression

                    //        ParseList parse = parseExpression(rule.Then_Action);
                    //        if (_edCodes.Where(x => x.Description == parse.LValue.Trim()).FirstOrDefault() != null)
                    //        {
                    //            // here we can also check the parameter count ==0 and it's exists in the edlist

                    //            // check the left expression is valid...
                    //            if (ValidateExpression(parse.Rvalue))
                    //            {

                    //                //evaluate the expression
                                    
                    //                // check whether the employee has payment details

                    //                if (_objRulePropertyInfo.PaymentPropertyInfoList.Count == 0) // no payment details associated with the employee
                    //                {
                    //                    insertOnlyFlag = true; //only insert operation is rquired in db

                    //                    if (payStuffRunTimeDictionary.Count > 0)
                    //                    {

                    //                        //add the items from payStuffRunTimeDictionary to the dictionary ...
                    //                        payStuffDictionary = payStuffRunTimeDictionary.ToDictionary(s => s.Key, s => s.Value);
                    //                        // now add remaining items from _edCodes

                    //                        var edcodes = _edCodes.Where(p => !payStuffRunTimeDictionary.Any(p2 => p2.Key == p.Description));

                    //                        // Add to the dictionary ...
                    //                        edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));
                                            
                    //                    }
                    //                    else
                    //                        payStuffDictionary = _edCodes.ToDictionary(s => s.Description, s => s.Amount); //s => s.Amount is always 0

                                      
                    //                }

                    //                else // has values in the payment stuff 
                    //                {

                    //                    //add the existing payment stuff to the dictionary ...
                    //                    payStuffDictionary = _objRulePropertyInfo.PaymentPropertyInfoList.ToDictionary(s => s.HeadName, s => s.Amount);

                    //                    // populate dictionay with all edlist items except the one exits in the payment list with 0 value for amount ..
                    //                    //dictionaryFrom.ToList().ForEach(x => dictionaryTo.Add(x.Key, x.Value));
                                        
                    //                    // var result = peopleList2.Where(p => !peopleList1.Any(p2 => p2.ID == p.ID));

                    //                    //select all payment stuff not contains in PaymentPropertyInfoList
                    //                    var edcodes = _edCodes.Where(p => !_objRulePropertyInfo.PaymentPropertyInfoList.Any(p2 => p2.HeadName == p.Description));
                                        
                    //                    // Add to the dictionary ...
                    //                    edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                    //                    //payStuffDictionary = _edCodes.ToDictionary(s => s.Description, s => s.Amount); //s => s.Amount is always 0

                    //                    //_lstSalaryEarningVO = new List<SalaryEarningVO>();
                    //                    // _lstSalaryEarningVO = _salaryEarningBUS.getSalaryEarningList(_objRulePropertyInfo.Mem_Code);
                                        
                    //                }

                    //                result = EvaluateExpression(parse.Rvalue, payStuffDictionary);
                    //                if (result != -1)//success
                    //                {
                                        
                    //                    // get the salary stuff of the current employee
                    //                    // update db ....
                    //                    //_qbuilder...
                    //                    _rtn = UpdateDB(parse.LValue, _objRulePropertyInfo.Mem_Code, rule.WEF_Date, result, _lstSalaryEarningVO, _edCodes, rule.OverRuled, insertOnlyFlag);
                    //                    payStuffRunTimeDictionary.Add(parse.LValue, result);

                    //                }

                    //            }
                    //            else
                    //            {
                    //                // the right expression is invalid so return InvalidRValue
                    //                return ResultStatus.InvalidRValue;
                    //            }


                    //        }//if (_edCodes.Where(x => x.Description == parse.LValue.Trim()).FirstOrDefault() != null)
                    //        else
                    //        {
                    //            // the left expression is invalid so return InvalidLValue
                    //            return ResultStatus.InvalidLValue;
                    //        }
                    //        /*
                             
                    //        string sExpression = "([Income ONE] * Tax)+([Income one] *0.1)";
                    //        NCalc.Expression expression = new NCalc.Expression(sExpression, NCalc.EvaluateOptions.IgnoreCase);

                    //        List<string> identifiers = new List<string>();

                    //        bool bHasErrors = expression.HasErrors();
                    //        if (!bHasErrors)
                    //        {
                    //            var ex = NCalc.Expression.Compile(sExpression, false);
                    //            //ExtractIdentifiers(expression.ParsedExpression, identifiers);
                    //             ParameterExtractionVisitor visitor = new ParameterExtractionVisitor();
                    //            ex.Accept(visitor);
                    //            var extractedParameters = visitor.Parameters;
                    //        }

                    //        */

                    //        /*
                            
                    //          Dictionary<string, int> dict = new Dictionary<string, int>() { { "Income", 1000 }, { "Tax", 5 } };

                    //           string expressionString = "(Income * Tax)+(Income *0.1)";
                    //           NCalc.Expression expr = new NCalc.Expression(expressionString);
                    //           // NCalc.Expression expression = new NCalc.Expression(expressionString);

                    //            //string[] variables = expression.GetVariablesList();
                    //            // NCalc.Expression expr = new NCalc.Expression(expressionString);

                    //            expr.EvaluateParameter += (name, args) =>
                    //            {
                    //                args.Result = dict[name];
                    //            };

                    //            double result1 = (double)expr.Evaluate();
                              
                              
                    //         */




                    //    }//if (evaluatorResult == true)
                    //    else // else action if (evaluatorResult == true)

                    //    {
                            
                    //      if(rule.Else_Action!=null)
                    //        {
                         
                    //        ParseList parse = parseExpression(rule.Else_Action);
                    //        if (_edCodes.Where(x => x.Description == parse.LValue.Trim()).FirstOrDefault() != null)
                    //        {


                    //            // check the left expression is valid...
                    //            if (ValidateExpression(parse.Rvalue))
                    //            {
                                    
                    //                // check for basic expression
                    //                // Eg : BASIC=1000
                    //                if (getParametersCount(parse.Rvalue)==0)
                    //                {
                    //                    result = Convert.ToDouble(parse.Rvalue);
                    //                }
                    //                else
                    //                {
                    //                    //evaluate the expression ...
                    //                    _lstSalaryEarningVO = new List<SalaryEarningVO>();
                    //                    _lstSalaryEarningVO = _salaryEarningBUS.getSalaryEarningList(_objRulePropertyInfo.Mem_Code);
                    //                    payStuffDictionary = _lstSalaryEarningVO.ToDictionary(s => s.HeadName, s => s.Amount);
                    //                    result = EvaluateExpression(parse.Rvalue, payStuffDictionary);

                    //                }
                                    
                    //                if (result != -1)//success
                    //                {
                    //                    // update db ...
                    //                    //_qbuilder...
                    //                    _rtn = UpdateDB(parse.LValue, _objRulePropertyInfo.Mem_Code, rule.WEF_Date, result, _lstSalaryEarningVO, _edCodes, rule.OverRuled, insertOnlyFlag);
                    //                }

                    //            }//if (ValidateExpression(parse.Rvalue))
                    //            else
                    //            {
                    //                // the right expression is invalid so return InvalidRValue
                    //                return ResultStatus.InvalidRValue;
                    //            }


                    //        }//if (_edCodes.Where(x => x.Description == parse.LValue.Trim()).FirstOrDefault() != null)
                    //        else
                    //        {
                    //            // the left expression is invalid so return InvalidLValue
                    //            return ResultStatus.InvalidLValue;
                    //        }
                    //    }// if(rule.Else_Action!=null)

                    //    }//if (evaluatorResult == true)

                    //}// foreach (RulesGroupVO rule in _lstRules)
                   
                    #endregion comment

                    #region foreach (RulesGroupVO rule in _lstRules)
                    foreach (RulesGroupVO rule in _lstRules)
                    {
                        //var evaluatorResult = evaluator.Evaluate<Person>(ruleText, person);
                        // validate the rule ...
                        /* 
                        Evaluator evaluator = new Evaluator();
                        string ss = rule.Condition.ToString();
                        
                        var evaluatorResult = evaluator.Evaluate<RulePropertyInfo>(ss, _objRulePropertyInfo);
                        */
                        
                        // check wheteher the rule is percentage based if yes , checck condition statement exits or not
                        
                        
                         if(rule.IsPercentage==false && string.IsNullOrEmpty(rule.Condition))
                             return ResultStatus.EmptyExpression;
                         #region  if (rule.IsPercentage == true && string.IsNullOrEmpty(rule.Condition))
                         if (rule.IsPercentage == true && string.IsNullOrEmpty(rule.Condition))
                         {
                        
                           // it is a percentage component without any condition
                           // now check then_action has values

                             if (string.IsNullOrEmpty(rule.Then_Action))
                                 return ResultStatus.EmptyExpression;

                             isPercentage = true;
                             ParseList parse = parseExpression(rule.Then_Action);
                             //check the Lvalue is a valid one by compare the values in edcodes
                             clearString = Regex.Replace(parse.LValue, @"[[\]]", "");
                             //clearString
                             //if (_edCodes.Where(x => x.Description == parse.LValue.Replace(.Trim()).FirstOrDefault() != null)
                              if (_edCodes.Where(x => x.Description == clearString.Trim()).FirstOrDefault() != null)
                                {
                                 // here we can also check the parameter count = 0 and it's exists in the edlist

                                 // check the left expression is valid...
                                 if (ValidateExpression(parse.Rvalue))
                                 {

                                     // check for basic expression

                                     if (getParametersCount(parse.Rvalue) == 0)
                                     {
                                         result = Convert.ToDouble(parse.Rvalue);

                                         // find the base ed code
                                         if (getParameters(parse.Rvalue).First().ToString().Trim() == parse.LValue.Trim())
                                         {
                                             sBaseCodeId = string.Empty; // both are same ed code so no baseedcode 
                                         }
                                         else
                                         {
                                             var BaseEdCodeId = _edCodes.Where(p => p.Description.Trim() == parse.Rvalue.ToString().Trim()).Select(z => z.EdcodeId);
                                             sBaseCodeId = BaseEdCodeId.First().ToString().Trim();
                                         }

                                         // set Percentage=0;
                                         iPercentage = 0;

                                     }

                                     else // not a basic expression ...
                                     {

                                         #region Setup  payStuffDictionary
                                         // check whether the employee has payment details

                                         if (_objRulePropertyInfo.PaymentPropertyInfoList.Count == 0) // no payment details associated with the employee
                                         {
                                             insertOnlyFlag = true; //only insert operation is rquired in db

                                             if (payStuffRunTimeDictionary.Count > 0)
                                             {

                                                 //add the items from payStuffRunTimeDictionary to the dictionary ...
                                                 payStuffDictionary = payStuffRunTimeDictionary.ToDictionary(s => s.Key, s => s.Value);
                                                 // now add remaining items from _edCodes

                                                 var edcodes = _edCodes.Where(p => !payStuffRunTimeDictionary.Any(p2 => p2.Key == p.Description));

                                                 // Add to the dictionary ...
                                                 edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                             }
                                             else
                                                 payStuffDictionary = _edCodes.ToDictionary(s => s.Description, s => s.Amount); //s => s.Amount is always 0


                                         }

                                         else // has values in the payment stuff 
                                         {

                                             //check whether the run-time payStuffRunTimeDictionary has elements
                                             if (payStuffRunTimeDictionary.Count > 0)
                                             {
                                                 //add the items from payStuffRunTimeDictionary to the dictionary ...
                                                 payStuffDictionary = payStuffRunTimeDictionary.ToDictionary(s => s.Key, s => s.Value);
                                                 // now add all items from payment stuff except the items in payStuffRunTimeDictionary
                                                 var remaining = _objRulePropertyInfo.PaymentPropertyInfoList.Where(p => !payStuffDictionary.Any(p2 => p2.Key == p.HeadName));
                                                 remaining.ToList().ForEach(x => payStuffDictionary.Add(x.HeadName, x.Amount));

                                                 // 

                                                 // now add remaining items from _edCodes except the items exists
                                                 var edcodes = _edCodes.Where(p => !payStuffDictionary.Any(p2 => p2.Key == p.Description));

                                                 // Add to the dictionary ...
                                                 edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                             }

                                             else
                                             {
                                                 //add the existing payment stuff to the dictionary ...
                                                 payStuffDictionary = _objRulePropertyInfo.PaymentPropertyInfoList.ToDictionary(s => s.HeadName, s => s.Amount);
                                                 
                                                 // now add remaining items from _edCodes except the items exists
                                                 var edcodes = _edCodes.Where(p => !payStuffDictionary.Any(p2 => p2.Key == p.Description));

                                                 // Add to the dictionary ...
                                                 edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                             }
                                             
                                             
                                            // populate dictionay with all edlist items except the one exits in the payment list with 0 value for amount ..
                                            //dictionaryFrom.ToList().ForEach(x => dictionaryTo.Add(x.Key, x.Value));

                                            // var result = peopleList2.Where(p => !peopleList1.Any(p2 => p2.ID == p.ID));

                                            //select all payment stuff not contains in PaymentPropertyInfoList
                                            
                                            /* old lines of code 
                                            var edcodes = _edCodes.Where(p => !_objRulePropertyInfo.PaymentPropertyInfoList.Any(p2 => p2.HeadName == p.Description));

                                            // Add to the dictionary ...
                                            edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                            */ 
                                             //payStuffDictionary = _edCodes.ToDictionary(s => s.Description, s => s.Amount); //s => s.Amount is always 0

                                             //_lstSalaryEarningVO = new List<SalaryEarningVO>();
                                             // _lstSalaryEarningVO = _salaryEarningBUS.getSalaryEarningList(_objRulePropertyInfo.Mem_Code);

                                         }
                                         #endregion

                                         //evaluate the expression
                                         result = EvaluateExpression(parse.Rvalue, payStuffDictionary);

                                         // find the base ed code
                                         if (getParameters(parse.Rvalue).First().ToString().Trim() == parse.LValue.Trim())
                                         {
                                             sBaseCodeId = string.Empty; // both are same ed code so no baseedcode 
                                         }
                                         else
                                         {
                                             var BaseEdCodeId = _edCodes.Where(p => p.Description.Trim() == getParameters(parse.Rvalue).First().ToString().Trim()).Select(z => z.EdcodeId);
                                             sBaseCodeId = BaseEdCodeId.First().ToString().Trim();
                                         }

                                         // get percentage component from expression

                                         string re= getParameterValue(parse.Rvalue, 1);

                                         if (string.IsNullOrEmpty(re))
                                             iPercentage = 0;
                                         else
                                         {
                                             var d = Convert.ToDouble(re) * 100.00;
                                             iPercentage = Convert.ToInt32(d);
                                         }
                                     }//else // not a basic expression ...


                                     if (result != -1)//success
                                     {


                                         // get the salary stuff of the current employee
                                         // update db ....
                                         //_qbuilder...
                                         _rtn = UpdateDB(parse.LValue, _objRulePropertyInfo.Mem_Code, rule.WEF_Date, result, _objRulePropertyInfo.PaymentPropertyInfoList, _edCodes, rule.OverRuled, insertOnlyFlag, sBaseCodeId,iPercentage);
                                         payStuffRunTimeDictionary.Add(parse.LValue, result);

                                     }//if (result != -1)//success

                                 }
                                 else
                                 {
                                     // the right expression is invalid so return InvalidRValue
                                     return ResultStatus.InvalidRValue;
                                 }


                             }//if (_edCodes.Where(x => x.Description == parse.LValue.Trim()).FirstOrDefault() != null)
                             else
                             {
                                 // the left expression is invalid so return InvalidLValue
                                 return ResultStatus.InvalidLValue;
                             }

                         }
                         #endregion
                         #region - non percentage expression

                        if (rule.IsPercentage==false)
                        {
                         //set the base ed-code to empty ...
                         sBaseCodeId = string.Empty;

                         var evaluatorResult = ValidateExpression(rule.Condition);

                        if (evaluatorResult == true)
                        {

                            //Evaluate the Then_Action expression

                            //check Then_Action is not null or empty
                            if (string.IsNullOrEmpty(rule.Then_Action))
                                return ResultStatus.EmptyExpression;

                            

                            ParseList parse = parseExpression(rule.Then_Action);
                            //clearString = rgx..Replace(parse.LValue, "");
                            clearString= Regex.Replace(parse.LValue, @"[[\]]","");
                            //check the Lvalue is a valid one by compare the values in edcodes
                            if (_edCodes.Where(x => x.Description == clearString.Trim()).FirstOrDefault() != null)
                            {
                                // here we can also check the parameter count = 0 and it's exists in the edlist

                                if (_objRulePropertyInfo.PaymentPropertyInfoList.Count == 0) // no payment details associated with the employee
                                    insertOnlyFlag = true; //only insert operation is rquired in db
                                else
                                    insertOnlyFlag =false; 

                                // check the left expression is valid...
                                if (ValidateExpression(parse.Rvalue))
                                {

                                    // check for basic expression
                                    // Eg : BASIC=1000
                                    if (getParametersCount(parse.Rvalue) == 0)
                                    {
                                        result = Convert.ToDouble(parse.Rvalue);
                                    }

                                    else // not a basic expression ...
                                    {

                                        #region Setup  payStuffDictionary
                                        // check whether the employee has payment details ...

                                        if (_objRulePropertyInfo.PaymentPropertyInfoList.Count == 0) // no payment details associated with the employee
                                        {
                                            insertOnlyFlag = true; //only insert operation is required in db ....

                                            if (payStuffRunTimeDictionary.Count > 0)
                                            {

                                                //add the items from payStuffRunTimeDictionary to the dictionary ...
                                                payStuffDictionary = payStuffRunTimeDictionary.ToDictionary(s => s.Key, s => s.Value);
                                                // now add remaining items from _edCodes ...

                                                var edcodes = _edCodes.Where(p => !payStuffRunTimeDictionary.Any(p2 => p2.Key == p.Description));

                                                // Add to the dictionary ...
                                                edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                            }
                                            else
                                                payStuffDictionary = _edCodes.ToDictionary(s => s.Description, s => s.Amount); //s => s.Amount is always 0


                                        }

                                        else // has values in the payment stuff 
                                        {

                                            //add the existing payment stuff to the dictionary ...
                                            payStuffDictionary = _objRulePropertyInfo.PaymentPropertyInfoList.ToDictionary(s => s.HeadName, s => s.Amount);

                                            // populate dictionay with all edlist items except the one exits in the payment list with 0 value for amount ..
                                            //dictionaryFrom.ToList().ForEach(x => dictionaryTo.Add(x.Key, x.Value));

                                            // var result = peopleList2.Where(p => !peopleList1.Any(p2 => p2.ID == p.ID));

                                            //select all payment stuff not contains in PaymentPropertyInfoList
                                            var edcodes = _edCodes.Where(p => !_objRulePropertyInfo.PaymentPropertyInfoList.Any(p2 => p2.HeadName == p.Description));

                                            // Add to the dictionary ...
                                            edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                            //payStuffDictionary = _edCodes.ToDictionary(s => s.Description, s => s.Amount); //s => s.Amount is always 0

                                            //_lstSalaryEarningVO = new List<SalaryEarningVO>();
                                            // _lstSalaryEarningVO = _salaryEarningBUS.getSalaryEarningList(_objRulePropertyInfo.Mem_Code);

                                        }
                                        #endregion

                                        //evaluate the expression
                                        result = EvaluateExpression(parse.Rvalue, payStuffDictionary);
                                    }//else // not a basic expression ...


                                    if (result != -1)//success
                                    {

                                        // get the salary stuff of the current employee
                                        // update db ....
                                        //_qbuilder...
                                        _rtn = UpdateDB(parse.LValue, _objRulePropertyInfo.Mem_Code, rule.WEF_Date, result, _objRulePropertyInfo.PaymentPropertyInfoList, _edCodes, rule.OverRuled, insertOnlyFlag, sBaseCodeId, iPercentage);
                                        payStuffRunTimeDictionary.Add(parse.LValue, result);

                                    }//if (result != -1)//success

                                }
                                else
                                {
                                    // the right expression is invalid so return InvalidRValue
                                    return ResultStatus.InvalidRValue;
                                }


                            }//if (_edCodes.Where(x => x.Description == parse.LValue.Trim()).FirstOrDefault() != null)
                            else
                            {
                                // the left expression is invalid so return InvalidLValue
                                return ResultStatus.InvalidLValue;
                            }

                            #region Comment
                            /*
                             
                                string sExpression = "([Income ONE] * Tax)+([Income one] *0.1)";
                                NCalc.Expression expression = new NCalc.Expression(sExpression, NCalc.EvaluateOptions.IgnoreCase);

                                List<string> identifiers = new List<string>();

                                bool bHasErrors = expression.HasErrors();
                                if (!bHasErrors)
                                {
                                    var ex = NCalc.Expression.Compile(sExpression, false);
                                    //ExtractIdentifiers(expression.ParsedExpression, identifiers);
                                     ParameterExtractionVisitor visitor = new ParameterExtractionVisitor();
                                    ex.Accept(visitor);
                                    var extractedParameters = visitor.Parameters;
                                }

                                */

                            /*
                            
                              Dictionary<string, int> dict = new Dictionary<string, int>() { { "Income", 1000 }, { "Tax", 5 } };

                               string expressionString = "(Income * Tax)+(Income *0.1)";
                               NCalc.Expression expr = new NCalc.Expression(expressionString);
                               // NCalc.Expression expression = new NCalc.Expression(expressionString);

                                //string[] variables = expression.GetVariablesList();
                                // NCalc.Expression expr = new NCalc.Expression(expressionString);

                                expr.EvaluateParameter += (name, args) =>
                                {
                                    args.Result = dict[name];
                                };

                                double result1 = (double)expr.Evaluate();
                              
                              
                             */
                            #endregion Comment



                        }//if (evaluatorResult == true)
                        else // else action if (evaluatorResult == true)
                        {

                            if (string.IsNullOrEmpty(rule.Else_Action))
                                return ResultStatus.EmptyExpression;

                            if (rule.Else_Action != null)
                            {

                                ParseList parse = parseExpression(rule.Else_Action);

                                //check the Lvalue is a valid one by compare the values in edcodes
                                if (_edCodes.Where(x => x.Description == parse.LValue.Trim()).FirstOrDefault() != null)
                                {


                                    // check the left expression is valid...
                                    if (ValidateExpression(parse.Rvalue))
                                    {


                                        // check for basic expression
                                        // Eg : BASIC=1000
                                        if (getParametersCount(parse.Rvalue) == 0)
                                        {
                                            result = Convert.ToDouble(parse.Rvalue);
                                        }

                                        else //// not a basic expression ...
                                        {


                                            #region Setup  payStuffDictionary
                                            // check whether the employee has payment details

                                            if (_objRulePropertyInfo.PaymentPropertyInfoList.Count == 0) // no payment details associated with the employee
                                            {
                                                insertOnlyFlag = true; //only insert operation is rquired in db

                                                if (payStuffRunTimeDictionary.Count > 0)
                                                {

                                                    //add the items from payStuffRunTimeDictionary to the dictionary ...
                                                    payStuffDictionary = payStuffRunTimeDictionary.ToDictionary(s => s.Key, s => s.Value);
                                                    // now add remaining items from _edCodes

                                                    var edcodes = _edCodes.Where(p => !payStuffRunTimeDictionary.Any(p2 => p2.Key == p.Description));

                                                    // Add to the dictionary ...
                                                    edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                                }
                                                else
                                                    payStuffDictionary = _edCodes.ToDictionary(s => s.Description, s => s.Amount); //s => s.Amount is always 0


                                            }

                                            else // has values in the payment stuff 
                                            {

                                                //add the existing payment stuff to the dictionary ...
                                                payStuffDictionary = _objRulePropertyInfo.PaymentPropertyInfoList.ToDictionary(s => s.HeadName, s => s.Amount);

                                                // populate dictionay with all edlist items except the one exits in the payment list with 0 value for amount ..
                                                //dictionaryFrom.ToList().ForEach(x => dictionaryTo.Add(x.Key, x.Value));

                                                // var result = peopleList2.Where(p => !peopleList1.Any(p2 => p2.ID == p.ID));

                                                //select all payment stuff not contains in PaymentPropertyInfoList
                                                var edcodes = _edCodes.Where(p => !_objRulePropertyInfo.PaymentPropertyInfoList.Any(p2 => p2.HeadName == p.Description));

                                                // Add to the dictionary ...
                                                edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                                //payStuffDictionary = _edCodes.ToDictionary(s => s.Description, s => s.Amount); //s => s.Amount is always 0

                                                //_lstSalaryEarningVO = new List<SalaryEarningVO>();
                                                // _lstSalaryEarningVO = _salaryEarningBUS.getSalaryEarningList(_objRulePropertyInfo.Mem_Code);

                                            }
                                            #endregion

                                            ///****************


                                            ////evaluate the expression ...
                                            //_lstSalaryEarningVO = new List<SalaryEarningVO>();
                                            //_lstSalaryEarningVO = _salaryEarningBUS.getSalaryEarningList(empPropertyInfo.Mem_Code);
                                            //payStuffDictionary = _lstSalaryEarningVO.ToDictionary(s => s.HeadName, s => s.Amount);
                                            result = EvaluateExpression(parse.Rvalue, payStuffDictionary);

                                        }

                                        if (result != -1)//success
                                        {
                                            // update db ...
                                            //_qbuilder...
                                            _rtn = UpdateDB(parse.LValue, _objRulePropertyInfo.Mem_Code, rule.WEF_Date, result, _objRulePropertyInfo.PaymentPropertyInfoList, _edCodes, rule.OverRuled, insertOnlyFlag, sBaseCodeId, iPercentage);
                                        }

                                    }//if (ValidateExpression(parse.Rvalue))
                                    else
                                    {
                                        // the right expression is invalid so return InvalidRValue
                                        return ResultStatus.InvalidRValue;
                                    }


                                }//if (_edCodes.Where(x => x.Description == parse.LValue.Trim()).FirstOrDefault() != null)
                                else
                                {
                                    // the left expression is invalid so return InvalidLValue
                                    return ResultStatus.InvalidLValue;
                                }
                            }// if(rule.Else_Action!=null)

                        }//if (evaluatorResult == true)
                        }//non-percetage expression

                    #endregion
                    }// foreach (RulesGroupVO rule in _lstRules)
                    #endregion foreach (RulesGroupVO rule in _lstRules)


                    return ( ResultStatus.Success);

                }
                catch (Exception ex)
                {
                    return (ResultStatus.Error);
                }
            }
            #endregion
            #region applyRules overload for including employee list
            /// <method> 
            /// applyRules

            /// </method>
            public ResultStatus applyRules(List<RulePropertyInfo> _lstRulePropertyInfo)
            {
                try
                {
                    #region initialization
                    int _rtn = 0;
                    double result = 0.0;
                    bool insertOnlyFlag = false;
                    bool isPercentage = false;
                    string sBaseCodeId = string.Empty;
                    int iPercentage = 0;
                    
                   
                    _lstRules = new List<RulesGroupVO>();

                    
                    List<EarningDeductionVO> _edCodes = new List<EarningDeductionVO>();
                    _edCodes = _earningDeductionBUS.getEarningDeductionList();
                    #endregion initialization

                    foreach (RulePropertyInfo rulePropertyInfo in _lstRulePropertyInfo)
                    {

                        if (rulePropertyInfo.PolicyGroupID == null)
                            return ResultStatus.EmptyString;

                        //populate rules using PolicyGroupID ...
                        _lstRules = _rulesDAO.LoadRules(rulePropertyInfo.PolicyGroupID);
                        _lstRules.OrderBy(s => s.Priority);

                        payStuffRunTimeDictionary.Clear();
                        #region foreach (RulesGroupVO rule in _lstRules)
                        foreach (RulesGroupVO rule in _lstRules)
                        {
                            //var evaluatorResult = evaluator.Evaluate<Person>(ruleText, person);
                            // validate the rule ...
                            /* 
                            Evaluator evaluator = new Evaluator();
                            string ss = rule.Condition.ToString();
                        
                            var evaluatorResult = evaluator.Evaluate<RulePropertyInfo>(ss, _objRulePropertyInfo);
                            */

                            // check wheteher the rule is percentage based if yes , checck condition statement exits or not


                            if (rule.IsPercentage == false && string.IsNullOrEmpty(rule.Condition))
                                return ResultStatus.EmptyExpression;
                            #region  if (rule.IsPercentage == true && string.IsNullOrEmpty(rule.Condition))
                            if (rule.IsPercentage == true && string.IsNullOrEmpty(rule.Condition))
                            {

                                // it is a percentage component without any condition
                                // now check then_action has values

                                if (string.IsNullOrEmpty(rule.Then_Action))
                                    return ResultStatus.EmptyExpression;

                                isPercentage = true;
                                ParseList parse = parseExpression(rule.Then_Action);
                                //check the Lvalue is a validone by compare the values in edcodes
                                if (_edCodes.Where(x => x.Description == parse.LValue.Trim()).FirstOrDefault() != null)
                                {
                                    // here we can also check the parameter count = 0 and it's exists in the edlist

                                    // check the left expression is valid...
                                    if (ValidateExpression(parse.Rvalue))
                                    {

                                        // check for basic expression

                                        if (getParametersCount(parse.Rvalue) == 0)
                                        {
                                            result = Convert.ToDouble(parse.Rvalue);

                                            // find the base ed code
                                            if (getParameters(parse.Rvalue).First().ToString().Trim() == parse.LValue.Trim())
                                            {
                                                sBaseCodeId = string.Empty; // both are same ed code so no baseedcode 
                                            }
                                            else
                                            {
                                                var BaseEdCodeId = _edCodes.Where(p => p.Description.Trim() == parse.Rvalue.ToString().Trim()).Select(z => z.EdcodeId);
                                                sBaseCodeId = BaseEdCodeId.First().ToString().Trim();
                                            }

                                            // set Percentage=0;
                                            iPercentage = 0;

                                        }

                                        else // not a basic expression ...
                                        {

                                            #region Setup  payStuffDictionary
                                            // check whether the employee has payment details

                                            if (rulePropertyInfo.PaymentPropertyInfoList.Count == 0) // no payment details associated with the employee
                                            {
                                                insertOnlyFlag = true; //only insert operation is rquired in db

                                                if (payStuffRunTimeDictionary.Count > 0)
                                                {

                                                    //add the items from payStuffRunTimeDictionary to the dictionary ...
                                                    payStuffDictionary = payStuffRunTimeDictionary.ToDictionary(s => s.Key, s => s.Value);
                                                    // now add remaining items from _edCodes

                                                    var edcodes = _edCodes.Where(p => !payStuffRunTimeDictionary.Any(p2 => p2.Key == p.Description));

                                                    // Add to the dictionary ...
                                                    edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                                }
                                                else
                                                    payStuffDictionary = _edCodes.ToDictionary(s => s.Description, s => s.Amount); //s => s.Amount is always 0


                                            }

                                            else // has values in the payment stuff 
                                            {

                                                //check whether the run-time payStuffRunTimeDictionary has elements
                                                if (payStuffRunTimeDictionary.Count > 0)
                                                {
                                                    //add the items from payStuffRunTimeDictionary to the dictionary ...
                                                    payStuffDictionary = payStuffRunTimeDictionary.ToDictionary(s => s.Key, s => s.Value);
                                                    // now add all items from payment stuff except the items in payStuffRunTimeDictionary
                                                    var remaining = _objRulePropertyInfo.PaymentPropertyInfoList.Where(p => !payStuffDictionary.Any(p2 => p2.Key == p.HeadName));
                                                    remaining.ToList().ForEach(x => payStuffDictionary.Add(x.HeadName, x.Amount));

                                                    // 

                                                    // now add remaining items from _edCodes except the items exists
                                                    var edcodes = _edCodes.Where(p => !payStuffDictionary.Any(p2 => p2.Key == p.Description));

                                                    // Add to the dictionary ...
                                                    edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                                }

                                                else
                                                {
                                                    //add the existing payment stuff to the dictionary ...
                                                    payStuffDictionary = _objRulePropertyInfo.PaymentPropertyInfoList.ToDictionary(s => s.HeadName, s => s.Amount);

                                                    // now add remaining items from _edCodes except the items exists
                                                    var edcodes = _edCodes.Where(p => !payStuffDictionary.Any(p2 => p2.Key == p.Description));

                                                    // Add to the dictionary ...
                                                    edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                                }


                                                // populate dictionay with all edlist items except the one exits in the payment list with 0 value for amount ..
                                                //dictionaryFrom.ToList().ForEach(x => dictionaryTo.Add(x.Key, x.Value));

                                                // var result = peopleList2.Where(p => !peopleList1.Any(p2 => p2.ID == p.ID));

                                                //select all payment stuff not contains in PaymentPropertyInfoList

                                                /* old lines of code 
                                                var edcodes = _edCodes.Where(p => !_objRulePropertyInfo.PaymentPropertyInfoList.Any(p2 => p2.HeadName == p.Description));

                                                // Add to the dictionary ...
                                                edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                                */
                                                //payStuffDictionary = _edCodes.ToDictionary(s => s.Description, s => s.Amount); //s => s.Amount is always 0

                                                //_lstSalaryEarningVO = new List<SalaryEarningVO>();
                                                // _lstSalaryEarningVO = _salaryEarningBUS.getSalaryEarningList(_objRulePropertyInfo.Mem_Code);

                                            }
                                            #endregion

                                            //evaluate the expression
                                            result = EvaluateExpression(parse.Rvalue, payStuffDictionary);

                                            // find the base ed code
                                            if (getParameters(parse.Rvalue).First().ToString().Trim() == parse.LValue.Trim())
                                            {
                                                sBaseCodeId = string.Empty; // both are same ed code so no baseedcode 
                                            }
                                            else
                                            {
                                                var BaseEdCodeId = _edCodes.Where(p => p.Description.Trim() == getParameters(parse.Rvalue).First().ToString().Trim()).Select(z => z.EdcodeId);
                                                sBaseCodeId = BaseEdCodeId.First().ToString().Trim();
                                            }

                                            // get percentage component from expression

                                            string re = getParameterValue(parse.Rvalue, 1);

                                            if (string.IsNullOrEmpty(re))
                                                iPercentage = 0;
                                            else
                                            {
                                                var d = Convert.ToDouble(re) * 100.00;
                                                iPercentage = Convert.ToInt32(d);
                                            }
                                        }//else // not a basic expression ...


                                        if (result != -1)//success
                                        {


                                            // get the salary stuff of the current employee
                                            // update db ....
                                            //_qbuilder...
                                            _rtn = UpdateDB(parse.LValue, rulePropertyInfo.Mem_Code, rule.WEF_Date, result, rulePropertyInfo.PaymentPropertyInfoList, _edCodes, rule.OverRuled, insertOnlyFlag, sBaseCodeId, iPercentage);
                                            payStuffRunTimeDictionary.Add(parse.LValue, result);

                                        }//if (result != -1)//success

                                    }
                                    else
                                    {
                                        // the right expression is invalid so return InvalidRValue
                                        return ResultStatus.InvalidRValue;
                                    }


                                }//if (_edCodes.Where(x => x.Description == parse.LValue.Trim()).FirstOrDefault() != null)
                                else
                                {
                                    // the left expression is invalid so return InvalidLValue
                                    return ResultStatus.InvalidLValue;
                                }

                            }
                            #endregion
                            #region - non percentage expression

                            if (rule.IsPercentage == false)
                            {
                                //set the base ed-code to empty ...
                                sBaseCodeId = string.Empty;

                                var evaluatorResult = ValidateExpression(rule.Condition);

                                if (evaluatorResult == true)
                                {

                                    //Evaluate the Then_Action expression

                                    //check Then_Action is not null or empty
                                    if (string.IsNullOrEmpty(rule.Then_Action))
                                        return ResultStatus.EmptyExpression;

                                    ParseList parse = parseExpression(rule.Then_Action);
                                    //check the Lvalue is a valid one by compare the values in edcodes
                                    if (_edCodes.Where(x => x.Description == parse.LValue.Trim()).FirstOrDefault() != null)
                                    {
                                        // here we can also check the parameter count = 0 and it's exists in the edlist

                                        if (rulePropertyInfo.PaymentPropertyInfoList.Count == 0) // no payment details associated with the employee
                                            insertOnlyFlag = true; //only insert operation is rquired in db
                                        else
                                            insertOnlyFlag = false;

                                        // check the left expression is valid...
                                        if (ValidateExpression(parse.Rvalue))
                                        {

                                            // check for basic expression
                                            // Eg : BASIC=1000
                                            if (getParametersCount(parse.Rvalue) == 0)
                                            {
                                                result = Convert.ToDouble(parse.Rvalue);
                                            }

                                            else // not a basic expression ...
                                            {

                                                #region Setup  payStuffDictionary
                                                // check whether the employee has payment details

                                                if (rulePropertyInfo.PaymentPropertyInfoList.Count == 0) // no payment details associated with the employee
                                                {
                                                    insertOnlyFlag = true; //only insert operation is rquired in db

                                                    if (payStuffRunTimeDictionary.Count > 0)
                                                    {

                                                        //add the items from payStuffRunTimeDictionary to the dictionary ...
                                                        payStuffDictionary = payStuffRunTimeDictionary.ToDictionary(s => s.Key, s => s.Value);
                                                        // now add remaining items from _edCodes

                                                        var edcodes = _edCodes.Where(p => !payStuffRunTimeDictionary.Any(p2 => p2.Key == p.Description));

                                                        // Add to the dictionary ...
                                                        edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                                    }
                                                    else
                                                        payStuffDictionary = _edCodes.ToDictionary(s => s.Description, s => s.Amount); //s => s.Amount is always 0


                                                }

                                                else // has values in the payment stuff 
                                                {

                                                    //add the existing payment stuff to the dictionary ...
                                                    payStuffDictionary = rulePropertyInfo.PaymentPropertyInfoList.ToDictionary(s => s.HeadName, s => s.Amount);

                                                    // populate dictionay with all edlist items except the one exits in the payment list with 0 value for amount ..
                                                    //dictionaryFrom.ToList().ForEach(x => dictionaryTo.Add(x.Key, x.Value));

                                                    // var result = peopleList2.Where(p => !peopleList1.Any(p2 => p2.ID == p.ID));

                                                    //select all payment stuff not contains in PaymentPropertyInfoList
                                                    var edcodes = _edCodes.Where(p => !rulePropertyInfo.PaymentPropertyInfoList.Any(p2 => p2.HeadName == p.Description));

                                                    // Add to the dictionary ...
                                                    edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                                    //payStuffDictionary = _edCodes.ToDictionary(s => s.Description, s => s.Amount); //s => s.Amount is always 0

                                                    //_lstSalaryEarningVO = new List<SalaryEarningVO>();
                                                    // _lstSalaryEarningVO = _salaryEarningBUS.getSalaryEarningList(_objRulePropertyInfo.Mem_Code);

                                                }
                                                #endregion

                                                //evaluate the expression
                                                result = EvaluateExpression(parse.Rvalue, payStuffDictionary);
                                            }//else // not a basic expression ...


                                            if (result != -1)//success
                                            {

                                                // get the salary stuff of the current employee
                                                // update db ....
                                                //_qbuilder...
                                                _rtn = UpdateDB(parse.LValue, rulePropertyInfo.Mem_Code, rule.WEF_Date, result, rulePropertyInfo.PaymentPropertyInfoList, _edCodes, rule.OverRuled, insertOnlyFlag, sBaseCodeId, iPercentage);
                                                payStuffRunTimeDictionary.Add(parse.LValue, result);

                                            }//if (result != -1)//success

                                        }
                                        else
                                        {
                                            // the right expression is invalid so return InvalidRValue
                                            return ResultStatus.InvalidRValue;
                                        }


                                    }//if (_edCodes.Where(x => x.Description == parse.LValue.Trim()).FirstOrDefault() != null)
                                    else
                                    {
                                        // the left expression is invalid so return InvalidLValue
                                        return ResultStatus.InvalidLValue;
                                    }

                                   



                                }//if (evaluatorResult == true)
                                else // else action if (evaluatorResult == true)
                                {

                                    if (string.IsNullOrEmpty(rule.Else_Action))
                                        return ResultStatus.EmptyExpression;

                                    if (rule.Else_Action != null)
                                    {

                                        ParseList parse = parseExpression(rule.Else_Action);

                                        //check the Lvalue is a valid one by compare the values in edcodes
                                        if (_edCodes.Where(x => x.Description == parse.LValue.Trim()).FirstOrDefault() != null)
                                        {


                                            // check the left expression is valid...
                                            if (ValidateExpression(parse.Rvalue))
                                            {


                                                // check for basic expression
                                                // Eg : BASIC=1000
                                                if (getParametersCount(parse.Rvalue) == 0)
                                                {
                                                    result = Convert.ToDouble(parse.Rvalue);
                                                }

                                                else //// not a basic expression ...
                                                {


                                                    #region Setup  payStuffDictionary
                                                    // check whether the employee has payment details

                                                    if (rulePropertyInfo.PaymentPropertyInfoList.Count == 0) // no payment details associated with the employee
                                                    {
                                                        insertOnlyFlag = true; //only insert operation is rquired in db

                                                        if (payStuffRunTimeDictionary.Count > 0)
                                                        {

                                                            //add the items from payStuffRunTimeDictionary to the dictionary ...
                                                            payStuffDictionary = payStuffRunTimeDictionary.ToDictionary(s => s.Key, s => s.Value);
                                                            // now add remaining items from _edCodes

                                                            var edcodes = _edCodes.Where(p => !payStuffRunTimeDictionary.Any(p2 => p2.Key == p.Description));

                                                            // Add to the dictionary ...
                                                            edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                                        }
                                                        else
                                                            payStuffDictionary = _edCodes.ToDictionary(s => s.Description, s => s.Amount); //s => s.Amount is always 0


                                                    }

                                                    else // has values in the payment stuff 
                                                    {

                                                        //add the existing payment stuff to the dictionary ...
                                                        payStuffDictionary = rulePropertyInfo.PaymentPropertyInfoList.ToDictionary(s => s.HeadName, s => s.Amount);

                                                        // populate dictionay with all edlist items except the one exits in the payment list with 0 value for amount ..
                                                        //dictionaryFrom.ToList().ForEach(x => dictionaryTo.Add(x.Key, x.Value));

                                                        // var result = peopleList2.Where(p => !peopleList1.Any(p2 => p2.ID == p.ID));

                                                        //select all payment stuff not contains in PaymentPropertyInfoList
                                                        var edcodes = _edCodes.Where(p => !rulePropertyInfo.PaymentPropertyInfoList.Any(p2 => p2.HeadName == p.Description));

                                                        // Add to the dictionary ...
                                                        edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                                        //payStuffDictionary = _edCodes.ToDictionary(s => s.Description, s => s.Amount); //s => s.Amount is always 0

                                                        //_lstSalaryEarningVO = new List<SalaryEarningVO>();
                                                        // _lstSalaryEarningVO = _salaryEarningBUS.getSalaryEarningList(_objRulePropertyInfo.Mem_Code);

                                                    }
                                                    #endregion

                                                    ///****************


                                                    ////evaluate the expression ...
                                                    //_lstSalaryEarningVO = new List<SalaryEarningVO>();
                                                    //_lstSalaryEarningVO = _salaryEarningBUS.getSalaryEarningList(empPropertyInfo.Mem_Code);
                                                    //payStuffDictionary = _lstSalaryEarningVO.ToDictionary(s => s.HeadName, s => s.Amount);
                                                    result = EvaluateExpression(parse.Rvalue, payStuffDictionary);

                                                }

                                                if (result != -1)//success
                                                {
                                                    // update db ...
                                                    //_qbuilder...
                                                    _rtn = UpdateDB(parse.LValue, rulePropertyInfo.Mem_Code, rule.WEF_Date, result, rulePropertyInfo.PaymentPropertyInfoList, _edCodes, rule.OverRuled, insertOnlyFlag, sBaseCodeId, iPercentage);
                                                }

                                            }//if (ValidateExpression(parse.Rvalue))
                                            else
                                            {
                                                // the right expression is invalid so return InvalidRValue
                                                return ResultStatus.InvalidRValue;
                                            }


                                        }//if (_edCodes.Where(x => x.Description == parse.LValue.Trim()).FirstOrDefault() != null)
                                        else
                                        {
                                            // the left expression is invalid so return InvalidLValue
                                            return ResultStatus.InvalidLValue;
                                        }
                                    }// if(rule.Else_Action!=null)

                                }//if (evaluatorResult == true)
                            }//non-percetage expression

                            #endregion
                        }// foreach (RulesGroupVO rule in _lstRules)
                        #endregion foreach (RulesGroupVO rule in _lstRules)
                      
                        return (ResultStatus.Success);
                    }//foreach (RulePropertyInfo emplist in _lstRulePropertyInfo)

                    return ResultStatus.Success;
                }
                catch (Exception ex)
                {
                    return (ResultStatus.Error);
                }
            }
            #endregion


            #region applyRules overload for including employee list
            /// <method> 
            /// applyRules

            /// </method>
            public ResultStatus applyRules(List<RulePropertyInfo> _lstRulePropertyInfo, List<RulesGroupVO> _lstRules, SalaryEarningBUS objSalaryEarningBUS)
            {
                try
                {
                    int _rtn = 0;
                    double result = 0.0;
                    bool insertOnlyFlag = false;
                    bool isPercentage = false;
                    int iPercentage = 0;
                    string sBaseCodeId = string.Empty;

                    /*
                    var result = ruleValidator.ValidateRulesSum(
                    new Person[] { person1, person2 },
                    new Rule[] { rule1, rule2 });            
                    */

                    foreach (RulePropertyInfo empPropertyInfo in _lstRulePropertyInfo)
                    {

                        payStuffRunTimeDictionary.Clear();
                        List<EarningDeductionVO> _edCodes = new List<EarningDeductionVO>();
                        _edCodes = _earningDeductionBUS.getEarningDeductionList();

                        #region foreach (RulesGroupVO rule in _lstRules)
                        foreach (RulesGroupVO rule in _lstRules)
                        {

                            // validate the rule ...
                            Evaluator evaluator = new Evaluator();
                            var evaluatorResult = evaluator.Evaluate<RulePropertyInfo>(rule.Condition, empPropertyInfo);

                            if (evaluatorResult == true)
                            {
                               
                                //Evaluate the Then_Action expression

                                //check Then_Action is not null or empty
                                if(string.IsNullOrEmpty(rule.Then_Action)) 
                                    return ResultStatus.EmptyExpression;

                                ParseList parse = parseExpression(rule.Then_Action);
                                //check the Lvalue is a valid one by compare the values in edcodes
                                if (_edCodes.Where(x => x.Description == parse.LValue.Trim()).FirstOrDefault() != null)
                                {
                                    // here we can also check the parameter count ==0 and it's exists in the edlist

                                    // check the left expression is valid...
                                    if (ValidateExpression(parse.Rvalue))
                                    {

                                        // check for basic expression
                                        // Eg : BASIC=1000
                                        if (getParametersCount(parse.Rvalue) == 0)
                                        {
                                            result = Convert.ToDouble(parse.Rvalue);
                                        }

                                        else // not a basic expression ...
                                        {

                                        #region Setup  payStuffDictionary
                                        // check whether the employee has payment details

                                        if (empPropertyInfo.PaymentPropertyInfoList.Count == 0) // no payment details associated with the employee
                                        {
                                            insertOnlyFlag = true; //only insert operation is rquired in db

                                            if (payStuffRunTimeDictionary.Count > 0)
                                            {

                                                //add the items from payStuffRunTimeDictionary to the dictionary ...
                                                payStuffDictionary = payStuffRunTimeDictionary.ToDictionary(s => s.Key, s => s.Value);
                                                // now add remaining items from _edCodes

                                                var edcodes = _edCodes.Where(p => !payStuffRunTimeDictionary.Any(p2 => p2.Key == p.Description));

                                                // Add to the dictionary ...
                                                edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                            }
                                            else
                                                payStuffDictionary = _edCodes.ToDictionary(s => s.Description, s => s.Amount); //s => s.Amount is always 0


                                        }

                                        else // has values in the payment stuff 
                                        {

                                            //add the existing payment stuff to the dictionary ...
                                            payStuffDictionary = empPropertyInfo.PaymentPropertyInfoList.ToDictionary(s => s.HeadName, s => s.Amount);

                                            // populate dictionay with all edlist items except the one exits in the payment list with 0 value for amount ..
                                            //dictionaryFrom.ToList().ForEach(x => dictionaryTo.Add(x.Key, x.Value));

                                            // var result = peopleList2.Where(p => !peopleList1.Any(p2 => p2.ID == p.ID));

                                            //select all payment stuff not contains in PaymentPropertyInfoList
                                            var edcodes = _edCodes.Where(p => !empPropertyInfo.PaymentPropertyInfoList.Any(p2 => p2.HeadName == p.Description));

                                            // Add to the dictionary ...
                                            edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                            //payStuffDictionary = _edCodes.ToDictionary(s => s.Description, s => s.Amount); //s => s.Amount is always 0

                                            //_lstSalaryEarningVO = new List<SalaryEarningVO>();
                                            // _lstSalaryEarningVO = _salaryEarningBUS.getSalaryEarningList(_objRulePropertyInfo.Mem_Code);

                                        }
                                        #endregion

                                        //evaluate the expression
                                        result = EvaluateExpression(parse.Rvalue, payStuffDictionary);
                                        }//else // not a basic expression ...
                                        
                                        
                                        if (result != -1)//success
                                        {

                                            // get the salary stuff of the current employee
                                            // update db ....
                                            //_qbuilder...
                                            _rtn = UpdateDB(parse.LValue, empPropertyInfo.Mem_Code, rule.WEF_Date, result, empPropertyInfo.PaymentPropertyInfoList, _edCodes, rule.OverRuled, insertOnlyFlag, sBaseCodeId, iPercentage);
                                            payStuffRunTimeDictionary.Add(parse.LValue, result);

                                        }

                                    }
                                    else
                                    {
                                        // the right expression is invalid so return InvalidRValue
                                        return ResultStatus.InvalidRValue;
                                    }


                                }//if (_edCodes.Where(x => x.Description == parse.LValue.Trim()).FirstOrDefault() != null)
                                else
                                {
                                    // the left expression is invalid so return InvalidLValue
                                    return ResultStatus.InvalidLValue;
                                }

                                #region Comment
                                /*
                             
                                string sExpression = "([Income ONE] * Tax)+([Income one] *0.1)";
                                NCalc.Expression expression = new NCalc.Expression(sExpression, NCalc.EvaluateOptions.IgnoreCase);

                                List<string> identifiers = new List<string>();

                                bool bHasErrors = expression.HasErrors();
                                if (!bHasErrors)
                                {
                                    var ex = NCalc.Expression.Compile(sExpression, false);
                                    //ExtractIdentifiers(expression.ParsedExpression, identifiers);
                                     ParameterExtractionVisitor visitor = new ParameterExtractionVisitor();
                                    ex.Accept(visitor);
                                    var extractedParameters = visitor.Parameters;
                                }

                                */

                                /*
                            
                                  Dictionary<string, int> dict = new Dictionary<string, int>() { { "Income", 1000 }, { "Tax", 5 } };

                                   string expressionString = "(Income * Tax)+(Income *0.1)";
                                   NCalc.Expression expr = new NCalc.Expression(expressionString);
                                   // NCalc.Expression expression = new NCalc.Expression(expressionString);

                                    //string[] variables = expression.GetVariablesList();
                                    // NCalc.Expression expr = new NCalc.Expression(expressionString);

                                    expr.EvaluateParameter += (name, args) =>
                                    {
                                        args.Result = dict[name];
                                    };

                                    double result1 = (double)expr.Evaluate();
                              
                              
                                 */
                                #endregion Comment



                            }//if (evaluatorResult == true)
                            else // else action if (evaluatorResult == true)
                            {

                                if (string.IsNullOrEmpty(rule.Else_Action))
                                    return ResultStatus.EmptyExpression;
                                
                                if (rule.Else_Action != null)
                                {

                                    ParseList parse = parseExpression(rule.Else_Action);

                                    //check the Lvalue is a valid one by compare the values in edcodes
                                    if (_edCodes.Where(x => x.Description == parse.LValue.Trim()).FirstOrDefault() != null)
                                    {


                                        // check the left expression is valid...
                                        if (ValidateExpression(parse.Rvalue))
                                        {


                                            // check for basic expression
                                            // Eg : BASIC=1000
                                            if (getParametersCount(parse.Rvalue) == 0)
                                            {
                                                result = Convert.ToDouble(parse.Rvalue);
                                            }

                                            else //// not a basic expression ...
                                            {


                                                #region Setup  payStuffDictionary
                                                // check whether the employee has payment details

                                                if (empPropertyInfo.PaymentPropertyInfoList.Count == 0) // no payment details associated with the employee
                                                {
                                                    insertOnlyFlag = true; //only insert operation is rquired in db

                                                    if (payStuffRunTimeDictionary.Count > 0)
                                                    {

                                                        //add the items from payStuffRunTimeDictionary to the dictionary ...
                                                        payStuffDictionary = payStuffRunTimeDictionary.ToDictionary(s => s.Key, s => s.Value);
                                                        // now add remaining items from _edCodes

                                                        var edcodes = _edCodes.Where(p => !payStuffRunTimeDictionary.Any(p2 => p2.Key == p.Description));

                                                        // Add to the dictionary ...
                                                        edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                                    }
                                                    else
                                                        payStuffDictionary = _edCodes.ToDictionary(s => s.Description, s => s.Amount); //s => s.Amount is always 0


                                                }

                                                else // has values in the payment stuff 
                                                {

                                                    //add the existing payment stuff to the dictionary ...
                                                    payStuffDictionary = empPropertyInfo.PaymentPropertyInfoList.ToDictionary(s => s.HeadName, s => s.Amount);

                                                    // populate dictionay with all edlist items except the one exits in the payment list with 0 value for amount ..
                                                    //dictionaryFrom.ToList().ForEach(x => dictionaryTo.Add(x.Key, x.Value));

                                                    // var result = peopleList2.Where(p => !peopleList1.Any(p2 => p2.ID == p.ID));

                                                    //select all payment stuff not contains in PaymentPropertyInfoList
                                                    var edcodes = _edCodes.Where(p => !empPropertyInfo.PaymentPropertyInfoList.Any(p2 => p2.HeadName == p.Description));

                                                    // Add to the dictionary ...
                                                    edcodes.ToList().ForEach(x => payStuffDictionary.Add(x.Description, x.Amount));

                                                    //payStuffDictionary = _edCodes.ToDictionary(s => s.Description, s => s.Amount); //s => s.Amount is always 0

                                                    //_lstSalaryEarningVO = new List<SalaryEarningVO>();
                                                    // _lstSalaryEarningVO = _salaryEarningBUS.getSalaryEarningList(_objRulePropertyInfo.Mem_Code);

                                                }
                                                #endregion
                                                
                                                ///****************
                                                
                                                
                                                ////evaluate the expression ...
                                                //_lstSalaryEarningVO = new List<SalaryEarningVO>();
                                                //_lstSalaryEarningVO = _salaryEarningBUS.getSalaryEarningList(empPropertyInfo.Mem_Code);
                                                //payStuffDictionary = _lstSalaryEarningVO.ToDictionary(s => s.HeadName, s => s.Amount);
                                                result = EvaluateExpression(parse.Rvalue, payStuffDictionary);

                                            }

                                            if (result != -1)//success
                                            {
                                                // update db ...
                                                //_qbuilder...
                                                _rtn = UpdateDB(parse.LValue, empPropertyInfo.Mem_Code, rule.WEF_Date, result, empPropertyInfo.PaymentPropertyInfoList, _edCodes, rule.OverRuled, insertOnlyFlag, sBaseCodeId, iPercentage);
                                            }

                                        }//if (ValidateExpression(parse.Rvalue))
                                        else
                                        {
                                            // the right expression is invalid so return InvalidRValue
                                            return ResultStatus.InvalidRValue;
                                        }


                                    }//if (_edCodes.Where(x => x.Description == parse.LValue.Trim()).FirstOrDefault() != null)
                                    else
                                    {
                                        // the left expression is invalid so return InvalidLValue
                                        return ResultStatus.InvalidLValue;
                                    }
                                }// if(rule.Else_Action!=null)

                            }//if (evaluatorResult == true)

                        }// foreach (RulesGroupVO rule in _lstRules)
                        #endregion foreach (RulesGroupVO rule in _lstRules)
                        return (ResultStatus.Success);
                    }//foreach (RulePropertyInfo emplist in _lstRulePropertyInfo)

                    return ResultStatus.Success;
                }
                catch (Exception ex)
                {
                    return (ResultStatus.Error);
                }
            }
            #endregion

            #region ParseExpression
            public bool ValidateExpression(string sExpression)
            {
                try
                {
                    
                    NCalc.Expression expression = new NCalc.Expression(sExpression, NCalc.EvaluateOptions.IgnoreCase);
                    bool bHasErrors = expression.HasErrors();
                    if (!bHasErrors)
                    {
                        return true;
                    }
                    else
                        return false;

                }
                catch (Exception ex)
                {
                    return false;
                
                }

            }


            #endregion

            #region parseExpression


            public ParseList parseExpression(string strExpression)
             {
                try
                    {
                        
                        ParseList _parseList = new ParseList();
                        _parseList.LValue = strExpression.Trim().Substring(0,strExpression.IndexOf('='));
                        _parseList.Rvalue = strExpression.Trim().Substring(strExpression.IndexOf('=')+1);
                         return(_parseList); 
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
             }
            #endregion

            #region ValidateRules

             public double EvaluateExpression(string sExpression, Dictionary<string, double> dict)
            {
                try
                {

                    double result = 0.0;




                    // Generate payStuffDictionary
                    

                   /*
                    NCalc.Expression expression = new NCalc.Expression(sExpression, NCalc.EvaluateOptions.IgnoreCase);
                    List<string> identifiers = new List<string>();

                    bool bHasErrors = expression.HasErrors();
                    if (!bHasErrors)
                    {
                        var ex = NCalc.Expression.Compile(sExpression, false);
                        //ExtractIdentifiers(expression.ParsedExpression, identifiers);
                        ParameterExtractionVisitor visitor = new ParameterExtractionVisitor();
                        ex.Accept(visitor);
                        var extractedParameters = visitor.Parameters;
                    }
                    */
                    
                    NCalc.Expression expression = new NCalc.Expression(sExpression, NCalc.EvaluateOptions.IgnoreCase);
                    bool bHasErrors = expression.HasErrors();
                    if (!bHasErrors) // no error so process the equation
                    {
                        //var expr = NCalc.Expression.Compile(sExpression, false);
                        NCalc.Expression expr = new NCalc.Expression(sExpression);
                        
                        expr.EvaluateParameter += (name, args) =>
                        {
                            args.Result = dict[name.Trim()];
                        };

                        result = (double)expr.Evaluate();
                    }

                    return (result);
                }
                catch (Exception exp)
                {
                    return (-1);
                }
            }

            #endregion

            #region getParametersCount
             public int getParametersCount(string sExpression)
             {
                 try
                 {
                     int iCount = 0;
                     NCalc.Expression expression = new NCalc.Expression(sExpression, NCalc.EvaluateOptions.IgnoreCase);
                     bool bHasErrors = expression.HasErrors();
                     if (!bHasErrors)
                     {
                         var ex = NCalc.Expression.Compile(sExpression, false);
                        // NCalc.Domain.ValueExpression val = (NCalc.Domain.ValueExpression)ex;
                         NCalc.Domain.LogicalExpression val = NCalc.Expression.Compile(sExpression, false);
                         
                         ParameterExtractionVisitor visitor = new ParameterExtractionVisitor();
                         ex.Accept(visitor);
                         var extractedParameters = visitor.Parameters;
                         iCount= extractedParameters.Count;
                         
                     }
                     return iCount;
                 }
                 catch (Exception exp)
                 {
                     return (-1);
                 }
             }
             #endregion

            #region getParameters
             public List<string> getParameters(string sExpression)
             {
                 try
                 {
                     List<string> _lstParams = new List<string>();

                     NCalc.Expression expression = new NCalc.Expression(sExpression, NCalc.EvaluateOptions.IgnoreCase);
                     bool bHasErrors = expression.HasErrors();
                     if (!bHasErrors)
                     {
                         var ex = NCalc.Expression.Compile(sExpression, false);
                         ParameterExtractionVisitor visitor = new ParameterExtractionVisitor();
                         ex.Accept(visitor);
                         var extractedParameters = visitor.Parameters;
                         _lstParams = extractedParameters.ToList<string>();

                     }
                     return _lstParams;
                 }
                 catch (Exception exp)
                 {
                     return null;
                 }
             }
            #endregion

            #region getParameters
             public double getRightExpressionValue(string sExpression)
             {
                 try
                 {
                     double value = 0.0;
                    
                     NCalc.Expression expression = new NCalc.Expression(sExpression, NCalc.EvaluateOptions.IgnoreCase);
                    // NCalc.Domain.BinaryExpression expression1 = new NCalc.Expression(sExpression, NCalc.EvaluateOptions.IgnoreCase);
                     bool bHasErrors = expression.HasErrors();
                     if (!bHasErrors)
                     {
                         //NCalc.Domain.
                        
                         var ex = NCalc.Expression.Compile(sExpression, false);
                        
                          






                         
                         //NCalc.Domain.ValueExpression 
                         ParameterExtractionVisitor visitor = new ParameterExtractionVisitor();
                         
                     }
                     return value;
                 }
                 catch (Exception exp)
                 {
                     return -1;
                 }
             }
             #endregion

             #region ExtractValue

             private string getParameterValue(string sExpression,int ExprType)
             {

                 try
                 {
                     string sRtn = string.Empty;

                     //var expression = new NCalc.Expression(sExpression, NCalc.EvaluateOptions.IgnoreCase);
                     NCalc.Expression ex = new NCalc.Expression(sExpression, NCalc.EvaluateOptions.IgnoreCase);
                     
                     bool bHasErrors = ex .HasErrors();
                     if (bHasErrors)  return string.Empty;


                     var expression = NCalc.Expression.Compile(sExpression, false);
                     
                     // ExprType indicate left expression or right expression 0-Left and 1- Right
                     if (expression is NCalc.Domain.BinaryExpression)
                     {
                         NCalc.Domain.BinaryExpression be = expression as NCalc.Domain.BinaryExpression;
                         sRtn=ExprType == 0? be.LeftExpression.ToString():be.RightExpression.ToString();
                         
                     }
                     else if (expression is NCalc.Domain.TernaryExpression)
                     {
                         NCalc.Domain.TernaryExpression te = expression as NCalc.Domain.TernaryExpression;
                         sRtn = ExprType == 0 ? te.LeftExpression.ToString() : te.RightExpression.ToString();
                     }
                     return sRtn;
                 }
                 catch (Exception exp)
                 {
                     return string.Empty;
                 }
             }
             
             
             
             
             #endregion






             #region Update Db
             // MEM_CODE	EdCodeId WEF_Date	AMOUNT ...
             public int UpdateDB(string sEDCode, string sMEM_CODE, DateTime WEF_Date, double AMOUNT, List<PaymentPropertyInfo> _salEDList, List<EarningDeductionVO> _EDList, bool isOverRide, bool insertOnlyFlag, string sBaseCodeId, int iPercentage)
            {
                try
                {
                    // check the sEDCode exits in the payment stuff .....
                    //get the ED info
                    int iSuccess = 0;

                    var clearString = Regex.Replace(sEDCode, @"[[\]]", "");
                   


                    if (insertOnlyFlag == true) // there is no items in the payment list .. only add items
                    {

                       // var EdCodeId = _EDList.Where(p => p.Description.Trim() == sEDCode.Trim()).Select(z => z.EdcodeId);
                        var EdCodeId = _EDList.Where(p => p.Description.Trim() == clearString.Trim()).Select(z => z.EdcodeId);
                        //inser the new record into the salary table ....
                        if (EdCodeId == null)
                        {
                            return 1;//failed
                        }
                         

                        int iEdCodeId = Convert.ToInt32(EdCodeId.First());


                        strUpdateSQL = "";

                        // add new salary record ... 
                        _qbuilder = new QueryBuilderHelper();

                        // [MEM_CODE]
                        //,[EdCodeId]
                        //,[WEF_Date]
                        //,[AMOUNT]
                        //,[IsPercentage]
                        //,[BaseEdCodeId]
                        //,[Percentage]
                        //,[Activate]
                        //,[Add_By]
                        //,[Add_Date]

                        // sEDCode, string sMEM_CODE, DateTime WEF_Date, double AMOUNT,
                        _qbuilder.QueryType = QueryTypes.Insert;
                        _qbuilder.AddTable("MASTER_EMPLOYEE_EARNING_DTLS");
                        _qbuilder.AddNameValuePair("MEM_CODE", "'" + sMEM_CODE.Trim() + "'");
                        _qbuilder.AddNameValuePair("EdCodeId", iEdCodeId.ToString());
                        // base ed code [BaseEdCodeId]
                        _qbuilder.AddNameValuePair("BaseEdCodeId", !string.IsNullOrEmpty(sBaseCodeId) ?  sBaseCodeId:"NULL");

                        _qbuilder.AddNameValuePair("WEF_Date", "'"+WEF_Date.ToString()+"'");
                        _qbuilder.AddNameValuePair("AMOUNT", AMOUNT.ToString());
                        
                       
                        _qbuilder.AddNameValuePair("IsPercentage", iPercentage!=0? "'true'":"'false'");
                        _qbuilder.AddNameValuePair("Percentage", iPercentage!=0? iPercentage.ToString(): "0.0");
                        _qbuilder.AddNameValuePair("IsPolicyApplied", "'true'");
                        // ...
                        _qbuilder.AddNameValuePair("Activate", "'A'");
                        _qbuilder.AddNameValuePair("Add_By", "'" + GlobalVariable.UserCode.Trim() + "'");
                        _qbuilder.AddNameValuePair("ADD_DATE", "GETDATE()");

                        strInsertSQL = _qbuilder.ToString();

                        if (SQLHelper.InsertRecord(strInsertSQL) > 0)
                            iSuccess = 0; // success ...
                        else
                            iSuccess = 1; // failed ...

                    }
                    else // there exits payment list items
                    {
                       // int EdCodeId;
                       // bool intResultTryParse = int.TryParse(_EDList.Where(p => p.Description.Trim() == sEDCode).Select(z => z.EdcodeId).ToString(), out EdCodeId);

                        var EdCodeId = _EDList.Where(p => p.Description.Trim() == clearString.Trim()).Select(z => z.EdcodeId);
                        

                        //if (intResultTryParse == false)
                        //{
                        //    return 1;//failed
                        //}
                         
                        if (EdCodeId == null)
                        {
                            return 1;//failed
                        }
                         

                        int iEdCodeId = Convert.ToInt32(EdCodeId.First());

                        var edSal = _salEDList.Where(x => x.EdCodeId == iEdCodeId).FirstOrDefault();

                        if (edSal != null && EdCodeId != null)
                        {
                            // check the rule is overruled  ....
                            if (isOverRide)
                            {
                                strInsertSQL = "";
                                strUpdateSQL = "";

                                // add new salary record ... 
                                _qbuilder = new QueryBuilderHelper();

                                // [MEM_CODE]
                                //,[EdCodeId]
                                //,[WEF_Date]
                                //,[AMOUNT]
                                //,[IsPercentage]
                                //,[BaseEdCodeId]
                                //,[Percentage]
                                //,[Activate]
                                //,[Add_By]
                                //,[Add_Date]

                                // sEDCode, string sMEM_CODE, DateTime WEF_Date, double AMOUNT,

                                _qbuilder.QueryType = QueryTypes.Insert;
                                _qbuilder.AddTable("MASTER_EMPLOYEE_EARNING_DTLS");
                                _qbuilder.AddNameValuePair("MEM_CODE", "'" + sMEM_CODE.Trim() + "'");
                                _qbuilder.AddNameValuePair("EdCodeId", iEdCodeId.ToString());
                                _qbuilder.AddNameValuePair("WEF_Date","'"+ WEF_Date.ToString()+"'");
                                _qbuilder.AddNameValuePair("AMOUNT", AMOUNT.ToString());
                                _qbuilder.AddNameValuePair("IsPercentage", iPercentage != 0 ? "'true'" : "'false'");
                                _qbuilder.AddNameValuePair("Percentage", iPercentage != 0 ? iPercentage.ToString() : "0.0");
                                // ...
                                // base ed code [BaseEdCodeId]
                                _qbuilder.AddNameValuePair("BaseEdCodeId", !string.IsNullOrEmpty(sBaseCodeId) ? sBaseCodeId : "NULL");
                                
                                _qbuilder.AddNameValuePair("IsPolicyApplied", "'true'");
                                // ...
                                _qbuilder.AddNameValuePair("Activate", "'A'");
                                _qbuilder.AddNameValuePair("Add_By", "'" + GlobalVariable.UserCode.Trim() + "'");
                                _qbuilder.AddNameValuePair("ADD_DATE", "GETDATE()");

                                strInsertSQL = _qbuilder.ToString();

                                // update the row having the same ED code iD which is inserted by the policy rule

                                _qbuilder = new QueryBuilderHelper();

                                _qbuilder.QueryType = QueryTypes.Update;
                                _qbuilder.AddTable("MASTER_EMPLOYEE_EARNING_DTLS");
                                _qbuilder.AddNameValuePair("Activate", "'I'");
                                _qbuilder.AddNameValuePair("Edit_By", "'" + GlobalVariable.UserCode.Trim() + "'");
                                _qbuilder.AddNameValuePair("Edit_Date", "GETDATE()");
                                _qbuilder.AddCondition("ID=" + edSal.ID);

                                strUpdateSQL = _qbuilder.ToString();

                                // do db transactions
                                if (SQLHelper.InsertRecord(strInsertSQL) > 0 && SQLHelper.InsertRecord(strUpdateSQL) > 0)
                                {
                                    //insert back log 
                                    //backup current row of MASTER_EMPLOYEE_EARNING_DTLS
                                    _qbuilder = new QueryBuilderHelper();
                                    _qbuilder.QueryType = QueryTypes.Insert;
                                    _qbuilder.AddTable("MASTER_EMPLOYEE_EARNING_DTLS_BCK_LOG");
                                    _qbuilder.AddNameValuePair("ED_ROW_ID", edSal.ID.ToString());
                                    _qbuilder.AddNameValuePair("Activate", "'A'");
                                    _qbuilder.AddNameValuePair("Add_By", "'" + GlobalVariable.UserCode.Trim() + "'");
                                    _qbuilder.AddNameValuePair("ADD_DATE", "GETDATE()");

                                    strInsertSQL = _qbuilder.ToString();
                                    if (SQLHelper.InsertRecord(strInsertSQL) > 0)
                                        iSuccess = 0;//success
                                    else
                                        iSuccess = 1;//failed
                                }
                                else
                                {
                                    iSuccess = 1;//failed
                                }

                            }//if (isOverRide)

                        }// if (edSal != null && EdCodeId!=null) 
                        else if (edSal == null && EdCodeId != null)
                        {
                            //inser the new record into the salary table ....

                            strUpdateSQL = "";

                            // add new salary record ... 
                            _qbuilder = new QueryBuilderHelper();

                            // [MEM_CODE]
                            //,[EdCodeId]
                            //,[WEF_Date]
                            //,[AMOUNT]
                            //,[IsPercentage]
                            //,[BaseEdCodeId]
                            //,[Percentage]
                            //,[Activate]
                            //,[Add_By]
                            //,[Add_Date]

                            // sEDCode, string sMEM_CODE, DateTime WEF_Date, double AMOUNT,
                            _qbuilder.QueryType = QueryTypes.Insert;
                            _qbuilder.AddTable("MASTER_EMPLOYEE_EARNING_DTLS");
                            _qbuilder.AddNameValuePair("MEM_CODE", "'" + sMEM_CODE.Trim() + "'");
                            _qbuilder.AddNameValuePair("EdCodeId", iEdCodeId.ToString());
                            _qbuilder.AddNameValuePair("WEF_Date","'"+ WEF_Date.ToString()+"'");
                            _qbuilder.AddNameValuePair("AMOUNT", AMOUNT.ToString());
                             
                            _qbuilder.AddNameValuePair("IsPercentage", iPercentage != 0 ? "'true'" : "'false'");
                            _qbuilder.AddNameValuePair("Percentage", iPercentage != 0 ? iPercentage.ToString() : "0.0");
                            // ...
                            // base ed code [BaseEdCodeId]
                            _qbuilder.AddNameValuePair("BaseEdCodeId", !string.IsNullOrEmpty(sBaseCodeId) ? sBaseCodeId : "NULL");
                             
                            _qbuilder.AddNameValuePair("IsPolicyApplied", "'true'");
                            // ...
                            _qbuilder.AddNameValuePair("Activate", "'A'");
                            _qbuilder.AddNameValuePair("Add_By", "'" + GlobalVariable.UserCode.Trim() + "'");
                            _qbuilder.AddNameValuePair("ADD_DATE", "GETDATE()");

                            strInsertSQL = _qbuilder.ToString();

                            if (SQLHelper.InsertRecord(strInsertSQL) > 0)
                                iSuccess = 0;//success
                            else
                                iSuccess = 1;//failed

                        }

                    }//else // there exits payment list items

                    return (iSuccess);//success
                }
                catch (Exception exp)
                {
                    return -1;
                }
            }
            
            #endregion 



        }



        #region ParseList
        public class ParseList
        {
            // to show left expression or right expression
            public  string  Rvalue  { get; set; }
            public  string  LValue { get; set; }

        }
        #endregion ParseList
        
    #region Enum

     public  enum ResultStatus
        {
            Valid,
            Invalid,
            InvalidLValue,
            InvalidRValue,
            Success,
            Error,
            EmptyExpression,
            EmptyString
        };

    #endregion

    }

