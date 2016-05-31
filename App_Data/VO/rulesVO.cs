using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
namespace ATTNPAY.Core
{
    public class RulesVO
    {
        #region Member Variables
         
        //[RULE_ID] 
        //[RULE_NAME]  
        //[RULE_DESCRIPTION]  
        //[Priority] 
        //[Condition] 
        //[Then_Action] 
        //[Else_Action] 
        // OverRuled
        //IsPercentage
        
        private int _rule_id;
        private string _rule_name;
        private string _rule_description;
        private int _priority;
        private int _rule_cat_id;
        private string _rule_category;
        private string _condition;
        private string _then_action;
        private string _else_action;
        private bool _isRuleOverride;
        private bool _isPercentage;
        private string _activate;

        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor RulesVO
        /// </constructor>
        public RulesVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region Rule_Id
        public int Rule_Id
        {
            get
            {
                return _rule_id;
            }
            set
            {
                _rule_id = value;
            }
        }
        #endregion Rule_Id
        #region Rule_CategoryId
        public int Rule_CategoryId
        {
            get
            {
                return _rule_cat_id;
            }
            set
            {
                _rule_cat_id = value;
            }
        }
        #endregion Rule_CategoryId

        //_rule_cat

        //
        #region Rule_Category
        public string Rule_Category
        {

            get { return _rule_category; }
            set { _rule_category = value; }
        }
        #endregion Rule_Category


        #region Rule_name
        public string Rule_Name
        {

            get { return _rule_name; }
            set { _rule_name = value; }
        }
        #endregion Rule_name
        #region Rule_Description
        public string Rule_Description
        {

            get { return _rule_description; }
            set { _rule_description = value; }
        }
        #endregion Rule_Description
        #region Priority
        public int Priority
        {

            get { return _priority; }
            set { _priority = value; }
        }
        #endregion Priority
        #region Condition
        public string Condition
        {

            get { return _condition; }
            set { _condition = value; }
        }
        #endregion Condition
        #region Then_Action
        public string Then_Action
        {
            get { return _then_action; }
            set { _then_action = value; }
        }
        #endregion Then_Action
        #region Else_Action
        public string Else_Action
        {

            get { return _else_action; }
            set { _else_action = value; }
        }
        #endregion Else_Action
        #region OverRuled
        //isRuleOverride
        public bool OverRuled
        {
            get
            { return Convert.ToBoolean(_isRuleOverride); }
            set
            { _isRuleOverride = Convert.ToBoolean(value); }
        }
        #endregion OverRuled

        #region IsPercentage
        //IsPercentage
        public bool IsPercentage
        {
            get
            { return Convert.ToBoolean(_isPercentage); }
            set
            { _isPercentage = Convert.ToBoolean(value); }
        }
        #endregion IsPercentage


        #region Activate
        public string Activate
        {
            get
            { return _activate; }
            set
            { _activate = value; }
        }
        #endregion Address
    }

    public class RuleInfoVO
    {
            
            public string RuleName { get; set; }  
            public int Priority { get; set; }  
            public string Condition { get; set; }  
            public string ThenAction { get; set; }  
            public string ElseAction { get; set; }  
            
    }

    public class RuleLoader
    {
        public RulesVO Load(int iPolicyGroupID)
        {
            
            // get all rules in the rule group ...

            switch (iPolicyGroupID)
            {
                //case 1: return new Rule("Name", Operator.NotEqual, "test");
                //case 2: return new Rule(" Children >= Age / 20 && Name != 'test' ");
                default:
                    return null;
            }
        }
    }








    #region RulesExpressionBuilder
    public class RulesExpressionBuilder
    {
        public static Func<RulesVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(RulesVO), "t");
            Expression exp = null;

            if (filters.Count == 1)
                exp = GetExpression(param, filters[0]);
            else if (filters.Count == 2)
                exp = GetExpression(param, filters[0], filters[1]);
            else
            {
                while (filters.Count > 0)
                {
                    var f1 = filters[0];
                    var f2 = filters[1];

                    if (exp == null)
                        exp = GetExpression(param, filters[0], filters[1]);
                    else
                        exp = Expression.AndAlso(exp, GetExpression(param, filters[0], filters[1]));

                    filters.Remove(f1);
                    filters.Remove(f2);

                    if (filters.Count == 1)
                    {
                        exp = Expression.AndAlso(exp, GetExpression(param, filters[0]));
                        filters.RemoveAt(0);
                    }
                }
            }
            return Expression.Lambda<Func<RulesVO, bool>>(exp, param).Compile();
        }
        private static Expression GetExpression(ParameterExpression param, Filter filter)
        {
            MemberExpression member = Expression.Property(param, filter.PropertyName);
            ConstantExpression constant = Expression.Constant(filter.Value);
            return Expression.Equal(member, constant);
        }

        private static BinaryExpression GetExpression
        (ParameterExpression param, Filter filter1, Filter filter2)
        {
            Expression bin1 = GetExpression(param, filter1);
            Expression bin2 = GetExpression(param, filter2);

            return Expression.AndAlso(bin1, bin2);
        }
    }
    #endregion RulesExpressionBuilder
}
